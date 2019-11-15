import sys
import json
if (3,0) <= sys.version_info < (4,0):
    import http.client as httplib
elif (2,6) <= sys.version_info < (3,0):
    import httplib

def execute(AccessToken):
    headers = {
    "Authorization": "Bearer "+ AccessToken,
    "Content-Type": "application/json"
    }

    params = None

    c = httplib.HTTPSConnection("api.dropboxapi.com")
    c.request("POST", "/2/file_requests/list", json.dumps(params), headers)
    r = c.getresponse().read()
    result = json.loads(r)
    return result