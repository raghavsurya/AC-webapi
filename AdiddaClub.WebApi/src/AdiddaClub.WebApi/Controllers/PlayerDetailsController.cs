using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdiddaClub.WebApi.Database;
using AdiddaClub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdiddaClub.WebApi.Controllers
{
    [Route("api/playerdetails/")]
    public class PlayerDetailsController : Controller
    {
        private readonly IMongoRepository _repository;

        public PlayerDetailsController(IMongoRepository repository)
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
            var notes = await _repository.GetCollection<PlayerDetails>();
            return JsonConvert.SerializeObject(notes);
        }

        [HttpGet("{id}")]

        public async Task<string> Get(string id)
        {
            var notes = await _repository.GetSingleRecord<PlayerDetails>(id);
            //notes.
            return JsonConvert.SerializeObject(notes);
        }
    }
}
