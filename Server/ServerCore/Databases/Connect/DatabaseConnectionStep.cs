using Server.ServerCore.ServerLogger;
using Server.ServerCore.Utilities;

namespace Server.ServerCore.Databases.Connect
{
    public class DatabaseConnectionStep : IStep
    {
        public void Execute(ServerContext context, ControllerCollection controllerCollection)
        {
            IDatabaseConnection databaseConnection = null;
            var data = JsonLoader.Load(@"ServerCore/ServerConfig.json");
            var dbConfig = data.GetNode("database");
            
            switch (dbConfig.GetString("type"))
            {
                case "SQL":
                    databaseConnection = new MongoDataBaseConnection(dbConfig.GetNode("settings"));
                    break;
            }

            databaseConnection.OpenConnect();

            if (databaseConnection.IsConnected)
            {
                ServerLoggerModel.Log(TypeLog.Info, "Connected to database");
            }
            else
            {
                ServerLoggerModel.Log(TypeLog.Fatal, "The server did not start correctly due to problems with the connection to the database");
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