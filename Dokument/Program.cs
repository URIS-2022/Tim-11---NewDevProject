using Microsoft.AspNetCore.Hosting;
using System;
namespace Korisnik
{
    public class Program
    {
        public Program()
        {
        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
              Host.CreateDefaultBuilder(args)
                  .ConfigureWebHostDefaults(webBuilder =>
                  {
                      //webBuilder.UseStartup<Startup>();
                  });
    }
}
