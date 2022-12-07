using notification_backend_api.Models;

namespace notification_backend_api.Servicies
{
    public interface IAnnouncementCollectionService:ICollectionService<Announcement>
    {
        List<Announcement> GetAnnouncementsByCategoryId(string categoryId);

    }
}
