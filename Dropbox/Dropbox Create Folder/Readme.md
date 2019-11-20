## Dropbox - Create folder


can see documentation in this url : https://www.dropbox.com/developers/documentation/http/documentation#files-create_folder

DESCRIPTION
Create a folder at a given path.

URL STRUCTURE
https://api.dropboxapi.com/2/files/create_folder_v2
AUTHENTICATION
User Authentication, Dropbox-API-Select-Admin (Team Admin)
ENDPOINT FORMAT
RPC
EXAMPLE
Get access token for:
curl -X POST https://api.dropboxapi.com/2/files/create_folder_v2 \
    --header "Authorization: Bearer " \
    --header "Content-Type: application/json" \
    --data "{\"path\": \"/Homework/math\",\"autorename\": false}"
PARAMETERS
{
    "path": "/Homework/math",
    "autorename": false
}
CreateFolderArg
path String(pattern="(/(.|[\r\n])*)|(ns:[0-9]+(/.*)?)") Path in the user's Dropbox to create.
autorename Boolean If there's a conflict, have the Dropbox server try to autorename the folder to avoid the conflict. The default for this field is False.
RETURNS
{
    "metadata": {
        "name": "math",
        "id": "id:a4ayc_80_OEAAAAAAAAAXz",
        "path_lower": "/homework/math",
        "path_display": "/Homework/math",
        "sharing_info": {
            "read_only": false,
            "parent_shared_folder_id": "84528192421",
            "traverse_only": false,
            "no_access": false
        },
        "property_groups": [
            {
                "template_id": "ptid:1a5n2i6d3OYEAAAAAAAAAYa",
                "fields": [
                    {
                        "name": "Security Policy",
                        "value": "Confidential"
                    }
                ]
            }
        ]
    }
}
CreateFolderResult
metadata FolderMetadata Metadata of the created folder.
ERRORS
CreateFolderError (union)
The value will be one of the following datatypes:
path WriteError