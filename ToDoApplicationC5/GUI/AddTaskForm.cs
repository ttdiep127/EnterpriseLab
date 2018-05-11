using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class AddTaskForm : Form
    {

        public AddTaskForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newTask = GetValue();

            if (IsValidTask(newTask))
            {
                addNewTask(newTask);
                this.Close();
            }
        }

        private bool IsValidTask(Task newTask)
        {
            lbTitleEmpty.Visible = false;
            lbInValidDate.Visible = false;

            var isValidTask = true;

            if (string.IsNullOrWhiteSpace(newTask.Title))
            {
                lbTitleEmpty.Visible = true;
                isValidTask = false;
            }

            if (newTask.FinishDate < newTask.CreateDate)
            {
                lbInValidDate.Visible = true;
                isValidTask = false;
            }

            return isValidTask;
        }

        private Task GetValue()
        {
            var task = new Task
            {
                Title = tbTitle.Text,
                Description = tbDescription.Text,
                CreateDate = dtpCreate.Value,
                FinishDate = dtpFinish.Value
            };

            switch (cbType.Text)
            {
                case "Backlog":
                    task.Type = KindOfTask.Backlog;
                    break;
                case "Resolved":
                    task.Type = KindOfTask.Resolved;
                    break;
                case "Closed":
                    task.Type = KindOfTask.Closed;
                    break;
            }

            return task;
        }

        public delegate void AddNewTask(Task newTask);
        public AddNewTask addNewTask;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddTaskForm_Load(object sender, EventArgs e)
        {
            var type = new List<string>
            {
                KindOfTask.Backlog.ToString(),
                KindOfTask.Resolved.ToString(),
                KindOfTask.Closed.ToString()
            };

            cbType.DataSource = type;
        }
    }
}
