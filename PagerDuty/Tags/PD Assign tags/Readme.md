<br>#     PagerDuty</br>
<br>Assign tags</br>
<br>Assign existing or new tags.

A Tag is applied to EScalation Policies, Teams or Users and can be used to filter them.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#tags)
</br>
<br>Method: Post</br>
<br>OperationID: createEntityTypeByIdChangeTags</br>
<br>EndPoint:</br>
<br>/{entity_type}/{id}/change_tags</br>
<br>Usage: add[]</br>
<br>[{
  "type": "%type%",
  "label": "%label%"
}]</br>
<br>Usage: remove[]</br>
<br>[{
  "type": "%remove_type%",
  "id": "%remove_id%"
}]</br>
