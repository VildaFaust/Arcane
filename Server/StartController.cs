using Microsoft.AspNetCore.Http;
using Server.ServerCore.Databases;
using ServerAspNetCoreLinux.Commands;
using ServerAspNetCoreLinux.ServerCore;
using ServerAspNetCoreLinux.ServerCore.Commands;
using ServerAspNetCoreLinux.ServerCore.ServerLogger;
using ServerAspNetCoreLinux.ServerCore.Utilities;

namespace ServerAspNetCoreLinux.Core
{
    public class StartController : IController
    {
        private readonly ServerContext _context;
        private ControllerCollection _controllerCollection = new ControllerCollection();
        private StepCollection _stepCollection = new StepCollection();
        private HttpContext _httpContext;

        public StartController(ServerContext context, HttpContext httpContext)
        {
            _context = context;
            _httpContext = httpContext;
            _stepCollection.Add(new DatabaseConnectionStep());
        }

        public void Activate()
        {
            _stepCollection.Execute(_context, _controllerCollection);
        }

        public void Deactivate()
        {
            _stepCollection.Clear(_context);
        }
    }
}