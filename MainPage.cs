using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_IGNOUAMS
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser user = new AddUser();
            user.Show();
            user.MdiParent = this;

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewUSers vu = new ViewUSers();
            vu.Show();
            vu.MdiParent = this;
        }
    }
}
