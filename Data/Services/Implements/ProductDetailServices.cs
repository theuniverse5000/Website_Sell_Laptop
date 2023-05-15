using Data.Models;
using Data.Models.ViewModels;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Implements
{
    public class ProductDetailServices : IProductDetailServices
    {
        ApplicationDbContext _dbContext;
        ICpuServices _cpu;
        IRamServices _ram;
        IHardDriveServices _hardDrive;
        IColorServices _color;
        IProductServices _product;
        IImageServices _image;
        IManufacturerServices _manufacturer;
        public ProductDetailServices()
        {
            _dbContext = new ApplicationDbContext();
            _cpu = new CpuServices();
            _ram = new RamServices();
            _hardDrive = new HardDriveServices();
            _color = new ColorServices();
            _product = new ProductServices();
            _image = new ImageServices();
            _manufacturer = new ManufacturerServices();
        }

        public async Task<bool> CreateProductDetail(ProductDetail obj)
        {
            try
            {
                if (obj == null) return true;
                else
                {
                    await _dbContext.ProductDetails.AddAsync(obj);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteProductDetail(Guid id)
        {
            try
            {
                var productDetail = await _dbContext.ProductDetails.FindAsync(id);
                if (productDetail == null) return false;
                else
                {
                    _dbContext.ProductDetails.Remove(productDetail);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<ProductDetail>> GetAllProductDetails()
        {
            return await _dbContext.ProductDetails.ToListAsync();
        }

        public Task<List<ProductDetailView>> GetAllProductDetailsPhunData()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDetailView> GetChiTietProductDetails(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDetail> GetProductDetailById(Guid id)
        {
            return await _dbContext.ProductDetails.FindAsync(id);
        }

        public async Task<bool> IsMaProductDetailExist(string ma)
        {
            var productDetails = await _dbContext.ProductDetails.ToListAsync();
            var t = productDetails.FirstOrDefault(x => x.Ma == ma);
            if (t == null) return false;
            else return true;
        }

        public async Task<bool> UpdateProductDetail(ProductDetail obj)
        {
            try
            {
                if (obj == null) return false;
                else
                {
                    var productDetail = _dbContext.ProductDetails.Find(obj.Id);
                    productDetail.ImportPrice = obj.ImportPrice;
                    productDetail.Price = obj.Price;
                    productDetail.AvailableQuantity = obj.AvailableQuantity;
                    productDetail.Description = obj.Description;
                    productDetail.Status = obj.Status;
                    _dbContext.ProductDetails.Update(productDetail);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> UpdateSoLuong(Guid id, int soLuong)
        {
            try
            {
                var productDetail = _dbContext.ProductDetails.Find(id);
                productDetail.AvailableQuantity -= soLuong;
                _dbContext.ProductDetails.Update(productDetail);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //public List<ProductDetailView> GetAllProductDetailsPhunData()
        //{


        //    List<ProductDetailView> listProductDetails = new List<ProductDetailView>();
        //    //listProductDetails = (
        //    //            from a in GetAllProductDetails()
        //    //            join b in _ram.GetAllRams() on a.IdRam equals b.Id
        //    //            join c in _cpu.GetAllCpus() on a.IdCpu equals c.Id
        //    //            join d in _HardDrive.GetAllHardDrives() on a.IdHardDrive equals d.Id
        //    //            join e in _color.GetAllColors() on a.IdColor equals e.Id
        //    //            join f in _product.GetAllProducts() on a.IdProduct equals f.Id
        //    //            join g in _Manufacturer.GetAllManufacturers() on f.IdManufacturer equals g.Id
        //    //            join h in _image.GetAllImages() on f.Id equals h.IdProduct
        //    //            select new ProductDetailView
        //    //            {
        //    //                Id = a.Id,
        //    //                Ma = a.Ma,
        //    //                ImportPrice = a.ImportPrice,
        //    //                Price = a.Price,
        //    //                AvailableQuantity = a.AvailableQuantity,
        //    //                Status = a.Status,
        //    //                Description = a.Description,
        //    //                ThongSoRam = b.ThongSo,
        //    //                MaRam = b.Ma,
        //    //                NameCpu = c.Name,
        //    //                MaCpu = c.Ma,
        //    //                ThongSoHardDrive = d.ThongSo,
        //    //                MaHardDrive = d.Ma,
        //    //                NameColor = e.Name,
        //    //                MaColor = e.Ma,
        //    //                NameProduct = f.Name,
        //    //                NameProduce = g.Name,
        //    //                LinkImage = h.LinkImage

        //    //            }

        //    //   ).ToList();
        //    return listProductDetails;
        //}
        //public ProductDetailView GetChiTietProductDetails(Guid Id)
        //{


        //    ProductDetailView ProductDetails = new ProductDetailView();
        //    ProductDetails = GetAllProductDetailsPhunData().FirstOrDefault(a => a.Id == Id);
        //    return ProductDetails;
        //}


    }
}
