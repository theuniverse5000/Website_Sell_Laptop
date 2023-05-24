using Data.IRepositories;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AllRepositories<T> : IAllRepositories<T> where T : class// bắt buộc là obj
    {
        ApplicationDbContext _dbContext;
        DbSet<T> _dbSet;// Tạo mới vì khi dùng Generic không chỉ tới 1 db set cụ thể
        public AllRepositories()
        {

        }
        public AllRepositories(ApplicationDbContext dbContext, DbSet<T> dbSet)
        {
            _dbContext = dbContext;
            _dbSet = dbSet;
        }
        public async Task<bool> CreateItem(T item)
        {
            try
            {
                await _dbSet.AddAsync(item);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteItem(T item)
        {
            try
            {
                _dbSet.Remove(item);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllItem()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<bool> UpdateItem(T item)
        {
            try
            {
                _dbSet.Update(item);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
