using Server.ServerCore.Services.BaseServices;
using Server.ServerCore.Services.WorldServices;
using Server.ServerCore.Utilities;

namespace Server.ServerCore.Services.Utilities
{
    public class ServicesCreateStep : IStep
    {
        public void Execute(ServerContext context, ControllerCollection controllerCollection)
        {
            var baseServices = new Services<BaseServices.BaseServices>();
            var worldServices = new Services<WorldServices.WorldServices>();
            
            new ServiceConfiguration<BaseServices.BaseServices>(new BaseServicesFactory(), baseServices).Configuration();
            new ServiceConfiguration<WorldServices.WorldServices>(new WorldServicesFactory(), worldServices).Configuration();
            
            context.BaseServices = baseServices;
            context.WorldServices = worldServices;
        }

        public void Clear(ServerContext context)
        {
            context.BaseServices.Clear();
            context.WorldServices.Clear();
            
            context.BaseServices = null;
            context.WorldServices = null;
        }
    }
}