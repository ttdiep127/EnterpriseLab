using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ToDoApplication.Logic.Entities;
using ToDoApplication.Logic.Services;
using ToDoApplication.Logic.Utilities;
using ToDoApplication.Service;

namespace GUI
{
    public partial class MainForm : Form
    {
        private ITaskService _taskService;
        private Task _taskDrag;
        private IList<Task> _listTask;

        public MainForm()
        {
            InitializeComponent();
            
            _taskService = new TaskService();

            _listTask = _taskService.GetTasks();

            UploadDataToListView(_listTask);
        }

        private void UploadDataToListView(IList<Task> allTasks)
        {
            BindDataToList(lstBacklog, KindOfTask.Backlog, allTasks);
            BindDataToList(lstResolved, KindOfTask.Resolved, allTasks);
            BindDataToList(lstClosed, KindOfTask.Closed, allTasks);
        }

        private void BindDataToList(ListBox listBox, KindOfTask taskType, IList<Task> tasks)
        {
            listBox.DisplayMember = "Title";

            var backlogType = (int)taskType;
            var backlogs = tasks.Where(_ => _.TypeID == backlogType).ToArray();
            listBox.Items.AddRange(backlogs);
        }


        public void AddNewTask(Task task)
        {
            _listTask.Add(task);
            if (!_taskService.SaveTasks(_listTask))
            {
                MessageBox.Show("Can't save!");
            }

            UploadDataToListView(_listTask);
        }


        private void lstBacklog_MouseDown(object sender, MouseEventArgs e)
        {
            lstBacklog.AllowDrop = true;
            var lstCopy = (ListBox)sender;
            var task = lstCopy.SelectedItem as Task;

            if (e.Button == MouseButtons.Left && e.Clicks == 1 && task != null)
            {
                _taskDrag = task;
                lstCopy.DoDragDrop(task, DragDropEffects.Copy);
            }
        }

        private void lstBacklog_DragDrop(object sender, DragEventArgs e)
        {

            var task = _taskDrag;
            var listBox = sender as ListBox;
            
            if ( task.TypeID != GetStatusByListBox(listBox))
            {
                task.TypeID = GetStatusByListBox(listBox);

                if (!_taskService.SaveTasks(_listTask))
                {
                    MessageBox.Show("Can not Remove!");
                }

                UploadDataToListView(_listTask);
            }
            
        }

        private void lstBacklog_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private int GetStatusByListBox(ListBox listBox)
        {
            if (listBox == lstResolved)
            {
                return (int)KindOfTask.Resolved;
            }
            else if (listBox == lstClosed)
            {
                return (int)KindOfTask.Closed;
            }

            return (int)KindOfTask.Backlog;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddTaskForm()
            {
                addNewTask = new AddTaskForm.AddNewTask(AddNewTask)
            };

            addForm.ShowDialog();
        }
    }
}
