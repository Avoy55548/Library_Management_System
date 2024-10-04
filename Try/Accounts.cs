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

            printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument1_PrintPage);

        }

        private bool IsValidToSave()
        {
            if (String.IsNullOrEmpty(this.txtStudentNameIsB.Text) || String.IsNullOrEmpty(this.txtPhoneNumberIsB.Text) ||
                String.IsNullOrEmpty(this.txtEmailIsB.Text) || String.IsNullOrEmpty(this.txtAddressIsB.Text) ||
                 String.IsNullOrEmpty(this.cmbBookNameIsB.Text) || String.IsNullOrEmpty(this.txtPrice.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void Accounts_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-CI2P4KU\SQLEXPRESS;Initial Catalog=Library_Management_System;Integrated Security=True";
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

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=new;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Users where UserType=3  AND  Enroll = '" + this.txtEnrollNumberIsB.Text + "'";
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
            this.txtPrice.Clear();
        }




        private void btnRefreshIsB_Click(object sender, EventArgs e)
        {
            txtEnrollNumberIsB.Clear();
            this.ClearAll();

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


                string selectedBook = cmbBookNameIsB.SelectedItem.ToString();

                double price = 0;



                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=new;Integrated Security=True";
                con.Open();


                SqlCommand cmdBook = new SqlCommand("SELECT Price FROM Book WHERE Name = @BookName", con);
                cmdBook.Parameters.AddWithValue("@BookName", selectedBook);
                SqlDataReader sdrBook = cmdBook.ExecuteReader();


                if (sdrBook.Read())
                {
                    txtPrice.Text = sdrBook["Price"].ToString();
                    txtPrice.ReadOnly = true;
                    price = Convert.ToDouble(sdrBook["Price"]);
                }
                sdrBook.Close();

                con.Close();
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
            e.Graphics.DrawString("Book Name: " + cmbBookNameIsB.Text, printFont, printBrush, 100, 220);
            e.Graphics.DrawString("Price: " + txtPrice.Text, printFont, printBrush, 100, 250);



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
            g.DrawString("Book Name: " + cmbBookNameIsB.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Price: " + txtPrice.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;



        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidToSave())
                {
                    MessageBox.Show("Please fill all the information");
                    return;
                }

               

            }
        }

        private void btnBuyAC_Click(object sender, EventArgs e)
        {

        }
    }
}
