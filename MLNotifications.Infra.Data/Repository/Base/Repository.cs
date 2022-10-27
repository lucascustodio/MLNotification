using Microsoft.EntityFrameworkCore;
using MLNotifications.Domain.Interface;

namespace MLNotifications.Infra.Data.Repository.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly Context _context;
        protected readonly DbSet<T> _set;

        public Repository(Context context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public virtual Task<List<T>> GetAll()
        {
            return _set.ToListAsync();
        }

        public async Task<T> AddAsync(T newEntity)
        {
            var response = await _set.AddAsync(newEntity);

            return response.Entity;
        }

        public virtual ValueTask<T> GetByIdAsync(Guid id)
        {
            return _set.FindAsync(id);
        }

        public void Remove(T entity)
        {
            var entry = _context.Entry(entity);

            var deleteProperty = entry.Property<bool>("IsDeleted");

            if (deleteProperty == null)
            {
                _context.Remove(entity);
            }
            else
            {
                deleteProperty.CurrentValue = true;
                _set.Update(entity);
            }
        }

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }

        public T Update(T entity)
        {
            return (_set.Update(entity)).Entity;
        }
    }
}
