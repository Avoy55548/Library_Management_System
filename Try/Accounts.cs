using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class Accounts : Form
    {

        private PrintDocument printDocument1 = new PrintDocument(); // PrintDocument instance
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog(); // PrintPreviewDialog instance
        public Accounts()
        {
            InitializeComponent();
            // Hook up the PrintPage event to the printDocument
            printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument1_PrintPage);

        }



        private void Accounts_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();
            cmd = new SqlCommand("select Name from Book", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    cmbBookNameIsB.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();
        }




        private void btnSearchIsB_Click(object sender, EventArgs e)
        {
            if (this.txtEnrollNumberIsB.Text != "")
            {
                //String eid = txtEnrollNumberIsB.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=Library_Management_System;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from Student where enroll = '" + this.txtEnrollNumberIsB.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);



                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtStudentNameIsB.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtStudentNameIsB.ReadOnly = true;


                    txtPhoneNumberIsB.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtPhoneNumberIsB.ReadOnly = true;


                    txtEmailIsB.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtEmailIsB.ReadOnly = true;


                    txtAddressIsB.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtAddressIsB.ReadOnly = true;
                }
                else
                {
                    this.ClearAll();
                    MessageBox.Show("Invalid Enrollment Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearAll()
        {
            this.txtStudentNameIsB.Clear();
            this.txtPhoneNumberIsB.Clear();
            this.txtEmailIsB.Clear();
            this.txtAddressIsB.Clear();
        }




        private void btnRefreshIsB_Click(object sender, EventArgs e)
        {
            txtEnrollNumberIsB.Clear();


        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {

        }

        private void btnExitAc_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void cmbBookNameIsB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                // Get the selected book name
                string selectedBook = cmbBookNameIsB.SelectedItem.ToString();

                double price = 0;
                double fine = 0;

                // Database connection setup
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=Library_Management_System;Integrated Security=True";
                con.Open();

                // Query to get the book price from Book table
                SqlCommand cmdBook = new SqlCommand("SELECT Price FROM Book WHERE Name = @BookName", con);
                cmdBook.Parameters.AddWithValue("@BookName", selectedBook);
                SqlDataReader sdrBook = cmdBook.ExecuteReader();

                // If book is found, set the price in txtPrice
                if (sdrBook.Read())
                {
                    txtPrice.Text = sdrBook["Price"].ToString();
                    txtPrice.ReadOnly = true;
                    price = Convert.ToDouble(sdrBook["Price"]);
                }
                sdrBook.Close();  // Close the first reader

                // Query to get the fine from IRBook table
                SqlCommand cmdIRBook = new SqlCommand("SELECT Fine FROM IRBook WHERE Book_Name = @BookName", con);
                cmdIRBook.Parameters.AddWithValue("@BookName", selectedBook);
                SqlDataReader sdrIRBook = cmdIRBook.ExecuteReader();

                if (sdrIRBook.Read() && !string.IsNullOrEmpty(sdrIRBook["Fine"].ToString()))
                {
                    txtFine.Text = sdrIRBook["Fine"].ToString();
                    txtFine.ReadOnly = true;
                    fine = Convert.ToDouble(sdrIRBook["Fine"]);
                }
                else
                {
                    // Set default fine value to 0
                    txtFine.Text = "0";
                    fine = 0;
                }
                sdrIRBook.Close();

                // Close the connection
                con.Close();

                // Calculate the total and set it in txtTotal
                double total = price + fine;  // Calculate total
                txtTotal.Text = total.ToString();  // Set total in txtTotal
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Define font and brush for printing
            Font printFont = new Font("Arial", 12);
            Brush printBrush = Brushes.Black;

            // Print data from all text boxes
            e.Graphics.DrawString("Student Name: " + txtStudentNameIsB.Text, printFont, printBrush, 100, 100);
            e.Graphics.DrawString("Phone Number: " + txtPhoneNumberIsB.Text, printFont, printBrush, 100, 130);
            e.Graphics.DrawString("Email: " + txtEmailIsB.Text, printFont, printBrush, 100, 160);
            e.Graphics.DrawString("Address: " + txtAddressIsB.Text, printFont, printBrush, 100, 190);
            e.Graphics.DrawString("Price: " + txtPrice.Text, printFont, printBrush, 100, 220);
            e.Graphics.DrawString("Fine: " + txtFine.Text, printFont, printBrush, 100, 250);
            e.Graphics.DrawString("Total: " + txtTotal.Text, printFont, printBrush, 100, 280);

            // If you have more textboxes, print them similarly with e.Graphics.DrawString
        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Times New Roman", 20); // Change to Times New Roman
            float yPos = 100; // Starting position for printing
            int leftMargin = 50;

            // Print the header
            g.DrawString("Library Management System - Printout", new Font("Times New Roman", 26, FontStyle.Bold), Brushes.Black, leftMargin, yPos);
            yPos += 40;

            // Print data from all text boxes
            g.DrawString("Student Name: " + txtStudentNameIsB.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Phone Number: " + txtPhoneNumberIsB.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Email: " + txtEmailIsB.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Address: " + txtAddressIsB.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Price: " + txtPrice.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Fine: " + txtFine.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Total: " + txtTotal.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;

            // You can add more textboxes similarly
        }

        private void btnPrint_Click(object sender, EventArgs e)
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

        private void btnBuyAC_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=Library_Management_System;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();

                // ======= Change to Parameterized Query to Avoid SQL Injection ======= //
                cmd.CommandText = "INSERT INTO Accounts (Stu_Name, PhoneNo,email, address,Book, Price, Fine,Total ) VALUES (@Name, @Phone, @Email,@Address, @book, @Price,@Fine,@Total)";
                cmd.Parameters.AddWithValue("@Name", this.txtStudentNameIsB.Text);
                cmd.Parameters.AddWithValue("@Phone", this.txtPhoneNumberIsB.Text);
                cmd.Parameters.AddWithValue("@Email", this.txtEmailIsB.Text);
                cmd.Parameters.AddWithValue("@Address", this.txtAddressIsB.Text);
                cmd.Parameters.AddWithValue("@book", this.cmbBookNameIsB.Text);
                cmd.Parameters.AddWithValue("@Price", this.txtPrice.Text);
                cmd.Parameters.AddWithValue("@Fine", this.txtFine.Text);
                cmd.Parameters.AddWithValue("@Total", this.txtTotal.Text);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exc)
            {
                MessageBox.Show("There is an error in your input: " + exc.Message);
            }
        }
    }
}
