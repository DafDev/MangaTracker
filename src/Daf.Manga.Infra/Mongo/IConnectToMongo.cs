using MongoDB.Driver;

namespace Daf.Manga.Infra.Mongo;

public interface IConnectToMongo
{
    IMongoClient Client { get; }
    IEnumerable<MongoDB.Bson.BsonDocument> GetDatabases(CancellationToken cancellationToken);
    IMongoDatabase GetDatabase(string databaseName);
}