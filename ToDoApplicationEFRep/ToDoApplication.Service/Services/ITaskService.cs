using System.Collections.Generic;
using ToDoApplication.Logic.Entities;
using ToDoApplication.Logic.Service;

namespace ToDoApplication.Logic.Services
{
    public interface ITaskService : IBaseService<Task>
    {
        
        IList<Task> GetTasks();

        bool SaveTasks(IList<Task> persons, bool saveChangesImmediately = true);
    }
}
