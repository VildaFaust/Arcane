using Microsoft.AspNetCore.Http;
using Server.ServerCore.Handlers.Base;
using Server.ServerCore.Services.WorldServices;
using Server.ServerCore.Services.WorldServices.Services;

namespace Server.ServerCore.Handlers.World.ExitWorld
{
    public class ExitWorldHandler : ExecuteHandler
    {
        private ExitWorldHandlerData _data;
        
        public ExitWorldHandler(IFormCollection data, HttpResponse response, HttpRequest request) : base(data, response, request)
        {
            NameCommand = nameof(ExitWorldHandler);
            _data = new ExitWorldHandlerData()
            {

            };
        }

        public override void Execute(ServerContext context)
        {
            context.WorldServices.Get<ExitWorldService>(WorldServices.ExitWorldService).AddRequest(_data, context);
        }
    }
}