using Server.ServerCore.Models.Base;
using Server.ServerCore.Models.User;

namespace Server.ServerCore.Models
{
    public class ModelsCollection : IModelsCollection
    {
        public BaseModelCollection<UserModel> Users { get; } = new BaseModelCollection<UserModel>();
    }
}