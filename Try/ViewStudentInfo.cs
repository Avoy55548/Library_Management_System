using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class ViewStudentInfo : Form
    {
        private readonly string connectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=new;Integrated Security=True"; //readonly because it cannot be modified
        private int StdID;
        private Int64 rowid;

        public ViewStudentInfo()
        {
            InitializeComponent();
        }


        private void ViewStudentInfo_Load(object sender, EventArgs e)
        {
            pnlURViewStudent.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;


            cmd.CommandText = "SELECT * FROM Users  where UserType=3"; //UserType=3 for student
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dgvViewStudent.DataSource = ds.Tables[0];

        }

        // Method to refresh student info
        private void btnRefreshViewStudent_Click(object sender, EventArgs e)
        {
            txtSearchViewStudent.Clear();
            pnlURViewStudent.Visible = false;
            RefreshDataGridView(); // Refreshes the DataGridView
        }

        // Method to cancel and hide panel
        private void btnCancelViewStudent_Click(object sender, EventArgs e)
        {
            pnlURViewStudent.Visible = false;
        }

        private void dgvViewStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvViewStudent.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    StdID = int.Parse(dgvViewStudent.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                pnlURViewStudent.Visible = true;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = connectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM Users where Id = " + StdID + " AND UserType=3"; //UserType=3 for student
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                txtStudentNameAS.Text = ds.Tables[0].Rows[0][1].ToString();
                txtEnrollNoAS.Text = ds.Tables[0].Rows[0][3].ToString();
                txtPhoneNumberAS.Text = ds.Tables[0].Rows[0][4].ToString();
                txtEmailAS.Text = ds.Tables[0].Rows[0][5].ToString();
                txtAddressAS.Text = ds.Tables[0].Rows[0][6].ToString();
                txtDateOfBirth.Text = DateTime.Parse(ds.Tables[0].Rows[0][7].ToString()).ToShortDateString();
                txtPasswordAS.Text = ds.Tables[0].Rows[0][2].ToString();
                cmbGenderAS.Text = ds.Tables[0].Rows[0][8].ToString();


            }
            catch (Exception exc)
            {
                MessageBox.Show("There is an error in your input: " + exc.Message);
            }
        }

        private void btnUpdateViewStudent_Click(object sender, EventArgs e)
        {
            // Validate email
            string email = txtEmailAS.Text;
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format. Please enter a valid email address.");
                return;
            }

            // Validate age (Student should be at least 8 years old)
            DateTime dob;
            if (!DateTime.TryParse(txtDateOfBirth.Text, out dob))
            {
                MessageBox.Show("Invalid date of birth. Please enter a valid date.");
                return;
            }

            int age = CalculateAge(dob);
            if (age < 8)
            {
                MessageBox.Show("Student must be at least 8 years old.");
                return;
            }

            if (MessageBox.Show("Data will be updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = connectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "update Users set UserName = @Name, Enroll = @Enroll, Contact = @Contact, Email = @Email, Address = @Address, DOB = @DateOfBirth, Password = @Password, Gender=@Gender where Id = @ID";

                    cmd.Parameters.AddWithValue("@Name", this.txtStudentNameAS.Text);
                    cmd.Parameters.AddWithValue("@Enroll", this.txtEnrollNoAS.Text);
                    cmd.Parameters.AddWithValue("@Contact", this.txtPhoneNumberAS.Text);
                    cmd.Parameters.AddWithValue("@Email", this.txtEmailAS.Text);
                    cmd.Parameters.AddWithValue("@Address", this.txtAddressAS.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dob); 
                    cmd.Parameters.AddWithValue("@Password", this.txtPasswordAS.Text);
                    cmd.Parameters.AddWithValue("@Gender", this.cmbGenderAS.Text);
                    cmd.Parameters.AddWithValue("@ID", rowid);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data Updated Successfully");
                        RefreshDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Update Failed");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void RefreshDataGridView()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users  where UserType=3", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dgvViewStudent.DataSource = ds.Tables[0];
            }
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private int CalculateAge(DateTime dob)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;
            if (dob > today.AddYears(-age)) age--;
            return age;
        }

        private void btnRemoveViewStudent_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be updated. Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = "delete from Users where Id = @StudentID";
                        cmd.Parameters.AddWithValue("@StudentID", rowid);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data Deleted Successfully");
                            RefreshDataGridView(); // Refresh DataGridView after successful deletion
                        }
                        else
                        {
                            MessageBox.Show("Deletion Failed");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void txtSearchViewStudent_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchViewStudent.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = connectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM Users where   UserType=3  AND UserName LIKE '" + txtSearchViewStudent.Text + "%' ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dgvViewStudent.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = connectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM Users where UserType=3";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dgvViewStudent.DataSource = ds.Tables[0];
            }
        }

        private void label1_Click(object sender, EventArgs e) //opened due to clicking
        {

        }

        private void pnlURViewStudent_Paint(object sender, PaintEventArgs e)  //opened due to clicking
        {

        }

        private void txtPasswordAS_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) //opened due to clicking
        {

        }

        

    }
}
