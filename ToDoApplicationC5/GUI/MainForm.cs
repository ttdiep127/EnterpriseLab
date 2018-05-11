using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        private IList<Task> _tasks;
        private TaskBLL _objBLL;
        private bool _inSQLDatabase;

        public MainForm(bool inSQLDatabase)
        {
            InitializeComponent();
            _inSQLDatabase = inSQLDatabase;
            _objBLL = new TaskBLL(_inSQLDatabase);
            UploadDataToListView();
        }

        private void UploadDataToListView()
        {
            //Set field is displayed is Title of Task
            lstBacklog.DisplayMember = "Title";
            lstResolved.DisplayMember = "Title";
            lstClosed.DisplayMember = "Title";

            _tasks = _objBLL.GetTaskList();
            LoadDataFromDataBase();
        }

        private void LoadDataFromDataBase()
        {
            lstBacklog.Items.Clear();
            lstClosed.Items.Clear();
            lstResolved.Items.Clear();

            if (_tasks != null)
            {
                foreach (var task in _tasks)
                {
                    switch (task.Type)
                    {
                        case KindOfTask.Backlog:
                            lstBacklog.Items.Add(task);
                            break;
                        case KindOfTask.Resolved:
                            lstResolved.Items.Add(task);
                            break;
                        case KindOfTask.Closed:
                            lstClosed.Items.Add(task);
                            break;
                        default: break;
                    }
                }
            }
        }

        public void AddNewTask(Task task)
        {
            if (!_objBLL.Save(task))
            {
                MessageBox.Show("Can't save!");
            }

            UploadDataToListView();
        }


        private void ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            lstBacklog.AllowDrop = true;
            var lstCopy = (ListBox)sender;
            var task = lstCopy.SelectedItem as Task;

            if (e.Button == MouseButtons.Left && e.Clicks == 1 && task != null)
            {
                lstCopy.DoDragDrop(task, DragDropEffects.Copy);
            }
        }

        private void ListBox_DragDrop(object sender, DragEventArgs e)
        {
            var task = (Task)e.Data.GetData(typeof(Task));
            var listBox = (ListBox)sender;

            task.Type = GetStatusByListBox(listBox);

            if (!_objBLL.Save(task))
            {
                MessageBox.Show("Can not Remove!");
            }

            UploadDataToListView();
        }

        private void ListBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private KindOfTask GetStatusByListBox(ListBox listBox)
        {
            if (listBox == lstResolved)
            {
                return KindOfTask.Resolved;
            }
            else if (listBox == lstClosed)
            {
                return KindOfTask.Closed;
            }

            return KindOfTask.Backlog;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
