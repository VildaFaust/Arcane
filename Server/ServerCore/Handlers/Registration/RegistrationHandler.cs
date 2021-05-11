using Microsoft.AspNetCore.Http;
using Server.ServerCore.Handlers.Base;
using Server.ServerCore.Services.BaseServices;
using Server.ServerCore.Services.BaseServices.Services;

namespace Server.ServerCore.Handlers.Registration
{
    public class RegistrationHandler : ExecuteHandler
    {
        private readonly RegistrationHandlerData _data;
        
        public RegistrationHandler(IFormCollection data, HttpResponse response, HttpRequest request) : base(data, response, request)
        {
            NameCommand = nameof(RegistrationHandler);
            _data = new RegistrationHandlerData()
            {
                Email = data["e"],
                Login = data["l"],
                Name = data["n"],
                Password = data["p"],
                Response = response
            };
        }

        public override void Execute(ServerContext context)
        {
            context.BaseServices.Get<RegistrationService>(BaseServices.RegistrationService).AddRequest(_data, context);
        }
    }
}