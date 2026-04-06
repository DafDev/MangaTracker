using Daf.Manga.Domain.Adapters;
using Microsoft.Extensions.DependencyInjection;

namespace Daf.Manga.Infra;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddMangaApplication(this IServiceCollection services)
    {
        services.AddScoped<IMangaRepository, MangaRepository>();
        return services;
    }
}