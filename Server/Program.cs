using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using DefaultNamespace;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ServerAspNetCoreLinux.ServerCore;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var configServer = new ConfigurationBuilder().Build();
            
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Server started");
            CreateHostBuilder(configServer).Build().Start();
        }
        
        public static IWebHostBuilder CreateHostBuilder(IConfigurationRoot args) => new WebHostBuilder()
            .UseConfiguration(args)
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>().UseContentRoot(Environment.CurrentDirectory);
    }
}
