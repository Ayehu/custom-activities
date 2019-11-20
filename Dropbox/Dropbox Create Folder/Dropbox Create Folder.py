import sys
import json
if (3,0) <= sys.version_info < (4,0):
    import http.client as httplib
elif (2,6) <= sys.version_info < (3,0):
    import httplib


def execute(Path,AccessToken):
    headers = {
      "Authorization": "Bearer "+ AccessToken,
      "Content-Type": "application/json"
      }

    params = {
          "path": Path
    }

    c = httplib.HTTPSConnection("api.dropboxapi.com")
    c.request("POST", "/2/files/create_folder_v2", json.dumps(params), headers)
    r = c.getresponse().read()
    result = json.loads(r)
    
    try:
      id = result["metadata"]["id"]
      id = id.split(":")[1]
      result = id
    except:     
      sys.tracebacklimit = 0
      raise Exception(result)
      return result