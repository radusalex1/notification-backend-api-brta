﻿using MongoDB.Driver;
using notification_backend_api.Models;

namespace notification_backend_api.Servicies
{
    public class AnnouncementCollectionService:IAnnouncementCollectionService
    {
        private readonly IMongoCollection<Announcement> _announcements;

        public AnnouncementCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _announcements = database.GetCollection<Announcement>(settings.AnnouncementsCollectionName);
        }
        
        public async Task<bool> deleteAll()
        {
            var listOfA = await GetAll();
            foreach(Announcement announcement in listOfA)
            {
                await _announcements.DeleteOneAsync<Announcement>(a=>a.Id==announcement.Id);
            }
            return true;
        }
        
        public async Task<bool> Create(Announcement announcement)
        {
            if (announcement.Id == Guid.Empty || announcement.Id==null)
            {
                announcement.Id = Guid.NewGuid();
            }

            await _announcements.InsertOneAsync(announcement);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _announcements.DeleteOneAsync(announcement => announcement.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<Announcement> GetByID(Guid id)
        {
            return (await _announcements.FindAsync(announcement => announcement.Id == id)).FirstOrDefault();
        }

        public async Task<bool> Update(Guid id, Announcement announcement)
        {
            announcement.Id = id;

            var result = await _announcements.ReplaceOneAsync(announcement => announcement.Id == id, announcement);

            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _announcements.InsertOneAsync(announcement);
                return false;
            }

            return true;
        }
        
        public async Task<List<Announcement>> GetAll()
        {
            var result = await _announcements.FindAsync(announcement => true);
            return result.ToList();
        }
    }
}
