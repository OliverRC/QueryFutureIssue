# Query Future Issue

I have run into some issues get Query Future to work in the expected way.
To try and narrow it down I created the following example.

I included .NET Aspire to try make it easier to visualize the actual calls happening to the database.

## Setup

To test locally you can use Docker to run the databases, and then run the appropriate scripts from the `Database` folder.

### MariaDB (i.e MySql to EF)

Default username is `root`.

```powershell
docker run --detach --name mariadb --env MARIADB_ROOT_PASSWORD=<password> -p 3306:3306 mariadb:latest
```

Add the secret
```
dotnet user-secrets --id 4b11fa26-211f-429a-a4dc-e7ae2215d874 set ConnectionStrings:AppDatabaseMySql "server=localhost;user=root;password=<password>;database=appdb;"
```

### MSSQL or SQL Server

Default username is `sa`.
```powershell
docker run --name mssql -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<password>" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

Add the secret
```
dotnet user-secrets --id 4b11fa26-211f-429a-a4dc-e7ae2215d874 set ConnectionStrings:AppDatabaseMySql "Server=localhost,1433;Database=appdb;User=sa;Password=<password>;TrustServerCertificate=True;"
```

### Provider

You can switch between DB providers by editing the `AspireApp1.ApiServer\Program.cs` file.
Uncomment the provider you want to use.

```csharp
// MySql / MariaDB
// builder.AddMySqlDbContext<AppDbContext>("AppDatabaseMySql");
// MSSQL
//builder.AddSqlServerDbContext<AppDbContext>("AppDatabaseSqlServer");
```