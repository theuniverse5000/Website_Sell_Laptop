using Data.Models;
using Data.Services.Interfaces;

namespace Data.Services.Implements
{
    public class CpuServices : ICpuServices
    {
        ApplicationDbContext _dbContext;
        public CpuServices()
        {
            _dbContext = new ApplicationDbContext();
        }
        public bool CreateCpu(Cpu thao)
        {
            try
            {
                _dbContext.Cpus.Add(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCpu(Guid id)
        {
            try
            {
                var thao = _dbContext.Cpus.Find(id);
                _dbContext.Cpus.Remove(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Cpu> GetAllCpus()
        {
            return _dbContext.Cpus.ToList();
        }
        public bool IsMaCpuExist(string Ma)
        {
            var linh = _dbContext.Cpus;
            var thao = linh.FirstOrDefault(a => a.Ma == Ma);
            if (thao != null) return true;
            else return false;
        }

        public bool UpdateCpu(Cpu thao)
        {
            try
            {
                var linh = _dbContext.Cpus.Find(thao.Id);
                linh.Name = thao.Name;
                _dbContext.Cpus.Update(linh);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
