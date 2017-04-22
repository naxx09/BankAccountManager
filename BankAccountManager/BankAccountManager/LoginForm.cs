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
        private AccessClass UserDB = new AccessClass();
        public LoginForm()
        {
            InitializeComponent();

            UserDB.ExecuteQuery("select * from usertb");
            if(UserDB.exception != string.Empty)
            {
                MessageBox.Show(UserDB.exception);
            }
            
        }
    }
}
