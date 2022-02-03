<br>#     Github</br>
<br>Get all contributor commit activity</br>
<br>
Returns the `total` number of commits authored by the contributor. In addition, the response includes a Weekly Hash (`weeks` array) with the following information:

*   `w` - Start of the week, given as a [Unix timestamp](http://en.wikipedia.org/wiki/Unix_time).
*   `a` - Number of additions
*   `d` - Number of deletions
*   `c` - Number of commits</br>
<br>Method: Get</br>
<br>OperationID: repos/get-contributors-stats</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/stats/contributors</br>
