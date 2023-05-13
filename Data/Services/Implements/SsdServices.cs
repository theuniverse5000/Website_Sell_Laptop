using Data.Models;
using Data.Services.Interfaces;

namespace Data.Services.Implements
{
    public class HardDriveServices : IHardDriveServices
    {
        ApplicationDbContext _dbContext;
        public HardDriveServices()
        {
            _dbContext = new ApplicationDbContext();
        }
        public bool CreateHardDrive(HardDrive s)
        {
            try
            {
                _dbContext.HardDrives.Add(s);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteHardDrive(Guid id)
        {
            try
            {
                var s = _dbContext.HardDrives.Find(id);
                _dbContext.HardDrives.Remove(s);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<HardDrive> GetAllHardDrives()
        {
            return _dbContext.HardDrives.ToList();
        }
        public bool IsMaHardDriveExist(string Ma)
        {
            var linh = _dbContext.HardDrives;
            var s = linh.FirstOrDefault(a => a.Ma == Ma);
            if (s != null) return true;
            else return false;
        }

        public bool UpdateHardDrive(HardDrive s)
        {
            try
            {
                var linh = _dbContext.HardDrives.Find(s.Id);
                linh.ThongSo = s.ThongSo;
                _dbContext.HardDrives.Update(linh);
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
