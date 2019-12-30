using Microsoft.EntityFrameworkCore;
using FoodBlog.Models;

namespace FoodBlog.Services
{
  public class BlogContext : DbContext {
    public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

    public DbSet<BlogPost> BlogPosts { get; set; }

    public DbSet<Author> Authors { get; set; }
  }
}
