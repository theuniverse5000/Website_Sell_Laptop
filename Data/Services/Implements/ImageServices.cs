using Data.Models;
using Data.Services.Interfaces;

namespace Data.Services.Implements
{
    public class ImageServices : IImageServices
    {
        ApplicationDbContext _dbContext;
        public ImageServices()
        {
            _dbContext = new ApplicationDbContext();
        }
        public bool CreateImage(Image thao)
        {
            try
            {
                _dbContext.Images.Add(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteImage(Guid id)
        {
            try
            {
                var thao = _dbContext.Images.Find(id);
                _dbContext.Images.Remove(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Image> GetAllImages()
        {
            return _dbContext.Images.ToList();
        }
        public bool IsMaImageExist(string Ma)
        {
            var linh = _dbContext.Images;
            var thao = linh.FirstOrDefault(a => a.Ma == Ma);
            if (thao != null) return true;
            else return false;
        }

        public bool UpdateImage(Image thao)
        {
            try
            {
                var linh = _dbContext.Images.Find(thao.Id);
                linh.LinkImage = thao.LinkImage;
                _dbContext.Images.Update(linh);
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
