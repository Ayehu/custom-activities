<h1>MemoryTableGetUniqueRows</h1>
This activity will take two Memory Tables and then output a new Memory Table containing either:
<br><br>
1) The unique rows from Table 1.
<br>
2) The unique rows from Table 2.
<br>
3) The unique rows from both tables.
<br><br><br>
Let's consider the following examples.  Here are two separate Memory Tables defined in a workflow.
<br><br>
<img src="https://raw.githubusercontent.com/Ayehu/custom-activities/master/MemoryTableGetUniqueRows/screenshots/table1.png">
<br>
<img src="https://raw.githubusercontent.com/Ayehu/custom-activities/master/MemoryTableGetUniqueRows/screenshots/table2.png">
<br><br>
<h3>Example 1</h3>
The <b>MemoryTableGetUniqueRows</b> activity is configured with the "Table 1" option for "Show Unique".  This option says "show me all rows in Table 1 that aren't duplicated in Table 2".
<br><br>
<img src="https://raw.githubusercontent.com/Ayehu/custom-activities/master/MemoryTableGetUniqueRows/screenshots/activity1.png">
<br>
The output is as follows:
<br><br>
<img src="https://raw.githubusercontent.com/Ayehu/custom-activities/master/MemoryTableGetUniqueRows/screenshots/output1.png">
<br><br>
<h3>Example 2</h3>
The <b>MemoryTableGetUniqueRows</b> activity is configured with the "Table 2" option for "Show Unique".  This option says "show me all rows in Table 2 that aren't duplicated in Table 1".
<br><br>
<img src="https://raw.githubusercontent.com/Ayehu/custom-activities/master/MemoryTableGetUniqueRows/screenshots/activity2.png">
<br>
The output is as follows:
<br><br>
<img src="https://raw.githubusercontent.com/Ayehu/custom-activities/master/MemoryTableGetUniqueRows/screenshots/output2.png">
<br><br>
<h3>Example 3</h3>
The <b>MemoryTableGetUniqueRows</b> activity is configured with the "Both Tables" option for "Show Unique".  This option says "combine Table 1 and Table 2 and then show me all unique rows with no duplicates".
<br><br>
<img src="https://raw.githubusercontent.com/Ayehu/custom-activities/master/MemoryTableGetUniqueRows/screenshots/activity3.png">
<br>
The output is as follows:
<br><br>
<img src="https://raw.githubusercontent.com/Ayehu/custom-activities/master/MemoryTableGetUniqueRows/screenshots/output3.png">
