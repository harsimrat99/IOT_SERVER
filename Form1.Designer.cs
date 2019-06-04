using System.Drawing;

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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblPort = new System.Windows.Forms.Label();
            this.Clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.protocolBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.msgBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.comPortBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.baudrateBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.button5 = new System.Windows.Forms.Button();
            this.portBox = new System.Windows.Forms.ComboBox();
            this.addressBox = new System.Windows.Forms.ComboBox();
            this.bufferLengthBox = new System.Windows.Forms.ComboBox();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox.Location = new System.Drawing.Point(12, 12);
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(581, 331);
            this.textBox.TabIndex = 9;
            this.textBox.Text = "";
            this.textBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 22);
            this.button1.TabIndex = 6;
            this.button1.Text = "Start Client";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(483, 355);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 47);
            this.button2.TabIndex = 7;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(602, 16);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(37, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "PORT";
            this.lblPort.Click += new System.EventHandler(this.Label1_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(602, 380);
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
            this.label1.Location = new System.Drawing.Point(602, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ADDRESS";
            this.label1.Click += new System.EventHandler(this.Label1_Click_1);
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.Red;
            this.pnl.Location = new System.Drawing.Point(251, 355);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(94, 47);
            this.pnl.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(599, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "STREAM BUFFER LENGTH";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // protocolBox
            // 
            this.protocolBox.FormattingEnabled = true;
            this.protocolBox.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            protocolBox.SelectedIndex = 0;
            this.protocolBox.Location = new System.Drawing.Point(602, 149);
            this.protocolBox.Name = "protocolBox";
            this.protocolBox.Size = new System.Drawing.Size(158, 21);
            this.protocolBox.TabIndex = 3;
            this.protocolBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(599, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "PROTOCOL";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // msgBox
            // 
            this.msgBox.Location = new System.Drawing.Point(602, 280);
            this.msgBox.Name = "msgBox";
            this.msgBox.Size = new System.Drawing.Size(158, 20);
            this.msgBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(599, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "QUERY";
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(602, 306);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 37);
            this.button3.TabIndex = 8;
            this.button3.Text = "SEND";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // comPortBox
            // 
            this.comPortBox.Enabled = false;
            this.comPortBox.Location = new System.Drawing.Point(602, 192);
            this.comPortBox.Name = "comPortBox";
            this.comPortBox.Size = new System.Drawing.Size(158, 20);
            this.comPortBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(599, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "COM PORT";
            this.label5.Click += new System.EventHandler(this.Label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(599, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "BAUD RATE";
            // 
            // baudrateBox
            // 
            this.baudrateBox.Enabled = false;
            this.baudrateBox.Location = new System.Drawing.Point(602, 231);
            this.baudrateBox.Name = "baudrateBox";
            this.baudrateBox.Size = new System.Drawing.Size(158, 20);
            this.baudrateBox.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(602, 355);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(158, 22);
            this.button4.TabIndex = 21;
            this.button4.Text = "Scroll to Bottom";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker2_DoWork);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 355);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(109, 22);
            this.button5.TabIndex = 22;
            this.button5.Text = "Start Server";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
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
            portBox.SelectedIndex = 0;
            this.portBox.Location = new System.Drawing.Point(602, 31);
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
            "52.20.16.20", "Add"});
            addressBox.SelectedIndex = 0;
            this.addressBox.Location = new System.Drawing.Point(602, 70);
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
            400, "Add"});
            this.bufferLengthBox.Location = new System.Drawing.Point(602, 110);
            this.bufferLengthBox.Name = "bufferLengthBox";
            this.bufferLengthBox.Size = new System.Drawing.Size(158, 21);
            this.bufferLengthBox.TabIndex = 25;
            bufferLengthBox.SelectedIndex = 0;
            this.bufferLengthBox.SelectedIndexChanged += new System.EventHandler(this.BufferLengthBox_SelectedIndexChanged);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker3_DoWork);
            // 
            // IOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 411);
            this.Controls.Add(this.bufferLengthBox);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.baudrateBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comPortBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.msgBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.protocolBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "IOT";
            this.Text = "IOT";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Load += new System.EventHandler(this.IOT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox protocolBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox msgBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox comPortBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox baudrateBox;
        private System.Windows.Forms.Button button4;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox portBox;
        private System.Windows.Forms.ComboBox addressBox;
        private System.Windows.Forms.ComboBox bufferLengthBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
    }
}

