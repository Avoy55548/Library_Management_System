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
    public partial class Login : Form
    {

        
        public Login()
        {
            InitializeComponent();
        }

        private void btnLgLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tbxUNLogin.Text == "admin" && this.tbxPassLogin.Text == "admin")
                {
                    AdminDashboard ad = new AdminDashboard();
                    ad.Show();
                }
                else
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=Library_Management_System;Integrated Security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@UserID", this.tbxUNLogin.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", this.tbxPassLogin.Text.Trim());

                    cmd.CommandText = "SELECT * FROM Librarian where UserID = @UserID AND Password = @Password";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        LibrarianDashboard ld = new LibrarianDashboard();
                        ld.Show();
                    }




                }




                this.tbxUNLogin.Clear();
                this.tbxPassLogin.Clear();
            }
            catch (Exception exc)
            {
                MessageBox.Show("There is an error in your input: " + exc.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
