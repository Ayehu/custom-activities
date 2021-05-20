import sys
import requests
import json

def execute(Resource,TenantID,ClientID,password,GrantType):
  headers = {
    'Content-Type': 'application/x-www-form-urlencoded'
  }

  resource = Resource
  tenant_id = TenantID
  client_id = ClientID
  client_secret = password
  grant_type = GrantType

  auth_body_data = {
    'resource': resource,
    'grant_type': grant_type,
    'client_secret': client_secret,
    'client_id' : client_id
  }

  try:
      access_token_response = requests.post("https://login.microsoftonline.com/" + tenant_id + "/oauth2/token", data=auth_body_data, allow_redirects=False)
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