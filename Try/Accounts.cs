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

        private PrintDocument printDocument1 = new PrintDocument(); 
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog(); 
        public Accounts()
        {
            InitializeComponent();
           
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

                
                string selectedBook = cmbBookNameIsB.SelectedItem.ToString();

                double price = 0;
                double fine = 0;

                
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=Library_Management_System;Integrated Security=True";
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
                    
                    txtFine.Text = "0";
                    fine = 0;
                }
                sdrIRBook.Close();

                
                con.Close();

                
                double total = price + fine; 
                txtTotal.Text = total.ToString();  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            Font printFont = new Font("Arial", 12);
            Brush printBrush = Brushes.Black;

            
            e.Graphics.DrawString("Student Name: " + txtStudentNameIsB.Text, printFont, printBrush, 100, 100);
            e.Graphics.DrawString("Phone Number: " + txtPhoneNumberIsB.Text, printFont, printBrush, 100, 130);
            e.Graphics.DrawString("Email: " + txtEmailIsB.Text, printFont, printBrush, 100, 160);
            e.Graphics.DrawString("Address: " + txtAddressIsB.Text, printFont, printBrush, 100, 190);
            e.Graphics.DrawString("Price: " + txtPrice.Text, printFont, printBrush, 100, 220);
            e.Graphics.DrawString("Fine: " + txtFine.Text, printFont, printBrush, 100, 250);
            e.Graphics.DrawString("Total: " + txtTotal.Text, printFont, printBrush, 100, 280);

           
        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Times New Roman", 20); 
            float yPos = 100; 
            int leftMargin = 50;

           
            g.DrawString("Library Management System - Printout", new Font("Times New Roman", 26, FontStyle.Bold), Brushes.Black, leftMargin, yPos);
            yPos += 40;

            
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

            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1; 
            printPreviewDialog1.ShowDialog(); 

            
            if (printPreviewDialog1.DialogResult == DialogResult.OK)
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument1;

               
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }



    }
}
