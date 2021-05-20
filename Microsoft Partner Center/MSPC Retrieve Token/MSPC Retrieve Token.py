import sys
import requests
import json

def execute(Resource,TenantID,ClientID,password,GrantType):
  headers = {
    'Content-Type': 'application/x-www-form-urlencoded'
  }

  auth_body_data = {
    'resource': Resource,
    'grant_type': GrantType,
    'client_secret': password,
    'client_id' : ClientID
  }

  try:
      access_token_response = requests.post("https://login.microsoftonline.com/" + TenantID + "/oauth2/token", data=auth_body_data, allow_redirects=False)
      access_token_response.raise_for_status()
  except requests.exceptions.HTTPError as errh:
      result = (errh)
  except requests.exceptions.ConnectionError as errc:
      result = (errc)
  except requests.exceptions.Timeout as errt:
      result = (errt)
  except requests.exceptions.RequestException as err:
      result = (err)
  else:
      response_obj = json.loads(access_token_response.content)
      result =  response_obj['access_token']

  return result