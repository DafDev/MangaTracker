using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Daf.Manga.Infra.Mongo;

internal class MongoConnector(IOptions<MongoSettings> settings) : IConnectToMongo
{
    private readonly MongoClient _client = new(settings.Value.ConnectionString);
  
    public IMongoClient Client => _client;
  
    public IEnumerable<MongoDB.Bson.BsonDocument> GetDatabases(CancellationToken cancellationToken)
        => _client.ListDatabases(cancellationToken).ToList();

    public IMongoDatabase GetDatabase(string databaseName) => _client.GetDatabase(databaseName);
}