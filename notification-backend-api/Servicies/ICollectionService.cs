namespace notification_backend_api.Servicies
{
    public interface ICollectionService<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task<bool> Create(T model);


    }
}
