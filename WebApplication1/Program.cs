using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1
{
    public class Program
    {
        public static void CreateIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    context.Database.EnsureCreated();
                    // Look for any movies.
                    if (context.Books.Any())
                    {
                        return;   // DB has been seeded
                    }
                    context.Books.AddRange(
                        new Books
                        {
                            Title = "When Harry Met Sally",
                            Rating = 90,
                            Description = "Harry and Sally have known each other for years, and are very good friends, but they fear sex would ruin the friendship.",
                            //Image = 
                });
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
        }
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateIfNotExists(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
