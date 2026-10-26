using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); // WebAPI
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); // Dokumentation aktiv

var app = builder.Build(); //########################################################

//### STARTBEISPIEL ##############################################
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Erste Middleware\n");
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
