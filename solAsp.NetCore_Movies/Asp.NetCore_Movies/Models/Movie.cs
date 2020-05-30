using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Asp.NetCore_Movies.Models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Ime")]
        [Required]
        public string Ime { get; set; }

        [BsonElement("Zanr")]
        [Required]
        public string Zanr { get; set; }



        [BsonElement("Info")]
        [Required]
        public string Info { get; set; }
    }
}
