using LaundryAppWasm.Server.DBContext;
using LaundryAppWasm.Server.Models;
using LaundryAppWasm.Server.Repositories;
using LaundryAppWasm.Shared.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped(sp =>
{
    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=LaundryDb; Integrated Security=True")
        .Options;

    return new ApplicationDbContext(options);
});
//Injection of Interfaces
builder.Services.AddScoped<IItem, ItemRepository>();
builder.Services.AddScoped<ICustomer, CustomerRepository>();
builder.Services.AddScoped<IEmployee, EmployeeRepository>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultUI()
        .AddDefaultTokenProviders();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
