using Data.Models;
using Data.Models.ViewModels;

namespace Data.Services.Interfaces
{
    public interface ICartDetailServices
    {
        bool CreateCartDetail(CartDetail thao);
        bool UpdateCartDetail(CartDetail thao);
        bool DeleteCartDetail(Guid id);
        List<CartDetail> GetAllCartDetails();
        CartDetail GetCartDetailById(Guid id);
        //List<CartDetail> GetCartDetailByName(string CartDetailname);
        List<CartDetailView> GetCartDetailJoinProductDetail();
    }
}
