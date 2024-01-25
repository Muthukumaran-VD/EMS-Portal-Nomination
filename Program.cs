using EMS_Portal_Nomination.Data;
using EMS_Portal_Nomination.Models;
using EMS_Portal_Nomination.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<DBService>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Connection to the database
builder.Services.AddDbContext<DataContext>(item => item.UseSqlServer(connectionString));

// Entity Framework

var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

optionsBuilder.UseSqlServer(connectionString);

// enabling auto migration

using (var context = new DataContext(optionsBuilder.Options))

{

    context.Database.Migrate();

}


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

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
