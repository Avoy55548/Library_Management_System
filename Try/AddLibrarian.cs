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

       


        






       


       

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            
          
            


            // You can add more textboxes similarly
        }
        private void pbxAL_Click(object sender, EventArgs e)
        {

        }

        private void btnClearAL_Click(object sender, EventArgs e)
        {
            this.txtUserIDAL.Clear();
            this.txtPasswordAL.Clear();
            this.txtEmailAL.Clear();
            this.txtPhoneNumberAL.Clear();
            this.dtpDateOfBirthAL.Text = "";
            this.cmbGenderAL.Text = "";
            this.txtSalaryAL.Clear();
        }
    }
}
