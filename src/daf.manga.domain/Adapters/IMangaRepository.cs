namespace Daf.Manga.Domain.Adapters;
using System.Collections.Generic;
public interface IMangaRepository
{
    Task<IEnumerable<Manga>> GetAllManga(CancellationToken cancellationToken);
    Task<Manga> GetMangaByTitle(string title, CancellationToken cancellationToken);
    Task AddManga(Manga manga, CancellationToken cancellationToken);
    Task UpdateManga(Manga manga, CancellationToken cancellationToken);
    Task DeleteManga(string title, CancellationToken cancellationToken);
}