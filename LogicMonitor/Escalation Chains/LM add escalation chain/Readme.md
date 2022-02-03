<br>#     LogicMonitor</br>
<br>add escalation chain</br>
<br>LM add escalation chain</br>
<br>Method: Post</br>
<br>OperationID: addEscalationChain</br>
<br>EndPoint:</br>
<br>/setting/alert/chains</br>
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
