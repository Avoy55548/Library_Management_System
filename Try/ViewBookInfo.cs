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
    public partial class ViewBookInfo : Form
    {
        public ViewBookInfo()
        {
            InitializeComponent();
        }

        private void ViewBookInfo_Load(object sender, EventArgs e)
        {
            pnlURViewBooks.Visible = false;
            if (Login.Type == 3)
            {
                btnUpdateViewBooks.Visible = false; // Hide the Update button for students
                btnRemoveVBI.Visible = false;       // Hide the Remove button for students
            }
            else
            {
                btnUpdateViewBooks.Visible = true;
                btnRemoveVBI.Visible = true;
            }


            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-8PBDEDF\SQLEXPRESS;Initial Catalog=new;Integrated Security=True;Encrypt=False";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM Book";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dgvViewBooks.DataSource = ds.Tables[0];
        }
        int BookID;
        Int64 rowid;
        private void dgvViewBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvViewBooks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    BookID = int.Parse(dgvViewBooks.Rows[e.RowIndex].Cells[0].Value.ToString());
                    //MessageBox.Show(dgvViewBooks.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                pnlURViewBooks.Visible = true;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-8PBDEDF\SQLEXPRESS;Initial Catalog=new;Integrated Security=True;Encrypt=False";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM Book where BookID = " + BookID + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                txtBookNameVB.Text = ds.Tables[0].Rows[0][1].ToString();
                txtBookAuthorVB.Text = ds.Tables[0].Rows[0][2].ToString();
                txtBookPublicationVB.Text = ds.Tables[0].Rows[0][3].ToString();
                txtISBNNoVB.Text = ds.Tables[0].Rows[0][4].ToString();
                txtBookPriceVB.Text = ds.Tables[0].Rows[0][6].ToString();
                txtBookQuantityVB.Text = ds.Tables[0].Rows[0][5].ToString();

            }
            catch (Exception exc)
            {
                MessageBox.Show("There is an error in your input: " + exc.Message);
            }

        }

        private void btnCancelVBI_Click(object sender, EventArgs e)
        {
            pnlURViewBooks.Visible = false;
        }

        private void txtSearchViewBook_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchViewBook.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-8PBDEDF\SQLEXPRESS;Initial Catalog=new;Integrated Security=True;Encrypt=False";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM Book where Name LIKE '" + txtSearchViewBook.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dgvViewBooks.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-8PBDEDF\SQLEXPRESS;Initial Catalog=new;Integrated Security=True;Encrypt=False";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM Book";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dgvViewBooks.DataSource = ds.Tables[0];
            }
        }


        private void btnUpdateViewBooks_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=new;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update Book set Name = '" + this.txtBookNameVB.Text + "', Author = '" + this.txtBookAuthorVB.Text + "',Publication = '" + this.txtBookPublicationVB.Text + "', ISBN = '" + this.txtISBNNoVB.Text + "',Quantity = " + this.txtBookQuantityVB.Text + ", Price = " + this.txtBookPriceVB.Text + " where BookID = " + rowid + " ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void btnRemoveVBI_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Updated. Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-8PBDEDF\SQLEXPRESS;Initial Catalog=new;Integrated Security=True;Encrypt=False";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from Book where BookID = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void btnRefreshViewBook_Click(object sender, EventArgs e)
        {
            txtSearchViewBook.Clear();
            pnlURViewBooks.Visible = false;
        }



        private void pnlURViewBooks_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
