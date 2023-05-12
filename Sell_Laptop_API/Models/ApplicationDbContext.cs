using Sell_Laptop_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Sell_Laptop_API.Configurations;

namespace Sell_Laptop_API.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Cpu> Cpus { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<Ssd> Ssds { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
              optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3S9P0UC\SQLEXPRESS;Initial Catalog=Sell_Laptop_API;Persist Security Info=True;User ID=theuniverse;Password=theuniverse");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new BillConfigurations());
            modelBuilder.ApplyConfiguration(new BillDetailConfigurations());
            modelBuilder.ApplyConfiguration(new ProductConfigurations());
            modelBuilder.ApplyConfiguration(new ProductDetailConfigurations());
            modelBuilder.ApplyConfiguration(new CartConfigurations());
            modelBuilder.ApplyConfiguration(new CartDetailConfigurations());
            modelBuilder.ApplyConfiguration(new ColorConfigurations());
            modelBuilder.ApplyConfiguration(new CpuConfigurations());
            modelBuilder.ApplyConfiguration(new RamConfigurations());
            modelBuilder.ApplyConfiguration(new SsdConfigurations());
            modelBuilder.ApplyConfiguration(new ImageConfigurations());
            modelBuilder.ApplyConfiguration(new ProducerConfigurations()); 
            modelBuilder.ApplyConfiguration(new RoleConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations()); 
            modelBuilder.ApplyConfiguration(new VoucherConfigurations());
        }


    }
}
