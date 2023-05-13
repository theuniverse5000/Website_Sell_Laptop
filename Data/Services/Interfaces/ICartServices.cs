using Data.Models;

namespace Data.Services.Interfaces
{
    public interface ICartServices
    {
        bool CreateCart(Cart thao);
        bool UpdateCart(Cart thao);
        bool DeleteCart(Guid id);
        List<Cart> GetAllCarts();
        Cart GetCartById(Guid id);
        //List<Cart> GetCartByName(string Cartname);
    }
}
