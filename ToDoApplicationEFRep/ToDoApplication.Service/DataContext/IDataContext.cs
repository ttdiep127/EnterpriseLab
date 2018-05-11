using System;


namespace ToDoApplication.Logic.DataContext
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
    }
}
