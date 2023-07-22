using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CutwrightsCRUD.Interface;
using CutwrightsCRUD.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CutwrightsCRUD.Data
{
    public class BoardsDbContext : IBoardsStore
    {
        public readonly IMongoDatabase Db;

        public BoardsDbContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            Db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<BoardsEntity> BoardCollection => Db.GetCollection<BoardsEntity>("boards");

        public List<BoardsEntity> GetAllBoards()
        {
            return (List<BoardsEntity>)BoardCollection.Find(a => true).ToList();
        }

        public BoardsEntity GetBoardsDetails(string id)
        {
            var boardsdetails = BoardCollection.Find(m => m._id == id).FirstOrDefault();
            return boardsdetails;
        }

        public void Create(BoardsEntity boardsData)
        {
            BoardCollection.InsertOne(boardsData);
        }

        public void Update(string id, BoardsEntity boardsData)
        {
            var filter = Builders<BoardsEntity>.Filter.Eq(c => c._id, id);
            var update = Builders<BoardsEntity>.Update
                .Set("_id", boardsData._id)
                .Set("description", boardsData.description)
                 .Set("length", boardsData.length)
                  .Set("width", boardsData.width)
                   .Set("sellingprice", boardsData.sellingprice)
                    .Set("stocktype", boardsData.stocktype)
                     .Set("code", boardsData.code);
            BoardCollection.UpdateOne(filter, update);
        }

        public void Delete(string id)
        {
            var filter = Builders<BoardsEntity>.Filter.Eq(c => c._id, id);
             BoardCollection.DeleteOne(filter);
        }
    }
}
