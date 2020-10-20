<h1>GetCellValueAdvanced</h1>
This activity is designed to extract a cell from a resultset table that is vertically-oriented and cannot be rotated efficiently with the <b>RotateTable</b> activity because it contains more than two (2) columns.  This single activity can achieve what normally must be achieved with a series of activities (e.g. <b>ResultSetFilter</b> and <b>GetCellValue</b>).
<br><br>
<h1>Example Usage</h1>
Consider the following table...
<br><br>
<img src="https://raw.githubusercontent.com/Ayehu/custom-activities/master/GetCellValueAdvanced/images/1.png">
<br><br>
Let's say we want the cell in the "Value" column that is on the same row that has "full_name" in the "Name" column.  In other words, we know that our table has a row that contains "full_name" in the "Name" column.  We also know that same row has another cell in it that we want, which is under the "Value" column.
<br><br>
Our activity configuration would look like this...
<br><br>
<img src="https://raw.githubusercontent.com/Ayehu/custom-activities/master/GetCellValueAdvanced/images/2.png">
<br><br>
Successful workflow execution results in the following...
<br><br>
<img src="https://raw.githubusercontent.com/Ayehu/custom-activities/master/GetCellValueAdvanced/images/3.png">
