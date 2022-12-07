namespace notification_backend_api.Servicies
{
    public class MongoDBSettings : IMongoDBSettings
    {
        public string AnnouncementsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get ; set; }
    }
}
