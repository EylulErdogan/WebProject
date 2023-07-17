using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Entities;

namespace WebProject.Data
{
    public class WebProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Database bağlantı cümlesi 
            //Connection String gelecek 
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WebProject;Integrated Security=True");
        }
        // Datatbase e her eklediğimiz tablo veya view burayas et edilmeli
        //Property adında Tablo ismi doğru yazılmalıdır 
        // ama nesnenim adı Örnek : User tekli olmalıdır Yani tablo adı Users ama nesnenin adı user olmalıdır.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
	        modelBuilder.Entity<ProductCategory>().HasKey(o => new
	        {
		        o.CategoryId, o.ProductId
	        });
        }
        public DbSet<User> Users { get; set; }
        //4. Tablo buraya eklenmelı 5. adım servise yazılır
        public DbSet<Category> Categories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }
        public DbSet<VwCategoryProduct> VwCategoryProducts { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<VwBasketProductList> VwBasketProductList { get; set; }
        public DbSet<Orders>  Orders { get; set; }
        public DbSet<OrderProduct>  OrderProducts{ get; set; }
        public DbSet<UserAddress> UserAddresses  { get; set; }
    }
}
