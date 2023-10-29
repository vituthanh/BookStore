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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Tâm linh", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Văn học", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Lập trình", DisplayOrder = 3 }
                );
        }
    }
}
