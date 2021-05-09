namespace Server.ServerCore.Commands.Base
{
    public interface IExecuteCommand : ICommand
    {
        void Execute(ServerContext context);
    }
}