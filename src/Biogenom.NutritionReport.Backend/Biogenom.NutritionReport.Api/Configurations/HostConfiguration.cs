namespace Biogenom.NutritionReport.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddSerializers()
            .AddMappers()
            .AddValidators()
            .AddMediatR()
            .AddCaching()
            .AddEventBus()
            .AddPersistence()
            .AddInfrastructure()
            .AddCors()
            .AddDevTools()
            .AddExposers();

        return new(builder);
    }

    public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        await app
            .MigratedataBaseSchemasAsync();

        await app.SeedDataAsync();

        app
            .UseCors();

        app
            .UseDevTools()
            .UseExposers()
            .UseIdentityInfrustructure();

        return app;
    }
}
