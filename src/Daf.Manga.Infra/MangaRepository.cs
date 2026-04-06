using Daf.Manga.Domain.Adapters;
using Daf.Manga.Infra.Mongo;
using LightResults;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Daf.Manga.Infra;

public class MangaRepository : IMangaRepository
{
    private readonly string _databaseName = "MangaTracker";
    private readonly string _collectionName = "Mangas";
    private readonly IMongoCollection<Dto.Manga> _mangas;
    private readonly ILogger<MangaRepository> _logger;

    public MangaRepository(IConnectToMongo mongoConnector, ILogger<MangaRepository> logger)
    {
        var database = mongoConnector.GetDatabase(_databaseName);
        _mangas = database.GetCollection<Dto.Manga>(_collectionName);
        _logger = logger;
    }
    public async Task<Result<IAsyncEnumerable<Domain.Manga>>> GetAllManga(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting all manga");
        var results = await _mangas.FindAsync(_ => true, null, cancellationToken);;
        return results is null || await results.AnyAsync(cancellationToken) == false
            ? Result.Failure<IAsyncEnumerable<Domain.Manga>>("No mangas found")
            : Result.Success(results.ToAsyncEnumerable().Select(manga => manga.ToDomain()));
    }

    public async Task<Result<Domain.Manga>> GetMangaByTitle(string title, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting manga by title: {Title}", title);
        var filter = Builders<Dto.Manga>.Filter.Eq(manga => manga.Title, title);
        var manga = await _mangas.Find(filter).FirstOrDefaultAsync(cancellationToken);
        return manga is not null 
            ? Result.Success(manga.ToDomain()) 
            : Result.Failure<Domain.Manga>("Manga not found");
    }

    public async Task<Result> AddManga(Domain.Manga manga, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Adding manga: {Title}", manga.Title);
        var existingManga = await GetMangaByTitle(manga.Title, cancellationToken);
        if (existingManga.IsSuccess())
            await UpdateManga(manga, cancellationToken);
        else
            await _mangas.InsertOneAsync(Dto.Manga.FromDomain(manga), null,cancellationToken);
        
        return Result.Success();
    }

    public async Task<Result> UpdateManga(Domain.Manga manga, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating manga: {Title}", manga.Title);
        var filter = Builders<Dto.Manga>.Filter.Eq(mangaToUpdate => mangaToUpdate.Title, manga.Title);
        var options = new ReplaceOptions { IsUpsert = true };
        var result = await _mangas.ReplaceOneAsync(filter, Dto.Manga.FromDomain(manga), options, cancellationToken);
        return result.IsAcknowledged 
            ? Result.Success() 
            : Result.Failure("Failed to update manga");
    }

    public Task<Result> DeleteManga(string title, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}