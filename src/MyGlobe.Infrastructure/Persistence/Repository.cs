using Microsoft.EntityFrameworkCore;
using MyGlobe.Domain;

namespace MyGlobe.Infrastructure.Persistence
{
    public abstract class Repository<T, TId> : IRepository<T, TId> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;

        protected Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public T Get(TId id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(TId id)
        {
            var entity = Get(id);
            if (null != entity)
                _dbSet.Remove(entity);
        }
    
        public void Save()
        {
            _context.SaveChanges();
        }
    
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}