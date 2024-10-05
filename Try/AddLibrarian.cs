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


        private bool IsValidToSave()
        {
            if (String.IsNullOrEmpty(this.txtUserIDAL.Text) || String.IsNullOrEmpty(this.txtPasswordAL.Text) || String.IsNullOrEmpty(this.txtEmailAL.Text) ||
                String.IsNullOrEmpty(this.txtPhoneNumberAL.Text) || String.IsNullOrEmpty(this.dtpDateOfBirthAL.Text) || String.IsNullOrEmpty(this.cmbGenderAL.Text) ||
                 String.IsNullOrEmpty(this.txtSalaryAL.Text) || String.IsNullOrEmpty(this.txtEnrollAL.Text) || String.IsNullOrEmpty(this.txtAddreAL.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void btnSaveAL_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidToSave())
                {
                    MessageBox.Show("Please fill all the information");
                    return;
                }

                // ======= New Code Added for Age Validation ======= //
                // Check if age is above 18
                DateTime dateOfBirth = DateTime.Parse(dtpDateOfBirthAL.Text); // Get the date of birth from DatePicker
                int age = CalculateAge(dateOfBirth); // Calculate the age based on the birth date


                if (age < 18) // If the age is less than 18
                {
                    MessageBox.Show("You are underage. Age must be 18 or above.", "Underage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop the saving process
                }
                // ================================================ //
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-HQ509SI\SQLEXPRESS01;Initial Catalog=Library_Management_System;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = @"
            INSERT INTO Users (UserName, Password, Enroll, Contact, Email, Address, DOB, Gender,UserType) 
            VALUES (@UserName, @Password, @Enroll, @Contact, @Email, @Address, @DOB, @Gender,2);
            
            INSERT INTO Librarian (Id, Salary) 
            VALUES (SCOPE_IDENTITY(), @Salary);";

                // Adding parameters
                cmd.Parameters.AddWithValue("@UserName", txtUserIDAL.Text);
                cmd.Parameters.AddWithValue("@Password", txtPasswordAL.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmailAL.Text);
                cmd.Parameters.AddWithValue("@Contact", txtPhoneNumberAL.Text);
                cmd.Parameters.AddWithValue("@DOB", dateOfBirth);
                cmd.Parameters.AddWithValue("@Enroll", txtEnrollAL.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddreAL.Text);
                cmd.Parameters.AddWithValue("@Gender", cmbGenderAL.Text);
                cmd.Parameters.AddWithValue("@Salary", Convert.ToDouble(txtSalaryAL.Text)); // Assuming Salary is a double

                // Execute the command
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exc)
            {
                MessageBox.Show("There is an error in your input: " + exc.Message);
            }
        }



        private int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today; // Get the current date
            int age = today.Year - birthDate.Year; // Calculate the basic age by subtracting years


            // If the user's birthday hasn't occurred yet this year, subtract one from the age
            if (birthDate.Date > today.AddYears(-age))
                age--;
            return age;
        }
        private void btnCancelAL_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will Remove you all unsaved data", "Are you sure to perform this??", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }


        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Define font and brush for printing
            Font printFont = new Font("Arial", 12);
            Brush printBrush = Brushes.Black;

            // Print data from all text boxes
            e.Graphics.DrawString("Librarian Name: " + txtUserIDAL.Text, printFont, printBrush, 100, 100);
            e.Graphics.DrawString("Phone Number: " + txtPhoneNumberAL.Text, printFont, printBrush, 100, 130);
            e.Graphics.DrawString("Email: " + txtEmailAL.Text, printFont, printBrush, 100, 160);
            e.Graphics.DrawString("Dath Of Birth: " + dtpDateOfBirthAL.Text, printFont, printBrush, 100, 190);
            e.Graphics.DrawString("Gender: " + cmbGenderAL.Text, printFont, printBrush, 100, 220);
            e.Graphics.DrawString("Address: " + txtAddreAL.Text, printFont, printBrush, 100, 250);
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
            g.DrawString("Congratilation!!!!! You have been apointed", new Font("Times New Roman", 26, FontStyle.Bold), Brushes.Black, leftMargin, yPos);
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
            g.DrawString("Address: " + txtAddreAL.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Salary: " + txtSalaryAL.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;


            // You can add more textboxes similarly
        }
        private void pbxAL_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintAL_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1; // Set the document to the PrintPreviewDialog
            printPreviewDialog1.ShowDialog(); // Show the print preview

            // If user confirms from preview, proceed to print
            if (printPreviewDialog1.DialogResult == DialogResult.OK)
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument1;

                // Show print dialog
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
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
            this.txtAddreAL.Clear();
            this.txtEnrollAL.Clear();
        }




    }
}
