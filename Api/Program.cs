using Api.Controllers;
using Api.Middleware;
using Application.Contracts.Services;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); // WebAPI
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); // Dokumentation aktiv


//Db ######################
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("ConnectionString nicht vorhanden");
builder.Services.AddDbContext<QotdDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

//DI
builder.Services.AddScoped<IQotdService, QotdService>();

var app = builder.Build(); //########################################################

//### STARTBEISPIEL ##############################################
//app.Use(async (context, next) =>
//{
//    var userAgent = context.Request.Headers["User-Agent"][0].ToLower();
//    await context.Response.WriteAsync($"Erste Middleware {userAgent}\n");
//    await next();
//    await context.Response.WriteAsync("Erste Back Middleware\n");
//});
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Zweite Middleware\n");
//    await next();
//});
//app.Run(async context =>
//{
//    await context.Response.WriteAsync("End Middleware\n");
//});

//#################################################

//app.UseBrowserAllowedMiddleware(Browser.Chrome, Browser.Edge); //Custom Middleware mit Browser Whitelist

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); // Scalar
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
