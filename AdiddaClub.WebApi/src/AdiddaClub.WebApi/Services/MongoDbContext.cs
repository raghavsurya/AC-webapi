using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdiddaClub.WebApi.Database;
using AdiddaClub.WebApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AdiddaClub.WebApi.Services
{
    public class MongoDbContext
    {
        public static IMongoDatabase Database { get; set; }
        

        public MongoDbContext(IOptions<Settings> settings )
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            Database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return Database.GetCollection<T>(typeof(T).Name);
        }
       
    }
}
