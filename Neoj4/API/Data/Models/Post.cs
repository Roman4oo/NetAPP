using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoj4.API.Data.Models
{
    [BsonIgnoreExtraElements]
    public class Post
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public DateTime PublishDate { get; set; }

        public List<Comment> Comments { get; set; }

        public int Views { get; set; }
    }
}
