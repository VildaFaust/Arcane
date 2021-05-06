using ServerAspNetCoreLinux.ServerCore;
using ServerAspNetCoreLinux.ServerCore.Commands;
using ServerAspNetCoreLinux.ServerCore.Utilities;

namespace ServerAspNetCoreLinux
{
    public class ServerContext
    {
        public CommandModel CommandModel;
        public CommandsFactory CommandsFactory;
        public DataBaseConnection DataBaseConnection;
    }
}