using DAO;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class TaskBLL
    {
        private ITaskDAO<Task> _objDAO;
        private FileTaskDAO objDAO; // Concrete class

        public TaskBLL(bool inSQLDatabase)
        {
            if (inSQLDatabase)
            {
                _objDAO = new SQLTaskDAO();
            }
            else
            {
                _objDAO = new FileTaskDAO();
            }
        }

        public IList<Task> GetTaskList()
        {
             return _objDAO.GetTaskList();
        }

        public bool Save(Task task)
        {
            if (task.ID == 0)
            {
                return _objDAO.InsertTask(task);
            }
            else
            {
                return _objDAO.UpdateTask(task);
            }
        }
    }
}
