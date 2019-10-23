using System;
using System.Data;
using System.Linq;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;

namespace Ayehu.Sdk.ActivityCreation
{
    public class DateConvertToTimezone : IActivity
    {
        /// <summary>
        /// The current reference time
        /// </summary>
        public string currentTime;

        /// <summary>
        /// Format of the input time
        /// </summary>
        public string dateFormat;

        /// <summary>
        /// Current time timeZone
        /// </summary>
        public string fromTimeZone;

        /// <summary>
        /// Convert input time to this timezone
        /// </summary>
        public string toTimeZone;

        /// <summary>
        /// Converted time format
        /// </summary>
        public string outDateFormat;

        public ICustomActivityResult Execute()
        {
            if (string.IsNullOrEmpty(currentTime))
                throw new Exception("Date and time cannot be empty");

            if (string.IsNullOrEmpty(dateFormat))
                throw new Exception("Date format cannot be empty");

            if (string.IsNullOrEmpty(outDateFormat))
                throw new Exception("out Date format cannot be empty");

            if (string.IsNullOrEmpty(fromTimeZone))
                throw new Exception("fromTimezone cannot be emty");

            if (string.IsNullOrEmpty(toTimeZone))
                throw new Exception("toTimezone cannot be emty");

            var culture = System.Globalization.CultureInfo.CurrentCulture;
            DateTime dt = DateTime.ParseExact(currentTime, dateFormat, culture, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
            var timezones = TimeZoneInfo.GetSystemTimeZones().ToList();
            TimeZoneInfo fromtz = timezones.Where(tz => tz.Id == fromTimeZone).FirstOrDefault();
            TimeZoneInfo totz = timezones.Where(tz => tz.Id == toTimeZone).FirstOrDefault();
            DateTime convertedDt = TimeZoneInfo.ConvertTime(dt, fromtz, totz);

            return this.GenerateActivityResult(GetActivityResult(convertedDt.ToString(outDateFormat)));
        }

        private DataTable GetActivityResult(string date)
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result");
            dt.Rows.Add(date);

            return dt;
        }
    }
}
