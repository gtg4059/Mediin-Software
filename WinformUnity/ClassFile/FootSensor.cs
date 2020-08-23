using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace WinformUnity
{
    class FootSensor
    {
        public  bool Sport_Open(SerialPort sport, string portNum, int baudR)
        {
            if (sport.IsOpen) sport.Close();
            sport.PortName = "COM" + portNum;
            sport.BaudRate = baudR;
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

        public  bool Sport_Close(SerialPort sport)
        {
            bool rtn;
            if (sport.IsOpen)
            {
                try
                {
                    sport.Close();
                    rtn = false;
                }
                catch { rtn = true; }
            }
            else rtn = true;                                      
            return rtn;
        }

        public  double getLeft(double[,] data)
        {
            //48x48 데이터 들어왔음
            const int matLen = 48;
            double[] arrLeft = new double[48 * 48 - 1];
            int k = 0;
            double max = 0;
            for (int j = 0; j < matLen; j++)
            {
                for (int i = 0; i < matLen; i++)
                {
                    arrLeft[k++] = data[i, j];
                    if (k >= 48 * 48 - 1) break;
                }
            }
            max = arrLeft.Max();
            return max;
        }

        public  double getRight(double[,] data)
        {
            //48x48 데이터 들어왔음
            const int matLen = 48;
            double[] arrRight = new double[48 * 48 - 1];
            int k = 0;
            double max = 0;
            for (int j = matLen/2; j < matLen; j++)
            {
                for (int i = 0; i < matLen; i++)
                {
                    arrRight[k++] = data[i, j];
                    if (k >= 48 * 48 - 1) break;
                }
            }
            max = arrRight.Max();
            return max;
        }
        
        public  double getFront (double[,] data)
        {
            const int matLen = 48;
            double[] arrFront = new double[48 * 48 - 1];
            int k = 0;
            double max = 0;
            for (int i = 0; i < matLen; i++)
            {
                for (int j = 0; j < matLen; j++)
                {
                    arrFront[k++] = data[i, j];
                    if (k >= 48 * 48 - 1) break;
                }
            }
            max = arrFront.Max();
            return max;
        }

        public  double getBack(double[,] data)
        {
            const int matLen = 48;
            double[] arrBack = new double[48 * 48 - 1];
            int k = 0;
            double max = 0;
            for (int i = 24; i < matLen; i++)
            {
                for (int j = 0; j < matLen; j++)
                {
                    arrBack[k++] = data[i, j];
                    if (k >= 48 * 48 - 1) break;
                }
            }
            max = arrBack.Max();
            return max;
        }

        public  double getMax(double[,] data)
        {
            const int matLen = 48;
            double[] arr = new double[48 * 48];
            int k = 0;
            for (int i = 0; i < matLen; i++)
            {
                for (int j = 0; j < matLen; j++)
                {
                    arr[k++] = data[i, j];
                }
            }
            double max = arr.Max();
            return max;
        }

        public  double getMin(double[,] data)
        {
            const int matLen = 48;
            double[] arr = new double[48 * 48];
            int k = 0;
            for (int i = 0; i < matLen; i++)
            {
                for (int j = 0; j < matLen; j++)
                {
                    arr[k++] = data[i, j];
                }
            }
            double min = arr.Min();
            return min;
        }
    }
}
