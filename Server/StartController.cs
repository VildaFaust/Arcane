using Microsoft.AspNetCore.Http;
using ServerAspNetCoreLinux.Commands;
using ServerAspNetCoreLinux.ServerCore;
using ServerAspNetCoreLinux.ServerCore.Commands;
using ServerAspNetCoreLinux.ServerCore.ServerLogger;
using ServerAspNetCoreLinux.ServerCore.Utilities;

namespace ServerAspNetCoreLinux.Core
{
    public class StartController
    {
        private readonly ServerContext _context;
        private ControllerCollection _controllerCollection = new ControllerCollection();
        private HttpContext _httpContext;

        public StartController(ServerContext context, HttpContext httpContext)
        {
            _context = context;
            _httpContext = httpContext;

            _context.SqlDataBaseConnection = new SqlDataBaseConnection();
            // _context.DataBaseConnection.Connect();
            // if (!context.DataBaseConnection.IsConnection)
            // {
            //     ServerLoggerModel.Log(TypeLog.Fatal, "The server did not start correctly due to problems with the connection to the database");
            // }
            // else
            // {
            //     CreateModels();
            //     CreateControllers();
            //     _controllerCollection.Activate();
            //     ServerLoggerModel.Log(TypeLog.Info, "server started");
            // }
        }

        private void CreateModels()
        {
            _context.CommandModel = new CommandModel();
            _context.CommandsFactory = new CommandsFactory(_context);
        }

        private void CreateControllers()
        {
            _controllerCollection.Add(new CommandController(_context, _context.CommandModel));
        }
    }
}