using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using FoodBlog.Models;
using FoodBlog.Services;

namespace FoodBlog.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SetupController : ControllerBase
  {
    readonly BlogContext _context;

    static Author Natstar = new Author
    {
      AuthorId = 1,
      Name = "Natstar",
      Description = "Foodie"
    };

    static BlogPost InitialPost = new BlogPost
    {
      BlogPostId = 1,
      Title = "First Post",
      Summary = "My first Post",
      Body = "I like food",
      Author = Natstar,
      Tags = new string[] { "food" }
    };

    public SetupController(BlogContext context)
    {
      _context = context;
    }

    [HttpGet]
    public ActionResult<string> Get()
    {
      if(!_context.Authors.Any())
      {
        _context.Authors.Add(Natstar);
        _context.BlogPosts.Add(InitialPost);
        _context.SaveChanges();
      }

      if(_context.Authors.Any())
      {
        return $"There is an author: {_context.Authors.First().Name}";
      }
      return "No authors";
    }
  }
}