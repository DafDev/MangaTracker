using Daf.Manga.Domain.Adapters;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Daf.Manga.Api.Endpoints;

public static class MangaEndpoints
{
    private const string Base = "api/manga";

    public static void MapMangaEndpoints(this IEndpointRouteBuilder routes)
    {
        var mangaApi = routes.MapGroup(Base).WithTags("Manga");
        mangaApi.MapGet("/", GetAllMangas);
        mangaApi.MapPost("/", AddManga);
        
        mangaApi.MapGet("/{title}", GetMangaByTitle);

    }
    
    private static async Task<Results<Ok<IAsyncEnumerable<Application.Dto.Manga>>, NotFound>> GetAllMangas(IMangaService service, CancellationToken cancellationToken)
    {
        var mangasResult = await service.GetAllManga(cancellationToken);
        return mangasResult.IsSuccess(out var mangas)
            ? TypedResults.Ok(mangas.Select(Application.Dto.Manga.FromDomain)) 
            : TypedResults.NotFound();
    }
    
    private static async Task<Results<Created, NotFound>> AddManga(IMangaService service, Application.Dto.Manga manga, CancellationToken cancellationToken)
    {
        var mangasResult = await service.AddManga(manga.ToDomain(), cancellationToken);
        return mangasResult.IsSuccess()
            ? TypedResults.Created()
            : TypedResults.NotFound();
    }
    
    private static async Task<Results<Ok<Application.Dto.Manga>, NotFound>> GetMangaByTitle(IMangaService service, string title,CancellationToken cancellationToken)
    {
        var mangasResult = await service.GetMangaByTitle(title, cancellationToken);
        return mangasResult.IsSuccess(out var manga)
            ? TypedResults.Ok(Application.Dto.Manga.FromDomain(manga)) 
            : TypedResults.NotFound();
    }
}