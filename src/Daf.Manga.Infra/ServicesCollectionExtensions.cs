using Daf.Manga.Domain.Adapters;
using Daf.Manga.Infra.Mongo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Daf.Manga.Infra;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddMangaInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoSettings>(configuration.GetSection("MongoDbSettings"));

        services.AddSingleton<IConnectToMongo, MongoConnector>();
        services.AddScoped<IMangaRepository, MangaRepository>();
        return services;
    }
}