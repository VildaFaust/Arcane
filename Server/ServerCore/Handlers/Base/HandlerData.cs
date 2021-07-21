using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Server.ServerCore.Handlers.Base
{
    public class HandlerData
    {
        public readonly Dictionary<string, string> UserParams = new Dictionary<string, string>();
        private readonly HttpResponse _response;

        protected HandlerData(HttpResponse response)
        {
            _response = response;
        }

        public async void Send(string sendObject)
        {
            _response.StatusCode = 200;
            
            await _response.WriteAsync(sendObject);
            await _response.CompleteAsync();
        }
    }
}