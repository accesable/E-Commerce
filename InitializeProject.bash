# SQL Server Docker Instance Initialize
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 --name sql_server_demo -d mcr.microsoft.com/mssql/server


dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.Extensions.Logging
dotnet add package Microsoft.EntityFrameworkCore.Proxies
dotnet add package Microsoft.EntityFrameworkCore.Tools
