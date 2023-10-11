using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorAppTodo.Data;
using HttpClientStuff.ClientInterfaces;
using HttpClientStuff.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<HttpClient>(new HttpClient
{
    BaseAddress = new Uri("https://localhost:7188/swagger/index.html")
});
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IUserService, UserHttpClient>();
builder.Services.AddScoped<ITodoService, TodoHttpClient>();

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