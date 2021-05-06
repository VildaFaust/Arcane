using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServerAspNetCoreLinux;
using ServerAspNetCoreLinux.Core;

namespace Server
{
    public class Startup
    {
        public HttpContext HttpContext;
        public ServerContext Context;
        public StartController StartController;
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(allowsites => { allowsites.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()); });
            services.AddRouting();
            services.AddResponseCompression();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Context = new ServerContext();
            StartController = new StartController(Context, HttpContext);

            app.UseDefaultFiles();

            app.UseRouting();

            app.UseResponseCompression();

            app.UseCors(options => options.AllowAnyOrigin());

            app.Use(async (context, next) =>
            {
                Console.WriteLine("Client request");
                if (context.Request.Path == "/request")
                {
                    if (!context.Request.HasFormContentType)
                    {
                        context.Response.Redirect("/");
                    }
                    else
                    {
                        Context.CommandModel.AddCommand(
                            Context.CommandsFactory.CommandFactory[context.Request.Form["Command"]](context.Request.Form,
                                context.Response, context.Request));
                    }
                }
                else
                {
                    await next();
                }
            });
        }
    }
}
