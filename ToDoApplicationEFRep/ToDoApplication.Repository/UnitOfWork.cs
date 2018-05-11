using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using ToDoApplication.Logic.DataContext;
using ToDoApplication.Logic.Entities;
using ToDoApplication.Logic.Repositories;
using ToDoApplication.Logic.UnitOfWork;
using ToDoApplication.Service.Entities;

namespace ToDoApplication.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDataContext _dataContext;
        private Dictionary<string, object> _repositories;
        private bool _disposed;
        private ObjectContext _objectContext;
        private DbTransaction _transaction;

        #region Construtor/Dipose

        public UnitOfWork()
        {
            _dataContext = new TaskStore2Entities();
            _repositories = new Dictionary<string, object>();

        }

        public void Dispose()
        {
            if (_objectContext != null && _objectContext.Connection.State == ConnectionState.Open)
                _objectContext.Connection.Close();

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _dataContext.Dispose();
            }
            _disposed = true;
        }
        #endregion Constructer/Dispose

        public int SaveChanges()
        {
            int i = 0;
            i = _dataContext.SaveChanges();

            return i;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {

            var entityType = typeof(TEntity).Name.ToUpper();

            if (_repositories.ContainsKey(entityType))
                return (IRepository<TEntity>)_repositories[entityType];

            object entityRepository = null;

            switch (entityType)
            {
                case "TASK":
                    entityRepository = new TaskRepository(_dataContext);
                    break;
                case "CATEGORY":
                    entityRepository = new CategoryRepository(_dataContext);
                    break;
                default:
                    return null;
            }

            _repositories.Add(entityType, entityRepository);

            return (IRepository<TEntity>)_repositories[entityType];
        }

        #region Unit of Work Transactions

        public void BeginTransaction()
        {
            _objectContext = ((IObjectContextAdapter)_dataContext).ObjectContext;
            if (_objectContext.Connection.State != ConnectionState.Open)
            {
                _objectContext.Connection.Open();
            }
            _transaction = _objectContext.Connection.BeginTransaction();
        }

        public bool Commit()
        {
            _dataContext.SaveChanges();

            if (_transaction != null)
            {
                _transaction.Commit();
            }

            return true;
        }

        public void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
        }

        #endregion
    }
}
