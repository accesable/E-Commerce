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
dotnet ef migrations add InitialCreate --output-dir Your/Directory --context ContextClassName
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
## Creating Middlewares in ASP.NET core
A Middleware class
```C#
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("Request Headers:");
        foreach (var header in context.Request.Headers)
        {
            Console.WriteLine($"{header.Key}: {header.Value}");
        }

        // Call the next delegate/middleware in the pipeline
        await _next(context);
                // Log response headers
        Console.WriteLine("Response Headers:");
        foreach (var header in context.Response.Headers)
        {
            Console.WriteLine($"{header.Key}: {header.Value}");
        }
    }
}
```
Make an Extension Method for using this middleware
```C#
using Microsoft.AspNetCore.Builder;

public static class CustomMiddlewareExtension
{
    public static IApplicationBuilder UseCustomMiddlewareExtension(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomMiddleware>();
    }
}
```
Use it in `Program.cs`
```C#
app.UseCustomMiddlewareExtension();
```
---
## `IEndpoints` In ASP.NET core
this interfaces responbile for configuring Endpoints 
```C#
app.MapGet("/test",async (context) =>{
    await context.Response.WriteAsync("Testing Endpoint");
});
```
## Create A Controller 
This Based on The Route Configuration `app.MapControllerRoute()` at `Program.cs`
```C#
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerces.Controllers;

public class TestController : Controller{
    public string Index(){
        return "This is A Controller for Testing";
    }
    // This route accept http://localhost:5226/test/welcome/2?name=nhutanh
    // And http://localhost:5226/test/welcome?id=1&name=nhutanh
    // http://localhost:5226/test/welcome?name=nhutanh
    public string Welcome(string name ,int ID = -1){
        return HtmlEncoder.Default.Encode($"Welcome to the Test Controller Platform Your ID {ID} and name : {name}");   
    }
}
```
## ASP.NET Scaffolding

### For Razor Pages
```bash
dotnet aspnet-codegenerator razorpage -h
dotnet aspnet-codegenerator razorpage -m Product -dc E_commreces.Models.ApplicationDbContext -udl -outDir Pages/Products --referenceScriptLibraries --databaseProvider sqlserver
```
- `-udl` : Use default Layout
- `-dc` : Create a DBContext based on that given models
- `-m` : Model Class name
- `-outDir` : Page output directory
- `--referenceScriptLibraries` : Adds `_ValidationScriptsPartial` to Edit and Create pages