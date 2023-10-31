using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Tâm linh", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Văn học", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Lập trình", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, 
                    Title = "Tử Thư Tây Tạng (Tây Tạng Sinh Tử Kỳ Thư)", 
                    Author = "Liên Hoa Sinh, Nguyên Phong", 
                    Description = "Tibetan Book of the Dead",
                    ISBN = "9781570627477",
                    ListPrice = 285000,
                    Price = 285000,
                    Price50 = 285000,
                    Price100 = 285000,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 2,
                    Title = "Nỗi buồn chiến tranh",
                    Author = "Bảo Ninh",
                    Description = "The Sorrow of War",
                    ISBN = "1573225436",
                    ListPrice = 300000,
                    Price = 300000,
                    Price50 = 300000,
                    Price100 = 300000,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    Title = "Người Cảm Tình Viên",
                    Author = "Nguyễn Thanh Việt",
                    Description = "The Sympathizer",
                    ISBN = "1543618022",
                    ListPrice = 360000,
                    Price = 360000,
                    Price50 = 360000,
                    Price100 = 360000,
                    CategoryId = 3,
                    ImageUrl = ""
                }
                );
        }
    }
}
