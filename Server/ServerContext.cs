using Server.ServerCore.Databases;
using Server.ServerCore.Databases.Connect;
using Server.ServerCore.Handlers.Base;
using Server.ServerCore.Services.BaseServices;
using Server.ServerCore.Services.Utilities;
using Server.ServerCore.Services.WorldServices;

namespace Server
{
    public class ServerContext
    {
        public HandlersModel HandlersModel;
        
        public IDatabaseConnection DatabaseConnection;
        public DatabaseCollectionData Data;

        public IServices<BaseServices> BaseServices;
        public IServices<WorldServices> WorldServices;
    }
}