## BambooAddEmployee - Activity to create a new employee in BambooHR.

##### Namespaces to import 
</br>
using System; </br>
using System.Data; </br>
using System.Text; </br>
using System.Net; </br>
using Ayehu.Sdk.ActivityCreation.Interfaces; </br>
using Ayehu.Sdk.ActivityCreation.Extension;

### Below fields needs to be provided to add an employee:
**First Name**      - Employee first name

**Last Name**		- Employee last name

**Job Title**       - Employee job title

**Work Phone**      - Employee work phone

**Work Email**      - Employee work email

**Mobile phone**    - Employee personal cell phone

**Department**      - The employee work department belongs to

**Api Key**		    - The registered company name in bamboohr                   

**Company Name**	- The api key provided by bamboohr

## Returns the ID of the newly created user
