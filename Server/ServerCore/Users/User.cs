using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using ObjectId = MongoDB.Bson.ObjectId;

namespace Server.ServerCore.Users
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public void Update(IMongoCollection<User> collection)
        {
            var filter = Builders<User>.Filter.Eq(nameof(Id), Id);
            var update = Builders<User>.Update
                .Set(nameof(Name), Name)
                .Set(nameof(Login), Login)
                .Set(nameof(Password), Password)
                .Set(nameof(Email), Email);

            collection.UpdateOne(filter, update);
        }
    }
}