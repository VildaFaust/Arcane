using Microsoft.AspNetCore.Http;
using Server.ServerCore.Handlers.Base;

namespace Server.ServerCore.Handlers.UpdatePermission
{
    public class UpdatePermissionHandlerData : HandlerData
    {
        public string UserId { get; set; }
        public string UserType { get; set; }
        public string AdminId { get; set; }

        public UpdatePermissionHandlerData(HttpResponse response) : base(response)
        {
            
        }
    }
}