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
    public partial class BalanceForm : Form
    {
        private AccessClass DB = new AccessClass();
        public BalanceForm(string userid)
        {
            InitializeComponent();

            Reset();

            DB.AddParam("@userid", userid);
            DB.ExecuteQuery("select * from usertb where userid = @userid");
            string caNum = DB.dbDataTable.Rows[0]["checkingaccount"].ToString();
            string saNum = DB.dbDataTable.Rows[0]["savingaccount"].ToString();
            string baNum = DB.dbDataTable.Rows[0]["businessaccount"].ToString();

            DB.AddParam("@checkingaccount", caNum);
            DB.ExecuteQuery("select * from checkingaccount where checkaccountid = @checkingaccount");
            string caAmount = DB.dbDataTable.Rows[0]["amount"].ToString();

            DB.AddParam("@savingaccount", saNum);
            DB.ExecuteQuery("select * from savingaccount where savingaccountid = @savingaccount");
            string saAmount = DB.dbDataTable.Rows[0]["amount"].ToString();

            DB.AddParam("@businessaccount", baNum);
            DB.ExecuteQuery("select * from businessaccount where businessaccountid = @businessaccount");
            string baAmount = DB.dbDataTable.Rows[0]["amount"].ToString();

            lblCheckingAcct.Text = caNum;
            lblCADebit.Text = caAmount;

            lblSavingAcct.Text = saNum;
            lblSADebit.Text = saAmount;

            lblBusinessAcct.Text = baNum;
            lblBADebit.Text = baAmount;

            lblUserID.Text = userid;
            lblDate.Text = DateTime.Now.ToShortDateString();
        }
        void Reset()
        {
            lblCheckingAcct.Text = string.Empty;
            lblCADebit.Text = string.Empty;

            lblSavingAcct.Text = string.Empty;
            lblSADebit.Text = string.Empty;

            lblBusinessAcct.Text = string.Empty;
            lblBADebit.Text = string.Empty;

            lblUserID.Text = string.Empty;
            lblDate.Text = string.Empty;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
