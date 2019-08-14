using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOT.Forms
{


    public partial class DatabaseForm : Form
    {

        public DatabaseForm()
        {
            InitializeComponent();


        }

        public Boolean isDatabseEnabled =>  dbEnabledCheckBox.Checked;

        public  void Disable()
        {

            dbEnabledCheckBox.Enabled = false;

            passwordBox.Enabled = false;

            userName.Enabled = false;

            serverName.Enabled = false;

            tableBox.Enabled = false;

        }

        public void Enable()
        {

            dbEnabledCheckBox.Enabled = true;

            passwordBox.Enabled = true;

            userName.Enabled = true;

            serverName.Enabled = true;

            tableBox.Enabled = true;

        }

        public  string Username => this.userName.Text;

        public  string Password => this.passwordBox.Text;

        public  string Server => this.serverName.Text;

        public string DefaultTable => this.tableBox.Text;

        private void BtnSave_Click_1(object sender, EventArgs e)
        {

            if (isDatabseEnabled)
            {

                if ((serverName.Text == "" || userName.Text == "")) MessageBox.Show("Please check the server/user field.");
                

            }
            Hide();
        }
    }

}
