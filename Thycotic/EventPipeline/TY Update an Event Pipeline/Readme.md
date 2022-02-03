<br>#     Thycotic</br>
<br>Update an Event Pipeline</br>
<br>Update an existing Event Pipeline using the existing Event Pipeline's ID</br>
<br>Method: Put</br>
<br>OperationID: EventPipelineService_ReorderPipeline</br>
<br>EndPoint:</br>
<br>/event-pipeline/{id}/order</br>
<br>Usage: filters_value[]</br>
<br>{
  "eventPipelineFilterId": {
    "dirty": "%eventPipelineFilterId_dirty%",
    "value": "%eventPipelineFilterId_value%"
  },
  "eventPipelineFilterMapId": {
    "dirty": "%eventPipelineFilterMapId_dirty%",
    "value": "%eventPipelineFilterMapId_value%"
  },
  "eventPipelineFilterName": {
    "dirty": "%eventPipelineFilterName_dirty%",
    "value": "%eventPipelineFilterName_value%"
  },
  "settings": {
    "dirty": "%settings_dirty%",
    "value": "[%settings_value%]"
  },
  "sortOrder": {
    "dirty": "%sortOrder_dirty%",
    "value": "%sortOrder_value%"
  }
}</br>
<br>Usage: tasks_value[]</br>
<br>{
  "eventPipelineTaskId": {
    "dirty": "%eventPipelineTaskId_dirty%",
    "value": "%eventPipelineTaskId_value%"
  },
  "eventPipelineTaskMapId": {
    "dirty": "%eventPipelineTaskMapId_dirty%",
    "value": "%eventPipelineTaskMapId_value%"
  },
  "eventPipelineTaskName": {
    "dirty": "%eventPipelineTaskName_dirty%",
    "value": "%eventPipelineTaskName_value%"
  },
  "settings": {
    "dirty": "%settings_dirty%",
    "value": "[%settings_value%]"
  },
  "sortOrder": {
    "dirty": "%sortOrder_dirty%",
    "value": "%sortOrder_value%"
  }
}</br>
<br>Usage: triggers_value[]</br>
<br>[{
  "eventActionId": {
    "dirty": "%eventActionId_dirty%",
    "value": "%eventActionId_value%"
  }
}]</br>
