namespace Short_message
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ledComOpen = new LEDLib.LEDControl();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cmbboxCom = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.接收计数标签 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRcvCnt = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.发送计数标签 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSndCnt = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FileName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.readTxt = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.confirm = new System.Windows.Forms.Button();
            this.AutoSend = new System.Windows.Forms.CheckBox();
            this.button8 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnHandSend = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.chkbHexDisplay = new System.Windows.Forms.CheckBox();
            this.chkbPauDisp = new System.Windows.Forms.CheckBox();
            this.ledRcvStat = new LEDLib.LEDControl();
            this.txtbRcvArea = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.AutoSendTime = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ledComOpen);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.cmbboxCom);
            this.groupBox1.Controls.Add(this.cmbBaudRate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(369, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口";
            // 
            // ledComOpen
            // 
            this.ledComOpen.LEDCenterColor = System.Drawing.Color.White;
            this.ledComOpen.LEDCircleColor = System.Drawing.Color.Gray;
            this.ledComOpen.LEDClickEnable = true;
            this.ledComOpen.LEDSurroundColor = System.Drawing.Color.OrangeRed;
            this.ledComOpen.LEDSwitch = false;
            this.ledComOpen.Location = new System.Drawing.Point(314, 30);
            this.ledComOpen.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ledComOpen.Name = "ledComOpen";
            this.ledComOpen.Size = new System.Drawing.Size(44, 45);
            this.ledComOpen.TabIndex = 9;
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.White;
            this.btnOpen.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpen.Location = new System.Drawing.Point(9, 99);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(348, 32);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cmbboxCom
            // 
            this.cmbboxCom.FormattingEnabled = true;
            this.cmbboxCom.Location = new System.Drawing.Point(98, 21);
            this.cmbboxCom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbboxCom.Name = "cmbboxCom";
            this.cmbboxCom.Size = new System.Drawing.Size(205, 26);
            this.cmbboxCom.TabIndex = 8;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(98, 60);
            this.cmbBaudRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(205, 26);
            this.cmbBaudRate.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "波特率：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "串口：";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.接收计数标签,
            this.lblRcvCnt,
            this.toolStripStatusLabel1,
            this.发送计数标签,
            this.lblSndCnt,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 644);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(861, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(838, 17);
            this.toolStripStatusLabel3.Spring = true;
            // 
            // 接收计数标签
            // 
            this.接收计数标签.Name = "接收计数标签";
            this.接收计数标签.Size = new System.Drawing.Size(88, 24);
            this.接收计数标签.Text = "receive：";
            this.接收计数标签.Visible = false;
            // 
            // lblRcvCnt
            // 
            this.lblRcvCnt.AutoSize = false;
            this.lblRcvCnt.Name = "lblRcvCnt";
            this.lblRcvCnt.Size = new System.Drawing.Size(50, 24);
            this.lblRcvCnt.Text = "0";
            this.lblRcvCnt.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(25, 24);
            this.toolStripStatusLabel1.Text = ";";
            this.toolStripStatusLabel1.Visible = false;
            // 
            // 发送计数标签
            // 
            this.发送计数标签.Name = "发送计数标签";
            this.发送计数标签.Size = new System.Drawing.Size(69, 24);
            this.发送计数标签.Text = "send：";
            this.发送计数标签.Visible = false;
            // 
            // lblSndCnt
            // 
            this.lblSndCnt.AutoSize = false;
            this.lblSndCnt.Name = "lblSndCnt";
            this.lblSndCnt.Size = new System.Drawing.Size(50, 24);
            this.lblSndCnt.Text = "0";
            this.lblSndCnt.Visible = false;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(25, 24);
            this.toolStripStatusLabel2.Text = ";";
            this.toolStripStatusLabel2.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FileName);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.readTxt);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.confirm);
            this.groupBox2.Controls.Add(this.AutoSend);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.btnHandSend);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.chkbHexDisplay);
            this.groupBox2.Controls.Add(this.chkbPauDisp);
            this.groupBox2.Controls.Add(this.ledRcvStat);
            this.groupBox2.Controls.Add(this.txtbRcvArea);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 170);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(861, 474);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据";
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(98, 312);
            this.FileName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(608, 28);
            this.FileName.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 320);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 18);
            this.label9.TabIndex = 36;
            this.label9.Text = "文件路径：";
            // 
            // readTxt
            // 
            this.readTxt.Location = new System.Drawing.Point(735, 309);
            this.readTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.readTxt.Name = "readTxt";
            this.readTxt.Size = new System.Drawing.Size(108, 34);
            this.readTxt.TabIndex = 11;
            this.readTxt.Text = "读取文件";
            this.readTxt.UseVisualStyleBackColor = true;
            this.readTxt.Click += new System.EventHandler(this.readTxt_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(302, 284);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 18);
            this.label8.TabIndex = 35;
            this.label8.Text = "发送间隔：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(405, 284);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 18);
            this.label7.TabIndex = 34;
            this.label7.Text = "0 s";
            // 
            // confirm
            // 
            this.confirm.Enabled = false;
            this.confirm.Location = new System.Drawing.Point(730, 384);
            this.confirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(112, 36);
            this.confirm.TabIndex = 33;
            this.confirm.Text = "确认数据";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.button2_Click);
            // 
            // AutoSend
            // 
            this.AutoSend.AutoSize = true;
            this.AutoSend.Enabled = false;
            this.AutoSend.Location = new System.Drawing.Point(730, 350);
            this.AutoSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AutoSend.Name = "AutoSend";
            this.AutoSend.Size = new System.Drawing.Size(106, 22);
            this.AutoSend.TabIndex = 32;
            this.AutoSend.Text = "自动发送";
            this.AutoSend.UseVisualStyleBackColor = true;
            this.AutoSend.CheckedChanged += new System.EventHandler(this.AutoSend_CheckedChanged);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(734, 218);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(99, 34);
            this.button8.TabIndex = 31;
            this.button8.Text = "打开保存";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 284);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 29;
            this.label6.Text = "联系人：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(98, 278);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(168, 28);
            this.textBox2.TabIndex = 30;
            this.textBox2.Text = "367963";
            // 
            // btnHandSend
            // 
            this.btnHandSend.Enabled = false;
            this.btnHandSend.Location = new System.Drawing.Point(730, 429);
            this.btnHandSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHandSend.Name = "btnHandSend";
            this.btnHandSend.Size = new System.Drawing.Size(112, 36);
            this.btnHandSend.TabIndex = 26;
            this.btnHandSend.Text = "发送";
            this.btnHandSend.UseVisualStyleBackColor = true;
            this.btnHandSend.Click += new System.EventHandler(this.btnHandSend_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(9, 350);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(695, 114);
            this.textBox1.TabIndex = 25;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(734, 147);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(106, 22);
            this.checkBox2.TabIndex = 24;
            this.checkBox2.Text = "保存解析";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(734, 180);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(99, 34);
            this.button7.TabIndex = 23;
            this.button7.Text = "清理数据";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // chkbHexDisplay
            // 
            this.chkbHexDisplay.AutoSize = true;
            this.chkbHexDisplay.Checked = true;
            this.chkbHexDisplay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbHexDisplay.Location = new System.Drawing.Point(734, 114);
            this.chkbHexDisplay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkbHexDisplay.Name = "chkbHexDisplay";
            this.chkbHexDisplay.Size = new System.Drawing.Size(88, 22);
            this.chkbHexDisplay.TabIndex = 22;
            this.chkbHexDisplay.Text = "16进制";
            this.chkbHexDisplay.UseVisualStyleBackColor = true;
            // 
            // chkbPauDisp
            // 
            this.chkbPauDisp.AutoSize = true;
            this.chkbPauDisp.Location = new System.Drawing.Point(734, 81);
            this.chkbPauDisp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkbPauDisp.Name = "chkbPauDisp";
            this.chkbPauDisp.Size = new System.Drawing.Size(70, 22);
            this.chkbPauDisp.TabIndex = 21;
            this.chkbPauDisp.Text = "暂停";
            this.chkbPauDisp.UseVisualStyleBackColor = true;
            // 
            // ledRcvStat
            // 
            this.ledRcvStat.LEDCenterColor = System.Drawing.Color.White;
            this.ledRcvStat.LEDCircleColor = System.Drawing.Color.Gray;
            this.ledRcvStat.LEDClickEnable = true;
            this.ledRcvStat.LEDSurroundColor = System.Drawing.Color.Lime;
            this.ledRcvStat.LEDSwitch = false;
            this.ledRcvStat.Location = new System.Drawing.Point(754, 30);
            this.ledRcvStat.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ledRcvStat.Name = "ledRcvStat";
            this.ledRcvStat.Size = new System.Drawing.Size(40, 42);
            this.ledRcvStat.TabIndex = 20;
            // 
            // txtbRcvArea
            // 
            this.txtbRcvArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbRcvArea.Location = new System.Drawing.Point(4, 26);
            this.txtbRcvArea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbRcvArea.Multiline = true;
            this.txtbRcvArea.Name = "txtbRcvArea";
            this.txtbRcvArea.ReadOnly = true;
            this.txtbRcvArea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbRcvArea.Size = new System.Drawing.Size(702, 242);
            this.txtbRcvArea.TabIndex = 0;
            this.txtbRcvArea.TextChanged += new System.EventHandler(this.txtbRcvArea_TextChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(356, 27);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 30);
            this.button4.TabIndex = 25;
            this.button4.Text = "状态检测";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(356, 66);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 30);
            this.button3.TabIndex = 26;
            this.button3.Text = "功率检测";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(356, 105);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 30);
            this.button1.TabIndex = 27;
            this.button1.Text = "关闭定位";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 28;
            this.label3.Text = "卡号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 29;
            this.label4.Text = "信号强度：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 111);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 18);
            this.label5.TabIndex = 30;
            this.label5.Text = "入站状态：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(378, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(478, 150);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "信号检测";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.Parity = System.IO.Ports.Parity.Odd;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.RecieveData);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AutoSendTime
            // 
            this.AutoSendTime.Interval = 61000;
            this.AutoSendTime.Tick += new System.EventHandler(this.AutoSendTime_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 666);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "短报文发送与接收软件";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox cmbboxCom;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private LEDLib.LEDControl ledComOpen;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtbRcvArea;
        private System.Windows.Forms.CheckBox chkbPauDisp;
        private LEDLib.LEDControl ledRcvStat;
        private System.Windows.Forms.CheckBox chkbHexDisplay;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnHandSend;
        private System.Windows.Forms.TextBox textBox1;
        public System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel 接收计数标签;
        private System.Windows.Forms.ToolStripStatusLabel lblRcvCnt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel 发送计数标签;
        private System.Windows.Forms.ToolStripStatusLabel lblSndCnt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckBox AutoSend;
        private System.Windows.Forms.Timer AutoSendTime;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button readTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox FileName;
    }
}

