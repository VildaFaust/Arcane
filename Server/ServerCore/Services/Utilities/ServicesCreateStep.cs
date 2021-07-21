using Server.ServerCore.Services.BaseServices;
using Utilities;

namespace Server.ServerCore.Services.Utilities
{
    public class ServicesCreateStep : IStep<ServerContext>
    {
        public void Execute(ServerContext context, ControllerCollection controllerCollection)
        {
            var baseServices = new Services<BaseServices.BaseServices>();
            
            new ServiceConfiguration<BaseServices.BaseServices>(new BaseServicesFactory(), baseServices).Configuration();
            
            context.BaseServices = baseServices;
        }
    
        public void Clear(ServerContext context)
        {
            context.BaseServices.Clear();
            context.BaseServices = null;
        }
    }
}