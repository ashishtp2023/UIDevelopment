using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CutwrightsCRUD.Models
{
    [BsonIgnoreExtraElements]
    public class BoardsEntity
    {
        
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public int  length { get; set; }
        public int width { get; set; }
        public double  sellingprice { get; set; }
        public string stocktype { get; set; }
        public string code { get; set; }

        public string description { get; set; }
    }
}
