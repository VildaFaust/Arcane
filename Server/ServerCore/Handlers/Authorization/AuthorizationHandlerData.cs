using Microsoft.AspNetCore.Http;
using Server.ServerCore.Handlers.Base;

namespace Server.ServerCore.Handlers.Authorization
{
    public class AuthorizationHandlerData : HandlerData
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public AuthorizationHandlerData(HttpResponse response) : base(response)
        {
            
        }
    }
}