namespace LIBRARY_MANAGEMENT_SYSTEM
{
    partial class IssueReturnBookInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvReturnBooksInfo = new System.Windows.Forms.DataGridView();
            this.dgvIssueBooksInfo = new System.Windows.Forms.DataGridView();
            this.lblReturnBooksInfo = new System.Windows.Forms.Label();
            this.lblIssueBooksInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnBooksInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssueBooksInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReturnBooksInfo
            // 
            this.dgvReturnBooksInfo.AllowUserToAddRows = false;
            this.dgvReturnBooksInfo.AllowUserToDeleteRows = false;
            this.dgvReturnBooksInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReturnBooksInfo.BackgroundColor = System.Drawing.Color.RosyBrown;
            this.dgvReturnBooksInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturnBooksInfo.Location = new System.Drawing.Point(1, 268);
            this.dgvReturnBooksInfo.Margin = new System.Windows.Forms.Padding(2);
            this.dgvReturnBooksInfo.Name = "dgvReturnBooksInfo";
            this.dgvReturnBooksInfo.ReadOnly = true;
            this.dgvReturnBooksInfo.RowHeadersWidth = 62;
            this.dgvReturnBooksInfo.RowTemplate.Height = 28;
            this.dgvReturnBooksInfo.Size = new System.Drawing.Size(1063, 196);
            this.dgvReturnBooksInfo.TabIndex = 7;
            this.dgvReturnBooksInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReturnBooksInfo_CellContentClick);
            // 
            // dgvIssueBooksInfo
            // 
            this.dgvIssueBooksInfo.AllowUserToAddRows = false;
            this.dgvIssueBooksInfo.AllowUserToDeleteRows = false;
            this.dgvIssueBooksInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIssueBooksInfo.BackgroundColor = System.Drawing.Color.RosyBrown;
            this.dgvIssueBooksInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIssueBooksInfo.Location = new System.Drawing.Point(1, 36);
            this.dgvIssueBooksInfo.Margin = new System.Windows.Forms.Padding(2);
            this.dgvIssueBooksInfo.Name = "dgvIssueBooksInfo";
            this.dgvIssueBooksInfo.ReadOnly = true;
            this.dgvIssueBooksInfo.RowHeadersWidth = 62;
            this.dgvIssueBooksInfo.RowTemplate.Height = 28;
            this.dgvIssueBooksInfo.Size = new System.Drawing.Size(1063, 196);
            this.dgvIssueBooksInfo.TabIndex = 6;
            // 
            // lblReturnBooksInfo
            // 
            this.lblReturnBooksInfo.AutoSize = true;
            this.lblReturnBooksInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnBooksInfo.Location = new System.Drawing.Point(459, 246);
            this.lblReturnBooksInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReturnBooksInfo.Name = "lblReturnBooksInfo";
            this.lblReturnBooksInfo.Size = new System.Drawing.Size(156, 20);
            this.lblReturnBooksInfo.TabIndex = 5;
            this.lblReturnBooksInfo.Text = "Return Books Info";
            // 
            // lblIssueBooksInfo
            // 
            this.lblIssueBooksInfo.AutoSize = true;
            this.lblIssueBooksInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueBooksInfo.Location = new System.Drawing.Point(459, 9);
            this.lblIssueBooksInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIssueBooksInfo.Name = "lblIssueBooksInfo";
            this.lblIssueBooksInfo.Size = new System.Drawing.Size(145, 20);
            this.lblIssueBooksInfo.TabIndex = 4;
            this.lblIssueBooksInfo.Text = "Issue Books Info";
            // 
            // IssueReturnBookInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1064, 472);
            this.Controls.Add(this.dgvReturnBooksInfo);
            this.Controls.Add(this.dgvIssueBooksInfo);
            this.Controls.Add(this.lblReturnBooksInfo);
            this.Controls.Add(this.lblIssueBooksInfo);
            this.Name = "IssueReturnBookInfo";
            this.Text = "IssueReturnBookInfo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnBooksInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssueBooksInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReturnBooksInfo;
        private System.Windows.Forms.DataGridView dgvIssueBooksInfo;
        private System.Windows.Forms.Label lblReturnBooksInfo;
        private System.Windows.Forms.Label lblIssueBooksInfo;
    }
}