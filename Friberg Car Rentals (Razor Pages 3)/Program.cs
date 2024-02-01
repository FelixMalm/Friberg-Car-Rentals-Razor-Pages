using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Friberg_Car_Rentals__Razor_Pages_3_.Data;
using Friberg_Car_Rentals__Razor_Pages_3_.Repository;
using Microsoft.AspNetCore.Http;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Friberg_Car_Rentals__Razor_Pages_3_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Friberg_Car_Rentals__Razor_Pages_3_Context") ?? throw new InvalidOperationException("Connection string 'Friberg_Car_Rentals__Razor_Pages_3_Context' not found.")));
builder.Services.AddTransient(typeof(ICar), typeof(CarRepository));
builder.Services.AddTransient(typeof(ICustomer), typeof(CustomerRepository));
builder.Services.AddTransient(typeof(IAdmin), typeof(AdminRepository));
builder.Services.AddTransient(typeof(IOrder), typeof(OrderRepository));

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
