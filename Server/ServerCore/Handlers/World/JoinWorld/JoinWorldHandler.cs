using Microsoft.AspNetCore.Http;
using Server.ServerCore.Handlers.Base;
using Server.ServerCore.Services.WorldServices;
using Server.ServerCore.Services.WorldServices.Services;

namespace Server.ServerCore.Handlers.World.JoinWorld
{
    public class JoinWorldHandler : ExecuteHandler
    {
        private JoinWorldHandlerData _data;
        
        public JoinWorldHandler(IFormCollection data, HttpResponse response, HttpRequest request) : base(data, response, request)
        {
            NameCommand = nameof(JoinWorldHandler);
            _data = new JoinWorldHandlerData()
            {

            };
        }

        public override void Execute(ServerContext context)
        {
            context.WorldServices.Get<JoinWorldService>(WorldServices.JoinWorldService).AddRequest(_data, context);
        }
    }
}