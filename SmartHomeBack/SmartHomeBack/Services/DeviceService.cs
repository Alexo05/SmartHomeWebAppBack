using MongoDB.Driver;
using Microsoft.Extensions.Options;
using SmartHomeBack.Models;
using SmartHomeBack.Settings;

namespace SmartHomeBack.Services
{
    public class DeviceService
    {
        private readonly IMongoCollection<Device> _devices;

        public DeviceService(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _devices = database.GetCollection<Device>("devices"); 
        }

        public List<Device> Get() => _devices.Find(d => true).ToList();

        public Device Get(string id) =>
            _devices.Find<Device>(d => d.Id == id).FirstOrDefault();

        public void Create(Device device) =>
            _devices.InsertOne(device);

        public void Update(string id, Device deviceIn) =>
            _devices.ReplaceOne(d => d.Id == id, deviceIn);

        public void Remove(string id) =>
            _devices.DeleteOne(d => d.Id == id);
    }
}

