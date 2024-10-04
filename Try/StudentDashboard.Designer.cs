namespace LIBRARY_MANAGEMENT_SYSTEM
{
    partial class StudentDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssueReturnBookInfo));
            this.btnBH = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnViewBooks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBH
            // 
            this.btnBH.BackColor = System.Drawing.Color.RosyBrown;
            this.btnBH.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBH.Location = new System.Drawing.Point(20, 38);
            this.btnBH.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnBH.Name = "btnBH";
            this.btnBH.Size = new System.Drawing.Size(198, 75);
            this.btnBH.TabIndex = 13;
            this.btnBH.Text = "Borrow History";
            this.btnBH.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(482, 774);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Welcome To the Student Dash Board";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(-24, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1204, 627);
            this.panel1.TabIndex = 16;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.RosyBrown;
            this.btnLogOut.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(995, 38);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(112, 75);
            this.btnLogOut.TabIndex = 15;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            // 
            // btnViewBooks
            // 
            this.btnViewBooks.BackColor = System.Drawing.Color.RosyBrown;
            this.btnViewBooks.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewBooks.Location = new System.Drawing.Point(253, 38);
            this.btnViewBooks.Name = "btnViewBooks";
            this.btnViewBooks.Size = new System.Drawing.Size(203, 75);
            this.btnViewBooks.TabIndex = 14;
            this.btnViewBooks.Text = "View Books";
            this.btnViewBooks.UseVisualStyleBackColor = false;
            // 
            // IssueReturnBookInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1187, 796);
            this.Controls.Add(this.btnBH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnViewBooks);
            this.Name = "IssueReturnBookInfo";
            this.Text = "StudentDashboard";
            //this.Load += new System.EventHandler(this.IssueReturnBookInfo_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnViewBooks;
    }
}