using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Controllers;
using MongoDB.Bson.Serialization.Attributes;

namespace AdiddaClub.WebApi.Models
{

    public class PlayerDetails
    {
        [BsonElement("_id")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Contact Contact { get; set; }
        public string Email { get; set; }
        public HomeAddress HomeAddress { get; set; }
        public bool IsBadmintonMember { get; set; }
        public bool IsCricketMember { get; set; }
        public bool HasPaidBadminton { get; set; }
        public bool HasPaidCricket { get; set; }
    }


    public class Contact
    {
        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }
    }

    public class HomeAddress
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }
}
