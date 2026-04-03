using Daf.Manga.Domain.Adapters;
using Microsoft.Extensions.DependencyInjection;

namespace Daf.Manga.Application;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddMangaApplication(this IServiceCollection services)
    {
        services.AddScoped<IMangaService, MangaService>();
        return services;
    }
}