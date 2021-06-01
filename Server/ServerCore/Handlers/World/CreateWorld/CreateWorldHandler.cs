using Microsoft.AspNetCore.Http;
using Server.ServerCore.Handlers.Base;
using Server.ServerCore.Services.WorldServices;
using Server.ServerCore.Services.WorldServices.Services;

namespace Server.ServerCore.Handlers.World.CreateWorld
{
    public class CreateWorldHandler : ExecuteHandler
    {
        private CreateWorldHandlerData _data;
        
        public CreateWorldHandler(IFormCollection data, HttpResponse response, HttpRequest request) : base(data, response, request)
        {
            NameCommand = nameof(CreateWorldHandler);
            _data = new CreateWorldHandlerData()
            {
                
            };
        }

        public override void Execute(ServerContext context)
        {
            context.WorldServices.Get<CreateWorldService>(WorldServices.CreateWorldService).AddRequest(_data, context);
        }
    }
}