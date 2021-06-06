using System.Collections.Generic;
using MongoDB.Bson;

namespace Server.ServerCore.Models.Base
{
    public interface IBaseModelCollection<TModel> where TModel : IBaseModel
    {
        void Add(TModel model);
        void Remove(ObjectId guid);
        void Update(ObjectId guid);
        void Update();
        TModel this[ObjectId guid] { get; }
        bool GetByKey<T>(string key, T value, out IList<TModel> resultData) where T : class;
    }
}