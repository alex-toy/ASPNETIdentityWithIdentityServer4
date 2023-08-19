# ASP.NET Identity with Identity Server 4

In this project, we will see how to Configure ASP.NET Identity with Identity Server 4. The aim is to ease up the Authentication process and provide a clear step-by-step process on how to secure your web applications. The entire project will be done in .NET 6 and Blazor.


## Setup the API 

- install packages in *CoffeeShopAPI*
```
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 6.0.1
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 6.0.1
```

- install packages in *DataAccess*
```
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 6.0.1
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 6.0.1
```

- Migrations
```
Add-Migration InitialCreate
Update-Database
```

- run the project
<img src="/pictures/coffeeshop.png" title="coffee shop"  width="900">


## Setting up the Identity Server (Server) project

### Install IdentityServer4 Dependencies 
```
Install-Package IdentityServer4 -Version 4.1.2
Install-Package IdentityServer4.EntityFramework -Version 4.1.2
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 6.0.1
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 6.0.1
Install-Package Microsoft.AspNetCore.Identity.UI -Version 6.0.1
Install-Package IdentityServer4.AspNetIdentity -Version 4.1.2
Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore -Version 6.0.1
```

- PersistedGrantDbContext Migrations
```
Add-Migration seedData -Context PersistedGrantDbContext
Update-Database -Context PersistedGrantDbContext
```

- ConfigurationDbContext Migrations
```
Add-Migration ConfigurationDbContextMigration -Context ConfigurationDbContext
Update-Database -Context ConfigurationDbContext
```

### Add IdentityServer4 Configuration and SeedData

- AspNetIdentityDbContext Migrations
```
Add-Migration AspNetIdentityDbContextMigrations -Context AspNetIdentityDbContext
Update-Database -Context AspNetIdentityDbContext
```

- seed project
```
dotnet run IdentityServer/bin/Debug/net6.0/IdentityServer /seed --project IdentityServer
```

- Discovery Document: https://localhost:5443/.well-known/openid-configuration
<img src="/pictures/openid-configuration.png" title="openid-configuration"  width="900">

18. Setup the IdentityServer authentication flow
     - https://github.com/IdentityServer/Ide...
19. Update IdentityServer QuickStart code
20. Setup Program.cs for integration with the QuickStart code (Server)


