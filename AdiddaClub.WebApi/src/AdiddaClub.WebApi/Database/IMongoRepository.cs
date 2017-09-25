using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace AdiddaClub.WebApi.Database
{
    public interface IMongoRepository
    {
       // Task<GetOneResult<T>> GetOne<T>(string id) where T : class, new();
        Task<IEnumerable<T>> GetCollection<T>() where T : class;
        Task<T> GetSingleRecord<T>(string id) where T : class;
        Task AddRecord<T>(T item) where T : class;
        Task<DeleteResult> RemoveRecord<T>(string id) where T : class;
        Task<ReplaceOneResult> UpdateRecord<T>(string id, T item) where T : class;
    }
}
