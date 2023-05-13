using Data.Models;

namespace Data.Services.Interfaces
{
    public interface IRamServices
    {
        /*
            public Task<List<Bill>> GetAllAsync();
        public Task<Bill> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(Bill obj);
        public Task<bool> UpdateAsync(Guid id, Bill obj);
        public Task<bool> RemoveAsync(Guid id);

        public Task<List<Bill>> GetAllOfUserAsync(Guid idUser);
         */
        bool CreateRam(Ram r);
        bool UpdateRam(Ram r);
        bool DeleteRam(Guid id);
        bool IsMaRamExist(string ma);
        List<Ram> GetAllRams();
    }
}
