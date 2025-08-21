using HorizonCalender.Data;

namespace HorizonCalender.ApiService.Setup.DbContext;

public static class DbContextExtension
{
    public static void AddXDbContext(this IHostApplicationBuilder builder)
    {
        builder.Services.AddOpenTelemetry()
            .WithMetrics(x => x.AddMeter("Microsoft.EntityFrameworkCore"));

        builder.AddNpgsqlDbContext<HorizonCalenderDbContext>(
            connectionName: "eventing-db",
            configureSettings: settings => { settings.ConnectionString += ";Include Error Detail=true"; },
            configureDbContextOptions: options =>
            {
                if (builder.Environment.IsDevelopment())
                    options.EnableDetailedErrors()
                        .EnableSensitiveDataLogging();
            });
    }
}