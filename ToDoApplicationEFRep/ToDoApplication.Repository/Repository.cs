
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToDoApplication.Logic.DataContext;
using ToDoApplication.Logic.Entities;
using ToDoApplication.Logic.Repositories;

namespace ToDoApplication.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        private readonly TaskStore2Entities _session = null;

        public IDataContext Session
        {
            get
            {
                return _session;
            }
        }

        public Repository(IDataContext session)
        {
            _session = session as TaskStore2Entities;
        }

        public DbSet<TEntity> Entities
        {
            get
            {
                return _session.Set<TEntity>();
            }
        }

        #region Basic operations
        public virtual IList<TEntity> GetAll()
        {
            return _session.Set<TEntity>().ToList();
        }

        public virtual TEntity Add(TEntity entity)
        {
            try
            {
                _session.Set<TEntity>().Add(entity);

                return entity;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new AppException(ex.InnerException.Message, ex);
                throw new AppException(ex.Message, ex);

            }
        }

        public virtual TEntity Update(TEntity entity)
        {
            try
            {
                if (_session.Entry(entity).State == EntityState.Detached)
                {
                    Entities.Attach(entity);
                }
                _session.Entry(entity).State = EntityState.Modified;

                return entity;
            }
            catch (Exception ex)
            {
                //if (ex.InnerException != null)
                //    throw new AppException(ex.InnerException.Message, ex);

                //throw new AppException(ex.Message, ex);
                return null;
            }
        }

        //public bool Delete(TEntity entity)
        //{
        //    try
        //    {
        //        if (deleteType == DeleteType.SoftDelete)
        //        {
        //            _session.Entry(entity).State = EntityState.Modified;
        //        }
        //        else
        //        {
        //            _session.Entry(entity).State = EntityState.Deleted;
        //        }

        //        return _session.Entry(entity).GetValidationResult().IsValid;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException != null)
        //            throw new AppException(ex.InnerException.Message, ex);

        //        throw new AppException(ex.Message, ex);
        //    }
        //}
        #endregion
    }
}
