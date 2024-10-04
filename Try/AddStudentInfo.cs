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


    public partial class AddStudentInfo : Form
    {



       
        public AddStudentInfo()
        {
            InitializeComponent();


            this.txtEmailAS.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmailAS_Validating);


            
        }



        private void txtEmailAS_Validating(object sender, CancelEventArgs e)
        {

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";


            if (!Regex.IsMatch(txtEmailAS.Text, emailPattern))
            {
                MessageBox.Show("Please enter a valid email address (e.g., xxxxx@gmail.com).", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }



        private bool IsValidToSave()
        {
            if (String.IsNullOrEmpty(this.txtStudentNameAS.Text) || String.IsNullOrEmpty(this.txtEnrollNoAS.Text) ||
                String.IsNullOrEmpty(this.txtPhoneNumberAS.Text) || String.IsNullOrEmpty(this.txtEmailAS.Text) ||
                 String.IsNullOrEmpty(this.txtAddressAS.Text) || String.IsNullOrEmpty(this.dtpDateOfBirthAS.Text) ||
                 String.IsNullOrEmpty(this.dtpDateOfBirthAS.Text) || String.IsNullOrEmpty(this.txtPasswordAS.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;



            if (birthDate.Date > today.AddYears(-age))
                age--;
            return age;
        }


        private void btnClearAS_Click(object sender, EventArgs e)
        {
            this.txtStudentNameAS.Clear();
            this.txtPasswordAS.Clear();
            this.txtEnrollNoAS.Clear();
            this.txtPhoneNumberAS.Clear();
            this.dtpDateOfBirthAS.Text = "";
            this.txtEmailAS.Clear();
            this.txtAddressAS.Clear();
        }

       

        
        }

        
    }
}
