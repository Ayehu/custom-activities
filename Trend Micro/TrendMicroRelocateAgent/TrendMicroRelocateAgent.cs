using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Collections.Generic;
using System.Net.Http;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Net.Http.Headers;
using System.Threading;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace ActivitiesAyehu
{
    public class TrendMicroRelocateAgent : IActivity
    {
        public string use_url_base, use_application_id, use_api_key, relocate_to_server_id, relocate_to_folder_path;
        public bool allow_multiple_match;
        public string entity_id, ip_address, mac_address, host_name; // optional parameters

        public ICustomActivityResult Execute()
        {
            var res = RelocateProductAgent();

            return this.GenerateActivityResult(res ? "Sucess" : "Fail");
        }

        private bool RelocateProductAgent()
        {
            // Prepare the query Strings.
            List<KeyValuePair<string, string>> myQueryStrings = new List<KeyValuePair<string, string>>();
            myQueryStrings.Add(new KeyValuePair<string, string>("product", "SLF_PRODUCT_OFFICESCAN_CE"));

            // Make the API call.
            var body = new JObject();

            body["act"] = "cmd_relocate_agent";
            body["allow_multiple_match"] = allow_multiple_match;
            body["relocate_to_server_id"] = relocate_to_server_id;
            body["relocate_to_folder_path"] = relocate_to_folder_path;
            if (entity_id != "")
                body["entity_id"] = entity_id;
            if (ip_address != "")
                body["ip_address"] = ip_address;
            if (mac_address != "")
                body["mac_address"] = mac_address;
            if (host_name != "")
                body["host_name"] = host_name;

            TMCMAPIHelper useHelper = new TMCMAPIHelper(APIBaseAddress: use_url_base, applicationID: use_application_id,
                apiKey: use_api_key, signingSecurityAlgorithm: SecurityAlgorithms.HmacSha512);
            var task = useHelper.AsyncSendRequest("AgentResource/ProductAgents", HttpMethod.Post.Method,
                customHeaders: null, queryStrings: myQueryStrings, postBody: body.ToString());
            task.Wait();
            TMCMAPIHelper.APIResponse response = task.Result;

            // Parse the API call result.
            bool operationSuccessful = false;
            if (response.ResponseStatusCode == HttpStatusCode.OK && string.IsNullOrWhiteSpace(response.ResponseBodyString) == false)
            {
                TMCMAPIHelper.APIResponseBody responseBody = JsonConvert.DeserializeObject<TMCMAPIHelper.APIResponseBody>(response.ResponseBodyString);
                if (responseBody.result_code == 1)
                {
                    operationSuccessful = true;
                }
            }

            if (operationSuccessful == false)
            {
                string errorMsg = string.Format("Query failed. HTTP Status Code = {0}; Response Body = {1}", response.ResponseStatusCode.ToString(), response.ResponseBodyString);
                throw new Exception(errorMsg);
            }

            // Return the result.
            return operationSuccessful;
        }
    }

    class GenericProductAgentInfo
    {
        public string entity_id { get; set; }
        public string product { get; set; }
        public string managing_server_id { get; set; }
        public string ad_domain { get; set; }
        public string folder_path { get; set; }
        public string ip_address_list { get; set; }
        public string mac_address_list { get; set; }
        public string host_name { get; set; }
        public string isolation_status { get; set; }
        public string[] capabilities { get; set; }

        public string displayCapabilities
        {
            get
            {
                string result = string.Empty;
                if (capabilities != null && capabilities.Length > 0) { result = string.Join(",", capabilities); }
                return result;
            }
        }
    }

    public class TMCMAPIHelper
    {
        /// <summary>
        /// This class encapsulates the return response of an WebAPI call, containing the HttpStatusCode and BodyString of the response.
        /// </summary>
        public class APIResponse
        {
            public HttpStatusCode ResponseStatusCode { get; set; }
            public string ResponseBodyString { get; set; }
        }

        /// <summary>
        /// This class encapsulates the response body of an WebAPI call, containing the result_code, result_description, and result_content of the response body.
        /// </summary>
        public class APIResponseBody
        {
            public int result_code { get; set; }

            public string result_description { get; set; }

            public object result_content { get; set; }
        }

        /// <summary>
        /// Stores the base address of the Automation APIs.
        /// </summary>
        private readonly string APIBaseAddress;

        /// <summary>
        /// Stores the ApplicationID used to access Automation APIs.
        /// </summary>
        private readonly string ApplicationID;

        /// <summary>
        /// Stores the APIKey used to calculate JWT token checksum.
        /// </summary>
        private readonly string APIKey;

        /// <summary>
        /// Stores the signing security algorithm that will be used to calculate the JWT token checksum, such as "HS256", "HS512", etc...
        /// </summary>
        private readonly string SigningSecurityAlgorithm;

        /// <summary>
        /// Contruct a new TMCMAPIHelper used to access TMCM's Automation APIs.
        /// </summary>
        /// <param name="APIBaseAddress">Base address of the Automation APIs</param>
        /// <param name="applicationID">ApplicationID used to access Automation APIs</param>
        /// <param name="apiKey">APIKey used to calculate JWT token checksum</param>
        /// <param name="signingSecurityAlgorithm">The signing security algorithm that will be used to calculate the JWT token checksum, such as "HS256", "HS512", etc...</param>
        public TMCMAPIHelper(string APIBaseAddress, string applicationID, string apiKey,
            string signingSecurityAlgorithm = Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha512)
        {
            this.APIBaseAddress = APIBaseAddress;
            this.ApplicationID = applicationID;
            this.APIKey = apiKey;
            this.SigningSecurityAlgorithm = signingSecurityAlgorithm;
        }

        /// <summary>
        /// Calculate the checksum field of the JWT token payload
        /// </summary>
        /// <param name="httpMethod">The http method used to access the api, such as "GET", "POST", etc...</param>
        /// <param name="rawUrl">The raw url used to access the api, such as "https://TestTMCM:443/WebApp/API/V1/AgentResource/ProductAgents?product=SLF_PRODUCT_OFFICESCAN_CE".</param>
        /// <param name="requestHeaders">The request headers of the API call.</param>
        /// <param name="requestBody">The request body of the API call.</param>
        /// <returns></returns>
        private string CalculateChecksum(string httpMethod, string rawUrl, List<KeyValuePair<string, string>> requestHeaders = null, string requestBody = null)
        {
            // Get the headers that will be used to calculate the checksum, and join them into canonicalRequestHeaders.
            // Only headers that start with api are taken into account for calculating the checksum.
            string canonicalRequestHeaders = string.Empty;
            if (requestHeaders != null && requestHeaders.Count > 0)
            {
                List<string> requestHeadersToChecksum = new List<string>();
                foreach (var item in requestHeaders)
                {
                    if (item.Key.ToLower().StartsWith("api"))
                    { requestHeadersToChecksum.Add(item.Key.ToLower() + ":" + item.Value.Trim()); }
                }
                requestHeadersToChecksum.Sort();
                canonicalRequestHeaders = string.Join("&", requestHeadersToChecksum);
            }

            if (requestBody == null) { requestBody = string.Empty; }

            // Get the string used to generate the checksum.
            string stringToChecksum = string.Join("|", httpMethod.ToUpper(), rawUrl.ToLower(), canonicalRequestHeaders, requestBody);

            // Get the checksum as a base64 string.
            byte[] checkSumBytes = null;
            using (SHA256 useSHA256 = SHA256Managed.Create())
            { checkSumBytes = useSHA256.ComputeHash(Encoding.UTF8.GetBytes(stringToChecksum)); }
            string checkSumString = Convert.ToBase64String(checkSumBytes);

            return checkSumString;
        }

        /// <summary>
        /// Get the local time from a unix timestamp.
        /// </summary>
        /// <param name="unixTimeStamp">The unix timestamp to calculate from.</param>
        /// <returns></returns>
        private DateTime UnixTimeStampToLocalDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        /// <summary>
        /// Get the unix timestamp from a datetime.
        /// </summary>
        /// <param name="dateTime">The datetime used to calculate the unix timestamp.</param>
        /// <returns></returns>
        private double LocalDateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds;
        }

        /// <summary>
        /// Generate a JWTToken used to access TMCM Automation APIs.
        /// </summary>
        /// <param name="requestCheckSum">The request checksum of this request.</param>
        /// <returns></returns>
        private string GenJWTTokenV1(string requestCheckSum)
        {
            // The security key of this token is the API Key.
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key: Encoding.UTF8.GetBytes(this.APIKey));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(key: securityKey, algorithm: this.SigningSecurityAlgorithm);

            // Prepare the JWT header
            var header = new JwtHeader(signingCredentials: signingCredentials);

            // Prepare the JWT payload
            var payload = new JwtPayload
            {
                {"appid", ApplicationID},
                {"iat", LocalDateTimeToUnixTimestamp(DateTime.Now)},
                {"version", "V1"},
                {"checkSum", requestCheckSum}
            };

            // Create the JWT token
            var secToken = new JwtSecurityToken(header: header, payload: payload);

            // Write the token to a string
            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(secToken);
            return tokenString;
        }

        /// <summary>
        /// Make an async TMCM Automation API call, and provide the return response as an APIResponse.
        /// </summary>
        /// <param name="resourcePath">The resource path this call wishes to access, such as "AgentResource/ProductAgents".</param>
        /// <param name="usingHttpMethod">The http method used to make this API call, such as "GET", "POST", "PUT", "PATCH".</param>
        /// <param name="customHeaders">The custom headers used for this API call.</param>
        /// <param name="queryStrings">The query strings used for this API call.</param>
        /// <param name="postBody">The object used for the post body of this API call.</param>
        /// <returns>The APIResponse response of this API call.</returns>
        public async Task<APIResponse> AsyncSendRequest(string resourcePath, string usingHttpMethod,
            List<KeyValuePair<string, string>> customHeaders = null, List<KeyValuePair<string, string>> queryStrings = null, object postBody = null)
        {
            // Only the http methods "GET", "POST", "PUT", "PATCH" should be used.
            if (string.Compare(usingHttpMethod, HttpMethod.Get.Method, true) != 0 &&
                string.Compare(usingHttpMethod, HttpMethod.Post.Method, true) != 0 &&
                string.Compare(usingHttpMethod, HttpMethod.Put.Method, true) != 0 &&
                string.Compare(usingHttpMethod, "Patch", true) != 0)
            { throw new Exception("Unsupported http method."); }

            #region Generate the full resource path, including the query string, such as "AgentResource/ProductAgents?product=SLF_PRODUCT_OFFICESCAN_CE"

            string useQueryString = string.Empty;
            if (queryStrings != null && queryStrings.Count > 0)
            {
                StringBuilder sbQueryString = new StringBuilder();
                foreach (var item in queryStrings)
                { sbQueryString.AppendFormat("&{0}={1}", WebUtility.UrlEncode(item.Key), WebUtility.UrlEncode(item.Value)); }

                // Remove the leading "&" from the previous loop, and add a leading "?" for the query string
                if (sbQueryString.Length > 1)
                { useQueryString = "?" + sbQueryString.ToString().Substring(1); }
            }

            if (string.IsNullOrWhiteSpace(resourcePath) == false && resourcePath.StartsWith("/") == true)
            { resourcePath = resourcePath.Substring(1); }

            string fullResourcePath = (string.IsNullOrWhiteSpace(resourcePath) ? "" : resourcePath) + (string.IsNullOrWhiteSpace(useQueryString) ? "" : useQueryString);

            #endregion

            #region Generate the checksum string of this API call.

            Uri requestUri = new Uri(APIBaseAddress + fullResourcePath);
            string rawPath = requestUri.PathAndQuery;

            string postContentAsJSONString = string.Empty;
            if (postBody != null)
            { postContentAsJSONString = JsonConvert.SerializeObject(postBody); }

            string checkSumString = CalculateChecksum(httpMethod: usingHttpMethod, rawUrl: rawPath, requestHeaders: customHeaders, requestBody: postContentAsJSONString);

            #endregion

            string useJWTToken = GenJWTTokenV1(requestCheckSum: checkSumString);

            // The demo server will fail the https certification check if checked, so use this to override.
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            // Create a HttpClient for the API call.            
            HttpClient useHttpClient = new HttpClient();
            useHttpClient.BaseAddress = new Uri(uriString: this.APIBaseAddress);
            useHttpClient.DefaultRequestHeaders.Clear();
            useHttpClient.DefaultRequestHeaders.Accept.Clear();
            useHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // The JWT token should be placed in the authorization header.
            AuthenticationHeaderValue useAuthHeader = new AuthenticationHeaderValue("Bearer", useJWTToken);
            useHttpClient.DefaultRequestHeaders.Authorization = useAuthHeader;

            // Add the custom headers.
            if (customHeaders != null && customHeaders.Count > 0)
            {
                foreach (var item in customHeaders)
                { useHttpClient.DefaultRequestHeaders.Add(item.Key, item.Value); }
            }

            HttpResponseMessage responseSync = null;
            StringContent postJSONContent = null;
            if (postBody != null)
            { postJSONContent = new StringContent(postContentAsJSONString); }

            if (string.Compare(usingHttpMethod, HttpMethod.Get.Method, true) == 0) { responseSync = await useHttpClient.GetAsync(fullResourcePath, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false); }
            else if (string.Compare(usingHttpMethod, HttpMethod.Post.Method, true) == 0) { responseSync = await useHttpClient.PostAsync(fullResourcePath, postJSONContent).ConfigureAwait(false); }
            else if (string.Compare(usingHttpMethod, HttpMethod.Put.Method, true) == 0) { responseSync = await useHttpClient.PutAsync(fullResourcePath, postJSONContent).ConfigureAwait(false); }
            else if (string.Compare(usingHttpMethod, "Patch", true) == 0) { responseSync = await useHttpClient.PatchAsync(fullResourcePath, postJSONContent).ConfigureAwait(false); }

            HttpStatusCode responseStatusCode = responseSync.StatusCode;
            string responseContent = await responseSync.Content.ReadAsStringAsync();

            APIResponse result = new APIResponse()
            {
                ResponseStatusCode = responseStatusCode,
                ResponseBodyString = responseContent
            };

            return result;
        }
    }

    public static class HttpClientExtensions
    {
        /// <summary>
        /// Send a PATCH request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// 
        /// <returns>
        /// Returns <see cref="T:System.Threading.Tasks.Task`1"/>.The task object representing the asynchronous operation.
        /// </returns>
        /// <param name="client">The instantiated Http Client <see cref="HttpClient"/></param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="content">The HTTP request content sent to the server.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="client"/> was null.</exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri"/> was null.</exception>
        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content)
        {
            return client.PatchAsync(CreateUri(requestUri), content);
        }

        /// <summary>
        /// Send a PATCH request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// 
        /// <returns>
        /// Returns <see cref="T:System.Threading.Tasks.Task`1"/>.The task object representing the asynchronous operation.
        /// </returns>
        /// <param name="client">The instantiated Http Client <see cref="HttpClient"/></param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="content">The HTTP request content sent to the server.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="client"/> was null.</exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri"/> was null.</exception>
        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, Uri requestUri, HttpContent content)
        {
            return client.PatchAsync(requestUri, content, CancellationToken.None);
        }
        /// <summary>
        /// Send a PATCH request with a cancellation token as an asynchronous operation.
        /// </summary>
        /// 
        /// <returns>
        /// Returns <see cref="T:System.Threading.Tasks.Task`1"/>.The task object representing the asynchronous operation.
        /// </returns>
        /// <param name="client">The instantiated Http Client <see cref="HttpClient"/></param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="content">The HTTP request content sent to the server.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="client"/> was null.</exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri"/> was null.</exception>
        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return client.PatchAsync(CreateUri(requestUri), content, cancellationToken);
        }

        /// <summary>
        /// Send a PATCH request with a cancellation token as an asynchronous operation.
        /// </summary>
        /// 
        /// <returns>
        /// Returns <see cref="T:System.Threading.Tasks.Task`1"/>.The task object representing the asynchronous operation.
        /// </returns>
        /// <param name="client">The instantiated Http Client <see cref="HttpClient"/></param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="content">The HTTP request content sent to the server.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="client"/> was null.</exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri"/> was null.</exception>
        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return client.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), requestUri)
            {
                Content = content
            }, cancellationToken);
        }

        private static Uri CreateUri(string uri)
        {
            return string.IsNullOrEmpty(uri) ? null : new Uri(uri, UriKind.RelativeOrAbsolute);
        }
    }
}
