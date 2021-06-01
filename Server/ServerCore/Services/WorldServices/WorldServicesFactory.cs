using System.Collections.Generic;
using Server.ServerCore.Services.Utilities;
using Server.ServerCore.Services.WorldServices.Services;

namespace Server.ServerCore.Services.WorldServices
{
    public class WorldServicesFactory : IServiceFactory<WorldServices>
    {
        private readonly Dictionary<WorldServices, IService> _services = new Dictionary<WorldServices, IService>()
        {
            {WorldServices.CreateWorldService, new CreateWorldService()},
            {WorldServices.JoinWorldService, new JoinWorldService()},
            {WorldServices.ExitWorldService, new ExitWorldService()},
        };

        public IService Create(WorldServices type)
        {
            return _services[type];
        }
    }
}