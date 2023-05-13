using Data.Models;
using Data.Models.ViewModels;
using Data.Services.Interfaces;

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
        public bool CreateCartDetail(CartDetail thao)
        {
            try
            {
                _dbContext.CartDetails.Add(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool DeleteCartDetail(Guid id)
        {
            try
            {
                var thao = _dbContext.CartDetails.Find(id);
                _dbContext.CartDetails.Remove(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<CartDetail> GetAllCartDetails()
        {
            return _dbContext.CartDetails.ToList();
        }
        public List<CartDetailView> GetCartDetailJoinProductDetail()
        {
            List<CartDetailView> listItemInCart = new List<CartDetailView>();
            //listItemInCart = (
            //      from a in _dbContext.Carts.ToList()
            //      join b in _dbContext.CartDetails.ToList() on a.UserId equals b.UserId
            //      join c in _dbContext.ProductDetails.ToList() on b.IdProductDetails equals c.Id
            //      join d in _dbContext.Rams.ToList() on c.IdRam equals d.Id
            //      join e in _dbContext.Cpus.ToList() on c.IdCpu equals e.Id
            //      join f in _dbContext.HardDrives.ToList() on c.IdHardDrive equals f.Id
            //      join g in _dbContext.Colors.ToList() on c.IdColor equals g.Id
            //      join h in _dbContext.Products.ToList() on c.IdProduct equals h.Id
            //      join i in _dbContext.Manufacturers.ToList() on h.IdManufacturer equals i.Id
            //      join k in _dbContext.Images.ToList() on h.Id equals k.IdProduct
            //      select new CartDetailView
            //      {
            //          UserId = a.UserId,
            //          DescriptionCart = a.Description,
            //          Id = b.Id,
            //          Quantity = b.Quantity,
            //          MaProductDetail = c.Ma,
            //          NameProduct = h.Name,
            //          Price = c.Price,
            //          ThongSoRam = d.ThongSo,
            //          ThongSoHardDrive = f.ThongSo,
            //          NameCpu = e.Name,
            //          LinkImage = k.LinkImage

            //      }
            //      ).ToList();
            return listItemInCart;
        }

        public CartDetail GetCartDetailById(Guid id)
        {
            return _dbContext.CartDetails.Find(id);
        }

        public bool UpdateCartDetail(CartDetail thao)
        {
            try
            {
                var linh = _dbContext.CartDetails.Find(thao.Id);
                linh.Quantity = thao.Quantity;
                _dbContext.CartDetails.Update(linh);
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
