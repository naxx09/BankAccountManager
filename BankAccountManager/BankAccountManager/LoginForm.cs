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
    public partial class LoginForm : Form
    {
        private AccessClass DB = new AccessClass();
        public LoginForm()
        {
            InitializeComponent();

            RefreshForm();

            DB.ExecuteQuery("select * from usertb");
            if(DB.exception != string.Empty)
            {
                MessageBox.Show(DB.exception);
            } 
        }

        void RefreshForm()
        {
            tbUserID.Clear();
            tbPW.Clear();
        }

        void LoginFunction()
        {
            if(tbUserID.Text == string.Empty){
                MessageBox.Show("Please enter your user ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbUserID.Focus();
            }
            else if(tbPW.Text == string.Empty)
            {
                MessageBox.Show("Please enter password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPW.Focus();
            }
            else
            {
                DB.AddParam("@userid", tbUserID.Text);
                DB.AddParam("@password", tbPW.Text);
                DB.ExecuteQuery("select * from usertb where userid = @userid and password = @password");

                if (DB.RecordCount == 0)
                {
                    MessageBox.Show("Wrong user name or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                string nUserID = DB.dbDataTable.Rows[0]["userid"].ToString();

                PanelForm PanelForm = new PanelForm(nUserID);
                Hide();
                PanelForm.ShowDialog();
                }
            }
        }
        private void lblCreateID_Click(object sender, EventArgs e)
        {
            CreateUserForm CreateUserForm = new CreateUserForm();
            CreateUserForm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginFunction();
        }
    }
}
