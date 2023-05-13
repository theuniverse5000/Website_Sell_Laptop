using Data.Models;

namespace Data.Services.Interfaces
{
    public interface IManufacturerServices
    {
        bool CreateManufacturer(Manufacturer a);
        bool UpdateManufacturer(Manufacturer a);
        bool DeleteManufacturer(Guid id);
        bool IsNameManufacturerExist(string Name);
        List<Manufacturer> GetAllManufacturers();
    }
}
