using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;

namespace BookStore.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            var productFromDb = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (productFromDb != null)
            {
                productFromDb.Title = product.Title;
                productFromDb.ISBN = product.ISBN;
                productFromDb.ListPrice = product.ListPrice;
                productFromDb.Price = product.Price;
                productFromDb.Price50 = product.Price50;
                productFromDb.Price100 = product.Price100;
                productFromDb.Description = product.Description;    
                productFromDb.CategoryId = product.CategoryId;
                productFromDb.Author = product.Author;
                if (product.ImageUrl != null)
                {
                    productFromDb.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}
