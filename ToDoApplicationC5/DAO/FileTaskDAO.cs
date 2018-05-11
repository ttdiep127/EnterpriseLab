using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace DAO
{
    public class FileTaskDAO : ITaskDAO<Task>
    {
        private int _id = 0;
        private string _fileName;

        public FileTaskDAO()
        {
            _fileName = ConfigurationManager.AppSettings["FilePath"];
        }

        public bool DeleteTask(Task task)
        {
            return false;
        }

        public IList<Task> GetTaskList()
        {
            try
            {
                var taskList = new List<Task>();

                var lines = File.ReadAllLines(_fileName);

                for (int index = 0; index < lines.Length; index++)
                {
                    if (!string.IsNullOrWhiteSpace(lines[index]))
                    {
                        var task = GetTask(lines[index]);
                        taskList.Add(task);
                        _id = task.ID;
                    }
                }

                return taskList;
            }
            catch
            {
                return null;
            }
        }

        private Task GetTask(string line)
        {
            string[] arr = line.Split(',');

            var task = new Task
            {
                ID = Convert.ToInt32(arr[0]),
                Title = arr[1],
                Description = arr[2],
                CreateDate = arr[3].ToDateTime(),
                FinishDate = arr[4].ToDateTime(),
                Type = (KindOfTask)Convert.ToInt32(arr[5])
            };

            return task;
        }

        public bool InsertTask(Task insertTask)
        {
            _id++;
            try
            {
                using (var fileStream = new FileStream(_fileName, FileMode.Append, FileAccess.Write))
                {
                    using (var streamWrite = new StreamWriter(fileStream))
                    {
                        var line = string.Format("{0},{1},{2},{3},{4},{5}", _id.ToString(), insertTask.Title, insertTask.Description, insertTask.CreateDate, insertTask.FinishDate, Convert.ToInt32(insertTask.Type));
                        streamWrite.WriteLine(line);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateTask(Task updateTask)
        {
            try
            {
                string[] values = File.ReadAllLines(_fileName);

                using (var streamWrite = new StreamWriter(_fileName))
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        var task = GetTask(values[i]);
                        if (task.ID == updateTask.ID)
                        {
                            var line = string.Format("{0},{1},{2},{3},{4},{5}", updateTask.ID, updateTask.Title, updateTask.Description, updateTask.CreateDate, updateTask.FinishDate, Convert.ToInt32(updateTask.Type));
                            streamWrite.WriteLine(line);
                        }
                        else
                        {
                            streamWrite.WriteLine(values[i]);
                        }
                    }
                }
                
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
