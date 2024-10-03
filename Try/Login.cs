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

        public static string UserName = "";
        public static string Password = "";
        public static string Type = "";

        public Login()
        {
            InitializeComponent();
        }

        private void btnLgLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-CI2P4KU\SQLEXPRESS;Initial Catalog=Library_Management_System;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();

                // Check in the User table for the specific UserType
                cmd.Parameters.AddWithValue("@UserID", this.tbxUNLogin.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", this.tbxPassLogin.Text.Trim());

                cmd.CommandText = "SELECT * FROM [Users] WHERE UserName = @UserID AND Password = @Password";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow user = ds.Tables[0].Rows[0];
                    int userType = Convert.ToInt32(user["UserType"]); // Get the UserType from the User table

                    // Based on UserType, open the corresponding dashboard
                    if (userType == 1)
                    {
                        AdminDashboard ad = new AdminDashboard();
                        UserName = user["UserName"].ToString();
                        Password = user["Password"].ToString();

                        Type = Convert.ToString(userType);
                        ad.Show();
                        this.Hide();
                    }
                    else if (userType == 2)
                    {
                        LibrarianDashboard ld = new LibrarianDashboard();
                        UserName = user["UserName"].ToString();
                        Password = user["Password"].ToString();

                        Type = Convert.ToString(userType);
                        ld.Show();
                        this.Hide();
                    }
                    else if (userType == 3)
                    {
                        StudentName = user["UserName"].ToString();
                        StudentPassword = user["Password"].ToString();

                        UserName = user["UserName"].ToString();
                        Password = user["Password"].ToString();

                        Type = Convert.ToString(userType);
                        StudentDashboard sd = new StudentDashboard();
                        sd.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password", "Information");
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

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
