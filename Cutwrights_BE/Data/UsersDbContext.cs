using CutwrightsCRUD.Interface;
using CutwrightsCRUD.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CutwrightsCRUD.Data
{
    public class UsersDbContext : IUsers
    {
        public readonly IMongoDatabase Db;

        public UsersDbContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            Db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<UsersEntity> UsersCollection => Db.GetCollection<UsersEntity>("users");

        public UsersEntity GetUserDetails(string Email, string password)
        {
            var userdetails = UsersCollection.Find(m => m.emailaddress == Email && m.password == password).FirstOrDefault();
            return userdetails;
        }

    }
}
