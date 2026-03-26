namespace daf.manga.domain.Adapters;
using System.Collections.Generic;
public interface IMangaService
{
    Task<IEnumerable<Manga>> GetAllManga();
    Task<Manga> GetMangaByTitle(string title);
    Task AddManga(Manga manga);
    Task UpdateManga(Manga manga);
    Task DeleteManga(string title);
}