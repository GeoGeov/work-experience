using WorkExperience.Server.Interfaces;
using WorkExperience.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorComponents();
builder.Services.AddRazorPages();

builder.Services.AddHttpClient<IHarryPotterService, HarryPotterService>(client =>
client.BaseAddress = new Uri("https://hp-api.onrender.com/api/"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.UseBlazorFrameworkFiles();

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
