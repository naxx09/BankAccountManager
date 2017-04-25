namespace BankAccountManager
{
    partial class WithdrawForm
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
            this.lblDate = new System.Windows.Forms.Label();
            this.btn20D = new System.Windows.Forms.Button();
            this.btn40D = new System.Windows.Forms.Button();
            this.btn100D = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(12, 9);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(42, 13);
            this.lblUserID.TabIndex = 0;
            this.lblUserID.Text = "User iD";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(90, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date";
            // 
            // btn20D
            // 
            this.btn20D.Location = new System.Drawing.Point(38, 58);
            this.btn20D.Name = "btn20D";
            this.btn20D.Size = new System.Drawing.Size(75, 23);
            this.btn20D.TabIndex = 2;
            this.btn20D.Text = "20 USD";
            this.btn20D.UseVisualStyleBackColor = true;
            this.btn20D.Click += new System.EventHandler(this.btn20D_Click);
            // 
            // btn40D
            // 
            this.btn40D.Location = new System.Drawing.Point(119, 58);
            this.btn40D.Name = "btn40D";
            this.btn40D.Size = new System.Drawing.Size(75, 23);
            this.btn40D.TabIndex = 3;
            this.btn40D.Text = "40 USD";
            this.btn40D.UseVisualStyleBackColor = true;
            this.btn40D.Click += new System.EventHandler(this.btn40D_Click);
            // 
            // btn100D
            // 
            this.btn100D.Location = new System.Drawing.Point(200, 58);
            this.btn100D.Name = "btn100D";
            this.btn100D.Size = new System.Drawing.Size(75, 23);
            this.btn100D.TabIndex = 4;
            this.btn100D.Text = "100 USD";
            this.btn100D.UseVisualStyleBackColor = true;
            this.btn100D.Click += new System.EventHandler(this.btn100D_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "USD";
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(38, 135);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(100, 20);
            this.tbAmount.TabIndex = 6;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(200, 133);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Confirm";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Quick withdraw";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Enter Amount:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(200, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // WithdrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 223);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn100D);
            this.Controls.Add(this.btn40D);
            this.Controls.Add(this.btn20D);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblUserID);
            this.Name = "WithdrawForm";
            this.Text = "Withdraw";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btn20D;
        private System.Windows.Forms.Button btn40D;
        private System.Windows.Forms.Button btn100D;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
    }
}