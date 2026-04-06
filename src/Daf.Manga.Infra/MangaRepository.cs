using Daf.Manga.Domain.Adapters;
using LightResults;
using Microsoft.Extensions.Logging;

namespace Daf.Manga.Infra;

public class MangaRepository(ILogger<MangaRepository> logger) : IMangaRepository
{
    public Task<Result<IEnumerable<Domain.Manga>>> GetAllManga(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Domain.Manga>> GetMangaByTitle(string title, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result> AddManga(Domain.Manga manga, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateManga(Domain.Manga manga, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteManga(string title, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}