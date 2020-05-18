using Microsoft.AspNetCore.Mvc;
using Neoj4.API.Services.Abstract;
using Neoj4.API.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoj4.API
{
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("api/getallposts")]
        private IActionResult GetAll()
        {
            return Ok(_postService.getAll());
        }

        [HttpPost("api/createpost/{username}")]
        private IActionResult Create([FromBody]PostDTO postDTO, string username)
        {
            return Ok(_postService.Create(postDTO, username));
        }

        [HttpPost("api/addcomment/{username}/{text}")]
        private IActionResult AddComment ([FromBody] PostDTO PostDTO, string username, string text)
        {
            return Ok(_postService.AddComment(PostDTO, username,text));
        }




    }
}
