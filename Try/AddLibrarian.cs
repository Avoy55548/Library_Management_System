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

       


        






       


        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
           
            
            e.Graphics.DrawString("Librarian Name: " + txtUserIDAL.Text, printFont, printBrush, 100, 100);
            e.Graphics.DrawString("Phone Number: " + txtPhoneNumberAL.Text, printFont, printBrush, 100, 130);
            e.Graphics.DrawString("Email: " + txtEmailAL.Text, printFont, printBrush, 100, 160);
            e.Graphics.DrawString("Date Of Birth: " + dtpDateOfBirthAL.Text, printFont, printBrush, 100, 190);
            e.Graphics.DrawString("Gender: " + cmbGenderAL.Text, printFont, printBrush, 100, 220);
            e.Graphics.DrawString("Salary: " + txtSalaryAL.Text, printFont, printBrush, 100, 250);


            // If you have more textboxes, print them similarly with e.Graphics.DrawString
        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Times New Roman", 20); // Change to Times New Roman
            float yPos = 100; // Starting position for printing
            int leftMargin = 50;

            // Print the header
            g.DrawString("Congratulation!!!!! You have been apointed", new Font("Times New Roman", 26, FontStyle.Bold), Brushes.Black, leftMargin, yPos);
            yPos += 40;

            // Print data from all text boxes
            g.DrawString("Librarian Name:  " + txtUserIDAL.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Phone Number: " + txtPhoneNumberAL.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Email: " + txtEmailAL.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Dath Of Birth: " + dtpDateOfBirthAL.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Gender: " + cmbGenderAL.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Salary: " + txtSalaryAL.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;


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
