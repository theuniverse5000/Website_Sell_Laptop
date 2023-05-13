using Data.Models;
using Data.Models.ViewModels;

namespace Data.Services.Interfaces
{
    public interface IProductDetailServices
    {
        bool CreateProductDetail(ProductDetail thao);
        bool UpdateProductDetail(ProductDetail thao);
        bool DeleteProductDetail(Guid id);
        List<ProductDetail> GetAllProductDetails();
        List<ProductDetailView> GetAllProductDetailsPhunData();
        ProductDetail GetProductDetailById(Guid id);
        //List<ProductDetail> GetProductDetailByName(string ProductDetailname);
        public ProductDetailView GetChiTietProductDetails(Guid Id);
        bool IsMaProductDetailExist(string Ma);
        bool UpdateSoLuong(Guid Id, int SoLuong);
    }
}
