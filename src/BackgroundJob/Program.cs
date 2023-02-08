using BackgroundJob.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>( options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),  ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")));
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

