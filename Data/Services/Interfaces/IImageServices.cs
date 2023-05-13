using Data.Models;

namespace Data.Services.Interfaces
{
    public interface IImageServices
    {
        bool CreateImage(Image a);
        bool UpdateImage(Image a);
        bool DeleteImage(Guid id);
        bool IsMaImageExist(string ma);
        List<Image> GetAllImages();
    }
}
