using Data.Models;
using Data.Models.ViewModels;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Implements
{
    public class ProductDetailServices : IProductDetailServices
    {
        ApplicationDbContext _dbContext;
        public ProductDetailServices()
        {
            _dbContext = new ApplicationDbContext();
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

        public async Task<List<ProductDetailView>> GetAllProductDetailsPhunData()
        {
            List<ProductDetailView> listProductDetails = new List<ProductDetailView>();
            listProductDetails = (
                        from a in await _dbContext.ProductDetails.ToListAsync()
                        join b in await _dbContext.Rams.ToListAsync() on a.IdRam equals b.Id
                        join c in await _dbContext.Cpus.ToListAsync() on a.IdCpu equals c.Id
                        join d in await _dbContext.HardDrives.ToListAsync() on a.IdHardDrive equals d.Id
                        join e in await _dbContext.Colors.ToListAsync() on a.IdColor equals e.Id
                        join f in await _dbContext.CardVGAs.ToListAsync() on a.IdCardVGA equals f.Id
                        join g in await _dbContext.Screens.ToListAsync() on a.IdScreen equals g.Id
                        // join h in await _dbContext.Images.ToListAsync() on a.Id equals h.IdProductDetail
                        join i in await _dbContext.Products.ToListAsync() on a.IdProduct equals i.Id
                        join k in await _dbContext.Manufacturers.ToListAsync() on i.IDManufacturer equals k.Id

                        select new ProductDetailView
                        {
                            Id = a.Id,
                            Ma = a.Ma,
                            ImportPrice = a.ImportPrice,
                            Price = a.Price,
                            AvailableQuantity = a.AvailableQuantity,
                            Status = a.Status,
                            Description = a.Description,
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
                            MaCardVGA = f.Ma,
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
            return listProductDetails;
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
