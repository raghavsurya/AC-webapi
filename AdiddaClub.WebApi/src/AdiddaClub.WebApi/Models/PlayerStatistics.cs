using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdiddaClub.WebApi.Models
{
    public class PlayerStatistics
    {

        [BsonElement("_id")]
        public int Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("matchNum")]
        public int MatchNum { get; set; }

        [BsonElement("isOut")]
        public bool IsOut { get; set; }

        public string HowOut { get; set; }

        [BsonElement("fours")]
        public int Fours { get; set; }

        [BsonElement("sixes")]
        public int Sixes { get; set; }

      //  public int NumberOfMatchesPlayed { get; set; }

        [BsonElement("score")]
        public int Score { get; set; }
        //public int NumberOfNotOuts { get; set; }
        //public int Average { get; set; }


        //public ICollection<MatchStatistics> MatchStatistics { get; set; }

        public PlayerStatistics()
        {
          //  MatchStatistics = new List<MatchStatistics>();
        }
    }
}
