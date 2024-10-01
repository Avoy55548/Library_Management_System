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

            //Subscribe to the Validating event for email validation
            this.txtEmailAS.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmailAS_Validating);


            printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument1_PrintPage);
        }



        private void txtEmailAS_Validating(object sender, CancelEventArgs e)
        {
            // Regular expression pattern to check for a valid email format
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // If the email doesn't match the pattern, show an error message
            if (!Regex.IsMatch(txtEmailAS.Text, emailPattern))
            {
                MessageBox.Show("Please enter a valid email address (e.g., xxxxx@gmail.com).", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;  // Prevents moving to the next control if the email is invalid
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


        private void btnSaveAB_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidToSave())
                {
                    MessageBox.Show("Please fill all the information");
                    return;
                }

                if (!IsValidToSave())
                {
                    MessageBox.Show("Please fill all the information");
                    return;
                }

                // ======= New Code Added for Age Validation ======= //
                // Check if age is above 18
                DateTime dateOfBirth = DateTime.Parse(dtpDateOfBirthAS.Text); // Get the date of birth from DatePicker
                int age = CalculateAge(dateOfBirth); // Calculate the age based on the birth date


                if (age < 8) // If the age is less than 8
                {
                    MessageBox.Show("You are underage. Age must be 8 or above.", "Underage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop the saving process
                }
                // ================================================ //

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=Library_Management_System;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();

                // ======= Change to Parameterized Query to Avoid SQL Injection ======= //
                cmd.CommandText = "INSERT INTO Student (Name, enroll, Contact, email, address, Date_Of_Birth,Password) VALUES (@Name, @Enroll, @Contact, @Email, @Address, @DateOfBirth,@Password)";
                cmd.Parameters.AddWithValue("@Name", this.txtStudentNameAS.Text);
                cmd.Parameters.AddWithValue("@Password", this.txtPasswordAS.Text);
                cmd.Parameters.AddWithValue("@Enroll", this.txtEnrollNoAS.Text);
                cmd.Parameters.AddWithValue("@Contact", this.txtPhoneNumberAS.Text);
                cmd.Parameters.AddWithValue("@Email", this.txtEmailAS.Text);
                cmd.Parameters.AddWithValue("@Address", this.txtAddressAS.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);

                cmd.ExecuteNonQuery();
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

        private void btnCancelAB_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will Remove you all unsaved data", "Are you sure to perform this??", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
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
            // Define font and brush for printing
            Font printFont = new Font("Arial", 12);
            Brush printBrush = Brushes.Black;

            // Print data from all text boxes
            e.Graphics.DrawString("Student Name: " + txtStudentNameAS.Text, printFont, printBrush, 100, 100);
            e.Graphics.DrawString("Enroll Number: " + txtEnrollNoAS.Text, printFont, printBrush, 100, 130);
            e.Graphics.DrawString("Phone Number: " + txtPhoneNumberAS.Text, printFont, printBrush, 100, 160);
            e.Graphics.DrawString("Address: " + txtAddressAS.Text, printFont, printBrush, 100, 190);
            e.Graphics.DrawString("Email: " + txtEmailAS.Text, printFont, printBrush, 100, 220);
            e.Graphics.DrawString("Date Of Birth: " + dtpDateOfBirthAS.Text, printFont, printBrush, 100, 250);



            // If you have more textboxes, print them similarly with e.Graphics.DrawString
        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Times New Roman", 20); // Change to Times New Roman
            float yPos = 100; // Starting position for printing
            int leftMargin = 50;

            // Print the header
            g.DrawString("Membership Card", new Font("Times New Roman", 26, FontStyle.Bold), Brushes.Black, leftMargin, yPos);
            yPos += 40;

            // Print data from all text boxes
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

            // You can add more textboxes similarly
        }

        private void btnPrintAS_Click(object sender, EventArgs e)
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

        private void dtpDateOfBirthAS_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AddStudentInfo_Load(object sender, EventArgs e)
        {

        }

        private void pnlInfoAC_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
