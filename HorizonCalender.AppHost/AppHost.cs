using Microsoft.Extensions.Hosting;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache")
    .WithRedisCommander();

var eventingDb = builder.AddPostgres("HorizonCalender")
    .WithDataVolume()
    .WithPgAdmin(configure
        => configure.WithImageTag("latest"))
    .AddDatabase("horizon-db");

var mailPit = builder.AddMailPit("mailpit");

builder.AddProject<HorizonCalender_Data_Migrator>("data-migrator")
    .WithReference(eventingDb)
    .WaitFor(eventingDb)
    .WithExplicitStart();

var apiService = builder.AddProject<HorizonCalender_ApiService>("api-service")
    .WithHttpHealthCheck("/health")
    .WaitFor(eventingDb)
    .WithReference(eventingDb)
    .WaitFor(cache)
    .WithReference(cache)
    .WaitFor(mailPit)
    .WithReference(mailPit);

if (builder.Environment.IsDevelopment())
    // See: https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/custom-resource-urls#customize-endpoint-url
    apiService.WithUrlForEndpoint("https", _ => new ResourceUrlAnnotation
    {
        Url = "/api-reference",
        DisplayText = "Scalar (HTTPS)"
    });

builder.AddProject<HorizonCalender_Web>("web-frontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();