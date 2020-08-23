using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WinformUnity
{
    class StreamString
    {
        private Stream ioStream;
        private UnicodeEncoding streamEncoding;

        public StreamString(Stream ioStream)
        {
            this.ioStream = ioStream;
            streamEncoding = new UnicodeEncoding();
        }
        public void StreamClear (Stream ioStream)
        {
            ioStream.Close();
        }
        public string ReadString()
        {

            int len = 0;

            try
            {
                len = ioStream.ReadByte() * 256;
                len += ioStream.ReadByte();
                byte[] inBuffer = new byte[len];
                ioStream.Read(inBuffer, 0, len);
                ioStream.Flush();
                return streamEncoding.GetString(inBuffer);
            }
            catch
            {
                
                return "";
            }
            





        }

        public int WriteString(string outString)
        {
            try
            {
                byte[] outBuffer = streamEncoding.GetBytes(outString);
                int len = outBuffer.Length;
                if (len > UInt16.MaxValue)
                {
                    len = (int)UInt16.MaxValue;
                }
                ioStream.WriteByte((byte)(len / 256));
                ioStream.WriteByte((byte)(len & 255));
                ioStream.Write(outBuffer, 0, len);
                ioStream.Flush();

                return outBuffer.Length + 2;
            }
            catch
            {
                
                return 0;
            }
            
        }
    }
}
