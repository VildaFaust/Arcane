namespace Server.ServerCore.Utilities
{
    public interface IStep
    {
        void Execute(ServerContext context, ControllerCollection controllerCollection);
        void Clear(ServerContext context);
    }
}