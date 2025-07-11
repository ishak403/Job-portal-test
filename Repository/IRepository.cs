using TeknorixTest.Entities;

namespace TeknorixTest.Repository
{
    public interface IRepository
    {
        Task<T?> GetByIdAsync<T>(int id) where T : BaseEntity;
        Task AddAsync<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        Task SaveChangesAsync();
        Task<List<T>> GetAllAsync<T>() where T : BaseEntity;
        Task<Job?> GetLastJobAsync();

        Task<bool> LocationExistsAsync(int id);
        Task<bool> DepartmentExistsAsync(int id);
    }
}
