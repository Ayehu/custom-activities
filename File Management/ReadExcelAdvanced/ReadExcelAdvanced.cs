using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using ExcelDataReader;
using System;
using System.Data;
using System.IO;

namespace Ayehu.Sdk.ActivityCreation
{
    public class ReadExcel : IActivity
    {
        public string IgnoreHeader;
        public string Path;
        public string Range;
        public string HostName;
        public string SheetName;
        public string UserName;
        public string Password;

        public ICustomActivityResult Execute()
        {
            DataTable dt = ReadFile();
            dt.TableName = "resultSet";
            var res = this.GenerateActivityResult(dt);
            return res;
        }

        public DataTable ReadFile()
        {
            if (string.IsNullOrEmpty(Path))
                throw new Exception("File Path can't be empty");

            using (var stream = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                IExcelDataReader reader;
                if (new FileInfo(Path).Extension.ToLower() == ".csv")
                {
                    using (reader = ExcelReaderFactory.CreateCsvReader(stream))
                    {
                        DataTable dt = reader.AsDataTable(new ExcelDataTableConfiguration
                        {
                            ExcludeHeaderRow = Convert.ToBoolean(IgnoreHeader),
                            FilterResult = (dr) =>
                            {
                                dr.GetRange(Range);
                                return true;
                            }
                        });
                        return dt;
                    }
                }
                else
                {
                    using (reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        DataTable dt = reader.AsDataTable(new ExcelDataTableConfiguration
                        {
                            ExcludeHeaderRow = Convert.ToBoolean(IgnoreHeader),
                            SheetName = this.SheetName,
                            FilterResult = (dr) =>
                            {
                                dr.GetRange(Range);
                                return true;
                            }
                        });

                        return dt;
                    }
                }
            }
        }
    }
}
