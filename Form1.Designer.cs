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
            this.textBox = new System.Windows.Forms.RichTextBox();
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.logPage = new System.Windows.Forms.TabPage();
            this.Clients = new System.Windows.Forms.TabPage();
            this.ClientsTabTextbox = new System.Windows.Forms.TextBox();
            this.ClientsTabSendButton = new System.Windows.Forms.Button();
            this.ClientList = new System.Windows.Forms.ListView();
            this.Client = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeConn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TabControl.SuspendLayout();
            this.logPage.SuspendLayout();
            this.Clients.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox.Location = new System.Drawing.Point(0, 0);
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(575, 333);
            this.textBox.TabIndex = 9;
            this.textBox.Text = "";
            // 
            // StartClientButton
            // 
            this.StartClientButton.Location = new System.Drawing.Point(12, 394);
            this.StartClientButton.Name = "StartClientButton";
            this.StartClientButton.Size = new System.Drawing.Size(109, 22);
            this.StartClientButton.TabIndex = 6;
            this.StartClientButton.Text = "Start Client";
            this.StartClientButton.UseVisualStyleBackColor = true;
            this.StartClientButton.Click += new System.EventHandler(this.StartClientProcessEvent);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(351, 372);
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
            this.lblPort.Location = new System.Drawing.Point(602, 38);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(37, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "PORT";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(602, 397);
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
            this.label1.Location = new System.Drawing.Point(602, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ADDRESS";
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.Red;
            this.pnl.Location = new System.Drawing.Point(182, 372);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(94, 47);
            this.pnl.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(599, 116);
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
            this.protocolBox.Location = new System.Drawing.Point(602, 171);
            this.protocolBox.Name = "protocolBox";
            this.protocolBox.Size = new System.Drawing.Size(158, 21);
            this.protocolBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(599, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "PROTOCOL";
            // 
            // msgBox
            // 
            this.msgBox.Location = new System.Drawing.Point(602, 302);
            this.msgBox.Name = "msgBox";
            this.msgBox.Size = new System.Drawing.Size(158, 20);
            this.msgBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(599, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "QUERY";
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(602, 328);
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
            this.label5.Location = new System.Drawing.Point(599, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "COM PORT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(599, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "BAUD RATE";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(602, 372);
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
            this.StartServerButton.Location = new System.Drawing.Point(12, 372);
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
            this.portBox.Location = new System.Drawing.Point(602, 53);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(158, 21);
            this.portBox.TabIndex = 23;
            this.portBox.SelectedIndexChanged += new System.EventHandler(this.PortBox_SelectedIndexChanged);
            // 
            // addressBox
            // 
            this.addressBox.FormattingEnabled = true;
            this.addressBox.Items.AddRange(new object[] {
            "exams.skule.ca",
            "23.100.17.104",
            "52.20.16.20",
            "Add"});
            this.addressBox.Location = new System.Drawing.Point(602, 92);
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
            this.bufferLengthBox.Location = new System.Drawing.Point(602, 132);
            this.bufferLengthBox.Name = "bufferLengthBox";
            this.bufferLengthBox.Size = new System.Drawing.Size(158, 21);
            this.bufferLengthBox.TabIndex = 25;
            this.bufferLengthBox.SelectedIndexChanged += new System.EventHandler(this.BufferLengthBox_SelectedIndexChanged);
            // 
            // comPortBox
            // 
            this.comPortBox.FormattingEnabled = true;
            this.comPortBox.Location = new System.Drawing.Point(602, 214);
            this.comPortBox.Name = "comPortBox";
            this.comPortBox.Size = new System.Drawing.Size(158, 21);
            this.comPortBox.TabIndex = 26;
            // 
            // baudRateBox
            // 
            this.baudRateBox.FormattingEnabled = true;
            this.baudRateBox.Location = new System.Drawing.Point(602, 255);
            this.baudRateBox.Name = "baudRateBox";
            this.baudRateBox.Size = new System.Drawing.Size(158, 21);
            this.baudRateBox.TabIndex = 27;
            // 
            // autoScroll
            // 
            this.autoScroll.AutoSize = true;
            this.autoScroll.Checked = true;
            this.autoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoScroll.Location = new System.Drawing.Point(501, 376);
            this.autoScroll.Name = "autoScroll";
            this.autoScroll.Size = new System.Drawing.Size(72, 17);
            this.autoScroll.TabIndex = 28;
            this.autoScroll.Text = "Autoscroll";
            this.autoScroll.UseVisualStyleBackColor = true;
            this.autoScroll.CheckedChanged += new System.EventHandler(this.AutoScroll_CheckedChanged);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.logPage);
            this.TabControl.Controls.Add(this.Clients);
            this.TabControl.Location = new System.Drawing.Point(12, 5);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(583, 359);
            this.TabControl.TabIndex = 30;
            // 
            // logPage
            // 
            this.logPage.Controls.Add(this.textBox);
            this.logPage.Location = new System.Drawing.Point(4, 22);
            this.logPage.Name = "logPage";
            this.logPage.Padding = new System.Windows.Forms.Padding(3);
            this.logPage.Size = new System.Drawing.Size(575, 333);
            this.logPage.TabIndex = 0;
            this.logPage.Text = "Log";
            this.logPage.UseVisualStyleBackColor = true;
            // 
            // Clients
            // 
            this.Clients.Controls.Add(this.ClientsTabTextbox);
            this.Clients.Controls.Add(this.ClientsTabSendButton);
            this.Clients.Controls.Add(this.ClientList);
            this.Clients.Location = new System.Drawing.Point(4, 22);
            this.Clients.Name = "Clients";
            this.Clients.Padding = new System.Windows.Forms.Padding(3);
            this.Clients.Size = new System.Drawing.Size(575, 333);
            this.Clients.TabIndex = 1;
            this.Clients.Text = "Clients";
            this.Clients.UseVisualStyleBackColor = true;
            // 
            // ClientsTabTextbox
            // 
            this.ClientsTabTextbox.Location = new System.Drawing.Point(108, 303);
            this.ClientsTabTextbox.Name = "ClientsTabTextbox";
            this.ClientsTabTextbox.Size = new System.Drawing.Size(455, 20);
            this.ClientsTabTextbox.TabIndex = 2;
            // 
            // ClientsTabSendButton
            // 
            this.ClientsTabSendButton.Location = new System.Drawing.Point(6, 301);
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
            this.ClientList.Location = new System.Drawing.Point(0, 0);
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(574, 295);
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
            // IOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 423);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.autoScroll);
            this.Controls.Add(this.baudRateBox);
            this.Controls.Add(this.comPortBox);
            this.Controls.Add(this.bufferLengthBox);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.StartServerButton);
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
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "IOT";
            this.Text = "IOT";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TabControl.ResumeLayout(false);
            this.logPage.ResumeLayout(false);
            this.Clients.ResumeLayout(false);
            this.Clients.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textBox;
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
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage logPage;
        private System.Windows.Forms.TabPage Clients;
        private System.Windows.Forms.TextBox ClientsTabTextbox;
        private System.Windows.Forms.Button ClientsTabSendButton;
        private System.Windows.Forms.ListView ClientList;
        private System.Windows.Forms.ColumnHeader Client;
        private System.Windows.Forms.ColumnHeader Ip;
        private System.Windows.Forms.ColumnHeader Port;
        private System.Windows.Forms.ColumnHeader lastMessage;
        private System.Windows.Forms.ColumnHeader timeConn;
    }
}

