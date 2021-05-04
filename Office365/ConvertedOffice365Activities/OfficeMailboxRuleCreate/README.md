## OfficeMailboxRuleCreate - Activity to create a new mailbox rule in Azure AD for Office365.

##### DLL's to reference
System.Net.Http.dll


### Mandatory fields when creating a mailbox rule:

**userEmail**		  - User's email to create the rule

**ruleDisplayName**   - The rule name

**senderContains**    - Apply the rule if sender contains this string

**bodyContains**	  - Apply the rule if body contains this string

**forwardAction**	  - Indicates that email have to be forwarded

**forwardEmail**      - Forward email to the specified email address

**deleteAction**      - Indicates that email have to be deleted

