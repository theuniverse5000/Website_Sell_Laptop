using Data.Models;
using Data.Models.ViewModels;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Implements
{
    public class CartDetailServices : ICartDetailServices
    {
        ApplicationDbContext _dbContext;
        IProductDetailServices _productDetailServices;
        public CartDetailServices()
        {
            _dbContext = new ApplicationDbContext();
            _productDetailServices = new ProductDetailServices();
        }

        public async Task<bool> CreateCartDetail(CartDetail obj)
        {
            try
            {
                if (obj == null) return false;
                else
                {
                    await _dbContext.CartDetails.AddAsync(obj);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteCartDetail(Guid id)
        {
            try
            {
                var x = await _dbContext.CartDetails.FindAsync(id);
                _dbContext.CartDetails.Remove(x);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<CartDetail>> GetAllCartDetails()
        {
            return await _dbContext.CartDetails.ToListAsync();
        }

        public async Task<CartDetail> GetCartDetailById(Guid id)
        {
            return await _dbContext.CartDetails.FindAsync(id);
        }

        public async Task<List<CartDetailView>> GetCartDetailJoinProductDetail()
        {
            List<CartDetailView> cartDetails = new List<CartDetailView>();
            cartDetails = (
                 from x in await _dbContext.Carts.ToListAsync()
                 join y in await _dbContext.CartDetails.ToListAsync() on x.UserId equals y.UserId
                 join a in await _dbContext.ProductDetails.ToListAsync() on y.IdProductDetails equals a.Id
                 join b in await _dbContext.Rams.ToListAsync() on a.IdRam equals b.Id
                 join c in await _dbContext.Cpus.ToListAsync() on a.IdCpu equals c.Id
                 join d in await _dbContext.HardDrives.ToListAsync() on a.IdHardDrive equals d.Id
                 join e in await _dbContext.Colors.ToListAsync() on a.IdColor equals e.Id
                 join f in await _dbContext.CardVGAs.ToListAsync() on a.IdCardVGA equals f.Id
                 join g in await _dbContext.Screens.ToListAsync() on a.IdScreen equals g.Id
                 // join h in await _dbContext.Images.ToListAsync() on a.Id equals h.IdProductDetail
                 join i in await _dbContext.Products.ToListAsync() on a.IdProduct equals i.Id
                 join k in await _dbContext.Manufacturers.ToListAsync() on i.IDManufacturer equals k.Id

                 select new CartDetailView
                 {
                     Id = y.Id,
                     Quantity = y.Quantity,
                     UserId = y.UserId,
                     IdProductDetails = a.Id,
                     MaProductDetai = a.Ma,
                     ImportPrice = a.ImportPrice,
                     Price = a.Price,
                     AvailableQuantity = a.AvailableQuantity,
                     Status = a.Status,
                     ThongSoRam = b.ThongSo,
                     MaRam = b.Ma,
                     SoKheCamRam = b.SoKheCam,
                     MoTaRam = b.MoTa,
                     NameCpu = c.Name,
                     ThongSoCpu = c.ThongSo,
                     MaCpu = c.Ma,
                     ThongSoHardDrive = d.ThongSo,
                     MoTaHardDrive = d.MoTa,
                     MaHardDrive = d.Ma,
                     NameColor = e.Name,
                     MaColor = e.Ma,
                     TenCardVGA = f.Ten,
                     ThongSoCardVGA = f.ThongSo,
                     TenManHinh = g.Ten,
                     KichCoManHinh = g.KichCo,
                     TanSoManHinh = g.TanSo,
                     ChatLieuManHinh = g.ChatLieu,
                     NameProduct = i.Name,
                     NameManufacturer = k.Name,
                     //  LinkImage = h.LinkImage

                 }

               ).ToList();
            return cartDetails;
        }

        public async Task<bool> UpdateCartDetail(CartDetail obj)
        {
            try
            {
                if (obj == null) return false;
                else
                {
                    var x = await _dbContext.CartDetails.FindAsync(obj.Id);
                    x.Quantity = obj.Quantity;
                    _dbContext.CartDetails.Update(x);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception)
            {

                return false;
            }
        }
        //public List<CartDetailView> GetCartDetailJoinProductDetail()
        //{
        //    List<CartDetailView> listItemInCart = new List<CartDetailView>();
        //    //listItemInCart = (
        //    //      from a in _dbContext.Carts.ToList()
        //    //      join b in _dbContext.CartDetails.ToList() on a.UserId equals b.UserId
        //    //      join c in _dbContext.ProductDetails.ToList() on b.IdProductDetails equals c.Id
        //    //      join d in _dbContext.Rams.ToList() on c.IdRam equals d.Id
        //    //      join e in _dbContext.Cpus.ToList() on c.IdCpu equals e.Id
        //    //      join f in _dbContext.HardDrives.ToList() on c.IdHardDrive equals f.Id
        //    //      join g in _dbContext.Colors.ToList() on c.IdColor equals g.Id
        //    //      join h in _dbContext.Products.ToList() on c.IdProduct equals h.Id
        //    //      join i in _dbContext.Manufacturers.ToList() on h.IdManufacturer equals i.Id
        //    //      join k in _dbContext.Images.ToList() on h.Id equals k.IdProduct
        //    //      select new CartDetailView
        //    //      {
        //    //          UserId = a.UserId,
        //    //          DescriptionCart = a.Description,
        //    //          Id = b.Id,
        //    //          Quantity = b.Quantity,
        //    //          MaProductDetail = c.Ma,
        //    //          NameProduct = h.Name,
        //    //          Price = c.Price,
        //    //          ThongSoRam = d.ThongSo,
        //    //          ThongSoHardDrive = f.ThongSo,
        //    //          NameCpu = e.Name,
        //    //          LinkImage = k.LinkImage

        //    //      }
        //    //      ).ToList();
        //    return listItemInCart;
        //}

    }
}
