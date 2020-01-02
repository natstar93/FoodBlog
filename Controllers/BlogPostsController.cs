using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FoodBlog.Models;
using FoodBlog.Services;

namespace FoodBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogPostsController : ControllerBase
    {
        public BlogContext _context;

        public BlogPostsController(BlogContext context)
        {
          _context = context; 
        }
        List<BlogPost> BlogPosts = new List<BlogPost>
        {
          new BlogPost {
            BlogPostId = 1,
            Title = "First Post",
            Summary = "My first Post",
            Body = "I like food",
            Author = new Author {
              AuthorId = 1,
              Name = "Natstar",
              Description = "Foodie"
            },
            Tags = new string[] {"food"}
          }
        };

        [HttpGet]
        public ActionResult<IEnumerable<BlogPost>> Get()
        {
          return BlogPosts;
        }
    }
}
