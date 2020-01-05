using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using FoodBlog.Services;

public static class Extensions
{
  public static IHost MigrateDatabase(this IHost webHost)
  {
    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    if (env == "Production")
    {
      var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));

      using (var scope = serviceScopeFactory.CreateScope())
      {
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<BlogContext>();
        dbContext.Database.Migrate();
      }
    }

    return webHost;
  }
}