
using System;

namespace DTO
{
    public class Task
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime FinishDate { get; set; }
        public KindOfTask Type { get; set; }

        public Task()
        {
        }
    }
}
