using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccountManager
{
    public partial class PanelForm : Form
    {
        public string userid;
        LoginForm LoginForm = new LoginForm();
        public PanelForm(string userid)
        {
            InitializeComponent();

            lblUserID.Text = userid;
            lblDate.Text = DateTime.Now.ToShortDateString();
        }

        DialogResult confirmClose;

        private void BtnSignOff_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PanelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            confirmClose = MessageBox.Show("Are you sure you want to sign off?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmClose == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                this.Hide();
                LoginForm.FormClosed += (s, args) => this.Close();
                LoginForm.Show();
            }
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            string nUserId = lblUserID.Text;
            BalanceForm BForm = new BalanceForm(nUserId);
            BForm.ShowDialog();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            string nUserId = lblUserID.Text;
            DepositForm DForm = new DepositForm(nUserId);
            DForm.ShowDialog();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            string nUserId = lblUserID.Text;
            WithdrawForm WForm = new WithdrawForm(nUserId);
            WForm.ShowDialog();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            string nUserId = lblUserID.Text;
            TransferForm TForm = new TransferForm(nUserId);
            TForm.ShowDialog();
        }
    }
}
