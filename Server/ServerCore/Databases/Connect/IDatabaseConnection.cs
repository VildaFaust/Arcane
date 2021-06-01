using MongoDB.Driver;

namespace Server.ServerCore.Databases.Connect
{
    public interface IDatabaseConnection
    {
        void OpenConnect();
        bool IsConnected { get;}
        IMongoClient Client { get; }
        IMongoDatabase Database { get; }
    }
}