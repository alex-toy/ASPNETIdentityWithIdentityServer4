# ASP.NET Identity with Identity Server 4

In this project, we will see how to Configure ASP.NET Identity with Identity Server 4. The aim is to ease up the Authentication process and provide a clear step-by-step process on how to secure your web applications. The entire project will be done in .NET 6 and Blazor.


## Setup the API 

### Setup a ClassLibrary project for the Database

- run command
```
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 6.0.1
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 6.0.1
```

- check that all templates have been installed
<img src="/pictures/templates.png" title="templates"  width="900">


## Setting up the Identity Server (Server) project
8. Add an empty ASP.NET Web Project to the Solution
9. Install IdentityServer4 Dependencies 
     Install-Package IdentityServer4 -Version 4.1.2
     Install-Package IdentityServer4.EntityFramework -Version 4.1.2
     Install-Package Microsoft.EntityFrameworkCore.Tools -Version 6.0.1
     Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 6.0.1
     Install-Package Microsoft.AspNetCore.Identity.UI -Version 6.0.1
     Install-Package IdentityServer4.AspNetIdentity -Version 4.1.2
     Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore -Version 6.0.1
10. Add Connection String to appsettings.json
11. Configure Program.cs
12. Create IdentityServer migrations (Default project: Server)
13. Update the IdentityServer Databases
14. Add ASP.NET Identity to the Server project 
15. Add ASP.NET Identity migrations (Server proj) and run them
     Add-Migration InitialAspNetIdentityMigration -Context AspNetIdentityDbContext
     Update-Database -Context AspNetIdentityDbContext
     Discovery Document: https://localhost:5443/.well-known/openid-configuration
16. Add IdentityServer4 Configuration and SeedData
     - Seed.cs template: https://github.com/IdentityServer/Ide...
     - Config.cs template: https://github.com/kevinrjones/Settin...
17. Setup the IdentityServer Seeding process
     - dotnet run Server/bin/Debug/net6.0/Server /seed --project Server
18. Setup the IdentityServer authentication flow
     - https://github.com/IdentityServer/Ide...
19. Update IdentityServer QuickStart code
20. Setup Program.cs for integration with the QuickStart code (Server)
