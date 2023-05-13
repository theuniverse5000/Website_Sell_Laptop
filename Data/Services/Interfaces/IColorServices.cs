using Data.Models;

namespace Data.Services.Interfaces
{
    public interface IColorServices
    {
        bool CreateColor(Color a);
        bool UpdateColor(Color a);
        bool DeleteColor(Guid id);
        bool IsMaColorExist(string ma);
        List<Color> GetAllColors();
    }
}
