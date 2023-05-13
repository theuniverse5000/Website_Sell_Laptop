using Data.Models;

namespace Data.Services.Interfaces
{
    public interface IProductServices
    {
        bool CreateProduct(Product p);
        bool UpdateProduct(Product p);
        bool DeleteProduct(Guid id);// khi xóa k tạo ra form mới
        bool IsNameProductExist(string name);

        List<Product> GetAllProducts();

        Product GetProductById(Guid id);
        List<Product> GetProductByName(string name);

        // xóa hàng loạt
        // sửa hàng loạt
    }
}
