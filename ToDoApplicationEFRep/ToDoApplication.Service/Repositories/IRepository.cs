using System.Collections.Generic;
using ToDoApplication.Logic.DataContext;

namespace ToDoApplication.Logic.Repositories
{
    public interface IRepository<TEntity> where TEntity: class
    {
        IDataContext Session { get; }

        //CRUD
        IList<TEntity> GetAll();
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        //bool Delete(TEntity entity);
    }
}
