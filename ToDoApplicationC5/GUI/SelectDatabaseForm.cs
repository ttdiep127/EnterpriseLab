using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class SelectDatabaseForm : Form
    {
        public SelectDatabaseForm()
        {
            InitializeComponent();
        }

        private void SQLServerbtn_Click(object sender, EventArgs e)
        {
            using (var mainForm = new MainForm(true))
            {
                Hide();
                mainForm.ShowDialog();
            }
            Show();
        }

        private void filebtn_Click(object sender, EventArgs e)
        {
            using (var mainForm = new MainForm(false))
            {
                Hide();
                mainForm.ShowDialog();
            }
            Show();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectDatabaseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
