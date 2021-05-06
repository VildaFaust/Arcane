using ServerAspNetCoreLinux.ServerCore;
using ServerAspNetCoreLinux.ServerCore.Commands;
using ServerAspNetCoreLinux.ServerCore.Databases;
using ServerAspNetCoreLinux.ServerCore.Utilities;

namespace ServerAspNetCoreLinux
{
    public class ServerContext
    {
        public CommandModel CommandModel;
        public CommandsFactory CommandsFactory;
        public IDatabaseConnection DatabaseConnection;
    }
}