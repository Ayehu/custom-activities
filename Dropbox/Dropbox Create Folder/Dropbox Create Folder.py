import sys
import json
if (3,0) <= sys.version_info < (4,0):
    import http.client as httplib
elif (2,6) <= sys.version_info < (3,0):
    import httplib

def execute(Title,Destination,AccessToken):
    headers = {
    "Authorization": "Bearer "+ AccessToken,
    "Content-Type": "application/json"
    }

    params = {
        "title": Title,
        "destination": Destination
    }

    c = httplib.HTTPSConnection("api.dropboxapi.com")
    c.request("POST", "/2/file_requests/create", json.dumps(params), headers)
    r = c.getresponse().read()
    result = json.loads(r)
    return result