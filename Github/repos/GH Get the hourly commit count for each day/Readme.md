<br>#     Github</br>
<br>Get the hourly commit count for each day</br>
<br>Each array contains the day number, hour number, and number of commits:

*   `0-6`: Sunday - Saturday
*   `0-23`: Hour of day
*   Number of commits

For example, `[2, 14, 25]` indicates that there were 25 total commits, during the 2:00pm hour on Tuesdays. All times are based on the time zone of individual commits.</br>
<br>Method: Get</br>
<br>OperationID: repos/get-punch-card-stats</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/stats/punch_card</br>
