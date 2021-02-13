using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


private readonly MongoClient _client;
private Dictionary<string, List<string>> _databasesAndCollections;

public DocumentService(MyDatabaseSettings settings)
{
    _client = new MongoClient(settings.ConnectionString);
}

public async Task<Dictionary<string, List<string>>> GetDatabasesAndCollections()
{
    if (_databasesAndCollections != null) return _databasesAndCollections;

    _databasesAndCollections = new Dictionary<string, List<string>>();
    var databasesResult = _client.ListDatabaseNames();

    await databasesResult.ForEachAsync(async databaseName =>
    {
        var collectionNames = new List<string>();
        var database = _client.GetDatabase(databaseName);
        var collectionNamesResult = database.ListCollectionNames();
        await collectionNamesResult.ForEachAsync(
            collectionName => { collectionNames.Add(collectionName); });
        _databasesAndCollections.Add(databaseName, collectionNames);
    });

    return _databasesAndCollections;
}
public async Task<BsonDocument> GetDocument(string databaseName, string collectionName, int index)
{
    var collection = GetCollection(databaseName, collectionName);
    BsonDocument document = null;
    await collection.Find(doc => true)
      .Skip(index)
      .Limit(1)
      .ForEachAsync(doc => document = doc);
    return document;
}

public async Task<long> GetCollectionCount(string databaseName, string collectionName)
{
    var collection = GetCollection(databaseName, collectionName);
    return await collection.EstimatedDocumentCountAsync();
}

private IMongoCollection<BsonDocument> GetCollection(string databaseName, string collectionName)
{
    var db = _client.GetDatabase(databaseName);
    return db.GetCollection<BsonDocument>(collectionName);
}

public async Task<UpdateResult> CreateOrUpdateField(string databaseName, string collectionName, string id, string fieldName, string value)
{
    var collection = GetCollection(databaseName, collectionName);
    var update = Builders<BsonDocument>.Update.Set(fieldName, new BsonString(value));
    return await collection.UpdateOneAsync(CreateIdFilter(id), update);
}

public async Task<DeleteResult> DeleteDocument(string databaseName, string collectionName, string id)
{
    var collection = GetCollection(databaseName, collectionName);
    return await collection.DeleteOneAsync(CreateIdFilter(id));
}

private static BsonDocument CreateIdFilter(string id)
{
    return new BsonDocument("_id", new BsonObjectId(new ObjectId(id)));
}

public async Task CreateDocument(string databaseName, string collectionName)
{
    var collection = GetCollection(databaseName, collectionName);
    await collection.InsertOneAsync(new BsonDocument());
}