using System.Collections.Generic;

namespace Server.ServerCore.Databases.Connect
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