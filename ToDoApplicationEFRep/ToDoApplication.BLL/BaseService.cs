using System.Collections.Generic;
using ToDoApplication.Logic.Repositories;
using ToDoApplication.Logic.Service;
using ToDoApplication.Logic.UnitOfWork;
using ToDoApplication.Repository;

namespace ToDoApplication.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseService()
        {
            _unitOfWork = new UnitOfWork();    //ObjectFactory.GetInstance<IUnitOfWork>();
            _repository = _unitOfWork.Repository<TEntity>();
        }

        public IList<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity Add(TEntity entity, bool saveChangesImmediately = true)
        {
            entity = _repository.Add(entity);

            if (saveChangesImmediately)
            {
                _unitOfWork.SaveChanges();
            }

            return entity;

        }

        public TEntity Update(TEntity entity, bool saveChangesImmediately = true)
        {

            entity = _repository.Update(entity);
            if (saveChangesImmediately)
            {
                _unitOfWork.SaveChanges();
            }

            return entity;

        }
    }
}
