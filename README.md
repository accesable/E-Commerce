# E-Commerce ASP.NET Project

### Initialize SQL Server Instance
```bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 --name sql_server -d mcr.microsoft.com/mssql/server
```
Install EF packages for project
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.Extensions.Logging
dotnet add package Microsoft.EntityFrameworkCore.Proxies
dotnet add package Microsoft.EntityFrameworkCore.Tools
```
```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Initial Catalog=E-Commerces;User ID=sa;Password=yourStrong(!)Password;Encrypt=false;TrustServerCertificate=false"
  }
```
Application DbContext class \
[EF Migrations Managing URL]("https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli")
```C#
using Microsoft.EntityFrameworkCore;

namespace E_Commerces.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }
    public DbSet<Product> Products{get;set;}
}
```
Most Used EF commands
```bash
dotnet ef migrations add InitialCreate --output-dir Your/Directory
dotnet ef migrations list
dotnet ef migrations remove
dotnet ef database update
```
## Integrate JS and CSS Library
We Will Integrate Boostrap and Jquery for this Project using `npm` \ 
`gulp` for bundling and minification
```npm
npm init
npm install boostrap jquery popper.js
npm install --save-dev gulp
```
package.json
```json
"scripts": {
    "gulp": "gulp"
}
```
Run `npm run gulp` to copy boostrap,jquery,popper.js into static folder which is `wwwroot` folder \
### Another ways of Integrating JS and CSS Library
Another Way to do it is to use `Webpack`. But you need to add a `scss` file into the project. in My case in `resources/scss/site.scss`
```bash
npm i -D webpack webpack-cli                        # cài đặt Webpack
npm i node-sass postcss-loader postcss-preset-env   # cài đặt các gói để làm việc với SCSS
npm i sass-loader css-loader cssnano                # cài đặt các gói để làm việc với SCSS, CSS
npm i mini-css-extract-plugin cross-env file-loader # cài đặt các gói để làm việc với SCSS
npm install copy-webpack-plugin                     # cài đặt plugin copy file cho Webpack
npm install npm-watch   
```
Remember when run `npm run build` make sure the project directory of the local machine must not containt any special character . In My Case the `C:\D\Projects\C#\E-Commerces` does not work so it cause a bug
```json
  "scripts": {
    "gulp": "gulp",
    "build": "webpack",
    "watch": "npm-watch"
  },
  "watch": {
    "build": "webpack --mode production",
    "dev": "webpack --mode development"
  }
```
---


