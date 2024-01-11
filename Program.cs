using E_Commerces.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Load the Conntection String
String ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection String Not Founded");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(
    options=>options.UseSqlServer(ConnectionString)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapGet("/test",async (context) =>{
    await context.Response.WriteAsync("Testing Endpoint");
});

app.MapGet("/testAPI", async (context) =>{
    await context.Response.WriteAsJsonAsync(new {Name = "Nhutanh", Age = 20});
});


app.UseAuthorization();
app.UseAuthorization();
app.UseCustomMiddlewareExtension();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
