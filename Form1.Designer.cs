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
            this.portBox = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.Clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addr = new System.Windows.Forms.TextBox();
            this.pnl = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.buffBox = new System.Windows.Forms.TextBox();
            this.proBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.msgBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.portBx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.baudBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox.Location = new System.Drawing.Point(12, 12);
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(293, 331);
            this.textBox.TabIndex = 0;
            this.textBox.Text = "";
            this.textBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 375);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(195, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 50);
            this.button2.TabIndex = 2;
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
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(311, 29);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(158, 20);
            this.portBox.TabIndex = 4;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(311, 13);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(37, 13);
            this.lblPort.TabIndex = 5;
            this.lblPort.Text = "PORT";
            this.lblPort.Click += new System.EventHandler(this.Label1_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(325, 377);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(144, 22);
            this.Clear.TabIndex = 6;
            this.Clear.Text = "Clear Screen";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ADDRESS";
            this.label1.Click += new System.EventHandler(this.Label1_Click_1);
            // 
            // addr
            // 
            this.addr.Location = new System.Drawing.Point(311, 68);
            this.addr.Name = "addr";
            this.addr.Size = new System.Drawing.Size(158, 20);
            this.addr.TabIndex = 7;
            this.addr.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.Red;
            this.pnl.Location = new System.Drawing.Point(128, 375);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(61, 24);
            this.pnl.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "STREAM BUFFER LENGTH";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // buffBox
            // 
            this.buffBox.Location = new System.Drawing.Point(311, 107);
            this.buffBox.Name = "buffBox";
            this.buffBox.Size = new System.Drawing.Size(158, 20);
            this.buffBox.TabIndex = 10;
            this.buffBox.Text = "Leave blank for default.";
            // 
            // proBox
            // 
            this.proBox.Enabled = false;
            this.proBox.FormattingEnabled = true;
            this.proBox.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            this.proBox.Location = new System.Drawing.Point(311, 146);
            this.proBox.Name = "proBox";
            this.proBox.Size = new System.Drawing.Size(121, 21);
            this.proBox.TabIndex = 12;
            this.proBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "PROTOCOL";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // msgBox
            // 
            this.msgBox.Location = new System.Drawing.Point(311, 292);
            this.msgBox.Name = "msgBox";
            this.msgBox.Size = new System.Drawing.Size(158, 20);
            this.msgBox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "QUERY";
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(311, 318);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "SEND";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // portBx
            // 
            this.portBx.Location = new System.Drawing.Point(311, 189);
            this.portBx.Name = "portBx";
            this.portBx.Size = new System.Drawing.Size(158, 20);
            this.portBx.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(308, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "COM PORT";
            this.label5.Click += new System.EventHandler(this.Label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "BAUD RATE";
            // 
            // baudBox
            // 
            this.baudBox.Location = new System.Drawing.Point(311, 228);
            this.baudBox.Name = "baudBox";
            this.baudBox.Size = new System.Drawing.Size(158, 20);
            this.baudBox.TabIndex = 19;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(325, 352);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(144, 22);
            this.button4.TabIndex = 21;
            this.button4.Text = "Scroll to Bottom";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // IOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.baudBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.portBx);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.msgBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.proBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buffBox);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addr);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 450);
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
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addr;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox buffBox;
        private System.Windows.Forms.ComboBox proBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox msgBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox portBx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox baudBox;
        private System.Windows.Forms.Button button4;
    }
}

