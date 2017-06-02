using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Threading;
using System.Net;

namespace RollerTest.WebUI.ExternalProgram
{
    public class DealMethod
    {
        object m_lock = new object();
        const int ReceiveDataCount = 4048;
        const int PacketHeadSize = 12;
        int nNetPos = 0;
        Socket s;
        //网络缓存数据
        List<byte> m_NetData = new List<byte>();
        //处理缓存数据
        byte[] m_TmpData;
        //所有待处理的包数据
        List<PackData> m_lstPackData = new List<PackData>();


        //连接用函数
        public bool SocketConnectState()
        {
            string txtIp = "192.168.0.30";
            string txtPort = "5003";
            IPEndPoint removeServer = new IPEndPoint(IPAddress.Parse(txtIp), int.Parse(txtPort));
            s=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(removeServer);
            if (s.Connected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        //接收数据调用函数

        /// <summary>
        /// 接收数据
        /// </summary>
        void ReceiveData()
        {
            while (true)
            {
                byte[] recvData = new byte[ReceiveDataCount];
                try
                {
                    int nRecvCount = s.Receive(recvData); //接收数据，返回每次接收的字节总数
                    for (int i = 0; i < nRecvCount; i++)
                    {
                        m_NetData.Add(recvData[i]);
                    }
                    ParseBuffer();
                }
                catch
                {
                    Console.WriteLine("ReceiveData Catch>>" + DateTime.Now);
                }
            }
        }

        /// <summary>
        /// 处理缓存数据
        /// </summary>
        void ParseBuffer()
        {
            m_TmpData = new byte[m_NetData.Count - nNetPos];
            Array.Copy(m_NetData.ToArray(), nNetPos, m_TmpData, 0, (m_NetData.Count - nNetPos));

            int nAlreadyRecCount = m_TmpData.Length;
            if (nAlreadyRecCount <= 0)
                return;

            // 查找包文头信息
            for (int i = 0; i < m_TmpData.Length - 3; i++)
            {
                if (m_TmpData[i] == 0x55 && m_TmpData[i + 1] == 0xaa && m_TmpData[i + 2] == 0xaa && m_TmpData[i + 3] == 0x55)
                {
                    FindPackHead(nAlreadyRecCount, i);
                }
            }
        }

        /// <summary>
        /// 找到包头标志后，对数据进行处理
        /// </summary>
        /// <param name="nAlreadyRecCount">接收的数据长度</param>
        /// <param name="nDataPointer">第几个字节开始为包头位置</param>
        void FindPackHead(int nAlreadyRecCount, int nDataPointer)
        {
            // 找到一个数据报头信息
            // 网络包长度小于包头时不是一个完整的包
            if (nAlreadyRecCount - nDataPointer < PacketHeadSize)
                return;

            PackHead m_PackHead = new PackHead();
            SetPackHead(nDataPointer, ref m_PackHead);

            // 判断获得的数据除去表头 是否大于数据长度
            if (nAlreadyRecCount - nDataPointer - PacketHeadSize < m_PackHead.DataLength)
                return;

            //完整的包数据
            byte[] m_ComData = new byte[PacketHeadSize + m_PackHead.DataLength];
            Array.Copy(m_TmpData, nDataPointer, m_ComData, 0, PacketHeadSize + m_PackHead.DataLength);

            PackData pd = new PackData();
            pd.m_Index = m_lstPackData.Count;
            pd.m_Head = m_PackHead;
            pd.m_ByteData = m_ComData.ToList();

            lock (m_lock)
            {
                nNetPos += PacketHeadSize + pd.m_Head.DataLength;
                m_lstPackData.Add(pd);
            }
        }
        /// <summary>
        /// 设置包头
        /// </summary>
        void SetPackHead(int nDataPointer, ref PackHead m_PackHead)
        {
            m_PackHead.Reset();
            m_PackHead.m_Signature[0] = m_TmpData[nDataPointer];
            m_PackHead.m_Signature[1] = m_TmpData[nDataPointer + 1];
            m_PackHead.m_Signature[2] = m_TmpData[nDataPointer + 2];
            m_PackHead.m_Signature[3] = m_TmpData[nDataPointer + 3];
            m_PackHead.m_Command[0] = m_TmpData[nDataPointer + 4];
            m_PackHead.m_Command[1] = m_TmpData[nDataPointer + 5];
            m_PackHead.m_Command[2] = m_TmpData[nDataPointer + 6];
            m_PackHead.m_Command[3] = m_TmpData[nDataPointer + 7];
            m_PackHead.m_Length[0] = m_TmpData[nDataPointer + 8];
            m_PackHead.m_Length[1] = m_TmpData[nDataPointer + 9];
            m_PackHead.m_Length[2] = m_TmpData[nDataPointer + 10];
            m_PackHead.m_Length[3] = m_TmpData[nDataPointer + 11];

            m_PackHead.DataLength = BitConverter.ToInt32(m_PackHead.m_Length, 0);
            m_PackHead.DataCommand = BitConverter.ToInt32(m_PackHead.m_Command, 0);
        }



 //处理数据调用函数

        /// <summary>
        /// 处理数据
        /// </summary>
        void DealData()
        {
            while (true)
            {
                lock (m_lock)
                {
                    if (m_lstPackData.Count == 0)
                    {
                        Thread.Sleep(100);
                    }
                    else
                    {
                        DealComData();
                        //处理完包数据后，将m_NetData中用过的数据清除
                        // 一直到 位置nNetPos 的m_NetData的数据已经用过
                        m_NetData.RemoveRange(0, nNetPos);
                        nNetPos = 0;
                    }
                }
            }
        }


        /// <summary>
        /// 处理完整包数据
        /// </summary>
        public List<string> DealComData()
        {
            List<string> str = new List<string>();
            string txtres = "";
            string txtSignalInfo = "";
            string res = "";
            for (int i = 0; i < m_lstPackData.Count; i++)
            {
                PackData pd = m_lstPackData[i];
                switch (m_lstPackData[i].m_Head.DataCommand)
                {
                    case 128:
                        res = DealCmd.DealGetSignal(pd);
                        txtSignalInfo += "Commond 128  信号类型：" + pd.m_SignalType + ";内容:" + res + Environment.NewLine;
                        break;
                    case 123:
                        res = DealCmd.DealTransferDataSignal(pd);
                        txtres += "Commond 123  信号类型：" + pd.m_SignalType + ";信号名称:" + res + Environment.NewLine;
                        break;
                    case 124:
                        res = DealCmd.DealSerialData(pd);
                        txtres += "Commond 124Serial  信号位置：" + pd.m_Position + ";数据量:" + pd.m_DataCount + ";信号数："
                            + pd.m_SignalCount + Environment.NewLine + "数据：" + res + Environment.NewLine;
                        break;
                    case 125:
                        res = DealCmd.DealStatData(pd);
                        txtres += "Commond 125Stat  信号数：" + pd.m_SignalCount + ";数据：" + res + Environment.NewLine;
                        break;
                    case 126:
                        res = DealCmd.DealBlockData(pd);
                        txtres += "Commond 126Block  信号字符串长度：" + pd.m_SignalNameLength + ";信号名:" + pd.m_SignalName
                                + ";一个数据中包含几个float：" + pd.m_YCount + ";数据量：" + pd.m_DataCount + ";数据：" + res + Environment.NewLine;
                        break;
                }
            }
            m_lstPackData.Clear();
            str.Add(txtres);
            str.Add(txtSignalInfo);
            return str;
        }

// 操作方法

        //发送“服务器退出提示”
        void sendExit()
        {
            s.Shutdown(SocketShutdown.Both);
            s.Close();
        }
        bool CheckSocket()
        {
            bool res = false;
            if (s == null || s.Connected == false)
            {
                //MessageBox.Show("请点击连接...");
                res = true;
            }
            return res;
        }

        void GetSignalInfo()
        {
            s.Send(DealCmd.GetCmdGetSerialSignal());
            s.Send(DealCmd.GetCmdGetBlockSignal());
            s.Send(DealCmd.GetCmdGetStatSignal());
        }

    }



//  定义包数据成员变量

    public class PackData
    {
        public int m_Index;
        public PackHead m_Head;
        /// <summary>
        /// 完整包数据
        /// </summary>
        public List<byte> m_ByteData;

        //命令123的相关信息
        public int m_SignalType;
        public List<string> m_lstSignalName;

        //命令124的相关信息
        /// <summary>
        /// 位置
        /// </summary>
        public long m_Position;
        /// <summary>
        /// 数据量 每个通道发过来的数据数量
        /// </summary>
        public int m_DataCount;
        /// <summary>
        /// 通道数
        /// </summary>
        public int m_SignalCount;
        /// <summary>
        /// 发来的时间序列数据
        /// </summary>
        public List<float> m_lstSerialSignalData = new List<float>();

        //命令125的相关信息
        /// <summary>
        /// 发来的统计数据
        /// </summary>
        public List<StatData> m_lstStatSignalData = new List<StatData>();

        //命令126的相关信息
        /// <summary>
        /// 信号字符串长度
        /// </summary>
        public int m_SignalNameLength;
        /// <summary>
        /// 信号名
        /// </summary>
        public string m_SignalName;
        /// <summary>
        /// 信号信息
        /// </summary>
        public string m_SignalInfo = "";
        /// <summary>
        /// 数据量 每个通道发过来的数据数量
        /// </summary>
        public int m_SignalInfoLength;
        /// <summary>
        /// 一个数据中包含几个float
        /// </summary>
        public int m_YCount;
        /// <summary>
        /// 发来的块数据
        /// </summary>
        public List<BlockData> m_lstBlockSignalData = new List<BlockData>();
    }

    public class StatData
    {
        public float m_Time;
        public float m_Data;
    }

    public class BlockData
    {
        public float m_Time;
        /// <summary>
        /// 一个数据中包含1个float 则使用m_Data1,否则用m_Data1，m_Data2
        /// </summary>
        public float m_Data1;
        public float m_Data2;
    }

    public class PackHead
    {
        public byte[] m_Signature;
        public byte[] m_Command;
        public byte[] m_Length;
        public int DataLength;
        public int DataCommand;

        public void Reset()
        {
            m_Signature = new byte[4];
            m_Command = new byte[4];
            m_Length = new byte[4];
        }
    }
}