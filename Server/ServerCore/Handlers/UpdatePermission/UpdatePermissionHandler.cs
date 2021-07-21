using Microsoft.AspNetCore.Http;
using Server.ServerCore.Handlers.Base;
using Server.ServerCore.Services.BaseServices;
using Server.ServerCore.Services.BaseServices.Services;

namespace Server.ServerCore.Handlers.UpdatePermission
{
    public class UpdatePermissionHandler : ExecuteHandler
    {
        private readonly UpdatePermissionHandlerData _data;

        public UpdatePermissionHandler(IFormCollection data, HttpResponse response, HttpRequest request) : base(data, response, request)
        {
            NameCommand = nameof(UpdatePermissionHandler);

            _data = new UpdatePermissionHandlerData(response)
            {
                UserId = data["user_id"],
                AdminId = data["admin_id"],
                UserType = data["user_type"]
            };
        }
        
        public override void Execute(ServerContext context)
        {
            context.BaseServices.Get<UpdatePermissionService>(BaseServices.UpdatePermission).AddRequest(_data, context);
        }
    }
}