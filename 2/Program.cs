using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Http;

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
    
            public void Configure(IApplicationBuilder app, IHostingEnvironment env){
                app.Run(async(context) => await context.Response.WriteAsync("Hello World ASP.NET"));

            }

        }
    }
}
