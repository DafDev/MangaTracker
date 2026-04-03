using Microsoft.Extensions.Logging;
using Daf.Manga.Domain.Adapters;
using LightResults;

namespace Daf.Manga.Application;

public class MangaService(IMangaRepository mangaRepository, ILogger<MangaService> logger) : IMangaService
{
    public async Task<Result> AddManga(Domain.Manga manga, CancellationToken cancellationToken)
    {
        logger.LogInformation("Adding manga: {Title}", manga.Title);
        return await mangaRepository.AddManga(manga, cancellationToken);
    }

    public async Task<Result> DeleteManga(string title, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting manga: {Title}", title);
        return await mangaRepository.DeleteManga(title, cancellationToken);
    }

    public async Task<Result<IEnumerable<Domain.Manga>>> GetAllManga(CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all manga");
        return await mangaRepository.GetAllManga(cancellationToken);
    }

    public async Task<Result<Domain.Manga>> GetMangaByTitle(string title, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting manga by title: {Title}", title);
        return await mangaRepository.GetMangaByTitle(title, cancellationToken);
    }

    public async Task<Result> UpdateManga(Domain.Manga manga, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating manga: {Title}", manga.Title);
        return await mangaRepository.UpdateManga(manga, cancellationToken);
    }
}