using System.Collections.Generic;
using Server.ServerCore.Services.BaseServices.Services;
using Server.ServerCore.Services.Utilities;

namespace Server.ServerCore.Services.BaseServices
{
    public class BaseServicesFactory : IServiceFactory<BaseServices>
    {
        private readonly Dictionary<BaseServices, IService> _services = new Dictionary<BaseServices, IService>()
        {
            {BaseServices.RegistrationService, new RegistrationService()},
            {BaseServices.AuthorizeService, new AuthorizationService()},
            {BaseServices.UpdatePermission, new UpdatePermissionService()}
        };
         
         public IService Create(BaseServices type)
         {
             return _services[type];
         }
     }
 }