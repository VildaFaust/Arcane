using Server.ServerCore.Databases;
using Server.ServerCore.Databases.Connect;
using Server.ServerCore.Handlers.Base;
using Server.ServerCore.Services.BaseServices;
using Server.ServerCore.Services.Utilities;
using Server.ServerCore.Services.WorldServices;
using Utilities;

namespace Server
{
    public class ServerContext : IContext
    {
        public HandlersModel HandlersModel;
        
        public IDatabaseConnection DatabaseConnection;
        public DatabaseCollectionData Data;

        public IServices<BaseServices> BaseServices;
        public IServices<WorldServices> WorldServices;
    }
}