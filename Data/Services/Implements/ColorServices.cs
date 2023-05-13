using Data.Models;
using Microsoft.EntityFrameworkCore;
using Data.Services.Interfaces;

namespace Data.Services.Implements
{
    public class ColorServices : IColorServices
    {
        ApplicationDbContext _dbContext;
        public ColorServices()
        {
            _dbContext = new ApplicationDbContext();
        }
        public bool CreateColor(Color thao)
        {
            try
            {
                _dbContext.Colors.Add(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteColor(Guid id)
        {
            try
            {
                var thao = _dbContext.Colors.Find(id);
                _dbContext.Colors.Remove(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Color> GetAllColors()
        {
            return _dbContext.Colors.ToList();
        }
        public bool IsMaColorExist(string Ma)
        {
            var linh = _dbContext.Colors;
            var thao = linh.FirstOrDefault(a => a.Ma == Ma);
            if (thao != null) return true;
            else return false;
        }

        public bool UpdateColor(Color thao)
        {
            try
            {
                var linh = _dbContext.Colors.Find(thao.Id);
                linh.Name = thao.Name;
                _dbContext.Colors.Update(linh);
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
