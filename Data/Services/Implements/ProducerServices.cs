using Data.Models;
using Data.Services.Interfaces;

namespace Data.Services.Implements
{
    public class ManufacturerServices : IManufacturerServices
    {
        ApplicationDbContext _dbContext;
        public ManufacturerServices()
        {
            _dbContext = new ApplicationDbContext();
        }
        public bool CreateManufacturer(Manufacturer thao)
        {
            try
            {
                _dbContext.Manufacturers.Add(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteManufacturer(Guid id)
        {
            try
            {
                var thao = _dbContext.Manufacturers.Find(id);
                _dbContext.Manufacturers.Remove(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Manufacturer> GetAllManufacturers()
        {
            return _dbContext.Manufacturers.ToList();
        }
        public bool IsNameManufacturerExist(string Name)
        {
            var linh = _dbContext.Manufacturers;
            var thao = linh.FirstOrDefault(a => a.Name == Name);
            if (thao != null) return true;
            else return false;
        }

        public bool UpdateManufacturer(Manufacturer thao)
        {
            try
            {
                var linh = _dbContext.Manufacturers.Find(thao.Id);
                linh.Name = thao.Name;
                _dbContext.Manufacturers.Update(linh);
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
