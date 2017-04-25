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
    public partial class DepositForm : Form
    {
        string caNum;
        string saNum;
        string baNum;
        string caAmount;
        string saAmount;
        string baAmount;

        AccessClass DB = new AccessClass();
        public DepositForm(string userid)
        {
            InitializeComponent();

            lblUserID.Text = userid;
            lblDate.Text = DateTime.Now.ToShortDateString();

            DB.AddParam("@userid", userid);
            DB.ExecuteQuery("select * from usertb where userid = @userid");
            caNum = DB.dbDataTable.Rows[0]["checkingaccount"].ToString();
            saNum = DB.dbDataTable.Rows[0]["savingaccount"].ToString();
            baNum = DB.dbDataTable.Rows[0]["businessaccount"].ToString();

            DB.AddParam("@checkingaccount", caNum);
            DB.ExecuteQuery("select * from checkingaccount where checkaccountid = @checkingaccount");
            caAmount = DB.dbDataTable.Rows[0]["amount"].ToString();

            DB.AddParam("@savingaccount", saNum);
            DB.ExecuteQuery("select * from savingaccount where savingaccountid = @savingaccount");
            saAmount = DB.dbDataTable.Rows[0]["amount"].ToString();

            DB.AddParam("@businessaccount", baNum);
            DB.ExecuteQuery("select * from businessaccount where businessaccountid = @businessaccount");
            baAmount = DB.dbDataTable.Rows[0]["amount"].ToString();

            cbSelectAcct.Items.Add("Checking Account");
            cbSelectAcct.Items.Add("Saving Account");
            cbSelectAcct.Items.Add("Business Account");

            Reset();
        }
        void Reset()
        {
            cbSelectAcct.SelectedItem = "Please select account";
            tbAmount.Clear();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cbSelectAcct.SelectedItem == null)
            {
                MessageBox.Show("Please select an account you want to deposit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (decimal.TryParse(tbAmount.Text, out decimal amount) == false || tbAmount.Text == string.Empty || decimal.Parse(tbAmount.Text) == 0)
            {
                MessageBox.Show("Deposit amount is not valid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cbSelectAcct.Text == "Checking Account")
            {
                amount = decimal.Parse(tbAmount.Text) + decimal.Parse(caAmount);
                DB.AddParam("@amount", amount);
                DB.AddParam("@canum", caNum);
                DB.ExecuteQuery("update checkingaccount set amount = @amount where checkaccountid = @canum");

                if (DB.exception != string.Empty)
                {
                    MessageBox.Show(DB.exception);
                }
                else
                {
                    MessageBox.Show(amount + " USD has been deposited into your checking account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
            }
            else if (cbSelectAcct.Text == "Saving Account")
            {
                amount = decimal.Parse(tbAmount.Text) + decimal.Parse(saAmount);
                DB.AddParam("@amount", amount);
                DB.AddParam("@sanum", saNum);
                DB.ExecuteQuery("update savingaccount set amount = @amount where savingaccountid = @sanum");

                if (DB.exception != string.Empty)
                {
                    MessageBox.Show(DB.exception);
                }
                else
                {
                    MessageBox.Show(amount + " USD has been deposited into your saving account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
            }
            else if (cbSelectAcct.Text == "Business Account")
            {
                amount = decimal.Parse(tbAmount.Text) + decimal.Parse(baAmount);
                DB.AddParam("@amount", amount);
                DB.AddParam("@banum", baNum);
                DB.ExecuteQuery("update businessaccount set amount = @amount where businessaccountid = @banum");

                if (DB.exception != string.Empty)
                {
                    MessageBox.Show(DB.exception);
                }
                else
                {
                    MessageBox.Show(amount + " USD has been deposited into your business account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
