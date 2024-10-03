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
            if (!string.IsNullOrEmpty(Login.StudentName) && !string.IsNullOrEmpty(Login.StudentPassword))
            {
                btnUpdateViewBooks.Visible = false; // Hide the Update button for students
                btnRemoveVBI.Visible = false;       // Hide the Remove button for students
            }
            else if (!string.IsNullOrEmpty(Login.adminName) && !string.IsNullOrEmpty(Login.adminPassword))
            {
                btnUpdateViewBooks.Visible = true;
                btnRemoveVBI.Visible = true;
            }
            else
            {
                // Admins or librarians have full access, so the buttons are visible
                btnUpdateViewBooks.Visible = true;
                btnRemoveVBI.Visible = true;
            }

            RefreshDataGridView(); // Load the data into the grid view on form load
        }

        int BookID;
        Int64 rowid;

        private void dgvViewBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure the index is within valid range
                if (e.RowIndex >= 0 && e.RowIndex < dgvViewBooks.Rows.Count &&
                    e.ColumnIndex >= 0 && e.ColumnIndex < dgvViewBooks.Columns.Count)
                {
                    if (dgvViewBooks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        BookID = int.Parse(dgvViewBooks.Rows[e.RowIndex].Cells[0].Value.ToString());
                    }

                    pnlURViewBooks.Visible = true;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"Data Source=DESKTOP-8PBDEDF\SQLEXPRESS;Initial Catalog=saif;Integrated Security=True;Encrypt=False";
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
            }
            catch (Exception exc)
            {
                MessageBox.Show("There is an error in your input: " + exc.Message);
            }
        }

        private void btnUpdateViewBooks_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-8PBDEDF\SQLEXPRESS;Initial Catalog=saif;Integrated Security=True;Encrypt=False";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                try
                {
                    con.Open();
                    // Update the book details
                    cmd.CommandText = "UPDATE Book SET Name = '" + this.txtBookNameVB.Text + "', Author = '" + this.txtBookAuthorVB.Text + "', Publication = '" + this.txtBookPublicationVB.Text + "', ISBN = '" + this.txtISBNNoVB.Text + "', Quantity = " + this.txtBookQuantityVB.Text + ", Price = " + this.txtBookPriceVB.Text + " WHERE BookID = " + rowid + "";
                    cmd.ExecuteNonQuery();

                    // Refresh the DataGridView after the update
                    RefreshDataGridView();

                    MessageBox.Show("Book details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error while updating book details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btnRemoveVBI_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be deleted. Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-8PBDEDF\SQLEXPRESS;Initial Catalog=saif;Integrated Security=True;Encrypt=False";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                try
                {
                    con.Open();
                    cmd.CommandText = "DELETE FROM Book WHERE BookID = " + rowid + "";
                    cmd.ExecuteNonQuery();

                    // Refresh the DataGridView after the delete
                    RefreshDataGridView();

                    MessageBox.Show("Book removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while removing book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void RefreshDataGridView()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-8PBDEDF\SQLEXPRESS;Initial Catalog=saif;Integrated Security=True;Encrypt=False";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM Book";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dgvViewBooks.DataSource = ds.Tables[0];
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
                con.ConnectionString = @"Data Source=DESKTOP-8PBDEDF\SQLEXPRESS;Initial Catalog=saif;Integrated Security=True;Encrypt=False";
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
                RefreshDataGridView();
            }
        }

        private void btnRefreshViewBook_Click(object sender, EventArgs e)
        {
            // Ensure grid is refreshed after clearing the search
            txtSearchViewBook.Clear();
            pnlURViewBooks.Visible = false;
            RefreshDataGridView();
        }

    }
}
