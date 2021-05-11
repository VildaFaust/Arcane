using Newtonsoft.Json;
using Server.ServerCore.Handlers.Authorization;
using Server.ServerCore.Handlers.Base;
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
            var userCollection = context.Data.UserCollection;

            foreach (var user in userCollection.Users.Values)
            {
                var uniqueLogin = user.Login.Equals(data.Login);
                var uniquePassword = user.Password.Equals(data.Password);

                if (uniqueLogin && uniquePassword)
                {
                    data.UserParams.Add("id", user.Id.ToString());
                    data.UserParams.Add("err", "false");
                }

                if (!uniqueLogin || !uniquePassword)
                {
                    data.UserParams.Add("err", "true");
                    data.UserParams.Add("err_t", "Login or password is incorrect");
                }
            }

            var sendObject = JsonConvert.SerializeObject(data.UserParams);

            data.Send(sendObject);
        }
    }
}