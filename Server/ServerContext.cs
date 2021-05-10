using Server.ServerCore.Commands;
using Server.ServerCore.Databases.Connect;

namespace Server
{
    public class ServerContext
    {
        public CommandModel CommandModel;
        public CommandsFactory CommandsFactory;
        
        public IDatabaseConnection DatabaseConnection;
        public DatabaseCollectionData Data;
    }
}