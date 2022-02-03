<br>#     LogicMonitor</br>
<br>update escalation chain</br>
<br>LM update escalation chain</br>
<br>Method: Patch</br>
<br>OperationID: patchEscalationChainById</br>
<br>EndPoint:</br>
<br>/setting/alert/chains/{id}</br>
<br>Usage: ccDestinations[]</br>
<br>[{
  "addr": "%addr%",
  "contact": "%contact%",
  "method": "%method%",
  "type": "%type%"
}]</br>
<br>Usage: destinations[]</br>
<br>{
  "period": {
    "endMinutes": "%endMinutes%",
    "startMinutes": "%startMinutes%",
    "timezone": "%timezone%"
  },
  "stages": [
    [
      {
        "addr": "%stages_addr%",
        "contact": "%stages_contact%",
        "method": "%stages_method%",
        "type": "%stages_type%"
      }
    ]
  ],
  "type": "%destinations_type%"
}</br>
