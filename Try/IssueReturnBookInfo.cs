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

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class IssueReturnBookInfo : Form
    {
        public IssueReturnBookInfo()
        {
            InitializeComponent();
        }

        private void IssueReturnBookInfo_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-8PBDEDF\SQLEXPRESS;Initial Catalog=saif;Integrated Security=True;Encrypt=False";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();

                // Get issued book information
                cmd.CommandText = "SELECT BID, Stu_enroll, Stu_Name, PhoneNo, Email, Address, Book_Name, Book_issue_date, Book_return_date FROM IRBook WHERE Book_return_date IS NOT NULL";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvIssueBooksInfo.DataSource = ds.Tables[0];

                // Business logic to calculate fine for each book and update the database
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DateTime issueDate = DateTime.Parse(row["Book_issue_date"].ToString());
                    DateTime returnDate = DateTime.Parse(row["Book_return_date"].ToString());

                    // Calculate the number of days overdue
                    int daysOverdue = (returnDate - issueDate).Days - 7; // 7 days allowed

                    int fine = 0;

                    // If overdue, calculate fine
                    if (daysOverdue > 0)
                    {
                        fine = daysOverdue * 20; // 20 Taka per day
                    }

                    // Update the fine in the IRBook table
                    cmd.CommandText = "UPDATE IRBook SET Fine = @Fine WHERE BID = @BID";
                    cmd.Parameters.Clear();  // Clear previous parameters
                    cmd.Parameters.AddWithValue("@Fine", fine);
                    cmd.Parameters.AddWithValue("@BID", row["BID"]);
                    cmd.ExecuteNonQuery(); // Execute the update command
                }

                // Now that fines are updated, retrieve the updated data and show in DataGridView
                cmd.CommandText = "SELECT * FROM IRBook WHERE Book_return_date IS NOT NULL";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                dgvReturnBooksInfo.DataSource = ds1.Tables[0]; // Display the updated table

                con.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("There is an error in your input: " + exc.Message);
            }
        }

        private void dgvIssueBooksInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click event if necessary
        }

        private void dgvReturnBooksInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click event if necessary
        }
    }
}