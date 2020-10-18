<br>#     Ayehu</br>
<br>AY ModuleUpdateModule</br>
<br>Method: Post</br>
<br>OperationID: Module_UpdateModule</br>
<br>EndPoint:</br>
<br>/Api/Module/updateModuleData</br>
<br>Usage: instances[]</br>
<br>[{
  "id": "%instances_id%",
  "deviceId": "%deviceId%",
  "deviceName": "%deviceName%",
  "port": "%port%",
  "status": "%instances_status%"
}]</br>
<br>Usage: Form[]</br>
<br>{
  "FormID": "%FormID%",
  "FormName": "%FormName%",
  "Interval": "%Interval%",
  "Filter": "[%Filter%]",
  "IsDiscovered": "%IsDiscovered%"
}</br>
<br>Usage: Map[]</br>
<br>{
  "FormName": "%Map_FormName%",
  "OptionalParams": "[%OptionalParams%]",
  "EyeShareIncidentInstance": "%EyeShareIncidentInstance%",
  "ByPassIncident": "%ByPassIncident%",
  "StaticState": "%StaticState%",
  "StaticSeverity": "%StaticSeverity%",
  "SeverityStr": "%SeverityStr%",
  "StateStr": "%StateStr%",
  "Severity": {
    "Critical": "%Critical%",
    "Info": "%Info%",
    "Major": "%Major%",
    "Minor": "%Minor%",
    "Warning": "%Warning%"
  },
  "State": {
    "Down": "%Down%",
    "Up": "%Up%"
  }
}</br>
<br>Usage: forms[]</br>
<br>{
  "moduleId": "%moduleId%",
  "moduleType": "%moduleType%",
  "formId": "%formId%",
  "entityType": "%entityType%",
  "entityName": "%entityName%",
  "entityAlias": "%entityAlias%",
  "fields": "[%fields%]",
  "operators": "[%operators%]",
  "isFieldsDiscovered": "%isFieldsDiscovered%",
  "confType": "%confType%"
}</br>
<br>Usage: connectionParameters[]</br>
<br>[{
  "key": "%connectionParameters_key%",
  "value": "%connectionParameters_value%",
  "encrypted": "%encrypted%"
}]</br>
