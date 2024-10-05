using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class BorrowHistory : Form
    {




        public BorrowHistory()
        {
            InitializeComponent();

        }

        private void BorrowHistory_Load(object sender, EventArgs e)
        {

            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-HQ509SI\SQLEXPRESS01;Initial Catalog=Library_Management_System;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("@StudentName", Login.UserName);

                cmd.CommandText = "select Book_Name,Book_issue_date,Book_return_date,Fine  from IRBook where Stu_name=@StudentName";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvBH.DataSource = ds.Tables[0];



                if (Login.Type == 3)
                {
                    // Now query for fetching student information
                    cmd.CommandText = "select  UserName, Enroll from Users where UserName= @Name AND Password= @Password AND UserType=3";
                    cmd.Parameters.Clear(); // Clear previous parameter
                    cmd.Parameters.AddWithValue("@Name", Login.UserName);
                    cmd.Parameters.AddWithValue("@Password", Login.Password);
                }


                // Open the connection to fetch data
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // If the student is found
                {
                    // Set the text boxes with student data
                    txtNameBH.Text = reader["UserName"].ToString();
                    txtNameBH.ReadOnly = true;

                    txtEnrollBH.Text = reader["enroll"].ToString();
                    txtEnrollBH.ReadOnly = true;


                }
                else
                {
                    MessageBox.Show("No student found with the provided credentials.");
                }

                con.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("There is an error in your input: " + exc.Message);
            }
        }

        private void btnExitBH_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
