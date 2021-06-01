using Server.ServerCore.Users;

namespace Server.ServerCore.Databases
{
    public class DatabaseCollectionData
    {
        public UserCollection UserCollection;
        
        public DatabaseCollectionData(ServerContext context)
        {
            UserCollection = new UserCollection(context);
        }
    }
}