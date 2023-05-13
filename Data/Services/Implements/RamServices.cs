using Data.Models;
using Data.Services.Interfaces;

namespace Data.Services.Implements
{
    public class RamServices : IRamServices
    {
        ApplicationDbContext _dbContext;
        public RamServices()
        {
            _dbContext = new ApplicationDbContext();
        }
        /*
           public async Task<bool> AddAsync(Bill obj)
        {
            try
            {
                obj.CreatedTime = DateTime.Now;

                await _dbContext.Bills.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Bill>> GetAllAsync()
        {
            var list = await _dbContext.Bills.ToListAsync();
            if (list == null)
            {
                return new();
            }
            return list;
        }

        public async Task<List<Bill>> GetAllOfUserAsync(Guid idUser)
        {
            var list = await _dbContext.Bills.ToListAsync();
            if (list == null)
            {
                return new();
            }

            list = list.Where(c => c.IdUser == idUser).ToList();
            return list;
        }

        public async Task<Bill> GetByIdAsync(Guid id)
        {
            var list = await _dbContext.Bills.ToListAsync();
            var obj = list.FirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return new Bill();
            }
            return obj;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            try
            {
                var listObj = await _dbContext.Bills.ToListAsync();
                var obj = listObj.FirstOrDefault(c => c.Id == id);
                obj.Status = 1;

                _dbContext.Bills.Attach(obj);
                await Task.FromResult<Bill>(_dbContext.Bills.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid id, Bill obj)
        {
            try
            {
                var listObj = await _dbContext.Bills.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.Id == id);

                objForUpdate.Status = obj.Status;

                _dbContext.Bills.Attach(obj);
                await Task.FromResult<Bill>(_dbContext.Bills.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
         */
        public bool CreateRam(Ram r)
        {
            try
            {
                _dbContext.Rams.Add(r);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRam(Guid id)
        {
            try
            {
                var r = _dbContext.Rams.Find(id);
                _dbContext.Rams.Remove(r);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Ram> GetAllRams()
        {
            return _dbContext.Rams.ToList();
        }
        public bool IsMaRamExist(string Ma)
        {
            var linh = _dbContext.Rams;
            var r = linh.FirstOrDefault(a => a.Ma == Ma);
            if (r != null) return true;
            else return false;
        }

        public bool UpdateRam(Ram r)
        {
            try
            {
                var linh = _dbContext.Rams.Find(r.Id);
                linh.ThongSo = r.ThongSo;
                _dbContext.Rams.Update(linh);
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
