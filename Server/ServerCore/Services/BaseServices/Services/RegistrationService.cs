using System;
using Newtonsoft.Json;
using Server.ServerCore.Handlers.Registration;
using Server.ServerCore.Models.User;
using Server.ServerCore.ServerLogger;
using Server.ServerCore.Services.Utilities;

namespace Server.ServerCore.Services.BaseServices.Services
{
    public class RegistrationService : IService
    {
        public void Dispose()
        {
        }

        public void AddRequest(RegistrationHandlerData data, ServerContext context)
        {
            var userCollection = context.ModelsCollection.Users;

            if (userCollection.GetByKey(nameof(UserModel.Login), data.Login, out var resultData))
            {
                var user = resultData[0];

                if (!user.Email.Equals(data.Email) || !user.Login.Equals(data.Login))
                {
                    var newUser = new UserModel()
                    {
                        Email = data.Email,
                        Login = data.Login,
                        Name = data.Name,
                        Password = data.Password,
                        Type = UserType.Guest.ToString()
                    };
                
                    userCollection.Add(newUser);
                
                    data.UserParams.Add("id", newUser.Guid.ToString());
                    data.UserParams.Add("err", "false");
                
                    ServerLoggerModel.Log(TypeLog.UserMessage, $"User {newUser.Guid} has been registered at {DateTime.Now}");
                }
                else
                {
                    AddError(data);
                }
            }
            
            var sendObject = JsonConvert.SerializeObject(data.UserParams);
            data.Send(sendObject);
        }
        
        private static void AddError(RegistrationHandlerData data)
        {
            data.UserParams.Add("err", "true");
            data.UserParams.Add("err_t", "Email or login exists");
            
            ServerLoggerModel.Log(TypeLog.Error, $"Registration error at {DateTime.Now}");
        }
    }
}