using System;
using Newtonsoft.Json;
using Server.ServerCore.Handlers.Authorization;
using Server.ServerCore.Handlers.Base;
using Server.ServerCore.Models.User;
using Server.ServerCore.ServerLogger;
using Server.ServerCore.Services.Utilities;

namespace Server.ServerCore.Services.BaseServices.Services
{
    public class AuthorizationService : IService
    {
        public void Dispose()
        {
        }

        public void AddRequest(AuthorizationHandlerData data, ServerContext context)
        {
            var userCollection = context.ModelsCollection.Users;

            if (userCollection.GetByKey(nameof(UserModel.Login), data.Login, out var resultData))
            {
                var user = resultData[0];

                if (user.Password == data.Password)
                {
                    data.UserParams.Add("id", user.Guid.ToString());
                    data.UserParams.Add("err", "false");
                }
                else
                {
                    AddError(data);
                }
            }
            else
            {
                AddError(data);
            }

            var sendObject = JsonConvert.SerializeObject(data.UserParams);
            data.Send(sendObject);
        }

        private static void AddError(AuthorizationHandlerData data)
        {
            data.UserParams.Add("err", "true");
            data.UserParams.Add("err_t", "Login or password is incorrect");

            ServerLoggerModel.Log(TypeLog.Error, $"Registration error at {DateTime.Now}");
        }
    }
}