using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Server.ServerCore.Models.Base
{
    public class BaseModelCollection<TModel> : IBaseModelCollection<TModel> where TModel : IBaseModel
    {
        private readonly Dictionary<ObjectId, TModel> _models = new Dictionary<ObjectId, TModel>();
        public TModel this[ObjectId guid] => _models[guid];
        
        public void Add(TModel model)
        {
            _models.Add(model.Guid, model);
        }

        public void Remove(ObjectId guid)
        {
            _models.Remove(guid);
        }

        public void Update(ObjectId guid)
        {
        }

        public void Update()
        {
        }
        
        public bool GetByKey<T>(string key, T value, out IList<TModel> resultData) where T : class
        {
            bool exist = false;
            resultData = new List<TModel>();
            foreach (var model in _models.Values)
            {
                var result = (T)model.GetByKey(key);

                if (value == result)
                {
                    resultData.Add(model);
                    exist = true;
                }
            }

            return exist;
        }
    }
}