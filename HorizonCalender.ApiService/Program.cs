using HorizonCalender.ApiService.Setup;
using HorizonCalender.ApiService.Setup.Auth;
using HorizonCalender.ApiService.Setup.DbContext;
using HorizonCalender.ApiService.Setup.Emailing;
using HorizonCalender.ApiService.Setup.Identity;
using HorizonCalender.ApiService.Setup.JsonOptions;
using HorizonCalender.ApiService.Setup.Jwt;
using HorizonCalender.ApiService.Setup.OpenApi;
using HorizonCalender.ApiService.Setup.Scalar;
using HorizonCalender.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddXOpenApi();

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

builder.Services.AddXJsonOptions();

builder.AddRedisDistributedCache("cache");

builder.AddXDbContext();

builder.Services.AddXIdentityCore();

builder.Services.AddXJwt();

builder.Services.AddXAuthentication();

builder.Services.AddXAuthorization();

if (builder.Environment.IsDevelopment())
    builder.AddXTestEmailing();
else
    builder.AddXEmailing();

builder.Services.AddXMiscServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
    app.UseXScalar();
}

//app.MapIdentityApi<>()

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapDefaultEndpoints();

app.Run();