using System.Collections.Generic;
using ToDoApplication.Logic.Entities;
using ToDoApplication.Logic.Repositories;
using ToDoApplication.Logic.Services;

namespace ToDoApplication.Service
{
    public class TaskService : BaseService<Task>, ITaskService
    {

        private readonly ITaskRepository _taskRepository;

        public TaskService()
        {
            _taskRepository = _unitOfWork.Repository<Task>() as ITaskRepository;
        }

        public IList<Task> GetTasks()
        {
            return _taskRepository.GetAll();
        }

        public bool SaveTasks(IList<Task> tasks, bool saveChangesImmediately = true)
        {
            foreach (var entity in tasks)
            {
                if (entity.ID == 0)
                {
                    _taskRepository.Add(entity);
                }
                else
                {
                    _taskRepository.Update(entity);
                }
            }

            if (saveChangesImmediately)
            {
                _unitOfWork.SaveChanges();
            }

            return true;
        }
    }
}
