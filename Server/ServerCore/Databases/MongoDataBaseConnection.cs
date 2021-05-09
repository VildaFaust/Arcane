using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MongoDB.Driver;
using ServerAspNetCoreLinux.ServerCore.Databases;
using ServerAspNetCoreLinux.ServerCore.ServerLogger;
using ServerAspNetCoreLinux.ServerCore.Utilities;

namespace ServerAspNetCoreLinux.ServerCore
{
    public class MongoDataBaseConnection : IDatabaseConnection
    {
        private readonly IDictionary<string, object> _settings;
        public bool IsConnected { get; set; }
        public IMongoClient client;
        public MongoDataBaseConnection(IDictionary<string, object> settings)
        {
            _settings = settings;
        }

        public void OpenConnect()
        {
            var connectionString = _settings.GetString("mongodb");

            try
            {
                client = new MongoClient(connectionString);
                var database = client.GetDatabase("test");
                
                IsConnected = true;
            }
            catch (Exception e)
            {
                ServerLoggerModel.Log(TypeLog.Error, $"database connection error: {e.Message}");
            }
        }
        
        public void CloseConnect()
        {
        }
    }
}