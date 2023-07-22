using System.Collections;
using System.Collections.Generic;
using CutwrightsCRUD.Models;
using MongoDB.Driver;

namespace CutwrightsCRUD.Interface
{
    public interface IUsers
    {
        UsersEntity GetUserDetails(string Email, string password);
    }
}
