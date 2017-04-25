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
    public partial class WithdrawForm : Form
    {
        AccessClass DB = new AccessClass();
        string amount;
        string caNum;
        public WithdrawForm(string userid)
        {
            InitializeComponent();

            DB.AddParam("@userid", userid);
            DB.ExecuteQuery("select * from usertb where userid = @userid");
            caNum = DB.dbDataTable.Rows[0]["checkingaccount"].ToString();

            DB.AddParam("@checkingaccount", caNum);
            DB.ExecuteQuery("select * from checkingaccount where checkaccountid = @checkingaccount");
            amount = DB.dbDataTable.Rows[0]["amount"].ToString();

            lblUserID.Text = userid;
            lblDate.Text = DateTime.Now.ToShortDateString();
        }

        private void btn20D_Click(object sender, EventArgs e)
        {
            if(decimal.Parse(amount) < 20)
            {
                MessageBox.Show("Your checking account balance is less than 20 USD. Withdraw process failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                amount = (decimal.Parse(amount) - 20).ToString();
                DB.AddParam("@amount", amount);
                DB.AddParam("@canum", caNum);
                DB.ExecuteQuery("update checkingaccount set amount = @amount where checkaccountid = @canum");

                if (DB.exception != string.Empty)
                {
                    MessageBox.Show(DB.exception);
                }
                else
                {
                    MessageBox.Show("20 USD has been withdrawn from your checking account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn40D_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(amount) < 40)
            {
                MessageBox.Show("Your checking account balance is less than 40 USD. Withdraw process failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                amount = (decimal.Parse(amount) - 40).ToString();
                DB.AddParam("@amount", amount);
                DB.AddParam("@canum", caNum);
                DB.ExecuteQuery("update checkingaccount set amount = @amount where checkaccountid = @canum");

                if (DB.exception != string.Empty)
                {
                    MessageBox.Show(DB.exception);
                }
                else
                {
                    MessageBox.Show("40 USD has been withdrawn from your checking account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn100D_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(amount) < 100)
            {
                MessageBox.Show("Your checking account balance is less than 100 USD. Withdraw process failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                amount = (decimal.Parse(amount) - 100).ToString();
                DB.AddParam("@amount", amount);
                DB.AddParam("@canum", caNum);
                DB.ExecuteQuery("update checkingaccount set amount = @amount where checkaccountid = @canum");

                if (DB.exception != string.Empty)
                {
                    MessageBox.Show(DB.exception);
                }
                else
                {
                    MessageBox.Show("100 USD has been withdrawn from your checking account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(tbAmount.Text, out decimal txtAmount) == false || tbAmount.Text == string.Empty || decimal.Parse(tbAmount.Text) == 0)
            {
                MessageBox.Show("Withdraw amount is not valid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(decimal.Parse(amount) < decimal.Parse(tbAmount.Text))
            {
                MessageBox.Show("Your checking account balance is less than "+ tbAmount.Text +" USD. Withdraw process failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                amount = (decimal.Parse(amount) - decimal.Parse(tbAmount.Text)).ToString();
                DB.AddParam("@amount", amount);
                DB.AddParam("@canum", caNum);
                DB.ExecuteQuery("update checkingaccount set amount = @amount where checkaccountid = @canum");

                if (DB.exception != string.Empty)
                {
                    MessageBox.Show(DB.exception);
                }
                else
                {
                    MessageBox.Show(tbAmount.Text + " USD has been withdrawn from your checking account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
