using Microsoft.EntityFrameworkCore;
using TeknorixTest.Data;
using TeknorixTest.Entities;

namespace TeknorixTest.Repository
{
    public class GenericRepository(AppDbContext context) : IRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<T?> GetByIdAsync<T>(int id) where T : BaseEntity
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync<T>(T entity) where T : BaseEntity
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Update(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync<T>() where T : BaseEntity
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<Job?> GetLastJobAsync()
        {
            return await _context.Jobs
                .OrderByDescending(j => j.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> LocationExistsAsync(int id)
        {
            return await _context.Locations.AnyAsync(l => l.Id == id);
        }

        public async Task<bool> DepartmentExistsAsync(int id)
        {
            return await _context.Departments.AnyAsync(d => d.Id == id);
        }


    }
}
