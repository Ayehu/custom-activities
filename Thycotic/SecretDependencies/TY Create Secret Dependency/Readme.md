<br>#     Thycotic</br>
<br>Create Secret Dependency</br>
<br>Creates a new Secret Dependency and returns the model</br>
<br>Method: Post</br>
<br>OperationID: SecretDependenciesService_CreateDependency</br>
<br>EndPoint:</br>
<br>/secret-dependencies</br>
<br>Usage: dependencyScanItemFields[]</br>
<br>[{
  "id": "%id%",
  "name": "%name%",
  "parentName": "%parentName%",
  "value": "%value%"
}]</br>
<br>Usage: odbcConnectionArguments[]</br>
<br>[{
  "name": "%odbcConnectionArguments_name%",
  "value": "%odbcConnectionArguments_value%"
}]</br>
<br>Usage: scriptArguments[]</br>
<br>[{
  "name": "%scriptArguments_name%",
  "type": "%type%",
  "value": "%scriptArguments_value%"
}]</br>
<br>Usage: settings[]</br>
<br>{
  "changerSettingValue": "%changerSettingValue%",
  "setting": {
    "active": "%setting_active%",
    "canEdit": "%canEdit%",
    "canEditValue": "%canEditValue%",
    "childSettings": "[%childSettings%]",
    "defaultValue": "%setting_defaultValue%",
    "displayName": "%setting_displayName%",
    "id": "%setting_id%",
    "isVisibile": "%setting_isVisibile%",
    "parentSettingId": "%setting_parentSettingId%",
    "regexValidation": "%setting_regexValidation%",
    "settingName": "%setting_settingName%",
    "settingSectionId": "%setting_settingSectionId%",
    "settingType": "%setting_settingType%",
    "subSettingSectionId": "%setting_subSettingSectionId%"
  },
  "settingId": "%settingId%",
  "settingName": "%settings_settingName%",
  "settingValue": "%settingValue%"
}</br>
