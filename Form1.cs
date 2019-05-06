using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOT_SERVER
{
    public partial class IOT : Form
    {

        NetworkingClient myClient;

        public IOT()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();            

        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            if (portBox.Text == "" || addr.Text == "")
            {

                var k = new Action(portError);

                this.Invoke(k);

                return;
            }

            myClient = new NetworkingClient(NetworkingClient.ProtoType.TCP, addr.Text.Trim(), Int32.Parse(portBox.Text.Trim()));

            myClient.Connect();

            if (myClient.isConnected()) pnl.BackColor = Color.Green;

            myClient.Disconnect();

        }

        private void portError() {

            textBox.AppendText("\nPlease enter values in all the required fields.");

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            pnl.BackColor = Color.Red;

            backgroundWorker1.CancelAsync();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textBox.Clear();
        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void IOT_Load(object sender, EventArgs e)
        {

        }
    }
}
