using Neoj4.API.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoj4.API.Services.Abstract
{
    public interface IPostService
    {
        Task<PostDTO> GetById(string id);
        Task<IEnumerable<PostDTO>> getAll();

        Task Create(PostDTO post, string author);
        Task<PostDTO> AddComment(PostDTO post, string userName, string text);


    }
}
