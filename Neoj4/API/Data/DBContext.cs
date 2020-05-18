using MongoDB.Driver;
using Neoj4.API.Data.Configuration;
using Neoj4.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoj4.API.Data
{
    public class DBContext
    {
        private IMongoCollection<User> _users;
        private IMongoCollection<Post> _posts;
        private readonly IMongoDatabase _database;
        

        public IMongoCollection<User> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = _database.GetCollection<User>("users");
                }
                return _users;
            }

        }
        public IMongoCollection<Post> Posts
        {
            get
            {
                if (_posts == null)
                {
                    _posts = _database.GetCollection<Post>("posts");
                }
                return _posts;
            }
        }
        public DBContext(ClientConfiguration configuration)
        {
            var client = new MongoClient(configuration.ConnectionString);
            _database = client.GetDatabase(configuration.DatabaseName);
        }
    }
}
