using MongoDB.Driver;

namespace Daf.Manga.Infra.Mongo;

internal class MongoConnector : IConnectToMongo
{
    private const string ConnectionString =
        "mongodb+srv://dafdev:jpHtRY3vM6bvNK7O@normal.aycpm.mongodb.net/?retryWrites=true&w=majority&appName=Normal";

    private readonly MongoClient _client = new(ConnectionString);
  
    public IMongoClient Client => _client;
  
    public IEnumerable<MongoDB.Bson.BsonDocument> GetDatabases(CancellationToken cancellationToken)
        => _client.ListDatabases(cancellationToken).ToList();

    public IMongoDatabase GetDatabase(string databaseName) => _client.GetDatabase(databaseName);
}