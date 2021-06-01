using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Server.ServerCore.Handlers.Registration;
using Server.ServerCore.ServerLogger;
using Server.ServerCore.Services.Utilities;
using Server.ServerCore.Users;

namespace Server.ServerCore.Services.BaseServices.Services
{
    public class RegistrationService : IService
    {
        public void Dispose()
        {
        }

        public void AddRequest(RegistrationHandlerData data, ServerContext context)
        {
            var userCollection = context.Data.UserCollection;
            var unique = true;

            foreach (var user in userCollection.Users.Values)
            {
                if (user.Email.Equals(data.Email) || user.Login.Equals(data.Login))
                    unique = false;
            }

            if (unique)
            {
                var user = new User()
                {
                    Email = data.Email,
                    Login = data.Login,
                    Name = data.Name,
                    Password = data.Password,
                };
                
                userCollection.AddNewUser(user);
                data.UserParams.Add("id", user.Id.ToString());
                data.UserParams.Add("err", "false");
                
                ServerLoggerModel.Log(TypeLog.UserMessage, $"User {user.Id} has been registered at {DateTime.Now}");
            }
            else
            {
                data.UserParams.Add("err", "true");
                data.UserParams.Add("err_t", "Email or login exists");
                
                ServerLoggerModel.Log(TypeLog.UserMessage, $"Registration error at {DateTime.Now}");
            }
            
            var sendObject = JsonConvert.SerializeObject(data.UserParams);
            
            data.Send(sendObject);
        }
    }
}