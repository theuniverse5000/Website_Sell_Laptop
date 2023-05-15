using Data.Models;
using Data.Models.ViewModels;

namespace Data.Services.Interfaces
{
    public interface ICartDetailServices
    {
        Task<bool> CreateCartDetail(CartDetail obj);
        Task<bool> UpdateCartDetail(CartDetail obj);
        Task<bool> DeleteCartDetail(Guid id);
        Task<List<CartDetail>> GetAllCartDetails();
        Task<CartDetail> GetCartDetailById(Guid id);
        Task<List<CartDetailView>> GetCartDetailJoinProductDetail();
    }
}
