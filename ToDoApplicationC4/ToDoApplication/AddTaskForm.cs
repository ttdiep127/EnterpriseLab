using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoApplication
{
    public partial class AddTaskForm : Form
    {
        public AddTaskForm()
        {
            InitializeComponent();
            LoadDataToForm();
        }

        private void LoadDataToForm()
        {
            List<string> type = new List<string>();

            type.Add(KindOfTask.Backlog.ToString());
            type.Add(KindOfTask.Resolved.ToString());
            type.Add(KindOfTask.Closed.ToString());

            cbType.DataSource = type;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Task newTask = GetValue();
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

            var check = true;

            if (string.IsNullOrWhiteSpace(newTask.TaskTitle))
            {
                lbTitleEmpty.Visible = true;
                check = false;
            }

            if (newTask.FinishDate < newTask.CreateDate)
            {
                lbInValidDate.Visible = true;
                check = false;
            }

            return check;
        }

        private Task GetValue()
        {
            var task = new Task();

            task.TaskTitle = tbTitle.Text;
            task.Description = tbDescription.Text;
            task.CreateDate = dtpCreate.Value;
            task.FinishDate = dtpFinish.Value;

            switch (cbType.Text)
            {
                case "Backlog":
                    task.Type = KindOfTask.Backlog;
                    break;
                case "Resovled":
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
    }
}
