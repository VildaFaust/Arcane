using Server.ServerCore.Databases.Connect;
using Server.ServerCore.Handlers.Base;
using Server.ServerCore.Services;
using Server.ServerCore.Services.BaseServices;

namespace Server
{
    public class ServerContext
    {
        public HandlersModel HandlersModel;
        
        public IDatabaseConnection DatabaseConnection;
        public DatabaseCollectionData Data;

        public IServices<BaseServices> BaseServices;
    }
}