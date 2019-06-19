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
using System.Net;

namespace IOT_SERVER
{
    public partial class IOT : Form
    {        

        NetworkingClient myClient;

        SimpleServer Server;

        SimpleSerial Serial;

        Encoder myEncoder;

        object  myLock = new object();

        Boolean running = true;
        public enum MODE {SERVER, CLIENT, NONE};

        public int bfrLen = Encoder.DEFAULT_LENGTH_BUFFER;

        private MODE State;        

        public IOT()
        {
            InitializeComponent();

            ClientsTab.Hide();

            myEncoder = new Encoder(bfrLen, "ascii");

            comPortBox.Items.AddRange( SimpleSerial.GetPorts() );            

            baudRateBox.Items.AddRange(new object[] { 4800,9600, 14400, 19200, 38400, 57600, 115200, 128000, 256000 });

            baudRateBox.SelectedIndex = 0 ;

            portBox.SelectedIndex = 0;

            addressBox.SelectedIndex = 1;

            comPortBox.SelectedIndex = 0;

            protocolBox.SelectedIndex = 0;

            bufferLengthBox.SelectedIndex = 0;

            button4.Enabled = false;

            State = MODE.NONE;
        }

        private void StartClientProcessEvent(object sender, EventArgs e)
        {

            if (this.State == MODE.CLIENT || this.State == MODE.SERVER)
            {

                ShowErrorMessage("Cannot start event. Application is in " + this.State.ToString() + " mode.");

            }

            else {

                running = true;

                this.State = MODE.CLIENT;

                ClientWorker.RunWorkerAsync();

            }

        }

        private void ClientWorkerEvent(object sender, DoWorkEventArgs e)
        {

            if (GetComboSelectedText(portBox) == "" || GetComboSelectedText(addressBox) == "")
            {

                var k = new Action(PortError);

                this.Invoke(k);

                return;
            }


            if (!Int32.TryParse(GetComboSelectedText(bufferLengthBox).Trim(), out int bufferLength))
            {

                bufferLength = NetworkingClient.B_SIZE_DEAFULT;

            }

            NetworkingClient.ProtoType type;            

            type = (GetComboSelectedText(protocolBox) == "TCP") ? NetworkingClient.ProtoType.TCP : NetworkingClient.ProtoType.UDP;

            //AppendText(type.ToString());

            myClient = new NetworkingClient(type, GetComboSelectedText(addressBox).Trim(), Int32.Parse(GetComboSelectedText(portBox).Trim()), bufferLength);

            myClient.ServerDisconnect += MyClient_ServerDisconnect;

            myEncoder = new Encoder(Encoder.DEFAULT_LENGTH_BUFFER, "ascii");

            Serial = new SimpleSerial(GetComboSelectedText(comPortBox), Int32.Parse(GetComboSelectedText(baudRateBox)), true);

            Serial.DataReady += delegate
            {

                String data = Serial.ReadString();

                myClient.Write(myEncoder.Encode(Encoding.ASCII.GetBytes(data)));

                textBox.AppendText(data);

                if (autoScroll.Checked) textBox.ScrollToCaret();

            };

            try
            {

                if (myClient.Connect() > 0) AppendText("Connected succesfully to " + myClient.Ip());

            }

            catch (Exception es)
            {

                Console.WriteLine(es.Message);

                ShowErrorMessage("Connection Error\n");

            }

            if (myClient.IsConnected()) pnl.BackColor = Color.Green;


            while (!ClientWorker.CancellationPending)
            {

                lock (myLock)
                {

                    if (!running) return;

                }

                int btsRecv = myClient.Read();

                if (btsRecv > 0)
                {

                    AppendText("\nMessage from: " + myClient.Ip().ToString() + " " + Encoding.ASCII.GetString(myClient.readBuffer));                   

                }

                Thread.Sleep(10);

            }

        }

        private void MyClient_ServerDisconnect(object sender, EventArgs e)
        {

            AppendText("Server disconnected.");

            StopButtonEvent(sender, e);
            
        }

        private string GetComboSelectedText(System.Windows.Forms.ComboBox control) {


            string newText = "";

            this.Invoke((MethodInvoker)delegate
            {

                newText = control.SelectedItem.ToString();

            });

            return newText;

        }

        private void PortError() {

            textBox.AppendText("\nPlease enter values in all the required fields.");

        }

        private void StopButtonEvent(object sender, EventArgs e)
        {
            running = false;

            switch (State) {

                case MODE.CLIENT:

                    ClientWorker.CancelAsync();

                    try {

                       myClient.Disconnect(); 

                        Serial.Close();

                    }

                    catch (Exception) { }

                    finally { State = MODE.NONE; }

                    AppendText("Succesfully Disconnected.");

                    break;

                case MODE.SERVER:                                        

                    ServerWorker.CancelAsync();                    

                    Thread.Sleep(500);                   

                    Server.Close();                    

                    State = MODE.NONE;

                    AppendText("Succesfully closed server.");

                    break;

            }

            this.ClientList.Items.Clear();

            State = MODE.NONE;
            
            pnl.BackColor = Color.Red; 

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textBox.Clear();            

        }

        private void SendButtonEvent(object sender, EventArgs e)
        {

            String message = "";

            if (msgBox.Text.Trim() == "") {

                ShowErrorMessage("Please enter a query in the field.");

                return;

            }

            else {

                this.Invoke((MethodInvoker)delegate {

                    message = msgBox.Text;

                });

            }

            switch (State) {

                case MODE.CLIENT:

                    myClient.Write(myEncoder.Encode(Encoding.ASCII.GetBytes(message)));

                    break;

                case MODE.SERVER:

                    //Server.SendMessage(myEncoder.Encode(Encoding.ASCII.GetBytes(message)));                    

                    break;
            }


        }
 
        private void ScrollToCursorButton(object sender, EventArgs e)
        {
            textBox.ScrollToCaret();
        }

        private void ServerWorkerEvent(object sender, DoWorkEventArgs e)
        {


            if (!Int32.TryParse(GetComboSelectedText(portBox).Trim(), out int portNumber))
            {

                portNumber = SimpleServer.DEFAULT_SERVER_PORT;

            }

            Server = new SimpleServer(portNumber);

            Server.AcceptEvent += Server_AcceptEvent;

            Server.ConnectionClosed += Server_ConnectionClosed;

            String s = Server.Init();

            AppendText(s);

            s = null;

            for (; running == true;)
            {
                Server.Accept();

                s = (Server.GetMessage());
          
                if (s != null)
                {

                    AppendText(s);

                    if (autoScroll.Checked) {
                        this.Invoke((MethodInvoker)delegate {

                            textBox.ScrollToCaret();

                        });

                        s = null;
                }
            }                

            }

        }

        private void Server_ConnectionClosed(object sender, NetworkingServer.CloseConnectionEventArgs e)
        {
             
            this.Invoke((MethodInvoker)delegate 
            
            {
                ClientList.Items.RemoveByKey(e.Key.ToString());                
                
            });

        }

        private void Server_AcceptEvent(object sender, NetworkingServer.AcceptEventArgs e)
        {
            Console.WriteLine("Event");

            ListViewItem item = new ListViewItem();

            string remote = e.endp.ToString();

            item.Name = e.Name; 

            item.Text = e.Name;

            int index = remote.IndexOf(":");

            item.SubItems.Add(remote.Substring(0, index));

            item.SubItems.Add(remote.Substring(index + 1));

            item.SubItems.Add(DateTime.Now.ToString());

            try
            {
                AddToList(item);
            }
            catch (Exception ) {                
            }

        }

        private void ServerButtonStartEvent(object sender, EventArgs e)
        {

            if (this.State == MODE.CLIENT || this.State == MODE.SERVER)
            {

                ShowErrorMessage("Cannot start event. Application is in " + this.State.ToString() + " mode."); 

            }

            else {                

                this.State = MODE.SERVER;

                running = true;                

                ServerWorker.RunWorkerAsync();

                pnl.BackColor = Color.Green;

            }

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

        private void AddToList(ListViewItem item) {

            this.Invoke((MethodInvoker)delegate { ClientList.Items.Add(item); });

        }

        private void AddressBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddToCombo(addressBox);
        }

        private void AddToCombo(System.Windows.Forms.ComboBox box) {

            String s;

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

        private void AutoScroll_CheckedChanged(object sender, EventArgs e)
        {
            button4.Enabled = !button4.Enabled;            

        }

        private void ShowErrorMessage(string msg) {

            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private  void ClientsTabSendButton_Click(object sender, EventArgs e)
        {
            
            byte[] buff = myEncoder.Encode(Encoding.ASCII.GetBytes(this.ClientsTabTextbox.Text.Trim()));

            for (int i = 0; i < ClientList.SelectedItems.Count; i++) {

                Server.SendMessage(Int32.Parse(ClientList.SelectedItems[i].Text), buff);

            }

        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.State == MODE.CLIENT && this.TabControl.SelectedTab == ClientsTab) {
                (this.TabControl).SelectedTab = ClientsTab;
            }
        }

        private void RemoveClientButtonEvent(object sender, EventArgs e)
        {
            for (int  i = 0; i < ClientList.SelectedItems.Count; i++)

                Server.RemoveClient(Int32.Parse(ClientList.SelectedItems[i].Text));

        }
    }
}
