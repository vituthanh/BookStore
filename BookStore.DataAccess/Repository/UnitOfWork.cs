using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;

namespace BookStore.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICategoryRepository CategoryRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            CategoryRepository = new CategoryRepository(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
