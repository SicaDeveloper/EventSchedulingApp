using HorizonCalender.ApiService.Setup.OpenApi.Transformers;

namespace HorizonCalender.ApiService.Setup.OpenApi;

public static class OpenApiExtension
{
    public static void AddXOpenApi(this IServiceCollection services)
    {
        services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer<BearerSecuritySchemeDocumentTransformer>();
            options.AddOperationTransformer<BearerSecuritySchemeOperationTransformer>();
        });
    }
}