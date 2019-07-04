using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Short_message
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //全局
        System.Timers.Timer stat_timer = new System.Timers.Timer(100);
        bool m_bOpen = false;
        public List<byte> BufferData = new List<byte>();//串口数据数据帧识别缓存空间
        bool ReceiveByte_Busy = false;
        bool serialPort_Closing = false;//串口正在关闭标志
        Int32 ReceiveByte_Cnt = 0;//串口操作，接收字节计数
        Int32 SendByte_Cnt = 0;//串口操作，发送字节计数
        public FileStream writefile = null;
        public uint UseNum;
        public string UseInfo;
        public uint OtherNum;
        public string log;
        public uint bo1;
        public uint bo2;
        public uint bo3;
        public uint bo4;
        public uint bo5;
        public uint bo6;
        public string LastMsg;
        int markA = 0;
        int markB = 0;
        int markC = 0;
        Thread sendstring;
        int minute = 0;
        int send = 0;  //发送类型
        public byte[] Byte57 = new byte[57];
        public byte[] Byteleave = new byte[0];
        string msg;
        int time = 61;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.MaximizeBox = false;
                foreach (string com in System.IO.Ports.SerialPort.GetPortNames())
                {
                    this.cmbboxCom.Items.Add(com);
                }//自动获取串口号名称
                cmbboxCom.SelectedIndex = 0;
                cmbBaudRate.Items.Add("4800");
                cmbBaudRate.Items.Add("9600");
                cmbBaudRate.Items.Add("19200");
                cmbBaudRate.Items.Add("38400");
                cmbBaudRate.Items.Add("115200");
                cmbBaudRate.SelectedIndex = 4;
                sendstring = new Thread(new ThreadStart(sendMain));
                sendstring.Start();
                sendstring.IsBackground = true;
            }
            catch
            {
                MessageBox.Show("No serial connection found！", "Error");
            }
            stat_timer.Elapsed += new System.Timers.ElapsedEventHandler(stat_tmrout);
            stat_timer.AutoReset = false;//false执行一次，true一直执行
        }
        private void stat_tmrout(object source, System.Timers.ElapsedEventArgs e)
        {
            ledRcvStat.LEDSwitch = !ledRcvStat.LEDSwitch;
            ledRcvStat.Invalidate();
        }
        public void sendMain()
        {
            while (true)
            {
                if (send == 1)
                {
                    string sendinfo = textBox1.Text.Trim();
                    if (sendinfo != "" && textBox2.Text!="")
                    {
                        int useID = Convert.ToInt32(textBox2.Text);
                        MessageSend("$TXSQ", useID, sendinfo);
                    }
                    send = 0;
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            byte[] MsgByte = Message.ICJC("$ICJC", 0);
            string msg = "";
            for (int i = 0; i < MsgByte.Length; i++)
            {
                msg += MsgByte[i].ToString("X2");
            }
            byte[] sendData = HexStringToByte(msg);
            if (sendData == null)
            {
                MessageBox.Show("请输入数据", "警告");
            }
            else
            {
                if (!serialPort1.IsOpen)
                {
                    MessageBox.Show("串口未开启", "警告");
                }
                else
                {
                    serialPort1.Write(sendData, 0, sendData.Length);
                }
            }
        }
        //16进制转byte
        private byte[] HexStringToByte(string InString)
        {
            if (InString.Length % 2 != 0)
                InString = InString + "0";
            byte[] buffer = new byte[InString.Length / 2];
            for (int i = 0; i < InString.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(InString.Substring(i, 2), 16);
            return buffer;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn.Text == "打开")
            {
                string sComNum = cmbboxCom.Text;
                string sBaudRate = cmbBaudRate.Text;
                string sDataBit = "8";
                string sCheckBit = "None";
                string sStopBit = "One";
                string sHandShake = "None";

                try
                {
                    serialPort1.PortName = sComNum;
                    serialPort1.BaudRate = Int32.Parse(sBaudRate);
                    serialPort1.DataBits = Int32.Parse(sDataBit);
                    serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), sCheckBit);
                    serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), sStopBit);
                    serialPort1.Handshake = (Handshake)Enum.Parse(typeof(Handshake), sHandShake);

                    // Set the read/write timeouts
                    serialPort1.ReadTimeout = 500;
                    serialPort1.WriteTimeout = 500;

                    serialPort1.Open();
                    if (serialPort1.IsOpen)
                    {
                        m_bOpen = true;
                        //ledControl.LEDCenterColor = Color.Yellow;
                        //ledControl.LEDSurroundColor = Color.Lime;
                        ledComOpen.LEDSwitch = true;
                        ledComOpen.Invalidate();
                        btn.Text = "关闭";
                        btnHandSend.Enabled = true;
                        button1.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = true;
                        AutoSend.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    serialPort1.Close();
                    if (!serialPort1.IsOpen)
                    {
                        m_bOpen = false;
                        //ledControl.LEDCenterColor = Color.DarkGray;
                        //ledControl.LEDSurroundColor = Color.DarkGray;
                        ledComOpen.LEDSwitch = false;
                        ledComOpen.Invalidate();
                        btn.Text = "打开";
                        btnHandSend.Enabled = false;
                        button1.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        AutoSend.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] MsgByte = Message.XTZJ("$XTZJ", 0);
            string msg = "";
            for (int i = 0; i < MsgByte.Length; i++)
            {
                msg += MsgByte[i].ToString("X2");
            }
            byte[] sendData = HexStringToByte(msg);
            if (sendData == null)
            {
                MessageBox.Show("请输入数据", "警告");
            }
            else
            {
                if (!serialPort1.IsOpen)
                {
                    MessageBox.Show("串口未打开", "警告");
                }
                else
                {
                    serialPort1.Write(sendData, 0, sendData.Length);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string closeNmea = "$CCRMO,,3,*4F";
            try
            {
                char[] SendChars = closeNmea.ToCharArray();
                int CharsLength = SendChars.Length;
                SendByte_Cnt += CharsLength;
                for (int i = 0; i < CharsLength; i++)
                {
                    if (SendChars[i] >= 0x4e00 && SendChars[i] <= 0x9fa5)
                    {
                        SendByte_Cnt++;
                    }
                }
                lblSndCnt.Text = SendByte_Cnt.ToString("D");
                serialPort1.Encoding = System.Text.Encoding.GetEncoding("GB2312");//解决乱码问题，国标2312编码格式
                serialPort1.Write(SendChars, 0, CharsLength);
            }
            catch (Exception er)
            {
                MessageBox.Show("Error：SendData" + er.Message, "Error");
            }
        }

        private void btnHandSend_Click(object sender, EventArgs e)
        {
            int packet = 0;
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                time = 61;
                this.timer1.Interval = 1000;
                this.timer1.Enabled = true;
                this.timer1.Start();
                send = 1;
                btnHandSend.Enabled = false;
                AutoSend.Enabled = false;
            }
        }
        public byte[] TXSQWriteToByte(string Msg)
        {
            List<byte> bytes = new List<byte>();
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(Msg);
            bytes.AddRange(byteArray);
            return bytes.ToArray();
        }
        public void MessageSend(string MessageType, int MsgUseID, string Message)
        {
            List<byte> MsgBody = new List<byte>();
            byte[] bytehead = System.Text.Encoding.Default.GetBytes(MessageType);
            List<byte> bytes = new List<byte>(120);
            byte[] byteMsg = TXSQWriteToByte(Message);
            int style = 70;
            //消息体组包
            int x;
            int lex = 0;
            int num = 0;
            int Mno = 0;
            int MsgNo = 0;
            List<byte> MsgInfo = new List<byte>();
            MsgInfo.AddRange(byteMsg);
            Mno = MsgInfo.Count;
            MsgBody.Add((byte)style);
            MsgBody.Add((byte)(MsgUseID >> 16));
            MsgBody.Add((byte)(MsgUseID >> 8));
            MsgBody.Add((byte)MsgUseID);
            MsgBody.Add((byte)(((Mno) * 8) >> 8));
            MsgBody.Add((byte)(((Mno) * 8)));
            MsgBody.Add(0);
            MsgBody.AddRange(byteMsg);
            MsgNo = MsgBody.Count;
            TXSQMessage(MsgBody.ToArray(), MessageType, MsgNo);
        }
        public void TXSQMessage(byte[] MsgBody, string MessageType, int MsgNo)
        {
            int MsgUseID = 0;
            uint MsgLength = 0;
            byte[] bytehead = System.Text.Encoding.Default.GetBytes(MessageType);
            List<byte> bytes = new List<byte>(120);
            bytes.AddRange(bytehead);//拼接消息头

            MsgLength = Convert.ToUInt32(10 + MsgNo + 1);
            bytes.Add((byte)(MsgLength >> 8));
            bytes.Add((byte)MsgLength);//拼接消息长度

            bytes.Add((byte)(MsgUseID >> 16));
            bytes.Add((byte)(MsgUseID >> 8));
            bytes.Add((byte)MsgUseID);//拼接用户ID

            bytes.AddRange(MsgBody);//拼接消息体
            byte checkSum = GetCheckXor(bytes.ToArray(), 0, bytes.Count);
            bytes.Add(checkSum);//拼接校验
            byte[] FinMsg = bytes.ToArray();
            serialPort1.Write(FinMsg, 0, FinMsg.Length);
        }
        //CRC校验
        public byte GetCheckXor(byte[] data, int pos, int len)
        {
            byte A = 0;
            for (int i = pos; i < len; i++)
            {
                A ^= data[i];
            }
            return A;
        }
        private void RecieveData(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort_Closing == true)//如果正在关闭，忽略操作，直接返回，尽快的完成串口监听线程的一次循环
            {
                return;
            }

            try
            {
                int len = 0;
                ReceiveByte_Busy = true;//串口接收忙碌标志
                int ReceiveNums = serialPort1.BytesToRead;//记录缓存数量
                ReceiveByte_Cnt += ReceiveNums;
                this.Invoke((EventHandler)(delegate
                {
                    lblSndCnt.Text = ReceiveByte_Cnt.ToString("D");
                    if (chkbHexDisplay.CheckState == CheckState.Checked)
                    {
                        byte[] buf = new byte[ReceiveNums];//声明一个临时数据组存储当前串口数据
                        serialPort1.Read(buf, 0, ReceiveNums);//读取缓冲数据

                        ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadSavDat), buf);

                        BufferData.AddRange(buf);//串口数据写到自定义缓冲区，准备进行数据帧识别处理
                        while (BufferData.Count >= 7) //至少包含帧头（2字节）、长度（1字节）、功能位（1字节）；根据设计不同而不同
                        {
                            //2.1 查找数据头

                            if (BufferData[0] == 0x24) //传输数据有帧头，用于判断. 找到帧头  AA AA 0A 
                            {
                                len = (BufferData[5] << 8) + BufferData[6];
                                //int len = 79;
                                if (BufferData.Count < len) //数据区尚未接收完整，
                                {
                                    break;//跳出接收函数后之后继续接收数据
                                }
                                //得到完整的数据，复制到ReceiveBytes中进行校验
                                byte[] ReceiveBytes = new byte[len];
                                BufferData.CopyTo(0, ReceiveBytes, 0, len);//
                                byte jiaoyan; //开始校验
                                jiaoyan = GetCheckXor(ReceiveBytes, 0, len - 1);//jiaoyan = this.JY(ReceiveBytes);

                                if (jiaoyan != ReceiveBytes[len - 1]) //验证功能位失败    if (jiaoyan != ReceiveBytes[len+3])
                                {
                                    BufferData.RemoveRange(0, len);//从链表中移除接收到的校验失败的数据，
                                    //MessageBox.Show("数据包不正确！");//显示数据包不正确,
                                    continue;//继续执行while循环程序,
                                }
                                BufferData.RemoveRange(0, len);
                                //执行其他代码，对数据进行处理。
                                //解析5 6， 7 8字节的经纬度.
                                /**********************************************************************************解包开始*/
                                if (txtbRcvArea.TextLength > 20000)
                                {
                                    txtbRcvArea.Text = string.Empty;
                                }
                                parseMsg(ReceiveBytes);
                                /***********************************************************************************解包结束*/
                            }
                            else //帧头不正确时，记得清除
                            {
                                BufferData.RemoveAt(0);//清除第一个字节，继续检测下一个。
                            }
                        }
                        int idx = 0;
                        for (idx = 0; idx < BufferData.Count - 5; idx++)
                        {
                            if (BufferData[idx + 3] == 0x58 && BufferData[idx + 4] == 0x58)
                            {
                                if (BufferData.Count - idx >= len)
                                {
                                    byte[] tmb = new byte[len];
                                    BufferData.CopyTo(idx, tmb, 0, tmb.Length);
                                    //BufferData.RemoveRange(0, i + tmb.Length)
                                }
                                else
                                    break;
                            }
                        }
                        BufferData.RemoveRange(0, idx);

                        string tempstr = string.Empty;
                        for (int i = 0; i < ReceiveNums; i++)
                        {
                            tempstr += buf[i].ToString("X2") + " ";
                        }
                        if (chkbPauDisp.CheckState == CheckState.Unchecked)
                        {
                            txtbRcvArea.AppendText(tempstr);//追加到接收数据显示框中
                            txtbRcvArea.AppendText("\r\n");
                        }
                    }
                    else
                    {
                        serialPort1.Encoding = System.Text.Encoding.GetEncoding("GB2312");//解决乱码问题，国标2312编码格式
                        if (chkbPauDisp.CheckState == CheckState.Unchecked)
                        {
                            txtbRcvArea.AppendText(serialPort1.ReadExisting());
                        }
                    }
                    ledRcvStat.LEDSwitch = true;
                    ledRcvStat.Invalidate();
                    stat_timer.Enabled = true;
                }));
                ReceiveByte_Busy = false;
            }
            catch (Exception er)
            {
                //MessageBox.Show("错误: RecieveData" + er.Message, "错误");
            }
        }
        void ThreadSavDat(object o)
        {
            byte[] buf = o as byte[];
            if (writefile != null && writefile.CanWrite)
            {
                writefile.Write(buf, 0, buf.Length);
            }
        }
        /// <summary>
        /// 解析接收数据
        /// </summary>
        /// <param name="Msg"></param>
        public void parseMsg(byte[] Msg)
        {
            try
            {
                byte[] typeByte = new byte[5];
                typeByte[0] = Msg[0];
                typeByte[1] = Msg[1];
                typeByte[2] = Msg[2];
                typeByte[3] = Msg[3];
                typeByte[4] = Msg[4];
                string type = System.Text.Encoding.Default.GetString(typeByte);
                if (type == "$ICXX")
                {
                    UseNum = (uint)((Msg[7] << 16) + (Msg[8] << 8) + Msg[9]);
                    label3.Text = "卡号：" + UseNum.ToString();
                }
                else if (type == "$ZJXX")
                {
                    if (Msg[13] == 0x00)
                    {
                        UseInfo = "non-Inbound，non-inhibited";
                    }
                    else if (Msg[13] == 0x01)
                    {
                        UseInfo = "non-Inbound，inhibited";
                    }
                    else if (Msg[13] == 0x02)
                    {
                        UseInfo = "Inbound, non-inhibited";
                    }
                    else if (Msg[13] == 0x03)
                    {
                        UseInfo = "Inbound, inhibited";
                    }
                    bo1 = (uint)(Msg[14]);
                    bo2 = (uint)(Msg[15]);
                    bo3 = (uint)(Msg[16]);
                    bo4 = (uint)(Msg[17]);
                    bo5 = (uint)(Msg[18]);
                    bo6 = (uint)(Msg[19]);
                    label4.Text = "信号强度：" + bo1.ToString() + "-" + bo2.ToString() + "-" + bo3.ToString() + "-" + bo4.ToString() + "-" + bo5.ToString() + "-" + bo6.ToString();
                    label5.Text = "入站状态：" + UseInfo;
                }
                else if (type == "$TXXX")
                {
                    string value = "";
                    OtherNum = (uint)((Msg[11] << 16) + (Msg[12] << 8) + Msg[13]); //获得IC信息
                    uint E_Length = (uint)((Msg[16] << 8) + Msg[17]);//获得消息长度
                    uint hour = (uint)(Msg[14]);//获得时间
                    uint minutes = (uint)(Msg[15]);//获得分钟
                    uint datatype = (byte)((Msg[10] >> 5) & 0x1);//获得数据类型
                    List<byte> byteMsg = new List<byte>();
                    //获得通信信息中的消息内容
                    for (int i = 0; i < (E_Length / 8); i++)
                    {
                        byteMsg.Add(Msg[i + 18]);
                    }
                    value = Byte120(byteMsg.ToArray(), hour, minutes, datatype);
                    txtbRcvArea.AppendText(value);
                }
            }
            catch (Exception ex)
            {
            }
        }
        //对通讯信息报文进行解包的方法
        //传入参数：接收到短报文的消息,通信时间的时参数，通信时间的分参数，通信类别
        //输出：解析之后的短报文具体的信息
        List<byte> byteVoid = new List<byte>();
        public string Byte120(byte[] bytes, uint hour, uint minutes, uint type)
        {
            string value = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                byteVoid.Add(bytes[i]);
            }
            byte[] lastmsg = byteVoid.ToArray();
            string typetoString = "";
            string str = System.Text.Encoding.GetEncoding("GB2312").GetString(lastmsg);
            value += "\r\n";
            value += "  代理:" + OtherNum + "  时间为: " + DateTime.Now.ToString("T") + "  接收到的通信信息为:\r\n" + str + "\r\n";
            value += "BD网关:" + "367946 " + "  时间为: " + DateTime.Now.ToString("T") + "  数据包接收成功！\r\n";
            byteVoid.Clear();
            return value;
        }

        private void AutoSend_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoSend.Checked)
            {
                if (textBox2.Text != "")
                {
                    i = 0;
                    AutoSendTime.Start();
                    btnHandSend.Enabled = false;
                    confirm.Enabled = true;
                }
                else
                {
                    AutoSend.Checked = false;
                    MessageBox.Show("请添加联系人");
                }
            }
            else
            {
                i = 2;
            }
        }
        int i = 0;
        private void AutoSendTime_Tick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox2.Text);
            if (Byteleave.Length >= 57 && i == 0)
            {
                Array.Copy(Byteleave, 0, Byte57, 0, 57);
                Byteleave = CopyLeave(Byteleave);
                MessageSend("$TXSQ", ID, Byte57);
                i++;
            }
            else if (i == 1)
            {
                if (Byteleave.Length >= 57)
                {
                    Array.Copy(Byteleave, 0, Byte57, 0, 57);
                    Byteleave = CopyLeave(Byteleave);
                    MessageSend("$TXSQ", ID, Byte57);
                }
            }
            else if (i == 2)
            {
                if (Byteleave.Length >= 57)
                {
                    Array.Copy(Byteleave, 0, Byte57, 0, 57);
                    Byteleave = CopyLeave(Byteleave);
                    MessageSend("$TXSQ", ID, Byte57);
                }
                else
                {
                    MessageSend("$TXSQ", ID, Byteleave);
                    i = 0;
                    AutoSendTime.Stop();
                    btnHandSend.Enabled = true;
                    confirm.Enabled = false;
                }
            }
        }
        private Byte[] CopyLeave(Byte[] bytes)
        {
            byte[] newbyte=bytes;
            bytes = new byte[newbyte.Length - 57];
            Array.Copy(newbyte, 57, bytes, 0, newbyte.Length-57);
            return bytes;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            msg = textBox1.Text.Trim();
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(msg);
            Byteleave = copybyte(Byteleave, byteArray);
        }
        //合并数组


        public byte[] copybyte(byte[] a, byte[] b)
        {
            byte[] c = new byte[a.Length + b.Length];
            a.CopyTo(c, 0); 
            b.CopyTo(c, a.Length);
            return c;
        }
        //57字节自动发送组包
        public void MessageSend(string MessageType, int MsgUseID, byte[] Message)
        {
            List<byte> MsgBody = new List<byte>();
            byte[] bytehead = System.Text.Encoding.Default.GetBytes(MessageType);
            List<byte> bytes = new List<byte>(120);
            byte[] byteMsg = Message;
            int style = 70;
            //消息体组包
            int x;
            int lex = 0;
            int num = 0;
            int Mno = 0;
            int MsgNo = 0;
            List<byte> MsgInfo = new List<byte>();
            MsgInfo.AddRange(byteMsg);
            Mno = MsgInfo.Count;
            MsgBody.Add((byte)style);
            MsgBody.Add((byte)(MsgUseID >> 16));
            MsgBody.Add((byte)(MsgUseID >> 8));
            MsgBody.Add((byte)MsgUseID);
            MsgBody.Add((byte)(((Mno) * 8) >> 8));
            MsgBody.Add((byte)(((Mno) * 8)));
            MsgBody.Add(0);
            MsgBody.AddRange(byteMsg);
            MsgNo = MsgBody.Count;
            TXSQMessage(MsgBody.ToArray(), MessageType, MsgNo);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label7.Text = time.ToString() + " s";
            time--;
            if (time < 0)
            {
                AutoSend.Enabled = true;
                btnHandSend.Enabled = true;
                AutoSend.Enabled = false;
                this.timer1.Stop();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        { 
            string road = Application.StartupPath + @"\Data";
            System.Diagnostics.Process.Start(road);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtbRcvArea.Text = string.Empty;
        }
        /// <summary>
        /// 读取txt文件内容
        /// </summary>
        /// <param name="Path">文件地址</param>
        public void ReadTxtContent(string Path)
        {
            StreamReader sr = new StreamReader(Path, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                textBox1.AppendText(line.ToString()+"\r\n");
            }
        }

        private void readTxt_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.txt)|*.txt";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = string.Empty;
                string file = dialog.FileName;
                ReadTxtContent(file);
                FileName.Text = file;
            }
        }

        private void txtbRcvArea_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
