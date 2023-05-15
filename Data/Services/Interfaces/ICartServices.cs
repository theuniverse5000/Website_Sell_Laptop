using Data.Models;

namespace Data.Services.Interfaces
{
    public interface ICartServices
    {
        Task<bool> CreateCart(Cart obj);
        Task<bool> UpdateCart(Cart obj);
        Task<bool> DeleteCart(Guid id);
        Task<List<Cart>> GetAllCarts();
        Task<Cart> GetCartById(Guid id);

    }
}
