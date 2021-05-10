namespace Server.ServerCore.Handlers.Base
{
    public interface IExecuteHandler : IHandler
    {
        void Execute(ServerContext context);
    }
}