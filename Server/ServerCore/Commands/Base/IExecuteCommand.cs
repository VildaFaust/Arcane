using ServerAspNetCoreLinux.Commands.Base;

namespace ServerAspNetCoreLinux.ServerCore.Commands.Base
{
    public interface IExecuteCommand : ICommand
    {
        void Execute(ServerContext context);
    }
}