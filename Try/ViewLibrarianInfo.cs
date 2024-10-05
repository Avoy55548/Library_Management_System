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
        private readonly string connectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=Library_Management_System;Integrated Security=True";

        public ViewLibrarianInfo()
        {
            InitializeComponent();
        }

        

        private void ViewLibrarianInfo_Load(object sender, EventArgs e)
        {
            pnlInfoVLI.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=Library_Management_System;Integrated Security=True";
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

        }

        private void btnCancelVLI_Click(object sender, EventArgs e)
        {
            pnlInfoVLI.Visible = false;
        }

        private void txtSearchViewLibrarian_TextChanged(object sender, EventArgs e)
        {

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

        }
    }
}