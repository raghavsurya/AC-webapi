using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace AdiddaClub.WebApi.Models
{
    public class MatchStatistics
    {
        public ObjectId ID { get; set; }
        public int Year { get; set; }
        public string Opponent { get; set; }
        public string Venue { get; set; }
        public int TotalRunsScored { get; set; }
        public string HowOut { get; set; }
        public int Fours { get; set; }
        public int Sixes { get; set; }
        public int NumberOfBallsFaced { get; set; }
        public int StrikeRate => TotalRunsScored / NumberOfBallsFaced;
    }
}


public class LastDayAtBusinessTechnology
{
    private const string LastDayMessage =
        "To celebrate / commiserate my last day at Business Technology after 2 years there" +
        "is a selection Krispy Kreme Doughnuts next to my desk near the Avengers team in Business Technology.";

    private const string KeepInTouchMessage = "I wish you all the very best for the future. " +
                                             "I am on linkedin /facebook /twitter if you wish to stay in touch.";

    public bool HaveIEnjoyedMyStayHere()
    {
        return true;
    }

    
}

