using Data.Models;
using Data.Models.ViewModels;
using Data.Services.Interfaces;

namespace Data.Services.Implements
{
    public class ProductDetailServices : IProductDetailServices
    {
        ApplicationDbContext _dbContext;
        ICpuServices _cpu;
        IRamServices _ram;
        IHardDriveServices _HardDrive;
        IColorServices _color;
        IProductServices _product;
        IImageServices _image;
        IManufacturerServices _Manufacturer;
        public ProductDetailServices()
        {
            _dbContext = new ApplicationDbContext();
            _cpu = new CpuServices();
            _ram = new RamServices();
            _HardDrive = new HardDriveServices();
            _color = new ColorServices();
            _product = new ProductServices();
            _image = new ImageServices();
            _Manufacturer = new ManufacturerServices();
        }
        public bool CreateProductDetail(ProductDetail thao)
        {
            try
            {
                _dbContext.ProductDetails.Add(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool DeleteProductDetail(Guid id)
        {
            try
            {
                var thao = _dbContext.ProductDetails.Find(id);
                _dbContext.ProductDetails.Remove(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<ProductDetail> GetAllProductDetails()
        {
            return _dbContext.ProductDetails.ToList();
        }

        public List<ProductDetailView> GetAllProductDetailsPhunData()
        {


            List<ProductDetailView> listProductDetails = new List<ProductDetailView>();
            //listProductDetails = (
            //            from a in GetAllProductDetails()
            //            join b in _ram.GetAllRams() on a.IdRam equals b.Id
            //            join c in _cpu.GetAllCpus() on a.IdCpu equals c.Id
            //            join d in _HardDrive.GetAllHardDrives() on a.IdHardDrive equals d.Id
            //            join e in _color.GetAllColors() on a.IdColor equals e.Id
            //            join f in _product.GetAllProducts() on a.IdProduct equals f.Id
            //            join g in _Manufacturer.GetAllManufacturers() on f.IdManufacturer equals g.Id
            //            join h in _image.GetAllImages() on f.Id equals h.IdProduct
            //            select new ProductDetailView
            //            {
            //                Id = a.Id,
            //                Ma = a.Ma,
            //                ImportPrice = a.ImportPrice,
            //                Price = a.Price,
            //                AvailableQuantity = a.AvailableQuantity,
            //                Status = a.Status,
            //                Description = a.Description,
            //                ThongSoRam = b.ThongSo,
            //                MaRam = b.Ma,
            //                NameCpu = c.Name,
            //                MaCpu = c.Ma,
            //                ThongSoHardDrive = d.ThongSo,
            //                MaHardDrive = d.Ma,
            //                NameColor = e.Name,
            //                MaColor = e.Ma,
            //                NameProduct = f.Name,
            //                NameProduce = g.Name,
            //                LinkImage = h.LinkImage

            //            }

            //   ).ToList();
            return listProductDetails;
        }
        public ProductDetailView GetChiTietProductDetails(Guid Id)
        {


            ProductDetailView ProductDetails = new ProductDetailView();
            ProductDetails = GetAllProductDetailsPhunData().FirstOrDefault(a => a.Id == Id);
            return ProductDetails;
        }

        public ProductDetail GetProductDetailById(Guid id)
        {
            return _dbContext.ProductDetails.Find(id);
        }

        public bool IsMaProductDetailExist(string Ma)
        {
            var t = GetAllProductDetails().FirstOrDefault(a => a.Ma == Ma);
            if (t == null) return false;
            else return true;
        }

        public bool UpdateProductDetail(ProductDetail thao)
        {
            try
            {
                var linh = _dbContext.ProductDetails.Find(thao.Id);
                linh.ImportPrice = thao.ImportPrice;
                linh.Price = thao.Price;
                linh.AvailableQuantity = thao.AvailableQuantity;
                linh.Description = thao.Description;
                linh.Status = thao.Status;
                _dbContext.ProductDetails.Update(linh);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateSoLuong(Guid Id, int SoLuong)
        {
            try
            {
                var linh = _dbContext.ProductDetails.Find(Id);
                linh.AvailableQuantity -= SoLuong;
                _dbContext.ProductDetails.Update(linh);
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
