import sys
import urllib.request
import urllib.parse

def execute(Query):
     Query = urllib.parse.quote(Query)
     r = urllib.request.urlopen('https://api.duckduckgo.com/?q='+Query)
     result = r.read()
     return result