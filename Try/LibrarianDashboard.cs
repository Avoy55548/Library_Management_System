using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class LibrarianDashboard : Form
    {
        public LibrarianDashboard()
        {
            InitializeComponent();
        }

        private void addBooksToolStripMenuIte_Click_1(object sender, EventArgs e)
        {
            AddBooks ab = new AddBooks();
            ab.Show();
        }

        private void ViewBooksToolStripMenuIte_Click(object sender, EventArgs e)
        {
            ViewBookInfo vbi = new ViewBookInfo();
            vbi.Show();
        }

        private void LogouttoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out??", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
                Login lg = new Login();
                lg.Show();
            }
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBooks ib = new IssueBooks();
            ib.Show();
        }

        // Return book 
        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook rb = new ReturnBook();
            rb.Show();
        }

        private void ViewStudenttoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudentInfo vsi = new ViewStudentInfo();
            vsi.Show();
        }
        // add student
        private void AddStudenttoolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentInfo Stu = new AddStudentInfo();
            Stu.Show();
        }

        private void issueReturnBookInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueReturnBookInfo irbi = new IssueReturnBookInfo();
            irbi.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Accounts ac = new Accounts();
            ac.Show();
        }

       
    }
}
