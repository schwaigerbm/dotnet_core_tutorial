using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = new WebHostBuilder()
            
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>()
            .Build();

            host.Run();


            Console.WriteLine("Hello World!");
        }

        public class Startup{
            public IConfiguration Configuration{get;set;}

            public Startup(IHostingEnvironment env){
                Configuration = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("config.json")
                    .Build();
            }
    
            public void Configure(IApplicationBuilder app, IHostingEnvironment env){
                app.Run(async(context) => await context.Response.WriteAsync("Hello World "+ Configuration["Name"]));

            }

        }
    }
}
