using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            var builder = new SqlConnectionStringBuilder();
        
            builder.DataSource = _settings.GetString("host"); 
            builder.UserID = _settings.GetString("username");            
            builder.Password = _settings.GetString("password");     
            builder.InitialCatalog = _settings.GetString("database");
            
            Connection = new SqlConnection(builder.ConnectionString);
            try
            {
                Connection.Open();
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