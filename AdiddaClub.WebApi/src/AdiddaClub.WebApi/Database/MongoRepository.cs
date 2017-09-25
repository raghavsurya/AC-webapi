using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdiddaClub.WebApi.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AdiddaClub.WebApi.Database
{
    public class MongoRepository : IMongoRepository
    {

        private readonly MongoDbContext _mongoContext;

        public MongoRepository(IOptions<Settings> settings)
        {
            _mongoContext = new MongoDbContext(settings);
        }
        public async Task AddRecord<T>(T item) where T : class
        {
             await _mongoContext.GetCollection<T>().InsertOneAsync(item);
        }

        public async Task<IEnumerable<T>> GetCollection<T>() where T : class
        {
            return await _mongoContext.GetCollection<T>().Find(_ => true).ToListAsync();
        }

        public async Task<T> GetSingleRecord<T>(string id) where T : class
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            return await _mongoContext.GetCollection<T>().Find(filter).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> RemoveRecord<T>(string id) where T : class
        {
            return await _mongoContext.GetCollection<T>().DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
        }

        public async Task<ReplaceOneResult> UpdateRecord<T>(string id, T item) where T : class
        {
            return await _mongoContext.GetCollection<T>()
                .ReplaceOneAsync(Builders<T>.Filter.Eq("Id", id), item, new UpdateOptions {IsUpsert = true});
        }
    }
}
