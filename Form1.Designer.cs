using System.Drawing;
using System.Windows.Forms;

namespace IOT_SERVER
{
    partial class IOT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IOT));
            this.StartClientButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ClientWorker = new System.ComponentModel.BackgroundWorker();
            this.lblPort = new System.Windows.Forms.Label();
            this.Clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.protocolBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.msgBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.ServerWorker = new System.ComponentModel.BackgroundWorker();
            this.StartServerButton = new System.Windows.Forms.Button();
            this.portBox = new System.Windows.Forms.ComboBox();
            this.addressBox = new System.Windows.Forms.ComboBox();
            this.bufferLengthBox = new System.Windows.Forms.ComboBox();
            this.comPortBox = new System.Windows.Forms.ComboBox();
            this.baudRateBox = new System.Windows.Forms.ComboBox();
            this.autoScroll = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbConn = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientsTab = new System.Windows.Forms.TabPage();
            this.RemoveClientButton = new System.Windows.Forms.Button();
            this.ClientsTabTextbox = new System.Windows.Forms.TextBox();
            this.ClientsTabSendButton = new System.Windows.Forms.Button();
            this.ClientList = new System.Windows.Forms.ListView();
            this.Client = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeConn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logPage = new System.Windows.Forms.TabPage();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.RemoteTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRemoteNotify = new System.Windows.Forms.Label();
            this.animBar = new System.Windows.Forms.ProgressBar();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.disconBtn = new System.Windows.Forms.Button();
            this.SetActionBtn = new System.Windows.Forms.Button();
            this.OFFBox = new System.Windows.Forms.TextBox();
            this.OnBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.keyBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.conDeviceBtn = new System.Windows.Forms.Button();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.serLogTab = new System.Windows.Forms.TabPage();
            this.serText = new System.Windows.Forms.RichTextBox();
            this.serBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.ClientsTab.SuspendLayout();
            this.logPage.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.RemoteTab.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.serLogTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartClientButton
            // 
            this.StartClientButton.Location = new System.Drawing.Point(12, 467);
            this.StartClientButton.Name = "StartClientButton";
            this.StartClientButton.Size = new System.Drawing.Size(109, 22);
            this.StartClientButton.TabIndex = 6;
            this.StartClientButton.Text = "Start Client";
            this.StartClientButton.UseVisualStyleBackColor = true;
            this.StartClientButton.Click += new System.EventHandler(this.StartClientProcessEvent);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(351, 445);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(110, 47);
            this.StopButton.TabIndex = 7;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButtonEvent);
            // 
            // ClientWorker
            // 
            this.ClientWorker.WorkerReportsProgress = true;
            this.ClientWorker.WorkerSupportsCancellation = true;
            this.ClientWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ClientWorkerEvent);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(602, 60);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(37, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "PORT";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(602, 470);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(158, 22);
            this.Clear.TabIndex = 6;
            this.Clear.Text = "Clear Screen";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(602, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ADDRESS";
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.Red;
            this.pnl.Location = new System.Drawing.Point(187, 445);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(95, 43);
            this.pnl.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(599, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "STREAM BUFFER LENGTH";
            // 
            // protocolBox
            // 
            this.protocolBox.FormattingEnabled = true;
            this.protocolBox.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            this.protocolBox.Location = new System.Drawing.Point(602, 193);
            this.protocolBox.Name = "protocolBox";
            this.protocolBox.Size = new System.Drawing.Size(158, 21);
            this.protocolBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(599, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "PROTOCOL";
            // 
            // msgBox
            // 
            this.msgBox.Enabled = false;
            this.msgBox.Location = new System.Drawing.Point(602, 324);
            this.msgBox.Name = "msgBox";
            this.msgBox.Size = new System.Drawing.Size(158, 20);
            this.msgBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(599, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "QUERY";
            // 
            // SendButton
            // 
            this.SendButton.Enabled = false;
            this.SendButton.Location = new System.Drawing.Point(602, 350);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(158, 37);
            this.SendButton.TabIndex = 8;
            this.SendButton.Text = "SEND";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButtonEvent);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(599, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "COM PORT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(599, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "BAUD RATE";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(602, 445);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(158, 22);
            this.button4.TabIndex = 21;
            this.button4.Text = "Scroll to Bottom";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ScrollToCursorButton);
            // 
            // ServerWorker
            // 
            this.ServerWorker.WorkerSupportsCancellation = true;
            this.ServerWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ServerWorkerEvent);
            // 
            // StartServerButton
            // 
            this.StartServerButton.Location = new System.Drawing.Point(12, 445);
            this.StartServerButton.Name = "StartServerButton";
            this.StartServerButton.Size = new System.Drawing.Size(109, 22);
            this.StartServerButton.TabIndex = 22;
            this.StartServerButton.Text = "Start Server";
            this.StartServerButton.UseVisualStyleBackColor = true;
            this.StartServerButton.Click += new System.EventHandler(this.ServerButtonStartEvent);
            // 
            // portBox
            // 
            this.portBox.FormattingEnabled = true;
            this.portBox.Items.AddRange(new object[] {
            "8080",
            "21",
            "30000",
            "30001",
            "Add"});
            this.portBox.Location = new System.Drawing.Point(602, 75);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(158, 21);
            this.portBox.TabIndex = 23;
            this.portBox.SelectedIndexChanged += new System.EventHandler(this.PortBox_SelectedIndexChanged);
            // 
            // addressBox
            // 
            this.addressBox.FormattingEnabled = true;
            this.addressBox.Items.AddRange(new object[] {
            "harsimiot.eastus.cloudapp.azure.com",
            "exams.skule.ca",
            "23.100.17.104",
            "52.20.16.20",
            "Add"});
            this.addressBox.Location = new System.Drawing.Point(602, 114);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(158, 21);
            this.addressBox.TabIndex = 24;
            this.addressBox.SelectedIndexChanged += new System.EventHandler(this.AddressBox_SelectedIndexChanged);
            // 
            // bufferLengthBox
            // 
            this.bufferLengthBox.FormattingEnabled = true;
            this.bufferLengthBox.Items.AddRange(new object[] {
            50,
            100,
            150,
            200,
            250,
            300,
            350,
            400,
            "Add"});
            this.bufferLengthBox.Location = new System.Drawing.Point(602, 154);
            this.bufferLengthBox.Name = "bufferLengthBox";
            this.bufferLengthBox.Size = new System.Drawing.Size(158, 21);
            this.bufferLengthBox.TabIndex = 25;
            this.bufferLengthBox.SelectedIndexChanged += new System.EventHandler(this.BufferLengthBox_SelectedIndexChanged);
            // 
            // comPortBox
            // 
            this.comPortBox.FormattingEnabled = true;
            this.comPortBox.Location = new System.Drawing.Point(602, 236);
            this.comPortBox.Name = "comPortBox";
            this.comPortBox.Size = new System.Drawing.Size(158, 21);
            this.comPortBox.TabIndex = 26;
            // 
            // baudRateBox
            // 
            this.baudRateBox.FormattingEnabled = true;
            this.baudRateBox.Location = new System.Drawing.Point(602, 277);
            this.baudRateBox.Name = "baudRateBox";
            this.baudRateBox.Size = new System.Drawing.Size(158, 21);
            this.baudRateBox.TabIndex = 27;
            // 
            // autoScroll
            // 
            this.autoScroll.AutoSize = true;
            this.autoScroll.Checked = true;
            this.autoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoScroll.Location = new System.Drawing.Point(501, 449);
            this.autoScroll.Name = "autoScroll";
            this.autoScroll.Size = new System.Drawing.Size(72, 17);
            this.autoScroll.TabIndex = 28;
            this.autoScroll.Text = "Autoscroll";
            this.autoScroll.UseVisualStyleBackColor = true;
            this.autoScroll.CheckedChanged += new System.EventHandler(this.AutoScroll_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(771, 24);
            this.menuStrip1.TabIndex = 31;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "&File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(90, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dbConn});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // dbConn
            // 
            this.dbConn.Name = "dbConn";
            this.dbConn.Size = new System.Drawing.Size(181, 22);
            this.dbConn.Text = "Databse Connection";
            this.dbConn.Click += new System.EventHandler(this.DbConn_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(113, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // ClientsTab
            // 
            this.ClientsTab.Controls.Add(this.RemoveClientButton);
            this.ClientsTab.Controls.Add(this.ClientsTabTextbox);
            this.ClientsTab.Controls.Add(this.ClientsTabSendButton);
            this.ClientsTab.Controls.Add(this.ClientList);
            this.ClientsTab.Location = new System.Drawing.Point(4, 22);
            this.ClientsTab.Name = "ClientsTab";
            this.ClientsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ClientsTab.Size = new System.Drawing.Size(575, 386);
            this.ClientsTab.TabIndex = 1;
            this.ClientsTab.Text = "Clients";
            this.ClientsTab.UseVisualStyleBackColor = true;
            // 
            // RemoveClientButton
            // 
            this.RemoveClientButton.Location = new System.Drawing.Point(6, 332);
            this.RemoveClientButton.Name = "RemoveClientButton";
            this.RemoveClientButton.Size = new System.Drawing.Size(93, 23);
            this.RemoveClientButton.TabIndex = 4;
            this.RemoveClientButton.Text = "Remove";
            this.RemoveClientButton.UseVisualStyleBackColor = true;
            this.RemoveClientButton.Click += new System.EventHandler(this.RemoveClientButtonEvent);
            // 
            // ClientsTabTextbox
            // 
            this.ClientsTabTextbox.Location = new System.Drawing.Point(108, 335);
            this.ClientsTabTextbox.Multiline = true;
            this.ClientsTabTextbox.Name = "ClientsTabTextbox";
            this.ClientsTabTextbox.Size = new System.Drawing.Size(461, 43);
            this.ClientsTabTextbox.TabIndex = 2;
            // 
            // ClientsTabSendButton
            // 
            this.ClientsTabSendButton.Location = new System.Drawing.Point(6, 357);
            this.ClientsTabSendButton.Name = "ClientsTabSendButton";
            this.ClientsTabSendButton.Size = new System.Drawing.Size(93, 23);
            this.ClientsTabSendButton.TabIndex = 1;
            this.ClientsTabSendButton.Text = "Send";
            this.ClientsTabSendButton.UseVisualStyleBackColor = true;
            this.ClientsTabSendButton.Click += new System.EventHandler(this.ClientsTabSendButton_Click);
            // 
            // ClientList
            // 
            this.ClientList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Client,
            this.Ip,
            this.Port,
            this.lastMessage,
            this.timeConn});
            this.ClientList.FullRowSelect = true;
            this.ClientList.GridLines = true;
            this.ClientList.HideSelection = false;
            this.ClientList.Location = new System.Drawing.Point(0, 3);
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(574, 326);
            this.ClientList.TabIndex = 0;
            this.ClientList.UseCompatibleStateImageBehavior = false;
            this.ClientList.View = System.Windows.Forms.View.Details;
            // 
            // Client
            // 
            this.Client.Text = "Client";
            this.Client.Width = 99;
            // 
            // Ip
            // 
            this.Ip.Text = "IP Address";
            this.Ip.Width = 92;
            // 
            // Port
            // 
            this.Port.Text = "Port";
            this.Port.Width = 58;
            // 
            // lastMessage
            // 
            this.lastMessage.Text = "Attached on";
            this.lastMessage.Width = 188;
            // 
            // timeConn
            // 
            this.timeConn.Text = "Last Message";
            this.timeConn.Width = 154;
            // 
            // logPage
            // 
            this.logPage.Controls.Add(this.textBox);
            this.logPage.Location = new System.Drawing.Point(4, 22);
            this.logPage.Name = "logPage";
            this.logPage.Padding = new System.Windows.Forms.Padding(3);
            this.logPage.Size = new System.Drawing.Size(575, 386);
            this.logPage.TabIndex = 0;
            this.logPage.Text = "Log";
            this.logPage.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox.Location = new System.Drawing.Point(0, 0);
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(575, 386);
            this.textBox.TabIndex = 9;
            this.textBox.Text = "";
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.logPage);
            this.TabControl.Controls.Add(this.ClientsTab);
            this.TabControl.Controls.Add(this.RemoteTab);
            this.TabControl.Controls.Add(this.serLogTab);
            this.TabControl.Location = new System.Drawing.Point(12, 27);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 1;
            this.TabControl.Size = new System.Drawing.Size(583, 412);
            this.TabControl.TabIndex = 30;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // RemoteTab
            // 
            this.RemoteTab.Controls.Add(this.panel1);
            this.RemoteTab.Controls.Add(this.pictureBox2);
            this.RemoteTab.Controls.Add(this.pictureBox1);
            this.RemoteTab.Controls.Add(this.disconBtn);
            this.RemoteTab.Controls.Add(this.SetActionBtn);
            this.RemoteTab.Controls.Add(this.OFFBox);
            this.RemoteTab.Controls.Add(this.OnBox);
            this.RemoteTab.Controls.Add(this.label11);
            this.RemoteTab.Controls.Add(this.label10);
            this.RemoteTab.Controls.Add(this.keyBox);
            this.RemoteTab.Controls.Add(this.label9);
            this.RemoteTab.Controls.Add(this.conDeviceBtn);
            this.RemoteTab.Controls.Add(this.ipBox);
            this.RemoteTab.Controls.Add(this.label8);
            this.RemoteTab.Controls.Add(this.label7);
            this.RemoteTab.Location = new System.Drawing.Point(4, 22);
            this.RemoteTab.Name = "RemoteTab";
            this.RemoteTab.Padding = new System.Windows.Forms.Padding(3);
            this.RemoteTab.Size = new System.Drawing.Size(575, 386);
            this.RemoteTab.TabIndex = 2;
            this.RemoteTab.Text = "Remote Control";
            this.RemoteTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.lblRemoteNotify);
            this.panel1.Controls.Add(this.animBar);
            this.panel1.Location = new System.Drawing.Point(0, 362);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 24);
            this.panel1.TabIndex = 11;
            // 
            // lblRemoteNotify
            // 
            this.lblRemoteNotify.AutoSize = true;
            this.lblRemoteNotify.Location = new System.Drawing.Point(9, 3);
            this.lblRemoteNotify.Name = "lblRemoteNotify";
            this.lblRemoteNotify.Size = new System.Drawing.Size(160, 13);
            this.lblRemoteNotify.TabIndex = 17;
            this.lblRemoteNotify.Text = "Remote IoT Device Connection ";
            // 
            // animBar
            // 
            this.animBar.BackColor = System.Drawing.Color.LightSalmon;
            this.animBar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.animBar.Location = new System.Drawing.Point(485, 3);
            this.animBar.Name = "animBar";
            this.animBar.Size = new System.Drawing.Size(87, 17);
            this.animBar.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Location = new System.Drawing.Point(410, 119);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(144, 249);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 308);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 48);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // disconBtn
            // 
            this.disconBtn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.disconBtn.Location = new System.Drawing.Point(105, 79);
            this.disconBtn.Name = "disconBtn";
            this.disconBtn.Size = new System.Drawing.Size(75, 23);
            this.disconBtn.TabIndex = 12;
            this.disconBtn.Text = "Cancel";
            this.disconBtn.UseVisualStyleBackColor = true;
            this.disconBtn.Click += new System.EventHandler(this.DisconBtn_Click);
            // 
            // SetActionBtn
            // 
            this.SetActionBtn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.SetActionBtn.Location = new System.Drawing.Point(24, 187);
            this.SetActionBtn.Name = "SetActionBtn";
            this.SetActionBtn.Size = new System.Drawing.Size(75, 23);
            this.SetActionBtn.TabIndex = 10;
            this.SetActionBtn.Text = "Set";
            this.SetActionBtn.UseVisualStyleBackColor = true;
            this.SetActionBtn.Click += new System.EventHandler(this.SetActionBtn_Click);
            // 
            // OFFBox
            // 
            this.OFFBox.Location = new System.Drawing.Point(81, 155);
            this.OFFBox.Name = "OFFBox";
            this.OFFBox.Size = new System.Drawing.Size(100, 20);
            this.OFFBox.TabIndex = 9;
            // 
            // OnBox
            // 
            this.OnBox.Location = new System.Drawing.Point(81, 125);
            this.OnBox.Name = "OnBox";
            this.OnBox.Size = new System.Drawing.Size(100, 20);
            this.OnBox.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Off Action\r\n";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "On Action\r\n";
            // 
            // keyBox
            // 
            this.keyBox.Location = new System.Drawing.Point(451, 47);
            this.keyBox.Name = "keyBox";
            this.keyBox.ReadOnly = true;
            this.keyBox.Size = new System.Drawing.Size(100, 20);
            this.keyBox.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(377, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "IOT Key";
            // 
            // conDeviceBtn
            // 
            this.conDeviceBtn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.conDeviceBtn.Location = new System.Drawing.Point(24, 79);
            this.conDeviceBtn.Name = "conDeviceBtn";
            this.conDeviceBtn.Size = new System.Drawing.Size(75, 23);
            this.conDeviceBtn.TabIndex = 3;
            this.conDeviceBtn.Text = "Connect";
            this.conDeviceBtn.UseVisualStyleBackColor = true;
            this.conDeviceBtn.Click += new System.EventHandler(this.ConDeviceBtn_Click);
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(81, 47);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(100, 20);
            this.ipBox.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Device IP";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(7, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 26);
            this.label7.TabIndex = 0;
            this.label7.Text = "Device Connection";
            // 
            // serLogTab
            // 
            this.serLogTab.Controls.Add(this.serText);
            this.serLogTab.Location = new System.Drawing.Point(4, 22);
            this.serLogTab.Name = "serLogTab";
            this.serLogTab.Padding = new System.Windows.Forms.Padding(3);
            this.serLogTab.Size = new System.Drawing.Size(575, 386);
            this.serLogTab.TabIndex = 3;
            this.serLogTab.Text = "Serial";
            this.serLogTab.UseVisualStyleBackColor = true;
            // 
            // serText
            // 
            this.serText.Location = new System.Drawing.Point(3, 3);
            this.serText.Name = "serText";
            this.serText.Size = new System.Drawing.Size(569, 383);
            this.serText.TabIndex = 0;
            this.serText.Text = "";
            // 
            // serBox
            // 
            this.serBox.AutoSize = true;
            this.serBox.Location = new System.Drawing.Point(501, 472);
            this.serBox.Name = "serBox";
            this.serBox.Size = new System.Drawing.Size(73, 17);
            this.serBox.TabIndex = 32;
            this.serBox.Text = "Log Serial";
            this.serBox.UseVisualStyleBackColor = true;
            // 
            // IOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 500);
            this.Controls.Add(this.serBox);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.autoScroll);
            this.Controls.Add(this.baudRateBox);
            this.Controls.Add(this.comPortBox);
            this.Controls.Add(this.bufferLengthBox);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.msgBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.protocolBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartClientButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.StartServerButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(787, 539);
            this.MinimumSize = new System.Drawing.Size(787, 539);
            this.Name = "IOT";
            this.Text = "IOT";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ClientsTab.ResumeLayout(false);
            this.ClientsTab.PerformLayout();
            this.logPage.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.RemoteTab.ResumeLayout(false);
            this.RemoteTab.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.serLogTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button StartClientButton;
        private System.Windows.Forms.Button StopButton;
        private System.ComponentModel.BackgroundWorker ClientWorker;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox protocolBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox msgBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.ComponentModel.BackgroundWorker ServerWorker;
        private System.Windows.Forms.Button StartServerButton;
        private System.Windows.Forms.ComboBox portBox;
        private System.Windows.Forms.ComboBox addressBox;
        private System.Windows.Forms.ComboBox bufferLengthBox;
        private System.Windows.Forms.ComboBox comPortBox;
        private System.Windows.Forms.ComboBox baudRateBox;
        private System.Windows.Forms.CheckBox autoScroll;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private TabPage ClientsTab;
        private Button RemoveClientButton;
        private TextBox ClientsTabTextbox;
        private Button ClientsTabSendButton;
        private ListView ClientList;
        private ColumnHeader Client;
        private ColumnHeader Ip;
        private ColumnHeader Port;
        private ColumnHeader lastMessage;
        private ColumnHeader timeConn;
        private TabPage logPage;
        private RichTextBox textBox;
        private TabControl TabControl;
        private ToolStripMenuItem dbConn;
        private TabPage RemoteTab;
        private Label label7;
        private TextBox ipBox;
        private Label label8;
        private Label label11;
        private Label label10;
        private TextBox keyBox;
        private Label label9;
        private Button conDeviceBtn;
        private Button disconBtn;
        private Panel panel1;
        private ProgressBar animBar;
        private Button SetActionBtn;
        private TextBox OFFBox;
        private TextBox OnBox;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label lblRemoteNotify;
        private TabPage serLogTab;
        private RichTextBox serText;
        private CheckBox serBox;
    }
}

