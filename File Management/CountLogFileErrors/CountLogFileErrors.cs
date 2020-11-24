using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace Ayehu.Sdk.ActivityCreation
{
    enum TimeFrameType
    {
        Hours = 1,
        Date = 2
    }

    public class CountLogFileErrors : IActivity
    {
        public string HostName;
        public string UserName;
        public string Password;
        public string Path;
        public string search;

        public int timeFrameId;
        public int timeBack;

        public string dtFrom;
        public string dtTo;

        string regex = @"([(\d\.)]+) - - \[(?<date>.*?)\] ""(.*?)"" (?<code>\d+)";
        string dateFormat = "yyyy-MM-dd HH:mm";

        public ICustomActivityResult Execute()
        {
            return this.GenerateActivityResult(GetActivityResult(Read()));
        }

        private DataTable GetActivityResult(int occurrences)
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Occurrences");
            dt.Rows.Add(occurrences);

            return dt;
        }

        public int Read()
        {
            int occurrenceCount = 0;
            string[] logContent = ReadFile().Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            TimeFrameType timeType = (TimeFrameType)timeFrameId;

            foreach (string line in logContent)
            {
                var groups = Regex.Match(line, regex).Groups;
                if (groups.Count > 0)
                {
                    string dateValue = groups["date"].Value;
                    if (!string.IsNullOrEmpty(dateValue))
                    {
                        DateTime eventUTCDate;
                        DateTime inputTime = new DateTime();
                        DateTime.TryParseExact(dateValue, "dd/MMM/yyyy:HH:mm:ss zzz",
                            System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat, System.Globalization.DateTimeStyles.AdjustToUniversal, out eventUTCDate);

                        if (timeType == TimeFrameType.Hours)
                        {
                            inputTime = DateTime.Now.AddHours(-timeBack).ToUniversalTime();

                            if (eventUTCDate >= inputTime &&
                            eventUTCDate.TimeOfDay >= inputTime.TimeOfDay && eventUTCDate.TimeOfDay <= DateTime.Now.TimeOfDay)
                            {
                                if (groups["code"].Value.Trim() == search.Trim())
                                    occurrenceCount++;
                            }
                        }
                        else if (timeType == TimeFrameType.Date)
                        {
                            DateTime dateFrom = DateTime.ParseExact(dtFrom, dateFormat, System.Globalization.CultureInfo.InvariantCulture);
                            DateTime dateTo = DateTime.ParseExact(dtTo, dateFormat, System.Globalization.CultureInfo.InvariantCulture);

                            if (eventUTCDate >= dateFrom && eventUTCDate <= dateTo)
                                if (groups["code"].Value.Trim() == search.Trim())
                                    occurrenceCount++;
                        }
                    }
                }
            }

            return occurrenceCount;
        }

        private string ReadFile()
        {
            if (string.IsNullOrEmpty(Path))
                throw new Exception("File path cannot be empty");

            if (!File.Exists(Path))
                throw new Exception("File does not exist");

            using (StreamReader sr = File.OpenText(Path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}