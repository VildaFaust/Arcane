using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Server.ServerCore.Models.Base;
using ObjectId = MongoDB.Bson.ObjectId;

namespace Server.ServerCore.Models.User
{
    public class UserModel : IBaseModel
    {
        [BsonId]
        public ObjectId Guid { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }

        public void Update(IMongoCollection<UserModel> collection)
        {
            var filter = Builders<UserModel>.Filter.Eq(nameof(Guid), Guid);
            var update = Builders<UserModel>.Update
                .Set(nameof(Name), Name)
                .Set(nameof(Login), Login)
                .Set(nameof(Password), Password)
                .Set(nameof(Email), Email)
                .Set(nameof(Type), Type);

            collection.UpdateOne(filter, update);
        }
        
        public object GetByKey(string key)
        {
            switch (key)
            {
                case nameof(Name):
                    return Name;
                case nameof(Login):
                    return Login;
                case nameof(Password):
                    return Password;
                case nameof(Email):
                    return Email;
                case nameof(Type):
                    return Enum.Parse<UserType>(Type, true);
            }

            return null;
        }
    }
}