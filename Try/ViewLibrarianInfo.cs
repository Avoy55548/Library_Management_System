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

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class ViewLibrarianInfo : Form
    {
        private readonly string connectionString = @"Data Source=DESKTOP-HQ509SI\SQLEXPRESS01;Initial Catalog=Library_Management_System;Integrated Security=True";

        public ViewLibrarianInfo()
        {
            InitializeComponent();
        }

        //private void panel5_Paint(object sender, PaintEventArgs e)
        //{

        //}

        private void ViewLibrarianInfo_Load(object sender, EventArgs e)
        {
            pnlInfoVLI.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-HQ509SI\SQLEXPRESS01;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT U.*, L.Salary FROM Users U INNER JOIN Librarian L ON U.Id = L.Id WHERE U.UserType = 2";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dgvViewLibrarian.DataSource = ds.Tables[0];
        }

        int LibrarianSL;
        Int64 rowid;

        private void dgvViewLibrarian_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvViewLibrarian.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    LibrarianSL = int.Parse(dgvViewLibrarian.Rows[e.RowIndex].Cells[0].Value.ToString());
                    //MessageBox.Show(dgvViewBooks.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                pnlInfoVLI.Visible = true;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-HQ509SI\SQLEXPRESS01;Initial Catalog=Library_Management_System;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT U.*, L.Salary FROM Users U INNER JOIN Librarian L ON U.Id = L.Id WHERE U.UserType = 2 AND U.Id='" + LibrarianSL + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());


                txtPasswordAL.Text = ds.Tables[0].Rows[0][2].ToString();
                txtEmailAL.Text = ds.Tables[0].Rows[0][5].ToString();
                txtPhoneNumberAL.Text = ds.Tables[0].Rows[0][4].ToString();
                dtpDateOfBirthAL.Text = ds.Tables[0].Rows[0][7].ToString();
                txtSalaryAL.Text = ds.Tables[0].Rows[0][10].ToString();
                txtAddressAL.Text = ds.Tables[0].Rows[0][6].ToString();
                txtEnrollAL.Text = ds.Tables[0].Rows[0][3].ToString();
                cmbGenderAL.Text = ds.Tables[0].Rows[0][8].ToString();


            }
            catch (Exception exc)
            {
                MessageBox.Show("There is an error in your input: " + exc.Message);
            }
        }

        private void btnCancelVLI_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchViewLibrarian_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchViewLibrarian.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-HQ509SI\SQLEXPRESS01;Initial Catalog=Library_Management_System;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT U.*, L.Salary FROM Users U INNER JOIN Librarian L ON U.Id = L.Id WHERE U.UserType = 2 AND UserName LIKE '" + txtSearchViewLibrarian.Text + "%';";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dgvViewLibrarian.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-HQ509SI\SQLEXPRESS01;Initial Catalog=Library_Management_System;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT U.*, L.Salary FROM Users U INNER JOIN Librarian L ON U.Id = L.Id WHERE U.UserType = 2";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dgvViewLibrarian.DataSource = ds.Tables[0];
            }
        }

        private void btnRefreshViewLibrarian_Click(object sender, EventArgs e)
        {
            txtSearchViewLibrarian.Clear();
            pnlInfoVLI.Visible = false;
            RefreshDataGridView();

        }

        private void RefreshDataGridView()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT U.*, L.Salary FROM Users U INNER JOIN Librarian L ON U.Id = L.Id WHERE U.UserType = 2", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dgvViewLibrarian.DataSource = ds.Tables[0];
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            // Validate email
            string email = txtEmailAL.Text;
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format. Please enter a valid email address.");
                return;
            }

            // Validate age (Librarian should be at least 18 years old)
            DateTime dob;
            if (!DateTime.TryParse(dtpDateOfBirthAL.Text, out dob))
            {
                MessageBox.Show("Invalid date of birth. Please enter a valid date.");
                return;
            }

            int age = CalculateAge(dob);
            if (age < 18)
            {
                MessageBox.Show("Librarian must be at least 18 years old.");
                return;
            }
            if (MessageBox.Show("Data will be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-HQ509SI\SQLEXPRESS01;Initial Catalog=Library_Management_System;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();

                cmd.CommandText = " UPDATE Users SET  Password = @Password,  Email = @Email,  Contact = @Contact, DOB=@DOB, Enroll = @Enroll,  Address = @Address,  Gender = @Gender WHERE Id = @UserID; UPDATE Librarian  SET   Salary = @Salary     WHERE Id = @UserID;";
                cmd.Parameters.AddWithValue("@password", this.txtPasswordAL.Text);
                cmd.Parameters.AddWithValue("@Email", this.txtEmailAL.Text);
                cmd.Parameters.AddWithValue("@Contact", this.txtPhoneNumberAL.Text);
                cmd.Parameters.AddWithValue("@DOB", this.dtpDateOfBirthAL.Value);
                cmd.Parameters.AddWithValue("@Salary", Convert.ToDouble(this.txtSalaryAL.Text));
                cmd.Parameters.AddWithValue("@UserID", rowid);
                cmd.Parameters.AddWithValue("@Enroll", txtEnrollAL.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddressAL.Text);
                cmd.Parameters.AddWithValue("@Gender", cmbGenderAL.Text);



                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data Updated Successfully");
                    // Refresh DataGridView after successful update
                    RefreshDataGridView();
                }
                else
                {
                    MessageBox.Show("Update Failed");
                }
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
        private void btnRemoveVLI_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Updated. Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-HQ509SI\SQLEXPRESS01;Initial Catalog=Library_Management_System;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = @" DELETE FROM Librarian WHERE Id = @UserID; DELETE FROM Users WHERE Id = @UserID;";

                cmd.Parameters.AddWithValue("@UserID", rowid);


                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data Updated Successfully");
                    // Refresh DataGridView after successful update
                    RefreshDataGridView();
                }
                else
                {
                    MessageBox.Show("Remove Failed");
                }


                con.Close();
            }



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelVLI_Click_1(object sender, EventArgs e)
        {

        }
    }
}
