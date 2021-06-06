using Utilities;

namespace Server.ServerCore.Databases.Connect
{
    public class DatabaseCollectionDataStep : IStep<ServerContext>
    {
        public void Execute(ServerContext context, ControllerCollection controllerCollection)
        {
            context.ModelsCollection = new DatabaseCollectionData(context);
        }

        public void Clear(ServerContext context)
        {
            context.ModelsCollection = null;
        }
    }
}