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
    public partial class StudentDashboard : Form
    {
        //here btn for studentdashboard
        public StudentDashboard()
        {
            InitializeComponent();


        }

        private void btnBH_Click(object sender, EventArgs e)

        {
            BorrowHistory BH = new BorrowHistory();
            BH.Show();
        }

        private void btnViewBooks_Click(object sender, EventArgs e)

        {
            ViewBookInfo vb = new ViewBookInfo();
            vb.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)

        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)

        {

        }
    }
}
