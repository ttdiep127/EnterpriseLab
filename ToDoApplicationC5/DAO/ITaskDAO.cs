using System.Collections.Generic;

namespace DAO
{
    public interface ITaskDAO<Type>
    {
        IList<Type> GetTaskList();
        bool InsertTask(Type task);
        bool UpdateTask(Type task);
        bool DeleteTask(Type task);
    }
}
