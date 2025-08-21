using HorizonCalender.ApiService.Services.CurrentUser;

namespace HorizonCalender.ApiService.Setup;

public static class MiscServiceExtensions
{
    public static void AddXMiscServices(this IServiceCollection services)
    {
        services.AddScoped<CurrentUserService>();
    }
}