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
    public partial class CreateUserForm : Form
    {
        public CreateUserForm()
        {
            InitializeComponent();

            RefreshForm();

            DB.ExecuteQuery("select * from usertb");
            if (DB.exception != string.Empty)
            {
                MessageBox.Show(DB.exception);
            }
        }
        private AccessClass DB = new AccessClass();
        string CreateCA;
        string CreateSA;
        string CreateBA;
        int NewAccountNum;
        string AddZero;
        void RefreshForm()
        {
            tbUserID.Clear();
            tbPW.Clear();
            tbConfPW.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        void CreateID()
        {
            if (tbUserID.Text == string.Empty)
            {
                MessageBox.Show("Please enter your user ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbUserID.Focus();
            }
            else if (tbPW.Text == string.Empty || tbConfPW.Text == string.Empty)
            {
                MessageBox.Show("Please enter password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbUserID.Focus();
            }
            else if (tbPW.Text != tbConfPW.Text)
            {
                MessageBox.Show("Password does not match with confirm password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dateTimePicker1.Value == DateTime.Now)
            {
                MessageBox.Show("Your date of birth is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DB.AddParam("userid", tbUserID.Text);
                }
                catch (Exception exUserID)
                {
                    MessageBox.Show("Sorry, this username has been used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbUserID.Focus();
                }
                DB.AddParam("@password", tbPW.Text);
                DB.AddParam("@dob", dateTimePicker1.Value);

                // create new account
                NewAccountNum = DB.RecordCount + 1;
                for(int i = 0; i < 11 - NewAccountNum.ToString().Length; i++)
                {
                    AddZero += "0";
                }
                CreateCA = "12341" + AddZero + NewAccountNum.ToString();
                CreateSA = "12342" + AddZero + NewAccountNum.ToString();
                CreateBA = "12343" + AddZero + NewAccountNum.ToString();

                DB.AddParam("@checkingaccount", CreateCA);
                DB.AddParam("@savingaccount", CreateSA);
                DB.AddParam("@businessaccount", CreateBA);

                DB.ExecuteQuery("insert into usertb values(@userid, @password, @dob, @checkingaccount, @savingaccount, @businessaccount)");

                DB.AddParam("@checkingaccount", CreateCA);
                DB.AddParam("@amount", 0);
                DB.ExecuteQuery("insert into checkingaccount(checkaccountid, amount) values(@checkingaccount, @amount)");

                DB.AddParam("@businessaccount", CreateBA);
                DB.AddParam("@amount", 0);
                DB.ExecuteQuery("insert into businessaccount(businessaccountid, amount) values(@businessaccount, @amount)");

                DB.AddParam("@savingaccount", CreateSA);
                DB.AddParam("@amount", 0);
                DB.ExecuteQuery("insert into savingaccount(savingaccountid, amount) values(@savingaccount, @amount)");


                if (DB.exception != string.Empty)
                {
                    MessageBox.Show(DB.exception);
                }
                else
                {
                    MessageBox.Show("Thank you for choosing JY Bank. Your account has been created successfully.");
                    Close();
                }
            }

        }
        private void btnCreateID_Click(object sender, EventArgs e)
        {
            CreateID();
        }
    }
}
