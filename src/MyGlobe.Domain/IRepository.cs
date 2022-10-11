namespace MyGlobe.Domain
{
    public interface IRepository<T, in TId>:IDisposable
    {
        IEnumerable<T> GetAll();
        T Get(TId id);
        void Add(T entity);
        void Update(T entity);
        void Delete(TId id);
        void Save();
    }
}