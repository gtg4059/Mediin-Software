using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace WinformUnity
{
    class Sport
    {
        private static List<byte> rcvbytes = new List<byte>();

        public static char sSTX() { return Convert.ToChar(0x02); }
        public static char sETX() { return Convert.ToChar(0x03); }
        public static char sEOT() { return Convert.ToChar(0x04); }
        public static char sENQ() { return Convert.ToChar(0x05); }
        public static char sACK() { return Convert.ToChar(0x06); }
        public static char sNAK() { return Convert.ToChar(0x15); }
        public static char sCR() { return Convert.ToChar(13); }
        public static char sLF() { return Convert.ToChar(10); }
        public static string sCRLF() { return "\r\n"; }

        //========================================================
        //  컴퓨터에 존재하는 Port 알아보기
        //========================================================
        public static string[] GetPortsList()
        {
            List<string> serialportlist = new List<string>();
            serialportlist.Clear();
            foreach (string comport in SerialPort.GetPortNames())
            {
                serialportlist.Add(comport);
            }
            return serialportlist.ToArray();
        }

        //========================================================
        //  Port 열기
        //========================================================
        public static bool OpenPorts(SerialPort sport, int portnum)
        {
            if (sport.IsOpen) sport.Close();

            //SerialPort 초기설정
            sport.PortName = "COM" + portnum.ToString();
            sport.BaudRate = 115200;
            sport.DataBits = 8;
            sport.Parity = Parity.None;
            sport.StopBits = StopBits.One;

            sport.ReceivedBytesThreshold = 1;

            bool rtn;
            try
            {
                sport.Open();
                rtn = true;
            }
            catch { rtn = false; }

            return rtn;
        }

        public static bool OpenPorts(SerialPort sport, string portName)
        {
            if (sport.IsOpen) sport.Close();

            //SerialPort 초기설정
            sport.PortName = portName;
            sport.BaudRate = 115200;
            sport.DataBits = 8;
            sport.Parity = Parity.None;
            sport.StopBits = StopBits.One;

            sport.ReceivedBytesThreshold = 1;

            bool rtn;
            try
            {
                sport.Open();
                rtn = true;
            }
            catch { rtn = false; }

            return rtn;
        }

        //========================================================
        //  Port 닫기
        //========================================================
        public static void ClosePorts(SerialPort sport)
        {
            if (sport.IsOpen) sport.Close();
        }

        //========================================================
        //  데이터보내기
        //========================================================
        public static void Send(SerialPort sport, string text)
        {
            sport.Write(text);
        }
        public static void SendUnicode(SerialPort sport, string text)
        {
            byte[] tmp = Encoding.UTF8.GetBytes(text);
            sport.Write(tmp, 0, tmp.Length);
        }

        //========================================================
        //  데이터읽기
        //========================================================
        public static string Read(SerialPort sport)
        {
            return sport.ReadExisting();
        }
        public static string ReadUnicode(SerialPort sport, byte endByte)
        {
            while (true)
            {
                byte inbyte = (byte)sport.ReadByte();
                rcvbytes.Add(inbyte);
                if (inbyte == endByte) break;
            }

            byte[] bytes = rcvbytes.ToArray();
            rcvbytes.Clear();

            string st = Encoding.UTF8.GetString(bytes);
            return st;
        }

    }
}
