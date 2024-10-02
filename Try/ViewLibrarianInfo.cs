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

            cmd.CommandText = "SELECT * FROM Librarian";
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

                cmd.CommandText = "SELECT * FROM Librarian where LibrarianSL = " + LibrarianSL + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                //tx.Text = ds.Tables[0].Rows[0][1].ToString();
                txtPasswordAL.Text = ds.Tables[0].Rows[0][2].ToString();
                txtEmailAL.Text = ds.Tables[0].Rows[0][3].ToString();
                txtPhoneNumberAL.Text = ds.Tables[0].Rows[0][4].ToString();
                dtpDateOfBirthAL.Text = ds.Tables[0].Rows[0][5].ToString();
                txtSalaryAL.Text = ds.Tables[0].Rows[0][7].ToString();

            }
            catch (Exception exc)
            {
                MessageBox.Show("There is an error in your input: " + exc.Message);
            }
        }

        private void btnCancelVLI_Click(object sender, EventArgs e)
        {
            pnlInfoVLI.Visible = false;
        }

        private void txtSearchViewLibrarian_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchViewLibrarian.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-HQ509SI\SQLEXPRESS01;Initial Catalog=Library_Management_System;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM Librarian where UserID LIKE '" + txtSearchViewLibrarian.Text + "%'";
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

                cmd.CommandText = "SELECT * FROM Librarian";
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
        }

        private void RefreshDataGridView()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Librarian", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dgvViewLibrarian.DataSource = ds.Tables[0];
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-HQ509SI\SQLEXPRESS01;Initial Catalog=Library_Management_System;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();

                cmd.CommandText = "update Librarian set Password = @password, Email = @Email,Contact = @Contact, Date_of_birth = @DOB,Salary = @Salary where LibrarianSL = @UserID";
                cmd.Parameters.AddWithValue("@password", this.txtPasswordAL.Text);
                cmd.Parameters.AddWithValue("@Email", this.txtEmailAL.Text);
                cmd.Parameters.AddWithValue("@Contact", this.txtPhoneNumberAL.Text);
                cmd.Parameters.AddWithValue("@DOB", this.dtpDateOfBirthAL.Value);
                cmd.Parameters.AddWithValue("@Salary", Convert.ToDouble(this.txtSalaryAL.Text));
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
                    MessageBox.Show("Update Failed");
                }
            }
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
                cmd.CommandText = "delete from Librarian where LibrarianSL = " + rowid + "";


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
    }
}
