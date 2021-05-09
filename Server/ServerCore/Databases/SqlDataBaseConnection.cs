using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MongoDB.Driver;
using ServerAspNetCoreLinux.ServerCore.Databases;
using ServerAspNetCoreLinux.ServerCore.ServerLogger;
using ServerAspNetCoreLinux.ServerCore.Utilities;

namespace ServerAspNetCoreLinux.ServerCore
{
    public class SqlDataBaseConnection : IDatabaseConnection
    {
        private readonly IDictionary<string, object> _settings;
        public bool IsConnected { get; set; }
        public SqlConnection Connection;

        public SqlDataBaseConnection(IDictionary<string, object> settings)
        {
            _settings = settings;
        }

        public void OpenConnect()
        {
            var connectionString = _settings.GetString("mongodb");

            try
            {
                var client = new MongoClient(connectionString);
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
            Connection.Close();
        }
    }
}