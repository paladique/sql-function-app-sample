# Azure Functions Azure SQL DB Sample

This Function App Contains Two Functions:

- `WikiInputFunction`: HTTP POST Trigger that inserts Wikipedia Title text into database.
- `WikiFunction`: SQL Trigger that updates existing Wikipedia Titles with a Description.

Important Files:

- `Article.cs`: Data model of `Article` object
- `local.settings.dev.json`: Stores app secrets (ie: database connection string)

## How to Run Locally

**Azure Account Needed: [Create one here](https://azure.microsoft.com/free/)**

1. Clone Repo
1. Install [Azure Function Core Tools](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=windows%2Cisolated-process%2Cnode-v4%2Cpython-v2%2Chttp-trigger%2Ccontainer-apps&pivots=programming-language-csharp#install-the-azure-functions-core-tools) and [.NET](https://dotnet.microsoft.com/)
1. Create [Azure SQL Database for Free](https://learn.microsoft.com/azure/azure-sql/database/single-database-create-quickstart?view=azuresql&tabs=azure-portal)
1. Open Database in [Portal Query Editor](https://learn.microsoft.com/azure/azure-sql/database/connect-query-portal?view=azuresql), [SSMS](https://learn.microsoft.com/azure/azure-sql/database/design-first-database-tutorial?view=azuresql&tabs=ssms), or [Azure Data Studio](https://learn.microsoft.com/azure/azure-sql/database/design-first-database-azure-data-studio?view=azuresql) 
1. Follow instructions in `setup.sql`
1. Rename **local.settings.dev.json** to **local.settings.json**
1. Copy and paste database connection string into **local.settings.json**
1. (In VS Code) press F5 or open terminal and enter `func start`

## GitHub Codespaces Instructions: Coming Soon


## Learn More
- [Azure SQL bindings for Azure Functions overview](https://learn.microsoft.com/azure/azure-functions/functions-bindings-azure-sql?tabs=isolated-process%2Cextensionv4&pivots=programming-language-csharp)
- [Azure SQL Function Bindings Samples](https://github.com/Azure/azure-functions-sql-extension/tree/main/samples)