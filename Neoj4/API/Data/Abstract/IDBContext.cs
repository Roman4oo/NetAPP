using MongoDB.Driver;
using Neoj4.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoj4.API.Data.Abstract
{
    public interface IDBContext
    {
        IMongoCollection<User> Users { get; }
        IMongoCollection<Post> Posts { get; }
    }
}
