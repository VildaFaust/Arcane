using Microsoft.AspNetCore.Http;
using Server.ServerCore.Handlers.Base;
using Server.ServerCore.Services.BaseServices;
using Server.ServerCore.Services.BaseServices.Services;

namespace Server.ServerCore.Handlers.Authorization
{
    public class AuthorizationHandler : ExecuteHandler
    {
        private readonly AuthorizationHandlerData _data;
        
        public AuthorizationHandler(IFormCollection data, HttpResponse response, HttpRequest request) : base(data, response, request)
        {
            NameCommand = nameof(AuthorizationHandler);
            
            _data = new AuthorizationHandlerData(response)
            {
                Login = data["l"],
                Password = data["p"],
            };
        }

        public override void Execute(ServerContext context)
        {
            context.BaseServices.Get<AuthorizationService>(BaseServices.AuthorizeService).AddRequest(_data, context);
        }
    }
}