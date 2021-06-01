using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Server.ServerCore.ServerLogger;

namespace Server.ServerCore.Handlers.Base
{
    public abstract class ExecuteHandler : IExecuteHandler
    {
        public readonly HttpRequest Request;
        public string NameCommand { get; set; }
        protected HttpResponse Response { get; }

        protected ExecuteHandler(IFormCollection data, HttpResponse response, HttpRequest request)
        {
            Request = request;
            Response = response;
            Response.OnStarting(() =>
            {
#if DEBUG
                Response.Headers.Add("Host", "http://localhost:3000");
#endif
#if DEVELOP
                Response.Headers.Add("Host", "80.78.244.78");
#endif
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
            ServerLoggerModel.Log(TypeLog.Info,
                $"{NameCommand}: {Response.HttpContext.Connection.RemoteIpAddress}:{Response.HttpContext.Connection.RemotePort}\r");
        }

        public abstract void Execute(ServerContext context);
    }
}