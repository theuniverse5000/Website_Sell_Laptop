using Data.Models;

namespace Data.Services.Interfaces
{
    public interface ICpuServices
    {
        Task<bool> CreateCpu(Cpu obj);
        Task<bool> UpdateCpu(Cpu obj);
        Task<bool> DeleteCpu(Guid id);
        Task<bool> IsMaCpuExist(string ma);
        Task<List<Cpu>> GetAllCpus();
    }
}
