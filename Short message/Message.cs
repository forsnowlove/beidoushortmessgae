using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Short_message
{
    class Message : Form1
    {
        public uint MsgToId { get; set; }
        /// <summary>
        /// ic检测协议组包
        /// </summary>
        /// <param name="MessageType">消息类型</param>
        /// <param name="MsgUseID">对方ID</param>
        /// <returns></returns>

        public static byte[] ICJC(string MessageType, int MsgUseID)
        {
            List<byte> MsgBody = new List<byte>();
            byte[] bytehead = System.Text.Encoding.Default.GetBytes(MessageType);
            List<byte> bytes = new List<byte>(120);
            bytes.AddRange(bytehead);//拼接消息头
            MsgBody.Clear();
            MsgBody.AddRange(ICJCWriteToByte());
            int MsgNo = MsgBody.Count;//消息体长度
            uint MsgLength = Convert.ToUInt32(10 + MsgNo + 1);
            bytes.Add((byte)(MsgLength >> 8));
            bytes.Add((byte)MsgLength);//拼接消息长度

            bytes.Add((byte)(MsgUseID >> 16));
            bytes.Add((byte)(MsgUseID >> 8));
            bytes.Add((byte)MsgUseID);//拼接用户ID

            bytes.AddRange(MsgBody);//拼接消息体

            byte checkSum = GetCheckXor(bytes.ToArray(), 0, bytes.Count);
            bytes.Add(checkSum);//拼接校验

            return bytes.ToArray();
        }
        //IC检测
        public static byte[] ICJCWriteToByte()
        {
            List<byte> bytes = new List<byte>(1);
            bytes.Add(1);
            return bytes.ToArray();
        }
        /// <summary>
        /// 系统自检协议组包
        /// </summary>
        /// <param name="MessageType">消息类型</param>
        /// <param name="MsgUseID">对方ID</param>
        /// <returns></returns>
        public static byte[] XTZJ(string MessageType, int MsgUseID)
        {
            List<byte> MsgBody = new List<byte>();
            byte[] bytehead = System.Text.Encoding.Default.GetBytes(MessageType);
            List<byte> bytes = new List<byte>(120);
            bytes.AddRange(bytehead);//拼接消息头
            MsgBody.Clear();
            MsgBody.AddRange(XTJCWriteToByte());
            int MsgNo = MsgBody.Count;//消息体长度
            uint MsgLength = Convert.ToUInt32(10 + MsgNo + 1);
            bytes.Add((byte)(MsgLength >> 8));
            bytes.Add((byte)MsgLength);//拼接消息长度

            bytes.Add((byte)(MsgUseID >> 16));
            bytes.Add((byte)(MsgUseID >> 8));
            bytes.Add((byte)MsgUseID);//拼接用户ID

            bytes.AddRange(MsgBody);//拼接消息体

            byte checkSum = GetCheckXor(bytes.ToArray(), 0, bytes.Count);
            bytes.Add(checkSum);//拼接校验

            return bytes.ToArray();
        }
        //状态查询
        public static byte[] XTJCWriteToByte()
        {
            List<byte> bytes = new List<byte>(1);
            bytes.Add(0);
            return bytes.ToArray();
        }
        public void MessageSend(string MessageType, int MsgUseID, string Message, string MsgType)
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
            MsgBody.Add((byte)(MsgToId >> 16));
            MsgBody.Add((byte)(MsgToId >> 8));
            MsgBody.Add((byte)MsgToId);
            MsgBody.Add((byte)(((Mno) * 8) >> 8));
            MsgBody.Add((byte)(((Mno) * 8)));
            MsgBody.Add(0);
            MsgBody.AddRange(byteMsg);
            MsgNo = MsgBody.Count;
            TXSQMessage(MsgBody.ToArray(), MessageType, MsgNo, MsgUseID);
        }
        //通讯申请
        public byte[] TXSQWriteToByte(string Msg)
        {
            List<byte> bytes = new List<byte>();
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(Msg);
            bytes.AddRange(byteArray);
            return bytes.ToArray();
        }
        public void TXSQMessage(byte[] MsgBody, string MessageType, int MsgNo, int MsgUseID)
        {
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

        public static byte GetCheckXor(byte[] data, int pos, int len)
        {
            byte A = 0;
            for (int i = pos; i < len; i++)
            {
                A ^= data[i];
            }
            return A;
        }
    }
}
