using System.Net;
using BackgroundJob;
using BackgroundJob.Data;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Registration of services
builder.Services.RegisterService(builder.Environment, builder.Configuration);

var app = builder.Build();

app.UseHangfireDashboard();

app.MapGet("/", () => "Hello World!");

RecurringJob.AddOrUpdate(() => Console.WriteLine("Hello bro"), Cron.Minutely);

app.Run();
//HttpStatusCode.Created;