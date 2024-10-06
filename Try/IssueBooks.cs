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
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }


        private void IssueBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=new;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();
            cmd = new SqlCommand("select Name from Book", con); // Fetching book names
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    cmbBookNameIsB.Items.Add(sdr.GetString(i)); // Adding book names to ComboBox
                }
            }
            sdr.Close();
            con.Close();
        }

        int count;

        private void btnSearchIsB_Click(object sender, EventArgs e)
        {
            if (this.txtEnrollNumberIsB.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=new;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Modified SQL query to use Id (instead of Enroll) to search for the user
                cmd.CommandText = "select * from Users where UserType=3 AND Enroll = @Enroll";
                cmd.Parameters.AddWithValue("@Enroll", this.txtEnrollNumberIsB.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Count how many books have been issued for the given enrollment number
                cmd.CommandText = "select count(Stu_enroll) from IRBook where Stu_enroll = @Enroll and Book_return_date is null";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);

                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString()); // Count of issued books

                if (ds.Tables[0].Rows.Count != 0)
                {
                    // Display the student details
                    txtStudentNameIsB.Text = ds.Tables[0].Rows[0]["UserName"].ToString(); // Changed index to match with UserName field
                    txtPhoneNumberIsB.Text = ds.Tables[0].Rows[0]["Contact"].ToString();  // Changed index to match with Contact field
                    txtEmailIsB.Text = ds.Tables[0].Rows[0]["Email"].ToString();          // Changed index to match with Email field
                    txtAddressIsB.Text = ds.Tables[0].Rows[0]["Address"].ToString();      // Changed index to match with Address field
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

        private void btnIssueBookIsB_Click(object sender, EventArgs e)
        {
            if (txtStudentNameIsB.Text != "")
            {
                if (cmbBookNameIsB.SelectedIndex != -1 && count <= 2)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=new;Integrated Security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();

                    // Fetching the BookID based on the selected book name
                    int bookID = -1; // Initialize the variable to hold BookID

                    // Query to get the BookID based on the selected book name
                    cmd.CommandText = "SELECT BookID FROM Book WHERE Name = @BookName";
                    cmd.Parameters.AddWithValue("@BookName", this.cmbBookNameIsB.Text); // Book name

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // Read the result
                    {
                        bookID = reader.GetInt32(0); // Assuming BookID is the first column in the result set
                    }
                    reader.Close(); // Close the reader

                    if (bookID != -1) // Ensure a valid BookID was found
                    {
                        // Prepare to insert the new record into the IRBook table
                        cmd.CommandText = @"
                INSERT INTO IRBook (Stu_enroll, Stu_name, PhoneNo, Email, Address, BID, Book_name, Book_issue_date) 
                VALUES (@Enroll, @Name, @Phone, @Email, @Address, @BookID, @BookName, @IssueDate)";

                        // Using parameters to safely pass values
                        cmd.Parameters.Clear(); // Clear previous parameters
                        cmd.Parameters.AddWithValue("@Enroll", this.txtEnrollNumberIsB.Text); // Enrollment number
                        cmd.Parameters.AddWithValue("@Name", this.txtStudentNameIsB.Text);    // Student name
                        cmd.Parameters.AddWithValue("@Phone", this.txtPhoneNumberIsB.Text);  // Phone number
                        cmd.Parameters.AddWithValue("@Email", this.txtEmailIsB.Text);        // Email
                        cmd.Parameters.AddWithValue("@Address", this.txtAddressIsB.Text);    // Address
                        cmd.Parameters.AddWithValue("@BookID", bookID); // BookID retrieved above
                        cmd.Parameters.AddWithValue("@BookName", this.cmbBookNameIsB.Text);  // Book name
                        cmd.Parameters.AddWithValue("@IssueDate", this.dtpIssueDateIsB.Value); // DatePicker value

                        cmd.ExecuteNonQuery(); // Execute the insert
                        MessageBox.Show("Book Issued", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear the enrollment number text box for next entry
                        txtEnrollNumberIsB.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Book not found. Please select a valid book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    con.Close(); // Close the connection
                }
                else
                {
                    MessageBox.Show("Select a book or the maximum number of books has been issued.", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter a valid Enrollment No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEnrollNumberIsB_TextChanged(object sender, EventArgs e)
        {
            if (txtEnrollNumberIsB.Text == "")
            {
                this.ClearAll();
            }
        }

        private void btnRefreshIsB_Click(object sender, EventArgs e)
        {
            txtEnrollNumberIsB.Clear();
        }

        private void btnExitIsB_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit??", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void cmbBookNameIsB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}