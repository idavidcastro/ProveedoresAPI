using MongoDB.Driver;

namespace ProveedoresAPI.Repositories
{
    public class ProveedorRepository
    {
        public MongoClient client;
        public IMongoDatabase db;
        public ProveedorRepository()
        {
            client = new MongoClient("");
        }
    }
}
