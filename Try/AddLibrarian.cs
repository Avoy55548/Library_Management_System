using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing.Printing;

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class AddLibrarian : Form
    {

        private PrintDocument printDocument1 = new PrintDocument(); // PrintDocument instance
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog(); // PrintPreviewDialog instance

        public AddLibrarian()
        {
            InitializeComponent();
            this.txtEmailAL.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmailAL_Validating);
            printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument1_PrintPage);
        }

        private void txtEmailAL_Validating(object sender, CancelEventArgs e)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Simple email pattern
            if (!Regex.IsMatch(txtEmailAL.Text, emailPattern))
            {
                MessageBox.Show("Please enter a valid email address (e.g. xxxxxx@email.com).", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
















    }
}
