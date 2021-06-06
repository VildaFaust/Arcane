using System;
using MongoDB.Bson;

namespace Server.ServerCore.Models.Base
{
    public class BaseModel : IBaseModel
    {
        public ObjectId Guid { get; private set; }
        
        public object GetByKey(string key)
        {
            return null;
        }
    }
}