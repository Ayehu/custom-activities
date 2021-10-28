<h1>DeepL Translate Text</h1>
<br>
An activity to translate text into another language using the DeepL AI-powered machine translation service.
<br><br>
<h3>Input:</h3>
<ul>
  <li><b>API URL:</b> The API endpoint URL.</li>
  <li><b>API Key:</b> The API authentication key (<a href="https://www.deepl.com/docs-api/accessing-the-api/authentication/">read more</a>).</li>
  <li><b>Auto-Detect Source Language:</b> Toggle to allow DeepL to auto-detect the source language of the text to be translated.</li>
  <li><b>Source Language:</b> If auto-detect is turned off, this language will be used to tell DeepL the source language of the original text (<a href="https://www.deepl.com/docs-api/translating-text/">read more</a>).</li>
  <li><b>Target Language:</b> The target language in which to translate the text (<a href="https://www.deepl.com/docs-api/translating-text/">read more</a>).</li>
  <li><b>Formality:</b> Level of formality for the translated text.</li>
  <li><b>Text:</b> The body of text to translate.</li>
</ul>
<b>Note:</b> Only certain target languages support formality modes.  When attempting to translate to a target language with a formality mode other than "default", an error message like this will be returned if that target language does not support a formality mode other than "default".
<br><br>
<pre>
Target language does not support formality mode "more". Please use "default" setting. Only the following languages support formality levels:
DE, FR, IT, ES, NL, PL, PT-PT, PT-BR, RU
</pre>
<br>
<h3>Example:</h3>
<br>
<img src="https://github.com/Ayehu/custom-activities/blob/master/DeepL/screenshot1.png?raw=true">
<br><br>
<img src="https://github.com/Ayehu/custom-activities/blob/master/DeepL/screenshot2.png?raw=true">
