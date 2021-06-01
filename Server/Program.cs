using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configServer = new ConfigurationBuilder().AddCommandLine(args).Build();
            
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Server started");
            CreateHostBuilder(configServer).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(IConfigurationRoot args) => new WebHostBuilder()
            .UseConfiguration(args)
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseKestrel()
            .UseIISIntegration()
            .UseStartup<Startup>()
            .UseContentRoot(Environment.CurrentDirectory);
    }
}
