using Data.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Implements
{
    public class CartServices : ICartServices
    {
        ApplicationDbContext _dbContext;
        public CartServices()
        {
            _dbContext = new ApplicationDbContext();
        }

        public async Task<bool> CreateCart(Cart obj)
        {
            try
            {
                if (obj == null) return false;
                else
                {
                    await _dbContext.Carts.AddAsync(obj);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteCart(Guid id)
        {
            try
            {
                var cart = _dbContext.Carts.Find(id);
                _dbContext.Carts.Remove(cart);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Cart>> GetAllCarts()
        {
            return await _dbContext.Carts.ToListAsync();
        }

        public async Task<Cart> GetCartById(Guid id)
        {
            return await _dbContext.Carts.FindAsync(id);
        }

        public async Task<bool> UpdateCart(Cart obj)
        {
            try
            {
                if (obj == null) return false;
                else
                {
                    var cart = await _dbContext.Carts.FindAsync(obj.UserId);
                    cart.Description = obj.Description;
                    _dbContext.Carts.Update(cart);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
