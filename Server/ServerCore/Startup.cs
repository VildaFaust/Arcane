using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ServerAspNetCoreLinux.Core;
using ServerAspNetCoreLinux.ServerCore.ServerLogger;

namespace ServerAspNetCoreLinux.ServerCore
{
    public class Startup
    {
        public HttpContext HttpContext;
        public ServerContext Context;
        public StartController StartController;

        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddCors(allowsites => { allowsites.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()); });
            // services.AddRouting();
            // services.AddResponseCompression();
        }

        public void Configure(IApplicationBuilder app)
        {
            Context = new ServerContext();
            StartController = new StartController(Context, HttpContext);

            // app.UseDefaultFiles();
            //
            // app.UseRouting();
            //
            // app.UseResponseCompression();

            // app.UseCors(options => options.AllowAnyOrigin());    
            
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/request")
                {
                    ServerLoggerModel.Log(TypeLog.Info, "ПРИНЯТО ЗЕМЛЯНЕ!!!!!!!!!!!!!!!!!!!");
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