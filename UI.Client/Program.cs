using Application.Contracts.Services;
using UI.Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(); //Razor Pages

//Named HttpClient
builder.Services.AddHttpClient("qotdapi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7113");
    client.DefaultRequestHeaders.Add("Accept","application/json");
});

//DI
builder.Services.AddScoped<IQotdService, QotdApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
