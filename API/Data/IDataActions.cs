namespace API.Data
{
    public interface IDataActions<T>
    {
        Task SaveChanges();
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Create(T entity);
        void Delete(T entity);

    }
}
