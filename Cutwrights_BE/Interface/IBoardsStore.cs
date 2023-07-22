using System.Collections;
using System.Collections.Generic;
using CutwrightsCRUD.Models;
using MongoDB.Driver;

namespace CutwrightsCRUD.Interface
{
    public  interface IBoardsStore
    {
        IMongoCollection<BoardsEntity> BoardCollection { get;}
        List<BoardsEntity> GetAllBoards();

        BoardsEntity GetBoardsDetails(string _id);
        void Create(BoardsEntity boardsData);
        void Update(string _id, BoardsEntity boardsData);
        void Delete(string _id);
    }
}
