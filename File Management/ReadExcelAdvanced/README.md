## ReadExcelAdvanced - Read excel files.

##### DLL's to reference
ExcelDataReader.dll

##Fields to be set in the activity.

**IgnoreHeader** - If False then it will set the first row as header otherwise it will add one more row with naming convention Column1, Column2 ... Column_n

**Path** - The full path to the Excel file.

**Range** - One-cell or multi-cell range with rows and columns in format of [A1:A2], [fromRow, fromColumn, toRow, toColumn] or just [A1] to get a single column.

**HostName** - The name of the computer to get the file from.

**SheetName** - The name of the Sheet to get the data from.

**UserName** -  Username to authenticate to the computer where is located the file.

**Password** - Password to authenticate to the computer where is located the file.

