using MongoDB.Bson.Serialization.Attributes;

namespace Neoj4.API.Data.Models
{
    [BsonIgnoreExtraElements]
    public class Comment
    {
        public string Author { get; set; }

        public string Text { get; set; }

    }
}
