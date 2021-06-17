# ContractingApp
This is MVC .NET 5 app \
Pages: Home Page, Contractor Details, Add Contractors, Create Contract, Terminate Contract, Find Shortest Contracting chain \
1. Home Page: Display a grid with all the contractors that are currently active in system \
2. Contractor Details: Click on the details hyperlink on grid to open this page, it will list contractor details \
3. Add Contractors: Click on Add Contractors at bottom of home page to open this. You can add new contractors here \
4. Create Contract: To create a new contract. Click on the menu item on top \
5. Terminate Contract: To terminate an existing contract between two contractors. Click on menu item to access this page \
6. Find Shortest Contracting Chain: Choose any two contractors to check if they are related directly/indirectly. Click on menu item to access this page \
Architecture: MVC \

Code Flow: View -> Controller -> Service -> Repository \
Logging is done using Microsoft.Extensions.Logging and it will log into console only \
This system connects to an InMemory DB. To change it to sql server we have to create a config and given the connection string there.

# ContractingAppTest
Selenium 3 and NUnit 3 is used for automated unit testing of this project \
Architecture used is Page Object Model

**Please refer to attached User Manual to learn more about how the system works **


