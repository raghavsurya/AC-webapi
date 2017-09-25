using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdiddaClub.WebApi.Database;
using AdiddaClub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace AdiddaClub.WebApi.Controllers
{
    [Route("api/statistics/")]
    public class StatisticsController : Controller
    {
        private readonly IMongoRepository _repository;

        public StatisticsController(IMongoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public Task<string> Get()
        {
            return GetAllStatistics();
        }

        public async Task<string> GetAllStatistics()
        {
            var notes = await _repository.GetCollection<PlayerStatistics>();
            return JsonConvert.SerializeObject(notes);
        }

        [HttpGet("{id}")]

        public async Task<string> Get(string id)
        {
            var notes = await _repository.GetSingleRecord<PlayerStatistics>(id);
            //notes.
            return JsonConvert.SerializeObject(notes);
        }

    }
}
