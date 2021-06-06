using MongoDB.Bson;

namespace Server.ServerCore.Models.Base
{
    public interface IBaseModel
    {
        ObjectId Guid { get; }
        object GetByKey(string key);
    }
}