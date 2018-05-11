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
    public partial class MainUIForm : Form
    {
        private List<Task> Tasks ;

        public MainUIForm()
        {
            InitializeComponent();

            Tasks = new List<Task>();
            AddSomeTaskForDisplay();

            UploadDataToListView();
        }

        private void UploadDataToListView()
        {
            lstBacklog.DisplayMember = "TaskTitle";
            lstResolved.DisplayMember = "TaskTitle";
            lstClosed.DisplayMember = "TaskTitle";

            var BacklogTask = Tasks.Where(x => x.Type == KindOfTask.Backlog).ToList();
            var ResolvedTask = Tasks.Where(x => x.Type == KindOfTask.Resolved).ToList();
            var ClosedTask = Tasks.Where(x => x.Type == KindOfTask.Closed).ToList();

            lstBacklog.DataSource = BacklogTask;
            lstResolved.DataSource = ResolvedTask;
            lstClosed.DataSource = ClosedTask;

            lstBacklog.SelectedItem = null;
            lstResolved.SelectedItem = null;
            lstClosed.SelectedItem = null;
        }

        private void AddSomeTaskForDisplay()
        {
            var item1 = new Task("t1", "abc", DateTime.Now, DateTime.Now, KindOfTask.Backlog);
            var item2 = new Task("t2", "abc", DateTime.Now, DateTime.Now, KindOfTask.Backlog);
            var item3 = new Task("t3", "abc", DateTime.Now, DateTime.Now, KindOfTask.Closed);
            var item4 = new Task("t4", "abc", DateTime.Now, DateTime.Now, KindOfTask.Resolved);
            var item5 = new Task("t5", "abc", DateTime.Now, DateTime.Now, KindOfTask.Resolved);

            Tasks.Add(item1);
            Tasks.Add(item2);
            Tasks.Add(item3);
            Tasks.Add(item4);
            Tasks.Add(item5);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddTaskForm
            {
                addNewTask = new AddTaskForm.AddNewTask(AddNew)
            };
            addForm.ShowDialog();
        }

        public void AddNew(Task task)
        {
            Tasks.Add(task);
            UploadDataToListView();
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstBacklog_MouseDown(object sender, MouseEventArgs e)
        {
            lstBacklog.AllowDrop = true;
            var lstCopy = (ListBox)sender;
            var task = lstCopy.SelectedItem as Task;

            if (e.Button == MouseButtons.Left && e.Clicks == 1 && task != null)
            {
                lstCopy.DoDragDrop(task, DragDropEffects.Copy);
            }
        }

        private void lstBacklog_DragDrop(object sender, DragEventArgs e)
        {
            lstBacklog.Items.Add(e.Data);
        }

        private void lstBacklog_DragEnter(object sender, DragEventArgs e)
        {
            var task = (Task)e.Data.GetData(typeof(Task));
            var listBox = (ListBox)sender;

            Tasks[Tasks.IndexOf(task)].Type = GetStatusByListBox(listBox);

            UploadDataToListView();
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
    }
}
