using ToDoApplication.Logic.DataContext;
using ToDoApplication.Logic.Entities;
using ToDoApplication.Logic.Repositories;

namespace ToDoApplication.Repository
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(IDataContext dataContext) 
            : base(dataContext)
        {
           
        }
    }
}