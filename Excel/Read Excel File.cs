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
        public string IncludeHeader;
        public string FilePath;

        public ICustomActivityResult Execute()
        {
            return this.GenerateActivityResult(ReadFile());
        }

        public DataTable ReadFile()
        {
        	if (string.IsNullOrEmpty(FilePath))
                throw new Exception("File Path can't be empty");
        
            using (var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream)) 
                {
                    DataTable dt = reader.AsDataTable(new ExcelDataTableConfiguration
                    {
                       UseHeaderRow = Convert.ToBoolean(IncludeHeader)
                   });

                    dt.TableName = "resultSet";
                    return dt;
                }
            } 
        } 
    }
}
