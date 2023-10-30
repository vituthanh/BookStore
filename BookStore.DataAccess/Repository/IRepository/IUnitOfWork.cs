namespace BookStore.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }

        void SaveChanges();
    }
}
