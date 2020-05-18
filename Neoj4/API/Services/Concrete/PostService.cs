using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Neoj4.API.Data;
using Neoj4.API.Data.Abstract;
using Neoj4.API.Data.Models;
using Neoj4.API.Services.Abstract;
using Neoj4.API.Services.DTO_s;
using Neoj4.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoj4.API.Services.Concrete
{
    public class PostService
    {
        private readonly IDBContext _context;
        private readonly IUserService _userService;
        private readonly IMongoQueryable<Post> _posts;
        private readonly IMapper _mapper;

        public PostService(IDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            _posts = _context.Posts.AsQueryable().OrderByDescending(p => p.PublishDate);
        }


        public async Task<PostDTO> GetById(string id)
        {
            var post = await _posts.SingleOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<PostDTO>(post);
        }

        public async Task<IEnumerable<PostDTO>> getAll()
        {
            return _mapper.Map<IEnumerable<PostDTO>>(_posts);
        }

        public Task Create(PostDTO post, string author)
        {
            if (string.IsNullOrWhiteSpace(post.Text))
            {
                return Task.FromResult(1);
            }

            var entity = _mapper.Map<Post>(post);
            entity.PublishDate = DateTime.Now;
            entity.Author = author;
            entity.Comments = new List<Comment>();

            return _context.Posts.InsertOneAsync(entity);
        }
        public async Task<PostDTO> AddComment(PostDTO post, string userName, string text)
        {
            var comment = new Comment { Author = userName, Text = text };

            var setter = Builders<Post>.Update.Push(el => el.Comments, comment);
            await _context.Posts.UpdateOneAsync(el => el.Id == post.Id, setter);

            return _mapper.Map(_posts.SingleOrDefaultAsync(p => p.Id == post.Id), post);

        }
    }   
}
