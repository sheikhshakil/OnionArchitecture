using MongoDB.Bson;
using MongoDB.Driver;
using OA.Data;
using System.Collections.Generic;
using System.Linq;

namespace OA.Repo
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private MongoClient dbClient = DatabaseContext.DbClient;
        private string dbName = DatabaseContext.DbName, colName = null;

        public Repository(string colName)
        {
            this.colName = colName;
        }

        public T Get(string email)
        {
            try
            {
                var collection = dbClient.GetDatabase(dbName).GetCollection<T>(colName);
                var filter = Builders<T>.Filter.Eq("Email", email);
                var doc = collection.Find(filter).FirstOrDefault();

                return doc;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                var collection = dbClient.GetDatabase(dbName).GetCollection<T>(colName);
                var documents = collection.Find(new BsonDocument()).ToEnumerable();

                return documents;
            }
            catch
            {
                return null;
            }
        }

        public bool Save(T data)
        {
            try
            {
                var collection = dbClient.GetDatabase(dbName).GetCollection<T>(colName); // T : User
                collection.InsertOne(data);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string email)
        {
            try
            {
                var collection = dbClient.GetDatabase(dbName).GetCollection<T>(colName);
                var filter = Builders<T>.Filter.Eq("Email", email);
                var result = collection.DeleteOne(filter);
                if (result.DeletedCount == 1)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
