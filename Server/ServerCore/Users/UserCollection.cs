using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Server.ServerCore.Users
{
    public class UserCollection
    {
        // private readonly IMongoCollection<User> _collection;
        public readonly Dictionary<ObjectId, User> Users = new Dictionary<ObjectId, User>();

        public UserCollection(ServerContext context)
        {
            // var database = context.DatabaseConnection.Database;
            // _collection = database.GetCollection<User>("users");
        }

        private  void Load(ServerContext context)
        {
            // var listUsers = await _collection.Find(_ => true).ToListAsync();

            // foreach (var user in listUsers)
            // {
                // Users.Add(user.Id, user);
            // }
        }

        public void Update(User user)
        {
            // user.Update(_collection);
        }

        public void AddNewUser(User user)
        {
            // user.Id = ObjectId.GenerateNewId();
            // _collection.InsertOne(user);
        }
    }
}