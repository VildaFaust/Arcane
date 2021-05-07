using ServerAspNetCoreLinux;
using ServerAspNetCoreLinux.ServerCore;
using ServerAspNetCoreLinux.ServerCore.Databases;
using ServerAspNetCoreLinux.ServerCore.ServerLogger;
using ServerAspNetCoreLinux.ServerCore.Utilities;

namespace Server.ServerCore.Databases
{
    public class DatabaseConnectionStep : IStep
    {
        public void Execute(ServerContext context, ControllerCollection controllerCollection)
        {
            var data = JsonLoader.Load(@"ServerCore/ServerConfig.json");
            var dbConfig = data.GetNode("database");
            
            IDatabaseConnection databaseConnection = null;
            switch (dbConfig.GetString("type"))
            {
                case "SQL":
                    databaseConnection = new SqlDataBaseConnection(dbConfig.GetNode("settings"));
                    break;
            }

            databaseConnection.OpenConnect();

            if (!databaseConnection.IsConnected)
            {
                ServerLoggerModel.Log(TypeLog.Fatal, "The server did not start correctly due to problems with the connection to the database");
            }
            else
            {
                ServerLoggerModel.Log(TypeLog.Info, "Connected to database");
            }

            context.DatabaseConnection = databaseConnection;
        }

        public void Clear(ServerContext context)
        {
            context.DatabaseConnection.CloseConnect();
            context.DatabaseConnection = null;
        }
    }
}