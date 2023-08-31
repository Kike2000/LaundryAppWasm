using LaundryAppWasm.Server.DBContext;
using LaundryAppWasm.Server.Repositories;
using LaundryAppWasm.Shared.Interfaces;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<ApplicationDbContext>(sp =>
{
    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=LaundryDb; Integrated Security=True")
        .Options;

    return new ApplicationDbContext(options);
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

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
