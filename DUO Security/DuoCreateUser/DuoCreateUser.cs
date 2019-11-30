using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

namespace Ayehu.Sdk.ActivityCreation
{
    public class DuoCreateUser : IActivity
    {
        public string integrationKey;
        public string secretKey;
        public string apiHost;

        public string userName;
        public string realName;
        public string firstName;
        public string lastName;
        public string email;
        public string statusId;
        public string status;

        public ICustomActivityResult Execute()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("username", userName);
            
            if (!string.IsNullOrEmpty(realName))
                parameters.Add("realname", realName);

            if (!string.IsNullOrEmpty(email))
                parameters.Add("email", email);

            if (!string.IsNullOrEmpty(status))
                parameters.Add("status", status);

            if (!string.IsNullOrEmpty(firstName))
                parameters.Add("firstname", firstName);

            if (!string.IsNullOrEmpty(lastName))
                parameters.Add("lastname", lastName);

            var existingUser = new DuoApi(integrationKey, secretKey, apiHost, "https")
                .JSONApiCall<System.Collections.ArrayList>("GET", "/admin/v1/users",
                new Dictionary<string, string>() { { "username", userName } });

            if (existingUser.Count == 0)
            {
                HttpStatusCode code = HttpStatusCode.BadRequest;
                new DuoApi(integrationKey, secretKey, apiHost, "https").
                    ApiCall("POST", "/admin/v1/users", parameters, 0, DateTime.UtcNow, out code);

                if (code != HttpStatusCode.OK)
                {
                    throw new Exception("Error creating DUO user");
                }

                return this.GenerateActivityResult(GetActivityResult);
            }
            else
            {
                throw new Exception(string.Format("User '{0}' already exist", userName));
            }
        }

        private DataTable GetActivityResult
        {
            get
            {
                DataTable dt = new DataTable("resultSet");
                dt.Columns.Add("Result");
                dt.Rows.Add("Success");

                return dt;
            }
        }

        public class DuoApi
        {
            private string ikey;
            private string skey;
            private string host;
            private string url_scheme;

            public DuoApi(string ikey, string skey, string host, string url_scheme)
            {
                this.ikey = ikey;
                this.skey = skey;
                this.host = host;
                this.url_scheme = url_scheme;
            }

            public static string FinishCanonicalize(string p)
            {
                // Signatures require upper-case hex digits.
                p = Regex.Replace(p,
                                "(%[0-9A-Fa-f][0-9A-Fa-f])",
                                c => c.Value.ToUpperInvariant());
                // Escape only the expected characters.
                p = Regex.Replace(p,
                                "([!'()*])",
                                c => "%" + Convert.ToByte(c.Value[0]).ToString("X"));
                p = p.Replace("%7E", "~");
                p = p.Replace("+", "%20");
                return p;
            }

            public static string CanonicalizeParams(Dictionary<string, string> parameters)
            {
                if (parameters != null)
                {
                    var ret = new List<string>();

                    foreach (KeyValuePair<string, string> pair in parameters)
                    {
                        string p = string.Format("{0}={1}",
                                                 HttpUtility.UrlEncode(pair.Key),
                                                 HttpUtility.UrlEncode(pair.Value));

                        p = FinishCanonicalize(p);
                        ret.Add(p);
                    }
                    ret.Sort(StringComparer.Ordinal);
                    return string.Join("&", ret.ToArray());
                }

                return "";
            }

            protected string CanonicalizeRequest(string method,
                                                 string path,
                                                 string canon_params,
                                                 string date)
            {
                string[] lines = {
                date,
                method.ToUpperInvariant(),
                this.host.ToLower(),
                path,
                canon_params,
            };
                string canon = string.Join("\n",
                                           lines);
                return canon;
            }

            public string Sign(string method,
                               string path,
                               string canon_params,
                               string date)
            {
                string canon = this.CanonicalizeRequest(method,
                                                        path,
                                                        canon_params,
                                                        date);
                string sig = this.HmacSign(canon);
                string auth = this.ikey + ':' + sig;
                return "Basic " + DuoApi.Encode64(auth);
            }

            /// <param name="date">The current date and time, used to authenticate
            /// the API request. Typically, you should specify DateTime.UtcNow,
            /// but if you do not wish to rely on the system-wide clock, you may
            /// determine the current date/time by some other means.</param>
            /// <param name="timeout">The request timeout, in milliseconds.
            /// Specify 0 to use the system-default timeout. Use caution if
            /// you choose to specify a custom timeout - some API
            /// calls (particularly in the Auth APIs) will not
            /// return a response until an out-of-band authentication process
            /// has completed. In some cases, this may take as much as a
            /// small number of minutes.</param>
            public string ApiCall(string method,
                                  string path,
                                  Dictionary<string, string> parameters,
                                  int timeout,
                                  DateTime date,
                                  out HttpStatusCode statusCode)
            {
                string canon_params = DuoApi.CanonicalizeParams(parameters);
                string query = "";
                if (!method.Equals("POST") && !method.Equals("PUT"))
                {
                    if (parameters != null && parameters.Count > 0)
                    {
                        query = "?" + canon_params;
                    }
                }
                string url = string.Format("{0}://{1}{2}{3}",
                                           this.url_scheme,
                                           this.host,
                                           path,
                                           query);

                string date_string = DuoApi.DateToRFC822(date);
                string auth = this.Sign(method, path, canon_params, date_string);

                HttpWebResponse response = AttemptHttpRequest(
                    method, url, auth, date_string, canon_params, timeout);
                StreamReader reader
                    = new StreamReader(response.GetResponseStream());
                statusCode = response.StatusCode;
                return reader.ReadToEnd();
            }

            private HttpWebRequest PrepareHttpRequest(string method, string url, string auth, string date,
                string cannonParams, int timeout)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                request.Accept = "application/json";
                request.Headers.Add("Authorization", auth);
                request.Headers.Add("X-Duo-Date", date);
                request.ContentType = "application/x-www-form-urlencoded";

                if (method.Equals("POST") || method.Equals("PUT"))
                {
                    byte[] data = Encoding.UTF8.GetBytes(cannonParams);
                    request.ContentLength = data.Length;
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(data, 0, data.Length);
                    }
                }
                if (timeout > 0)
                {
                    request.Timeout = timeout;
                }

                return request;
            }

            private HttpWebResponse AttemptHttpRequest(
                string method, string url, string auth, string date, string cannonParams, int timeout)
            {
                // Do the request and process the result.
                HttpWebRequest request = PrepareHttpRequest(method, url, auth, date, cannonParams, timeout);
                HttpWebResponse response;

                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                    return response;
                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                    if (response == null)
                    {
                        throw;
                    }

                    return null;
                }
            }

            /// <param name="date">The current date and time, used to authenticate
            /// the API request. Typically, you should specify DateTime.UtcNow,
            /// but if you do not wish to rely on the system-wide clock, you may
            /// determine the current date/time by some other means.</param>
            /// <param name="timeout">The request timeout, in milliseconds.
            /// Specify 0 to use the system-default timeout. Use caution if
            /// you choose to specify a custom timeout - some API
            /// calls (particularly in the Auth APIs) will not
            /// return a complete JSON response.</param>
            /// raises if JSON response indicates an error
            private Dictionary<string, object> BaseJSONApiCall(string method,
                                    string path,
                                    Dictionary<string, string> parameters,
                                    int timeout,
                                    DateTime date)
            {
                HttpStatusCode statusCode;
                string res = this.ApiCall(method, path, parameters, timeout, date, out statusCode);

                var jss = new JavaScriptSerializer();

                try
                {
                    var dict = jss.Deserialize<Dictionary<string, object>>(res);

                    if (dict["stat"] as string == "OK")
                    {
                        return dict;
                    }
                    else
                    {
                        int? check = dict["code"] as int?;
                        int code;
                        if (check.HasValue)
                        {
                            code = check.Value;
                        }
                        else
                        {
                            code = 0;
                        }

                        string message_detail = "";
                        if (dict.ContainsKey("message_detail"))
                        {
                            message_detail = dict["message_detail"] as string;
                        }
                        throw new ApiException(code,
                                               (int)statusCode,
                                               dict["message"] as string,
                                               message_detail);
                    }
                }
                catch (ApiException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    throw new BadResponseException((int)statusCode, e);
                }
            }

            public T JSONApiCall<T>(string method,
                                    string path,
                                    Dictionary<string, string> parameters)
                where T : class
            {
                return JSONApiCall<T>(method, path, parameters, 0, DateTime.UtcNow);
            }

            /// <param name="date">The current date and time, used to authenticate
            /// the API request. Typically, you should specify DateTime.UtcNow,
            /// but if you do not wish to rely on the system-wide clock, you may
            /// determine the current date/time by some other means.</param>
            /// <param name="timeout">The request timeout, in milliseconds.
            /// Specify 0 to use the system-default timeout. Use caution if
            /// you choose to specify a custom timeout - some API
            /// calls (particularly in the Auth APIs) will not
            /// return a response until an out-of-band authentication process
            /// has completed. In some cases, this may take as much as a
            /// small number of minutes.</param>
            public T JSONApiCall<T>(string method,
                                    string path,
                                    Dictionary<string, string> parameters,
                                    int timeout,
                                    DateTime date)
                where T : class
            {
                var dict = BaseJSONApiCall(method, path, parameters, timeout, date);
                return dict["response"] as T;
            }

            #region Private Methods
            private string HmacSign(string data)
            {
                byte[] key_bytes = ASCIIEncoding.ASCII.GetBytes(this.skey);
                HMACSHA1 hmac = new HMACSHA1(key_bytes);

                byte[] data_bytes = ASCIIEncoding.ASCII.GetBytes(data);
                hmac.ComputeHash(data_bytes);

                string hex = BitConverter.ToString(hmac.Hash);
                return hex.Replace("-", "").ToLower();
            }

            private static string Encode64(string plaintext)
            {
                byte[] plaintext_bytes = ASCIIEncoding.ASCII.GetBytes(plaintext);
                string encoded = Convert.ToBase64String(plaintext_bytes);
                return encoded;
            }

            private static string DateToRFC822(DateTime date)
            {
                // Can't use the "zzzz" format because it adds a ":"
                // between the offset's hours and minutes.
                string date_string = date.ToString(
                    "ddd, dd MMM yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                int offset = TimeZone.CurrentTimeZone.GetUtcOffset(date).Hours;
                string zone;
                // + or -, then 0-pad, then offset, then more 0-padding.
                if (offset < 0)
                {
                    offset *= -1;
                    zone = "-";
                }
                else
                {
                    zone = "+";
                }
                zone += offset.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
                date_string += " " + zone.PadRight(5, '0');
                return date_string;
            }
            #endregion Private Methods
        }

        [Serializable]
        public class DuoException : Exception
        {
            public int HttpStatus { get; private set; }

            public DuoException(int http_status, string message, Exception inner)
                : base(message, inner)
            {
                this.HttpStatus = http_status;
            }

            protected DuoException(System.Runtime.Serialization.SerializationInfo info,
                                   System.Runtime.Serialization.StreamingContext ctxt)
                : base(info, ctxt)
            { }
        }

        [Serializable]
        public class ApiException : DuoException
        {
            public int Code { get; private set; }
            public string ApiMessage { get; private set; }
            public string ApiMessageDetail { get; private set; }

            public ApiException(int code,
                                int http_status,
                                string api_message,
                                string api_message_detail)
                : base(http_status, FormatMessage(code, api_message, api_message_detail), null)
            {
                this.Code = code;
                this.ApiMessage = api_message;
                this.ApiMessageDetail = api_message_detail;
            }

            protected ApiException(System.Runtime.Serialization.SerializationInfo info,
                                   System.Runtime.Serialization.StreamingContext ctxt)
                : base(info, ctxt)
            { }

            private static string FormatMessage(int code,
                                                string api_message,
                                                string api_message_detail)
            {
                return string.Format(
                    "Duo API Error {0}: '{1}' ('{2}')", code, api_message, api_message_detail);
            }
        }

        [Serializable]
        public class BadResponseException : DuoException
        {
            public BadResponseException(int http_status, Exception inner)
                : base(http_status, FormatMessage(http_status, inner), inner)
            { }

            protected BadResponseException(System.Runtime.Serialization.SerializationInfo info,
                                           System.Runtime.Serialization.StreamingContext ctxt)
                : base(info, ctxt)
            { }

            private static string FormatMessage(int http_status, Exception inner)
            {
                string inner_message = "(null)";
                if (inner != null)
                {
                    inner_message = String.Format("'{0}'", inner.Message);
                }
                return string.Format(
                    "Got error {0} with HTTP Status {1}", inner_message, http_status);
            }
        }
    }
}
