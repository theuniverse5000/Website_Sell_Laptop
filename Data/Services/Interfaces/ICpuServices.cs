using Data.Models;

namespace Data.Services.Interfaces
{
    public interface ICpuServices
    {
        bool CreateCpu(Cpu c);
        bool UpdateCpu(Cpu c);
        bool DeleteCpu(Guid id);
        bool IsMaCpuExist(string ma);
        List<Cpu> GetAllCpus();
    }
}
