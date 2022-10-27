namespace MLNotifications.Domain.Interface
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T entity);

        Task<List<T>> GetAll();

        ValueTask<T> GetByIdAsync(Guid id);

        T Update(T entity);

        void Remove(T entity);

        Task SaveChanges();
    }
}
