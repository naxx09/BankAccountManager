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
    public partial class TransferForm : Form
    {
        AccessClass DB = new AccessClass();
        string caNum, saNum, baNum, caAmount, saAmount, baAmount;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public TransferForm(string userid)
        {
            InitializeComponent();

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

            if (DB.exception != string.Empty)
            {
                MessageBox.Show(DB.exception);
            }

            cbFromAcct.Items.Add("Checking Account");
            cbFromAcct.Items.Add("Saving Account");
            cbFromAcct.Items.Add("Business Account");

            cbToAcct.Items.Add("Checking Account");
            cbToAcct.Items.Add("Saving Account");
            cbToAcct.Items.Add("Business Account");

            lblUserID.Text = userid;
            lblDate.Text = DateTime.Now.ToShortDateString();

            Reset();
        }
        void Reset()
        {
            cbFromAcct.SelectedItem = null;
            cbToAcct.SelectedItem = null;
            tbAmount.Clear();
        }
        void TransferTo()
        {
            decimal amount = decimal.Parse(tbAmount.Text);
            // to checking account
            if (cbToAcct.Text == "Checking Account")
            {
                caAmount = (decimal.Parse(caAmount) + amount).ToString();
                DB.AddParam("@amount", caAmount);
                DB.AddParam("@canum", caNum);
                DB.ExecuteQuery("update checkingaccount set amount = @amount where checkaccountid = @canum");
                if (DB.exception != string.Empty)
                {
                    MessageBox.Show(DB.exception);
                }
                else
                {
                    MessageBox.Show(amount + " USD has been transfered into checking account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
            }
            // to saving account
            else if (cbToAcct.Text == "Saving Account")
            {
                saAmount = (decimal.Parse(saAmount) + amount).ToString();
                DB.AddParam("@amount", saAmount);
                DB.AddParam("@sanum", saNum);
                DB.ExecuteQuery("update savingaccount set amount = @amount where savingaccountid = @sanum");
                if (DB.exception != string.Empty)
                {
                    MessageBox.Show(DB.exception);
                }
                else
                {
                    MessageBox.Show(amount + " USD has been transfered into saving account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
            }
            // to business account
            else if (cbToAcct.Text == "Business Account")
            {
                baAmount = (decimal.Parse(baAmount) + amount).ToString();
                DB.AddParam("@amount", baAmount);
                DB.AddParam("@banum", baNum);
                DB.ExecuteQuery("update businessaccount set amount = @amount where businessaccountid = @banum");
                if (DB.exception != string.Empty)
                {
                    MessageBox.Show(DB.exception);
                }
                else
                {
                    MessageBox.Show(amount + " USD has been transfered into business account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cbFromAcct.SelectedItem == null || cbToAcct.SelectedItem == null)
            {
                MessageBox.Show("Please select account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (decimal.TryParse(tbAmount.Text, out decimal amount) == false || tbAmount.Text == string.Empty || decimal.Parse(tbAmount.Text) == 0)
            {
                MessageBox.Show("Transfer amount is not valid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cbFromAcct.SelectedItem == cbToAcct.SelectedItem)
            {
                MessageBox.Show("You cannot transfer in same account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                amount = decimal.Parse(tbAmount.Text);

                // from checking account
                if (cbFromAcct.Text == "Checking Account")
                {
                    if (decimal.Parse(caAmount) < amount)
                    {
                        MessageBox.Show("Your checking account balance is less than " + amount + " USD.", "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        caAmount = (decimal.Parse(caAmount) - amount).ToString();
                        DB.AddParam("@amount", caAmount);
                        DB.AddParam("@canum", caNum);
                        DB.ExecuteQuery("update checkingaccount set amount = @amount where checkaccountid = @canum");
                        if (DB.exception != string.Empty)
                        {
                            MessageBox.Show(DB.exception);
                        }
                        else
                        {
                            TransferTo();
                        }
                    }
                }
                // from saving account
                else if (cbFromAcct.Text == "Saving Account")
                {
                    if (decimal.Parse(saAmount) < amount)
                    {
                        MessageBox.Show("Your saving account balance is less than " + amount + " USD.", "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        saAmount = (decimal.Parse(saAmount) - amount).ToString();
                        DB.AddParam("@amount", saAmount);
                        DB.AddParam("@sanum", saNum);
                        DB.ExecuteQuery("update savingaccount set amount = @amount where savingaccountid = @sanum");
                        if (DB.exception != string.Empty)
                        {
                            MessageBox.Show(DB.exception);
                        }
                        else
                        {
                            TransferTo();
                        }
                    }
                }
                // from business account
                else if (cbFromAcct.Text == "Business Account")
                {
                    if (decimal.Parse(baAmount) < amount)
                    {
                        MessageBox.Show("Your business account balance is less than " + amount + " USD.", "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        baAmount = (decimal.Parse(baAmount) - amount).ToString();
                        DB.AddParam("@amount", baAmount);
                        DB.AddParam("@banum", baNum);
                        DB.ExecuteQuery("update businessaccount set amount = @amount where businessaccountid = @banum");
                        if (DB.exception != string.Empty)
                        {
                            MessageBox.Show(DB.exception);
                        }
                        else
                        {
                            TransferTo();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }
    }
}
