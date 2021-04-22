<h1>GetTableRowsByRange</h1>
Retrieve rows from a Memory Table by range or length.  Note that if an out-of-bounds interval is specified while using "Length" mode, this activity will return the maximum number of rows possible.
<br><br>
<h2>Input Fields</h2>
<b>Source Table:</b> The source table variable (e.g. %processList%).
<br>
<b>Start Row:</b> The first row for the desired range.
<br>
<b>Interval Mode:</b> "End Row" will retrieve rows between, and including, a start and end row range, while "Length" will retrieve rows from, and including, the start row and X number of rows after it.
<br>
<b>Interval:</b> In "End Row" mode, this is the end row of the desired range to retrieve, while in "Length" mode this is the number of rows after, and including, the start row to retrieve.
