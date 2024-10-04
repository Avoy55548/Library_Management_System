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

        int count;

        private void btnSearchIsB_Click(object sender, EventArgs e)
        {
            if (this.txtEnrollNumberIsB.Text != "")
            {
                
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=new;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from Users where UserType=3 AND Enroll = '" + this.txtEnrollNumberIsB.Text + "'"; //UserType=3 for student
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                
                //Code to count how many books has been issued on this enrollment number
                cmd.CommandText = "select count(Stu_enroll) from IRBook where Stu_enroll = '" + this.txtEnrollNumberIsB.Text + "'and Book_return_date is null"; //UserType=3 for student
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);

                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                
                // Code to fill the textboxs
                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtStudentNameIsB.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtPhoneNumberIsB.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtEmailIsB.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtAddressIsB.Text = ds.Tables[0].Rows[0][5].ToString();
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
                    cmd.CommandText = @"
                INSERT INTO IRBook (Stu_enroll, Stu_name, PhoneNo, Email, Address, Book_name, Book_issue_date) 
                VALUES (@Enroll, @Name, @Phone, @Email, @Address, @BookName, @IssueDate)";

                    // Add parameters to the SQL command
                    cmd.Parameters.AddWithValue("@Enroll", this.txtEnrollNumberIsB.Text); 
                    cmd.Parameters.AddWithValue("@Name", this.txtStudentNameIsB.Text);
                    cmd.Parameters.AddWithValue("@Phone", this.txtPhoneNumberIsB.Text);
                    cmd.Parameters.AddWithValue("@Email", this.txtEmailIsB.Text); 
                    cmd.Parameters.AddWithValue("@Address", this.txtAddressIsB.Text); 
                    cmd.Parameters.AddWithValue("@BookName", this.cmbBookNameIsB.Text); 
                    cmd.Parameters.AddWithValue("@IssueDate", this.dtpIssueDateIsB.Value); 
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Book Issued", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtEnrollNumberIsB.Clear();
                }
                else
                {
                    MessageBox.Show("Select Books or Maximum number of books hab been issued ", "No book Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter valid Enrollment No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cmbBookNameIsB_SelectedIndexChanged(object sender, EventArgs e) //opened due to clicking
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
