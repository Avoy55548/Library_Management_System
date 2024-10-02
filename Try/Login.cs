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

        public static string StudentName = "";
        public static string StudentPassword = "";
        public static string adminName = "";
        public static string adminPassword = "";
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
                    adminName = tbxUNLogin.Text;
                    adminPassword = tbxPassLogin.Text;
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


                    else
                    {
                        // Check for Student if not a Librarian
                        con.Open();
                        cmd.CommandText = "SELECT * FROM Student WHERE Name = @UserID AND Password = @Password";
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow student = ds.Tables[0].Rows[0];
                            StudentName = student["Name"].ToString();
                            StudentPassword = student["Password"].ToString();


                            // If Student found
                            StudentDashboard sd = new StudentDashboard(); // Assuming there's a StudentDashboard form
                            sd.Show();


                        }
                        else
                        {
                            MessageBox.Show("Incorrect Username or Password", "Information");
                        }
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
