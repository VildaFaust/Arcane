using System;
using System.Data.SqlClient;
using ServerAspNetCoreLinux.ServerCore.ServerLogger;
using ServerAspNetCoreLinux.ServerCore.Utilities;

namespace ServerAspNetCoreLinux.ServerCore
{
    public class DataBaseConnection
    {
        // public bool IsConnection;
        // public SqlConnection Connection;
        // public void Connect()
        // {
        //     var data = JsonLoader.Load(@"ServerCore/ServerConfig.json");
        //     var bdConfig = data.GetNode("SQL").GetNode("DB");
        //     SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        //
        //     builder.DataSource = bdConfig.GetString("host"); 
        //     builder.UserID = bdConfig.GetString("username");            
        //     builder.Password = bdConfig.GetString("password");     
        //     builder.InitialCatalog = bdConfig.GetString("database");
        //     
        //     Connection = new SqlConnection(builder.ConnectionString);
        //     try
        //     {
        //         Connection.Open();
        //         ServerLoggerModel.Log(TypeLog.Info, "connection to db open");
        //         IsConnection = true;
        //     }
        //     catch (Exception e)
        //     {
        //         ServerLoggerModel.Log(TypeLog.Error, $"database connection error: {e.Message}");
        //     }
        // }
        //
        // public void OpenConnect()
        // {
        //     Connection.Open();
        // }
        //
        // public void CloseConnect()
        // {
        //     Connection.Close();
        // }
        //
        // public void InsertUser(ServerContext context, IUserUnitModel user)
        // {
        //     var command = new SqlCommand("")
        //     {
        //         Connection = context.DataBaseConnection.Connection
        //     };
        //     
        //     command.CommandText = $"INSERT INTO users (name, user_id, is_authorisation, second_name, email, password, session) VALUES ('{user.Name}', '{user.UserId}', '{user.IsAuthorisation}', '{user.SecondName}', '{user.Email}', '{user.Password}', '{user.Session}')";
        //     command.ExecuteNonQuery();
        // }
        //
        // public void UpdateUser(ServerContext context, IUserUnitModel user)
        // {
        //     var command = new SqlCommand("")
        //     {
        //         Connection = context.DataBaseConnection.Connection
        //     };
        //     command.CommandText = $"UPDATE users SET session = '{user.Session}' WHERE user_id = '{user.UserId}'";
        //     command.ExecuteNonQuery();
        // }
    }
}