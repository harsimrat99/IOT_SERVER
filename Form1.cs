using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOT_SERVER
{
    public partial class IOT : Form
    {

        public int bfrLen = Encoder.DEFAULT_LENGTH_BUFFER;

        NetworkingClient myClient;

        Encoder myEncoder;

        object myLock = new object();

        Boolean running = true;

        public IOT()
        {
            InitializeComponent();

            myEncoder = new Encoder(bfrLen, "ascii");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            running = true;

            backgroundWorker1.RunWorkerAsync();           

        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            this.Invoke((MethodInvoker)delegate
            {

                textBox.AppendText("\nMessage : " );

            });


            if (portBox.Text == "" || addr.Text == "")
            {

                var k = new Action(portError);

                this.Invoke(k);

                return;
            }

            int bufferLength;

            if (!Int32.TryParse(buffBox.Text.Trim(), out bufferLength))
            {

                bufferLength = NetworkingClient.B_SIZE_DEAFULT;

            }

            NetworkingClient.ProtoType type;

            String text = "";

            Action accessU = () => text = proBox.SelectedItem.ToString();

            if (InvokeRequired)

                Invoke(accessU);

            else

                accessU();

            type = (text == "TCP") ? NetworkingClient.ProtoType.TCP : NetworkingClient.ProtoType.UDP;

            myClient = new NetworkingClient(type, addr.Text.Trim(), Int32.Parse(portBox.Text.Trim()), bufferLength);

            myEncoder = new Encoder(Encoder.DEFAULT_LENGTH_BUFFER, "ascii");

            try
            {

                myClient.Connect();

            }

            catch (Exception es)
            {

                Console.WriteLine(es.Message);

            }

            if (myClient.isConnected()) pnl.BackColor = Color.Green;

            //this.Invoke((MethodInvoker)delegate
            //{

            //    textBox.AppendText("\nSuccessfully connected to: " + myClient.Ip().ToString());

            //});

            while (!backgroundWorker1.CancellationPending)
            {

                lock (myLock)
                {

                    if (!running) return;

                }

                int btsRecv = myClient.Read();

                if (btsRecv > 0)
                {

                    this.Invoke((MethodInvoker)delegate
                    {

                        textBox.AppendText("\nMessage from: " + myClient.Ip().ToString() + " " + Encoding.ASCII.GetString(myClient.readBuffer));

                    });

                }

                Thread.Sleep(100);

            }

        }

        private void bufferParsingError() {

            textBox.AppendText("\nCorrupted value entered in buffer length field. Using default value.");

        }

        private void portError() {

            textBox.AppendText("\nPlease enter values in all the required fields.");

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            running = false;

            backgroundWorker1.CancelAsync();

            backgroundWorker2.CancelAsync();

            pnl.BackColor = Color.Red;

            try
            {
                myClient.Disconnect();
            }

            catch (Exception ex) {

                Console.WriteLine(ex.ToString());

            }             

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

        //Send button
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

            myClient.Write(myEncoder.Encode(Encoding.ASCII.GetBytes(message)));                        

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox.ScrollToCaret();
        }

        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

            int portNumber;
            

            if (!Int32.TryParse(portBox.Text.Trim(), out portNumber)) {

                portNumber = SimpleServer.DEFAULT_SERVER_PORT;

            }

            SimpleServer Server = new SimpleServer(portNumber);

            String s = Server.Init();

            this.Invoke((MethodInvoker)delegate {

                textBox.AppendText("\n" + s);

            });            

            for (; ; ) {

                Thread.Sleep(50);

                s =(Server.GetMessage());

                if (s != null) {


                    this.Invoke((MethodInvoker)delegate {

                        textBox.AppendText("\n" + s);

                    });
                }

            }

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            backgroundWorker2.RunWorkerAsync();

            pnl.BackColor = Color.Green;

        }
    }
}
