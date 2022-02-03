<br>#     Github</br>
<br>Get a release asset</br>
<br>To download the asset's binary content, set the `Accept` header of the request to [`application/octet-stream`](https://developer.github.com/v3/media/#media-types). The API will either redirect the client to the location, or stream it directly if possible. API clients should handle both a `200` or `302` response.</br>
<br>Method: Get</br>
<br>OperationID: repos/get-release-asset</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/releases/assets/{asset_id}</br>
