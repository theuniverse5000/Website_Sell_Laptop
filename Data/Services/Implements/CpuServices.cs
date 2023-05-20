using Data.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Implements
{
    public class CpuServices : ICpuServices
    {
        ApplicationDbContext _dbContext;
        public CpuServices()
        {
            _dbContext = new ApplicationDbContext();
        }
        public async Task<bool> CreateCpu(Cpu obj)
        {
            try
            {
                await _dbContext.Cpus.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCpu(Guid id)
        {
            try
            {
                var t = await _dbContext.Cpus.FindAsync(id);
                _dbContext.Cpus.Remove(t);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Cpu>> GetAllCpus()
        {
            return await _dbContext.Cpus.ToListAsync();
        }
        public async Task<bool> IsMaCpuExist(string ma)
        {
            var l = _dbContext.Cpus;
            var t = await l.FirstOrDefaultAsync(x => x.Ma == ma);
            if (t != null) return true;
            else return false;
        }

        public async Task<bool> UpdateCpu(Cpu obj)
        {
            try
            {
                var l = await _dbContext.Cpus.FindAsync(obj.Id);
                l.Name = obj.Name;
                l.ThongSo = obj.ThongSo;
                _dbContext.Cpus.Update(l);
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
