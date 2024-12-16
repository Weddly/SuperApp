using Hangfire;
using Hangfire.MySql;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SuperApp.Infra.Data.Context;
using SuperApp.Infra.Data.Interfaces;
using SuperApp.Infra.Data.Repository;
using SuperApp.Infra.Data.Services;
using SuperApp.Jobs.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SuperAppContext>(options => { options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)); });
builder.Services.AddScoped<IUpsertService, UpsertService>();
builder.Services.AddScoped<IPrizeRepository, PrizeRepository>();
builder.Services.AddHttpClient<ISuperHeroService, SuperHeroService>();

var mysqlConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseStorage(
        new MySqlStorage(
            mysqlConnectionString,
            new MySqlStorageOptions
            {
                QueuePollInterval = TimeSpan.FromSeconds(15),
                CountersAggregateInterval = TimeSpan.FromMinutes(15),
                PrepareSchemaIfNecessary = true,
                DashboardJobListLimit = 50000,
                TransactionTimeout = TimeSpan.FromMinutes(10),
            })));

builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHangfireDashboard();


// Schedule the Hangfire job
using (var scope = app.Services.CreateScope())
{
    var upsertService = scope.ServiceProvider.GetRequiredService<IUpsertService>();
    RecurringJob.AddOrUpdate("UpsertDataJob", () => upsertService.UpsertDataAsync(), Cron.Hourly());
}

app.Run();