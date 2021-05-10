using System.Collections.Generic;
using Server.ServerCore.User;

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