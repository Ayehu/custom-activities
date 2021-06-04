<h1>ExcelWriteWithDropdown</h1>
Create an Excel spreadsheet from a Memory Table with one column containing a customizable dropdown list.
<br><br>
<h3>Input Fields</h3>
<b>Table:</b> Variable containing the Memory Table.
<br>
<b>Sheet Name:</b> Optional custom name to give to Excel sheet.
<br>
<b>Dropdown List:</b> A comma-separated list of items to include in the dropdown (e.g. <b>Yes,No</b>).
<br>
<b>Column Letter:</b> The letter value assigned to the column on which the dropdown list should be applied (e.g. column 2 would be <b>B</b>).
<br>
<b>Start Row:</b> The first row in the target column where dropdown list should appear (set to <b>2</b> by default as to skip the header row).
<br>
<b>End Row:</b> The last row in the target column where dropdown list should appear, which would typically be the value of <b>GetRowsCount</b> minus 1.
<br>
<b>Path:</b> The full path for the destination Excel spreadsheet file (e.g. <b>C:\my\folder\sheet.xls</b>).
<br>
<b>Hostname/User Name/Password:</b> Target host on which to write the destination Excel spreadsheet file.
<br><br>
<h3>Example</h3>
Consider the following table <b>%myTable%</b>:
<br><br>
<img src="https://github.com/Ayehu/custom-activities/blob/master/ExcelWrite/ExcelWriteWithDropDown/screenshots/table.png?raw=true">
<br>
Below, we pass that table to the <b>ExcelWriteWithDropdown</b> activity (note that <b>%excelEndRow%</b> is the value of <b>GetRowsCount</b> from the source table minus 1, calculated using the <b>FunctionCalculator</b> activity):
<br><br>
<img src="https://github.com/Ayehu/custom-activities/blob/master/ExcelWrite/ExcelWriteWithDropDown/screenshots/screenshot.png?raw=true">
<br>
Our resulting Excel spreadsheet is as follows:
<br><br>
<img src="https://github.com/Ayehu/custom-activities/blob/master/ExcelWrite/ExcelWriteWithDropDown/screenshots/excel.png?raw=true">
