using Server.ServerCore.Models.Base;
using Server.ServerCore.Models.User;

namespace Server.ServerCore.Models
{
    public interface IModelsCollection
    {
        BaseModelCollection<UserModel> Users { get; }
    }
}