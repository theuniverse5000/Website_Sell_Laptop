using Data.Models;

namespace Data.Services.Interfaces
{
    public interface IHardDriveServices
    {
        bool CreateHardDrive(HardDrive s);
        bool UpdateHardDrive(HardDrive s);
        bool DeleteHardDrive(Guid id);
        bool IsMaHardDriveExist(string ma);
        List<HardDrive> GetAllHardDrives();
    }
}
