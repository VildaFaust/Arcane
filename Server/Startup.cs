using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Server.ServerCore.Handlers;
using Server.ServerCore.Handlers.Base;

namespace Server
{
    public class Startup
    {
        private ServerContext _context;
        private StartController _startController;
        private readonly HandlersFactory _handlersFactory = new HandlersFactory();
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(allowsites => { allowsites.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()); });
            services.AddRouting();
            services.AddResponseCompression();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _context = new ServerContext();
            _startController = new StartController(_context);
            _startController.Activate();

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
                        _context.HandlersModel.AddCommand(
                            _handlersFactory.HandlerFactory[context.Request.Form["Command"]](context.Request.Form,
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
