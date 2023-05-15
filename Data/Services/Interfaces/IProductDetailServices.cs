using Data.Models;
using Data.Models.ViewModels;

namespace Data.Services.Interfaces
{
    public interface IProductDetailServices
    {
        Task<bool> CreateProductDetail(ProductDetail obj);
        Task<bool> UpdateProductDetail(ProductDetail obj);
        Task<bool> DeleteProductDetail(Guid id);
        Task<List<ProductDetail>> GetAllProductDetails();
        Task<List<ProductDetailView>> GetAllProductDetailsPhunData();
        Task<ProductDetail> GetProductDetailById(Guid id);
        //List<ProductDetail> GetProductDetailByName(string ProductDetailname);
        Task<ProductDetailView> GetChiTietProductDetails(Guid id);
        Task<bool> IsMaProductDetailExist(string ma);
        Task<bool> UpdateSoLuong(Guid id, int soLuong);
    }
}
