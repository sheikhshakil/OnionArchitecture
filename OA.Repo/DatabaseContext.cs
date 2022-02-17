using MongoDB.Driver;

namespace OA.Repo
{
    public class DatabaseContext
    {
        public static MongoClient DbClient { get; set; }
        public static string DbName { get; set; }
    }
}
