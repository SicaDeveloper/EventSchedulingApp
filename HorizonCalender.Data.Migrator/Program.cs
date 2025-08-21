using HorizonCalender.Data;
using HorizonCalender.Data.Migrator;
using HorizonCalender.ServiceDefaults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.ConfigureOpenTelemetry();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName))
    .WithMetrics(x => x.AddMeter("Microsoft.EntityFrameworkCore"));

builder.Services.AddHostedService<Worker>();

builder.Services.AddIdentityCore<IdentityUser<Guid>>()
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<HorizonCalenderDbContext>();

builder.AddNpgsqlDbContext<HorizonCalenderDbContext>("eventing-db",
    configureSettings: settings => { settings.ConnectionString += ";Include Error Detail=true"; });

var host = builder.Build();
host.Run();