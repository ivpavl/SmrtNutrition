using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SmrtNutrition.Data;
// using Microsoft.OpenApi;
// using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers().AddJsonOptions(options =>
    {
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    }
 );
builder.Services.AddSingleton<WeatherForecastService>();
//Services for Swagger
builder.Services.AddMvcCore();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TODO: Improve
// TODO: Improve
// TODO: Improve
builder.Services.AddHttpClient("LocalApi", client => client.BaseAddress = new Uri("http://localhost:5233/")); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("v1/swagger.json", "MyAPI V1");
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    // endpoints.MapFallbackToFile("index.html");
});

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
