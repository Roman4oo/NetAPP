using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoj4.API.Services.DTO_s
{
    public class PostDTO
    {

        public string Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }

        public List<CommentDTO> Comments { get; set; }

        public int Views { get; set; }
    }
}
