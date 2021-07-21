using System;
using Server.ServerCore.Handlers.UpdatePermission;
using Server.ServerCore.Models.User;
using Server.ServerCore.ServerLogger;
using Server.ServerCore.Services.Utilities;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace Server.ServerCore.Services.BaseServices.Services
{
    public class UpdatePermissionService : IService
    {
        public void Dispose()
        {

        }

        public void AddRequest(UpdatePermissionHandlerData data, ServerContext context)
        {
            var userCollection = context.ModelsCollection.Users;

            if (userCollection.GetByKey(nameof(UserModel.Guid), data.AdminId, out var adminResult))
            {
                var admin = adminResult[0];

                if ((UserType)Convert.ToInt32(admin.Type) == UserType.Admin)
                {
                    if (userCollection.GetByKey(nameof(UserModel.Guid), data.UserId, out var userResult))
                    {
                        var user = userResult[0];

                        user.Type = data.UserType;
                        data.UserParams.Add("err", "false");

                        ServerLoggerModel.Log(TypeLog.Info, $"{admin.Guid} changed user {user.Guid} type to {user.Type}");
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
            }
            else
            {
                AddError(data);
            }

            var sendObject = JsonConvert.SerializeObject(data.UserParams);
            data.Send(sendObject);
        }

        private static void AddError(UpdatePermissionHandlerData data)
        {
            data.UserParams.Add("err", "true");
            data.UserParams.Add("err_t", $"Admin {data.AdminId} isn't valid or cannot change type of user {data.UserId}");

            ServerLoggerModel.Log(TypeLog.Error, $"Change type of user {data.UserId} error at {DateTime.Now}");
        }
    }
}