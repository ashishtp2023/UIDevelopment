using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CutwrightsCRUD.Models
{
    [BsonIgnoreExtraElements]
    public class UsersEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string emailaddress { get; set; }
        public string password { get; set; }
        public string phonenumber { get; set; }
        public bool status { get; set; }
        public string displayName { get; set; }
        public string role { get; set; }
    }
}
