using System;

namespace ToDoApplication
{
    public class Task
    {
        public string TaskTitle { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime FinishDate { get; set; }
        public KindOfTask Type { get; set; }
 
        public Task(string title, string desc, DateTime createDate, DateTime finishDate, KindOfTask type)
        {
            TaskTitle = title;
            Description = desc;
            CreateDate = createDate;
            FinishDate = finishDate;
            Type = type;
        }

        public Task()
        {
        }
    }
}