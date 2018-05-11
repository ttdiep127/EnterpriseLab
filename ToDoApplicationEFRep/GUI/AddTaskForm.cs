using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ToDoApplication.Logic.Entities;
using ToDoApplication.Logic.Utilities;
using ToDoApplication.Service;

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
            lbInvalidTitle.Visible = false;
            lbInvalidDate.Visible = false;

            var isValidTask = true;

            if (string.IsNullOrWhiteSpace(newTask.Title))
            {
                lbInvalidTitle.Text = "The title is required!";
                lbInvalidTitle.Visible = true;
                isValidTask = false;
            }

            if (newTask.FinishDate < newTask.CreateDate)
            {
                lbInvalidDate.Visible = true;
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
                    task.TypeID = (int)KindOfTask.Backlog;
                    break;
                case "Resolved":
                    task.TypeID = (int)KindOfTask.Resolved;
                    break;
                case "Closed":
                    task.TypeID = (int)KindOfTask.Closed;
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

            var categoryService = new CategoryService();

            cbType.DisplayMember = "TypeName";

            cbType.DataSource = categoryService.GetAll();
        }
    }
}
