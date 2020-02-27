# Global Azure Bootcamp 2020 (ManagedIdentity)
 
1. [Create Azure SQL Database](https://docs.microsoft.com/en-us/azure/sql-database/sql-database-single-database-get-started?tabs=azure-portal)
2. [Configure Azure Active Directory authentication with SQL](https://docs.microsoft.com/en-us/azure/sql-database/sql-database-aad-authentication-configure?tabs=azure-powershell) 
3. [Publish a Web app to Azure App Service using Visual Studio](https://docs.microsoft.com/en-us/visualstudio/deployment/quickstart-deploy-to-azure?view=vs-2019) 
4. [How to use managed identities for App Service ](https://docs.microsoft.com/en-us/azure/app-service/overview-managed-identity?tabs=dotnet)
4. Change _<identity-name\>_ on your **App Service Name** and execute as AAD user with admin rights
``` SQL
CREATE USER [<identity-name>] FROM EXTERNAL PROVIDER;
ALTER ROLE db_datareader ADD MEMBER [<identity-name>];
ALTER ROLE db_datawriter ADD MEMBER [<identity-name>];
ALTER ROLE db_ddladmin ADD MEMBER [<identity-name>];
GO
```
6. [Create an Azure Storage account](https://docs.microsoft.com/en-us/azure/storage/common/storage-account-create?tabs=azure-portal)
7. [Use the Azure portal to assign an RBAC role for access to blob and queue data](https://docs.microsoft.com/en-us/azure/storage/common/storage-auth-aad-rbac-portal?toc=%2fazure%2fstorage%2fblobs%2ftoc.json)
