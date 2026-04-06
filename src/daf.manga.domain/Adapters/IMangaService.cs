using LightResults;

namespace Daf.Manga.Domain.Adapters;
using System.Collections.Generic;
public interface IMangaService
{
    Task<Result<IAsyncEnumerable<Manga>>>GetAllManga(CancellationToken cancellationToken);
    Task<Result<Manga>> GetMangaByTitle(string title, CancellationToken cancellationToken);
    Task<Result> AddManga(Manga manga, CancellationToken cancellationToken);
    Task<Result> UpdateManga(Manga manga, CancellationToken cancellationToken);
    Task<Result> DeleteManga(string title, CancellationToken cancellationToken);
}