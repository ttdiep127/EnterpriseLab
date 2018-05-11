using System.Collections.Generic;

namespace ToDoApplication.Logic.Service
{
    public interface IBaseService<TEntity>
    {
        IList<TEntity> GetAll();
        TEntity Add(TEntity entity, bool saveChangesImmediately = true);
        TEntity Update(TEntity entity, bool saveChangesImmediately = true);
        //bool Delete(TEntity entity, bool saveChangesImmediately = true);
        
    }
}
