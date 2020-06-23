This activity will take a string containing HTML text (including HTML-encoded characters) and return its plaintext equivalent.
<br><br>
<b>Example Input:</b>
```
<font color="red">Here's some text, it even contains <a href="http://www.google.com">a link to Google.com</a>!
<br>
And this text is <b>bold</b> while this text is <i>italic</i>.
<br>
We want to see this text here stripped of all HTML tags...
<br>
This is a &quot;test&quot; &amp; we will see how it works!
```
<br>
<b>Example Output:</b>
```
Here's some text, it even contains a link to Google.com !
And this text is bold while this text is italic .
We want to see this text here stripped of all HTML tags...
This is a "test" & we will see how it works!
```
