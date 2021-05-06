using ServerAspNetCoreLinux;
using ServerAspNetCoreLinux.ServerCore;
using ServerAspNetCoreLinux.ServerCore.Databases;
using ServerAspNetCoreLinux.ServerCore.Utilities;

namespace Server.ServerCore.Databases
{
    public class DatabaseConnectionStep : IStep
    {
        public void Execute(ServerContext context, ControllerCollection controllerCollection)
        {
            var data = JsonLoader.Load(@"ServerCore/ServerConfig.json");
            var dbConfig = data.GetNode("database");

            IDatabaseConnection databaseConnection;
            switch (dbConfig.GetString("type"))
            {
                case "SQL":
                    databaseConnection = new SqlDataBaseConnection(dbConfig.GetNode("settings"));
                    break;
            }
        }
    }
}