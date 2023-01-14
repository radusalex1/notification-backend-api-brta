using notification_backend_api.Models;

namespace notification_backend_api.Servicies
{
    public interface ICollectionService<T>
    {
        Task<List<T>> GetAll();

        Task<T> GetByID(Guid id);

        Task<bool> Create(T model);

        Task<bool> deleteAll();

        Task<bool> Delete(Guid id);

        Task<bool> Update(Guid id,Announcement announcement);

    }
}
