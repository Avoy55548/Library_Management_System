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



        private PrintDocument printDocument1 = new PrintDocument(); // PrintDocument instance
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog(); // PrintPreviewDialog instance
        public AddStudentInfo()
        {
            InitializeComponent();


            this.txtEmailAS.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmailAS_Validating);


            printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument1_PrintPage);
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

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

            Font printFont = new Font("Arial", 12);
            Brush printBrush = Brushes.Black;


            e.Graphics.DrawString("Student Name: " + txtStudentNameAS.Text, printFont, printBrush, 100, 100);
            e.Graphics.DrawString("Enroll Number: " + txtEnrollNoAS.Text, printFont, printBrush, 100, 130);
            e.Graphics.DrawString("Phone Number: " + txtPhoneNumberAS.Text, printFont, printBrush, 100, 160);
            e.Graphics.DrawString("Address: " + txtAddressAS.Text, printFont, printBrush, 100, 190);
            e.Graphics.DrawString("Email: " + txtEmailAS.Text, printFont, printBrush, 100, 220);
            e.Graphics.DrawString("Date Of Birth: " + dtpDateOfBirthAS.Text, printFont, printBrush, 100, 250);




        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Times New Roman", 20);
            float yPos = 100;
            int leftMargin = 50;


            g.DrawString("Membership Card", new Font("Times New Roman", 26, FontStyle.Bold), Brushes.Black, leftMargin, yPos);
            yPos += 40;


            g.DrawString("Student Name:  " + txtStudentNameAS.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Enroll Number: " + txtEnrollNoAS.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Phone Number: " + txtPhoneNumberAS.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Address: " + txtAddressAS.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Email: " + txtEmailAS.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Date Of Birth: " + dtpDateOfBirthAS.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;


        }

        
    }
}
