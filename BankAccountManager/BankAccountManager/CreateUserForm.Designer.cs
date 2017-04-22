namespace BankAccountManager
{
    partial class CreateUserForm
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
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblPW = new System.Windows.Forms.Label();
            this.lblConfPW = new System.Windows.Forms.Label();
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.tbPW = new System.Windows.Forms.TextBox();
            this.tbConfPW = new System.Windows.Forms.TextBox();
            this.btnCreateID = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(71, 47);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(46, 13);
            this.lblUserID.TabIndex = 0;
            this.lblUserID.Text = "User ID:";
            // 
            // lblPW
            // 
            this.lblPW.AutoSize = true;
            this.lblPW.Location = new System.Drawing.Point(61, 91);
            this.lblPW.Name = "lblPW";
            this.lblPW.Size = new System.Drawing.Size(56, 13);
            this.lblPW.TabIndex = 1;
            this.lblPW.Text = "Password:";
            // 
            // lblConfPW
            // 
            this.lblConfPW.AutoSize = true;
            this.lblConfPW.Location = new System.Drawing.Point(23, 137);
            this.lblConfPW.Name = "lblConfPW";
            this.lblConfPW.Size = new System.Drawing.Size(94, 13);
            this.lblConfPW.TabIndex = 2;
            this.lblConfPW.Text = "Confirm Password:";
            // 
            // tbUserID
            // 
            this.tbUserID.Location = new System.Drawing.Point(135, 44);
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.Size = new System.Drawing.Size(100, 20);
            this.tbUserID.TabIndex = 3;
            // 
            // tbPW
            // 
            this.tbPW.Location = new System.Drawing.Point(135, 88);
            this.tbPW.Name = "tbPW";
            this.tbPW.Size = new System.Drawing.Size(100, 20);
            this.tbPW.TabIndex = 4;
            // 
            // tbConfPW
            // 
            this.tbConfPW.Location = new System.Drawing.Point(135, 134);
            this.tbConfPW.Name = "tbConfPW";
            this.tbConfPW.Size = new System.Drawing.Size(100, 20);
            this.tbConfPW.TabIndex = 5;
            // 
            // btnCreateID
            // 
            this.btnCreateID.Location = new System.Drawing.Point(42, 187);
            this.btnCreateID.Name = "btnCreateID";
            this.btnCreateID.Size = new System.Drawing.Size(100, 23);
            this.btnCreateID.TabIndex = 6;
            this.btnCreateID.Text = "Create Account";
            this.btnCreateID.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(181, 187);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // CreateUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 298);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreateID);
            this.Controls.Add(this.tbConfPW);
            this.Controls.Add(this.tbPW);
            this.Controls.Add(this.tbUserID);
            this.Controls.Add(this.lblConfPW);
            this.Controls.Add(this.lblPW);
            this.Controls.Add(this.lblUserID);
            this.Name = "CreateUserForm";
            this.Text = "Create your account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblPW;
        private System.Windows.Forms.Label lblConfPW;
        private System.Windows.Forms.TextBox tbUserID;
        private System.Windows.Forms.TextBox tbPW;
        private System.Windows.Forms.TextBox tbConfPW;
        private System.Windows.Forms.Button btnCreateID;
        private System.Windows.Forms.Button btnCancel;
    }
}