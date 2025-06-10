using MongoDB.Driver;
using Microsoft.Extensions.Options;
using SmartHomeBack.Models;
using SmartHomeBack.Settings;
namespace SmartHomeBack.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;
        public UserService(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _users = database.GetCollection<User>("users"); 
        }
        public List<User> Get() => _users.Find(u => true).ToList();
        public User Get(string id) =>
            _users.Find<User>(u => u.Id == id).FirstOrDefault();
        public void Create(User user) =>
            _users.InsertOne(user);
        public void Update(string id, User userIn) =>
            _users.ReplaceOne(u => u.Id == id, userIn);
        public void Remove(string id) =>
            _users.DeleteOne(u => u.Id == id);
        public User GetByUsername(string username) =>
            _users.Find<User>(u => u.username == username).FirstOrDefault();
        public User GetByEmail(string email) =>
            _users.Find<User>(u => u.email == email).FirstOrDefault();


    }
}
