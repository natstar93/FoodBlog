using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FoodBlog.Models;

namespace FoodBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        List<BlogPost> Posts = new List<BlogPost>
        {
          new BlogPost {
            Id = 1,
            Title = "First Post",
            Summary = "My first Post",
            Body = "I like food",
            Author = new Author {
              Id = 1,
              Name = "Natstar",
              Description = "Foodie"
            },
            Tags = new string[] {"food"}
          }
        };

        [HttpGet]
        public ActionResult<IEnumerable<BlogPost>> Get()
        {
          return Posts;
        }
    }
}
