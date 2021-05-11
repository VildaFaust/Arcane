using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Server.ServerCore.Handlers.Base
{
    public class HandlerData
    {
        public Dictionary<string, string> UserParams = new Dictionary<string, string>();
        public HttpResponse Response;

        public async void Send(string sendObject)
        {
            Response.StatusCode = 200;
            
            await Response.WriteAsync(sendObject);
            await Response.CompleteAsync();
        }
    }
}