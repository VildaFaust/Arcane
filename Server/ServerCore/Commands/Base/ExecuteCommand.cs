using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Server.ServerCore.ServerLogger;

namespace Server.ServerCore.Commands.Base
{
    public abstract class ExecuteCommand : IExecuteCommand
    {
        public readonly HttpRequest Request;
        public string NameCommand { get; set; }
        protected Dictionary<string, object> UserParams = new Dictionary<string, object>();
        protected HttpResponse Response { get; }

        protected ExecuteCommand(HttpResponse response, HttpRequest request, string nameCommand)
        {
            NameCommand = nameCommand;
            Request = request;
            Response = response;
            UserParams.Add("error", false);
            UserParams.Add("error_text", string.Empty);
            Response.OnStarting(() =>
            {
                Response.Headers.Add("Host", "25.57.84.220:8000");
                Response.Headers.Add("Access-Control-Allow-Origin", "25.57.84.220:8000");
                Response.Headers.Add("Large-Allocation", "0");
                Response.Headers.Add("Content-Range", "bytes */*");
                Response.Headers.Add("Content-Encoding", "gzip");
                Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                Response.Headers.Add("Access-Control-Allow-Headers",
                    "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With, Accept");
                Response.Headers.Add("Access-Control-Allow-Methods", "GET,POST,PUT,DELETE,OPTIONS");
                Response.Headers.Add("X-Requested-With", "XMLHttpRequest");
                Response.Headers.Add("Accept", "*/*");
                Response.Headers.Add("Retry-After", "4");
                return Task.FromResult(0);
            });

            Response.StatusCode = 200;
            ServerLoggerModel.Log(TypeLog.Info, $"{NameCommand}: {Response.HttpContext.Connection.RemoteIpAddress}:{Response.HttpContext.Connection.RemotePort}\r");
        }

        protected async void Send()
        {
            try
            {
                var sendObject = JsonConvert.SerializeObject(UserParams);
                await Response.WriteAsync(sendObject);
                await Response.CompleteAsync();
            }
            catch (Exception e)
            {
                ServerLoggerModel.Log(TypeLog.Fatal, $"Response interrupted: {e.Message}");
            }
        }

        public abstract void Execute(ServerContext context);
    }
}