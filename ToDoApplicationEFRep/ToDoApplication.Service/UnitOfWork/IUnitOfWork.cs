
using ToDoApplication.Logic.Repositories;

namespace ToDoApplication.Logic.UnitOfWork
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity: class;
        void BeginTransaction();
        bool Commit();
        void Rollback();
    }
}
