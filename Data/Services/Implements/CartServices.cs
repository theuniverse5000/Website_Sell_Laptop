using Data.Models;
using Data.Services.Interfaces;

namespace Data.Services.Implements
{
    public class CartServices : ICartServices
    {
        ApplicationDbContext _dbContext;
        public CartServices()
        {
            _dbContext = new ApplicationDbContext();
        }
        public bool CreateCart(Cart thao)
        {
            try
            {
                _dbContext.Carts.Add(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool DeleteCart(Guid id)
        {
            try
            {
                var thao = _dbContext.Carts.Find(id);
                _dbContext.Carts.Remove(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Cart> GetAllCarts()
        {
            return _dbContext.Carts.ToList();
        }

        public Cart GetCartById(Guid id)
        {
            return _dbContext.Carts.Find(id);
        }

        public bool UpdateCart(Cart thao)
        {
            try
            {
                var linh = _dbContext.Carts.Find(thao.UserId);
                linh.Description = thao.Description;
                _dbContext.Carts.Update(linh);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
