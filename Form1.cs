using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using IOT.Forms;
using Microsoft.VisualBasic;

namespace IOT_SERVER
{
    public partial class IOT : Form
    {        

        NetworkingClient myClient, azClient = null;

        SimpleServer Server;

        SimpleSerial Serial;

        Encoder myEncoder;

        object  myLock = new object();

        MySqlClient sqlClient;

        bool running = true;

        public enum MODE {SERVER, CLIENT, NONE};

        public int bfrLen = Encoder.DEFAULT_LENGTH_BUFFER;

        private MODE State;

        private DatabaseForm database;

        private MessageBuilder builder = new MessageBuilder();

        public IOT()
        {
            InitializeComponent();

            ClientsTab.Hide();

            myEncoder = new Encoder(bfrLen, "ascii");

            comPortBox.Items.AddRange( SimpleSerial.GetPorts() );            

            baudRateBox.Items.AddRange(new object[] { 4800,9600, 14400, 19200, 38400, 57600, 115200, 128000, 256000 });

            baudRateBox.SelectedIndex = 0 ;

            portBox.SelectedIndex = 0;

            addressBox.SelectedIndex = 0;

            comPortBox.SelectedIndex = 0;

            protocolBox.SelectedIndex = 0;

            bufferLengthBox.SelectedIndex = 0;

            button4.Enabled = false;

            State = MODE.NONE;

            database = new DatabaseForm();

           

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

                msgBox.Enabled = true;

                SendButton.Enabled = true;

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

            myEncoder = new Encoder(Encoder.DEFAULT_LENGTH_BUFFER, "ascii");

            myClient.ClientReceiveEvent += MyClient_ClientReceiveEvent;

            myClient.ServerDisconnectedEvent += MyClient_ServerDisconnectedEvent;

            Serial = new SimpleSerial(GetComboSelectedText(comPortBox), Int32.Parse(GetComboSelectedText(baudRateBox)), true);

            Message SerialMessenger = new Message(Command.POST,"",Option.NULLPARAM);
            

            Serial.DataReady += delegate
            {

                String data = Serial.ReadString();

                SerialMessenger.ARGUMENTS = data;

                try
                {
                    myClient.Write(myEncoder.Encode(builder.GetBytes(SerialMessenger)));
                }

                catch (Exception E) {

                    Console.WriteLine(E.Message);

                }

                if (serBox.Checked) serText.AppendText(data);

                if (autoScroll.Checked) serText.ScrollToCaret();

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

                Thread.Sleep(10);

            }

        }

        private void MyClient_ServerDisconnectedEvent(object sender, EventArgs e)
        {
            AppendText("Server Disconnected.");

            StopButtonEvent(this, EventArgs.Empty);
        }

        private void MyClient_ClientReceiveEvent(object sender, NetworkingClient.ClientRecvEventArgs e)
        {
            AppendText("Message  from:" + e.endp.ToString() + " : " + e.message);

            String args = "";

            if (e.message.Contains("=")) {

                int idx = e.message.IndexOf("=");

                args = e.message.Substring(idx + 1);

            }

            if (args == "ON") Serial.WriteBytes(new byte[] { 1 });

            else if (args == "OFF") Serial.WriteBytes(new byte[] { 0 });

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

                    Thread.Sleep(500);

                    if (myClient != null) myClient.Disconnect();

                    if (Serial != null) Serial.Close();

                    AppendText("Succesfully disconnected.");

                    break;

                case MODE.SERVER:                                        

                    ServerWorker.CancelAsync();                    

                    Thread.Sleep(500);

                    if (Server != null)  Server.Close();                    

                    AppendText("Succesfully closed server.");

                    this.ClientList.Items.Clear();

                    if (!(sqlClient == null)) sqlClient.Close();

                    break;

            }

            database.Enable();

            State = MODE.NONE;
            
            pnl.BackColor = Color.Red; 

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            if (TabControl.SelectedTab.Name == serLogTab.Name) serText.Clear();

            else if (TabControl.SelectedTab.Name == logPage.Name) textBox.Clear();

        }

        private void SendButtonEvent(object sender, EventArgs e)
        {
            MessageBuilder bd = new MessageBuilder();

            String message = "";

            if (msgBox.Text.Trim() == "") {

                ShowErrorMessage("Please enter a query in the field.");

                return;

            }

            else {

                this.Invoke((MethodInvoker)delegate {

                    message = msgBox.Text;

                    Console.WriteLine(message);

                });

            }

            switch (State) {

                case MODE.CLIENT:

                    Message msg = new Message("","","");

                    try { msg = bd.CreateMessage(message); }

                    catch (Exception) {

                        AppendText("Input query is corrupted. See the help page for valid queries.");
                    }

                    myClient.Write(bd.GetBytes(msg));

                    break;

                case MODE.SERVER:                                  

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

            Server.MessageReceived += Server_MessageReceived;

            String s = Server.Init();

            AppendText(s);

            s = null;

            for (; running == true;)
            {
               Server.Accept();

               Server.GetMessage();                         

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

        private void Server_MessageReceived(object sender, NetworkingServer.ReceiveMessageEventArgs e)
        {
            
            this.Invoke((MethodInvoker)delegate {

                int idx = ClientList.Items.IndexOfKey(e.key.ToString());

                ClientList.Items[idx].SubItems[4].Text = e.message;

            });

            if (e.message == "CHANGE_ACTIVE_TO_FALSE")
            {

                if (sqlClient!= null) sqlClient.EditActive(e.key, false);

            }

            else
            {
                if (sqlClient != null) this.Invoke((MethodInvoker)delegate { sqlClient.Edit(e.key, e.message); });

                AppendText("Message from:" + e.endp.ToString() + ": " + e.message);
            }
        }

        private void Server_ConnectionClosed(object sender, NetworkingServer.CloseConnectionEventArgs e)
        {
             
            this.Invoke((MethodInvoker)delegate 
            
            {
                ClientList.Items.RemoveByKey(e.Key.ToString());

                if (sqlClient != null) sqlClient.DeleteByKey(e.Key);
                
            });

        }

        private void Server_AcceptEvent(object sender, NetworkingServer.AcceptEventArgs e)
        {

            ListViewItem item = new ListViewItem();

            string remote = e.endp.ToString();

            item.Name = e.Name; 

            item.Text = e.Name;

            int index = remote.IndexOf(":");

            int port = Int32.Parse(remote.Substring(index + 1));

            int key = Int32.Parse(e.Name);

            item.SubItems.Add(remote.Substring(0, index));

            item.SubItems.Add(remote.Substring(index + 1));

            item.SubItems.Add(DateTime.Now.ToString());

            item.SubItems.Add("N/A");

            if (sqlClient != null)
            {
                _ = sqlClient.InsertNew(remote.Substring(0, index), port, true, key);
            }

            try
            {
                AddToList(item);
                
            }
            catch (Exception ex) {

                Console.WriteLine(ex.Message);

            }

        }

        private void ServerButtonStartEvent(object sender, EventArgs e)
        {

            if (this.State == MODE.CLIENT || this.State == MODE.SERVER)
            {

                ShowErrorMessage("Cannot start event. Application is in " + this.State.ToString() + " mode."); 

            }

            else {                
                              

                if (database.isDatabseEnabled) {

                    sqlClient = new MySqlClient(database.Server, database.DatabaseName, database.Username, database.Password) { CurrentTable = database.DefaultTable };

                    string answer;

                    if ((answer = sqlClient.Initiliase()) != MySqlClient.Codes.OK) {

                        MessageBox.Show(answer, "Database Connection Unsuccesful", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        AppendText("Could not start server. Please check database parametres.");

                        return;
                    }

                    database.Disable();

                }

                else sqlClient = null;

                ServerWorker.RunWorkerAsync();

                pnl.BackColor = Color.Green;

                this.State = MODE.SERVER;

                running = true;

                msgBox.Enabled = false;

                SendButton.Enabled = false;

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

            for (int i = 0; i < ClientList.SelectedItems.Count; i++) {

                Server.SendMessage(Int32.Parse(ClientList.SelectedItems[i].Text), this.ClientsTabTextbox.Text.Trim());

            }

        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.State == (MODE.CLIENT ) || this.State == (MODE.NONE)) && this.TabControl.SelectedTab == ClientsTab) {
                (this.TabControl).SelectedTab = logPage;
            }
        }

        private void RemoveClientButtonEvent(object sender, EventArgs e)
        {
            for (int  i = 0; i < ClientList.SelectedItems.Count; i++)

                Server.RemoveClient(Int32.Parse(ClientList.SelectedItems[i].Text));

        }

        private void DbConn_Click(object sender, EventArgs e)
        {
            if (database != null) database.Show();

        }

        private void ConDeviceBtn_Click(object sender, EventArgs e)
        {

            if (azClient == null) {

                conDeviceBtn.Enabled = false;

                ThreadPool.QueueUserWorkItem(azConnect);
            }
            

        }

        private void DisconBtn_Click(object sender, EventArgs e)
        {
            if (azClient != null) {

                azClient.Disconnect();

                azClient = null;

                this.Invoke((MethodInvoker)delegate {

                    AppendText("Disconnected from Azure device.");

                    lblRemoteNotify.Text = "";


                });

                conDeviceBtn.Enabled = true;
            }
        }

        private void SetActionBtn_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(azSend);
        }

        private void azSend(object s) {

            if (azClient == null) return;

            Message m = new Message("SET", "ON", "");

            string x = "";

            this.Invoke((MethodInvoker)delegate {

                x = OnBox.Text;


            });

            m.OPTIONS = x;            

            azClient.Write(builder.GetBytes(m));

        }

        private void azConnect(object state) {

            azClient = new NetworkingClient(NetworkingClient.ProtoType.TCP, ipBox.Text, 15000);

            azClient.Timeout = 500;

            if (azClient.Connect() == 1)
            {
                byte[] rec = azClient.ReadRaw();

               
                this.Invoke((MethodInvoker)delegate {

                    AppendText("Connected to Azure device.");

                    lblRemoteNotify.Text = "Connected @ " + ipBox.Text;

                    keyBox.Text = System.Text.ASCIIEncoding.ASCII.GetString(rec);

                });

               
                
            }

            else {

                this.Invoke((MethodInvoker) delegate  {

                    AppendText("Could not connect to Azure device.");

                    lblRemoteNotify.Text = "Error"; ;


                });

            }
          

        }

    }
}
