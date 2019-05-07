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

        public int bfrLen = Encoder.DEFAULT_LENGTH_BUFFER;

        NetworkingClient myClient;

        Encoder myEncoder;

        public IOT()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();

            Encoding.ASCII.GetBytes("");

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

            if (!Int32.TryParse(buffBox.Text.Trim(), out bfrLen))
            {

                var k = new Action(bufferParsingError);

                this.Invoke(k);

                return;

            }

            myEncoder = new Encoder(bfrLen, "ascii");

            try
            {

                myClient.Connect();

            }

            catch (Exception es) {

                Console.WriteLine(es.Message);

            }

            if (myClient.isConnected()) pnl.BackColor = Color.Green;

            this.Invoke((MethodInvoker)delegate {

                textBox.AppendText("\nSuccessfully connected to: " + myClient.Ip().ToString());

            });

        }

        private void bufferParsingError() {

            textBox.AppendText("\nCorrupted value entered in buffer length field. Using default value.");

        }

        private void portError() {

            textBox.AppendText("\nPlease enter values in all the required fields.");

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            pnl.BackColor = Color.Red;

            myClient.Disconnect();
            
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

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

            String message = "";

            if (msgBox.Text.Trim() == "") {

                this.Invoke((MethodInvoker)delegate {

                    textBox.AppendText("\nPlease enter a query in the query field.");

                });

                return;

            }

            else {

                this.Invoke((MethodInvoker)delegate {

                    message = msgBox.Text;

                });

            }

            myEncoder = new Encoder(bfrLen, "ascii");

            message = (Encoding.ASCII.GetString(myEncoder.Encode(Encoding.ASCII.GetBytes(message))));

            textBox.AppendText("\n"+message);
            

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }
    }
}
