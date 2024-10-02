
namespace Try
{
    partial class BorrowHistory
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
            this.btnExitBH = new System.Windows.Forms.Button();
            this.lblBH = new System.Windows.Forms.Label();
            this.txtEnrollBH = new System.Windows.Forms.TextBox();
            this.txtNameBH = new System.Windows.Forms.TextBox();
            this.dgvBH = new System.Windows.Forms.DataGridView();
            this.lblEnrollBH = new System.Windows.Forms.Label();
            this.lblNameBH = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBH)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExitBH
            // 
            this.btnExitBH.BackColor = System.Drawing.Color.SandyBrown;
            this.btnExitBH.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitBH.Location = new System.Drawing.Point(864, 507);
            this.btnExitBH.Name = "btnExitBH";
            this.btnExitBH.Size = new System.Drawing.Size(192, 39);
            this.btnExitBH.TabIndex = 13;
            this.btnExitBH.Text = "Exit";
            this.btnExitBH.UseVisualStyleBackColor = false;
            // 
            // lblBH
            // 
            this.lblBH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBH.AutoSize = true;
            this.lblBH.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBH.ForeColor = System.Drawing.Color.Sienna;
            this.lblBH.Location = new System.Drawing.Point(415, 10);
            this.lblBH.Name = "lblBH";
            this.lblBH.Size = new System.Drawing.Size(333, 45);
            this.lblBH.TabIndex = 12;
            this.lblBH.Text = "Borrow History";
            // 
            // txtEnrollBH
            // 
            this.txtEnrollBH.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtEnrollBH.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnrollBH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtEnrollBH.Location = new System.Drawing.Point(704, 83);
            this.txtEnrollBH.Name = "txtEnrollBH";
            this.txtEnrollBH.Size = new System.Drawing.Size(330, 41);
            this.txtEnrollBH.TabIndex = 11;
            // 
            // txtNameBH
            // 
            this.txtNameBH.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtNameBH.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameBH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtNameBH.Location = new System.Drawing.Point(159, 83);
            this.txtNameBH.Name = "txtNameBH";
            this.txtNameBH.Size = new System.Drawing.Size(328, 41);
            this.txtNameBH.TabIndex = 10;
            // 
            // dgvBH
            // 
            this.dgvBH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBH.BackgroundColor = System.Drawing.Color.RosyBrown;
            this.dgvBH.ColumnHeadersHeight = 29;
            this.dgvBH.Location = new System.Drawing.Point(1, 201);
            this.dgvBH.Name = "dgvBH";
            this.dgvBH.RowHeadersWidth = 51;
            this.dgvBH.Size = new System.Drawing.Size(1065, 300);
            this.dgvBH.TabIndex = 9;
            // 
            // lblEnrollBH
            // 
            this.lblEnrollBH.AutoSize = true;
            this.lblEnrollBH.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnrollBH.ForeColor = System.Drawing.Color.Maroon;
            this.lblEnrollBH.Location = new System.Drawing.Point(602, 90);
            this.lblEnrollBH.Name = "lblEnrollBH";
            this.lblEnrollBH.Size = new System.Drawing.Size(101, 36);
            this.lblEnrollBH.TabIndex = 8;
            this.lblEnrollBH.Text = "Enroll:";
            // 
            // lblNameBH
            // 
            this.lblNameBH.AutoSize = true;
            this.lblNameBH.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameBH.ForeColor = System.Drawing.Color.Maroon;
            this.lblNameBH.Location = new System.Drawing.Point(58, 90);
            this.lblNameBH.Name = "lblNameBH";
            this.lblNameBH.Size = new System.Drawing.Size(100, 36);
            this.lblNameBH.TabIndex = 7;
            this.lblNameBH.Text = "Name:";
            // 
            // BorrowHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1067, 557);
            this.Controls.Add(this.btnExitBH);
            this.Controls.Add(this.lblBH);
            this.Controls.Add(this.txtEnrollBH);
            this.Controls.Add(this.txtNameBH);
            this.Controls.Add(this.dgvBH);
            this.Controls.Add(this.lblEnrollBH);
            this.Controls.Add(this.lblNameBH);
            this.Name = "BorrowHistory";
            this.Text = "BorrowHistory";
            this.Load += new System.EventHandler(this.BorrowHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExitBH;
        private System.Windows.Forms.Label lblBH;
        private System.Windows.Forms.TextBox txtEnrollBH;
        private System.Windows.Forms.TextBox txtNameBH;
        private System.Windows.Forms.DataGridView dgvBH;
        private System.Windows.Forms.Label lblEnrollBH;
        private System.Windows.Forms.Label lblNameBH;
    }
}