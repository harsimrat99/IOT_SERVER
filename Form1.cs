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
using Microsoft.VisualBasic;

namespace IOT_SERVER
{
    public partial class IOT : Form
    {

        public int bfrLen = Encoder.DEFAULT_LENGTH_BUFFER;

        NetworkingClient myClient;

        SimpleServer Server;

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

            if (GetComboSelectedText(portBox) == "" || GetComboSelectedText(addressBox) == "")
            {

                var k = new Action(portError);

                this.Invoke(k);

                return;
            }

            int bufferLength;

            if (!Int32.TryParse(GetComboSelectedText(bufferLengthBox).Trim(), out bufferLength))
            {

                bufferLength = NetworkingClient.B_SIZE_DEAFULT;

            }

            NetworkingClient.ProtoType type;            

            type = (GetComboSelectedText(protocolBox) == "TCP") ? NetworkingClient.ProtoType.TCP : NetworkingClient.ProtoType.UDP;

            //AppendText(type.ToString());

            myClient = new NetworkingClient(type, GetComboSelectedText(addressBox).Trim(), Int32.Parse(GetComboSelectedText(portBox).Trim()), bufferLength);

            myEncoder = new Encoder(Encoder.DEFAULT_LENGTH_BUFFER, "ascii");

            try
            {

                if (myClient.Connect() > 0) AppendText("Connected succesfully to " + myClient.Ip());

            }

            catch (Exception es)
            {

                Console.WriteLine(es.Message);

                AppendText("Connection Error\n");

            }

            if (myClient.isConnected()) pnl.BackColor = Color.Green;


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

                Thread.Sleep(10);

            }

        }


        private string GetComboSelectedText(System.Windows.Forms.ComboBox control) {


            string newText = "";

            this.Invoke((MethodInvoker)delegate
            {

                newText = control.SelectedItem.ToString();

            });

            return newText;

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

            try
            {
                Server.Close();

                myClient.Disconnect();

            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());

            }

            finally { pnl.BackColor = Color.Red; }

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

            int portNumber = 0;            

            if (!Int32.TryParse(GetComboSelectedText(portBox).Trim(), out portNumber)) {

                portNumber = SimpleServer.DEFAULT_SERVER_PORT;

            }

            Server = new SimpleServer(portNumber);

            String s = Server.Init();

            AppendText(s);

            for (; running == true ; ) {                

                s =(Server.GetMessage());

                if (s != null) {

                    AppendText(s);

                }

            }

        }

        private void Button5_Click(object sender, EventArgs e)
        {

            backgroundWorker2.RunWorkerAsync();

            running = true;

            pnl.BackColor = Color.Green;

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void PortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddToCombo(portBox);
        }

        private void AppendText(string s) {

            this.Invoke((MethodInvoker)delegate {

                textBox.AppendText("\n" + s);

            });

        }

        private void AddressBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddToCombo(addressBox);
        }

        private void AddToCombo(System.Windows.Forms.ComboBox box) {

            String s = "";

            if (box.SelectedIndex == box.Items.Count - 1)
            {

                 s = Interaction.InputBox("Add an item", "Add an item", null);

                if (s != null)
                {

                    box.Items.Insert(box.Items.Count - 1, s);

                    box.SelectedIndex = box.Items.Count - 2;

                }

            }
           
        }

        private void BufferLengthBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddToCombo(bufferLengthBox);
        }

        private void BackgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
