<br>#     Github</br>
<br>Update an attribute for a SCIM user</br>
<br>Allows you to change a provisioned user's individual attributes. To change a user's values, you must provide a specific `Operations` JSON format that contains at least one of the `add`, `remove`, or `replace` operations. For examples and more information on the SCIM operations format, see the [SCIM specification](https://tools.ietf.org/html/rfc7644#section-3.5.2).

**Note:** Complicated SCIM `path` selectors that include filters are not supported. For example, a `path` selector defined as `"path": "emails[type eq \"work\"]"` will not work.

**Warning:** If you set `active:false` using the `replace` operation (as shown in the JSON example below), it removes the user from the organization, deletes the external identity, and deletes the associated `:scim_user_id`.

```
{
  "Operations":[{
    "op":"replace",
    "value":{
      "active":false
    }
  }]
}
```</br>
<br>Method: Patch</br>
<br>OperationID: scim/update-attribute-for-user</br>
<br>EndPoint:</br>
<br>/scim/v2/organizations/{org}/Users/{scim_user_id}</br>
<br>Usage: Operations[]</br>
<br>[{
  "op": "%op%",
  "path": "%path%"
}]</br>
