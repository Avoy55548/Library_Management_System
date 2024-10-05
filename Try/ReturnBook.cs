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
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void btnSearchIsB_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=LAPTOP-P9NRKPUV\SQLEXPRESS;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from IRBook where Stu_enroll = '" + txtEnrollIsB.Text + "'and Book_return_date IS NULL";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dgvReturnBook.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid ID or no Book Issued.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        String bdate;
        String bname;
        Int64 rowid;
        private void ReturnBook_Load(object sender, EventArgs e)
        {
            pnlInfoRB.Visible = false;
            this.txtEnrollIsB.Clear();
        }

        private void dgvReturnBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pnlInfoRB.Visible = true;

            if (dgvReturnBook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(dgvReturnBook.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dgvReturnBook.Rows[e.RowIndex].Cells[6].Value.ToString();
                bdate = dgvReturnBook.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            txtBookNameRB.Text = bname;
            txtBookIssueDateRB.Text = bdate;
        }

        private void btnReturnRB_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=LAPTOP-P9NRKPUV\SQLEXPRESS;Initial Catalog=Library_Management_System;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update IRBook set Book_return_date = '" + dtpBookReturnDateRB.Text + "' where Stu_enroll = '" + txtEnrollIsB.Text + "' and BID = " + rowid + "";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Return Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReturnBook_Load(this, null);
        }

        
        private void txtEnrollIsB_TextChanged(object sender, EventArgs e)
        {
            if (txtEnrollIsB.Text == "")
            {
                pnlInfoRB.Visible = false;
                dgvReturnBook.DataSource = null;
            }
        }

        private void btnRefreshRB_Click(object sender, EventArgs e)

        {
            this.txtEnrollIsB.Clear();
        }

        private void btnExitRB_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnCancelRB_Click(object sender, EventArgs e)
        {
            pnlInfoRB.Visible = false;
        }

    }
}
