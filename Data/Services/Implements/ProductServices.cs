using Data.Models;
using Data.Services.Interfaces;

namespace Data.Services.Implements
{
    public class ProductServices : IProductServices
    {
        ApplicationDbContext _dbContext;
        public ProductServices()
        {
            _dbContext = new ApplicationDbContext();
        }
        public bool CreateProduct(Product p)
        {
            try
            {
                _dbContext.Products.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct(Guid id)
        {
            try
            {
                // var là từ khóa - không phải hiểu dữ liệu
                // dynamic là kiểu dữ liệu
                // find(id) chỉ dùng đc khi id là khóa chính
                //dynamic dproduct = _dbContext.Products.Find(id);
                var dproduct = _dbContext.Products.Find(id);
                _dbContext.Products.Remove(dproduct);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
            // _dbContext.Products ở dạng DbSet
            // không tác động đến db lên chỉ có 2 khả năng lỗi :+server or code nên k cần try catch
        }

        public Product GetProductById(Guid id)
        {
            return _dbContext.Products.Find(id);
            //  return _dbContext.Products.FirstOrDefault(a=>a.Id == id); 
            // nếu khồng có trả về Default
            // trả về cái đầu tiên
            //  return _dbContext.Products.SingleOrDefault(a => a.Id == id);
            // khi không có sinh ra ngoại lệ ex
            //(a => a.Id == id) là lamdaExpression
            // Predicate : Call back đến hàm kiểm tra
        }

        public List<Product> GetProductByName(string name)
        {
            return _dbContext.Products.Where(a => a.Name.Contains(name)).ToList();
        }

        public bool IsNameProductExist(string name)
        {
            var linh = _dbContext.Products;
            var thao = linh.FirstOrDefault(l => l.Name == name);
            if (thao != null) return true;
            else return false;
        }

        public bool UpdateProduct(Product p)
        {
            try
            {
                // var là từ khóa - không phải hiểu dữ liệu
                // dynamic là kiểu dữ liệu
                // find(id) chỉ dùng đc khi id là khóa chính
                //dynamic dproduct = _dbContext.Products.Find(id);
                var uProduct = _dbContext.Products.Find(p.Id);
                uProduct.Name = p.Name;
                // thêm thuộc tính
                _dbContext.Products.Update(uProduct);
                // tính checking của entityfamework
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
