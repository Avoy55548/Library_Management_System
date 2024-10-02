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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void addBooksToolStripMenuIte_Click(object sender, EventArgs e)
        {
            AddBooks ab = new AddBooks();
            ab.Show();
        }

        private void ViewBooksToolStripMenuIte_Click(object sender, EventArgs e)
        {
            ViewBookInfo vbi = new ViewBookInfo();
            vbi.Show();
        }


        private void AddLibrariantoolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLibrarian al = new AddLibrarian();
            al.Show();
        }


        private void ViewLibrariantoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewLibrarianInfo vli = new ViewLibrarianInfo();
            vli.Show();
        }

        private void LogouttoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out??", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
                Login lg = new Login();
            }
        }

        private void AddStudenttoolStripMIAdminD_Click(object sender, EventArgs e)
        {
            AddStudentInfo asi = new AddStudentInfo();
            asi.Show();
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBooks ib = new IssueBooks();
            ib.Show();
        }

        private void retrunBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook rb = new ReturnBook();
            rb.Show();
        }

        private void ViewStudenttoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudentInfo vsi = new ViewStudentInfo();
            vsi.Show();
        }

        private void issueReturnInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueReturnBookInfo irbi = new IssueReturnBookInfo();
            irbi.Show();
        }
    }
}
