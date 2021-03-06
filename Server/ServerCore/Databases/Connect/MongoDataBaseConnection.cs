using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Server.ServerCore.ServerLogger;
using Utilities;

namespace Server.ServerCore.Databases.Connect
{
    public class MongoDataBaseConnection : IDatabaseConnection
    {
        private readonly IDictionary<string, object> _settings;
        public bool IsConnected { get; set; }
        public IMongoClient Client { get; set; }
        public IMongoDatabase Database { get; set; }

        public MongoDataBaseConnection(IDictionary<string, object> settings)
        {
            _settings = settings;
        }

        public void OpenConnect()
        {
            var connectionString = _settings.GetString("mongodb");

            try
            {
                Client = new MongoClient(connectionString);
                IsConnected = true;
            }
            catch (Exception e)
            {
                ServerLoggerModel.Log(TypeLog.Error, $"database connection error: {e.Message}");
            }
        }
    }
}