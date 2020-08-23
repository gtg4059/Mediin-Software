using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Pipes;
using MMCWHPNET;
using System.Security.Principal;
using Microsoft.Kinect;
using Coding4Fun.Kinect.WinForm;
using System.IO.Ports;
using System.Media;
namespace WinformUnity
{
    /// <summary>
    /// https://docs.unity3d.com/Manual/CommandLineArguments.html
    /// </summary>
    public partial class ContainerForm : Form
    {
        ListBox listbox = new ListBox();
        bool isFootConnected, LeftTiltFlag, RightTiltFlag, LeftWeight, RightWeight, ExerciseLeftFlageStart = false, ExerciseRightFlageStart = false;
        Bitmap bmapOrg = new Bitmap(48 * 3, 48 * 3);
        Int32 ColorLeftSum = 0, ColorRightSum = 0;
        short LeftLegCount = 0, RightLegCount = 0, LeftHandCount = 0, RightHandCount = 0, cnt = 0, ElbowCount = 0, UpDownCount = 0;
        bool fixguidelineflag = false,u=true; int firstyaw = 0;
        string rxBuffer = "";
        #region Kinect Declaration
        private KinectSensor kSensor;
        private readonly Brush inferredJointBrush = Brushes.Yellow;
        private readonly Brush trackedJointBrush = new SolidBrush(Color.FromArgb(255, 68, 192, 68));
        private readonly Pen trackedBonePen = new Pen(Brushes.Green, 6);
        private readonly Pen inferredBonePen = new Pen(Brushes.Gray, 1);
        private bool LeftHandReachdFlag = true, RightHandReachdFlag = true, LeftLegReachdFlag = true, RightLegReachdFlag = true, LegReachdFlag = true;
        private bool ElbowModeReachdFlag = true, ElbowDownReachdFlag = false, ElbowExModeFlag = false, UpFlag = true, DownFlag = true, 
            CenterfixedFlag = false,threadend=false,StandingFlag=false;
        double Center_Right, Right_Elbow_R, Elbow_Wrist_R;
        double Center_Left, Left_Elbow_L, Elbow_Wrist_L, RightLegDown, LeftLegDown, RightLegUp, LeftLegUp, CenterSpine, CenterSpineContainer;
        private NAudio.Wave.BlockAlignReductionStream stream = null;
        private NAudio.Wave.DirectSoundOut output = null;
        #endregion

        #region Unity Declaration
        [DllImport("User32.dll")]
        static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool redraw);

        internal delegate int WindowEnumProc(IntPtr hwnd, IntPtr lparam);
        [DllImport("user32.dll")]
        internal static extern bool EnumChildWindows(IntPtr hwnd, WindowEnumProc func, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private Process process;
        private IntPtr unityHWND = IntPtr.Zero;

        private const int WM_ACTIVATE = 0x0006;
        private readonly IntPtr WA_ACTIVE = new IntPtr(1);
        private readonly IntPtr WA_INACTIVE = new IntPtr(0);

        //Declaration for Communication
        Thread thread1, thread2;
        NamedPipeClientStream client1, client2;
        StreamString clientStream1, clientStream2;
        string dataFromServer = "";
        bool processflag1 = false, processflag2 = false, ReachHeight = false;
        #endregion

        #region MMCWHP Declaration
        long[] addr = new long[4] { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
        double[,] dataOrg = new double[48, 48], dataInterp = new double[48 * 3, 48 * 3];
        int[] sensors = new int[48 * 48];
        int[,] r = new int[48, 48], g = new int[48, 48], b = new int[48, 48];
        int[,] rr = new int[48 * 3, 48 * 3], gg = new int[48 * 3, 48 * 3], bb = new int[48 * 3, 48 * 3];
        bool isConnected;
        int homesen = 0;
        double axis0pos = 0;
        double axis1pos = 0;
        double axis2pos = 0;
        double axis3pos = 0;
        bool MotorInitFlag = false;
        #endregion       

        #region initialize, End Components
        public ContainerForm()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(300, 300);
            InitializeComponent();
            //Control.CheckForIllegalCrossThreadCalls = false;
            NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(Application.StartupPath + "\\Audio\\시작_운동.mp3"));
            stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(stream);
            output.Play();
        }

        private void btn초기화_Click(object sender, EventArgs e)
        {
            /*NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(Application.StartupPath + "\\Audio\\초기화.mp3"));
            stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(stream);
            output.Play();*/

            try
            {
                if (rdbSki.Checked)
                {
                    initMotor();
                    initHomming();
                    rdbSki.Enabled = false;
                    rdbCoach.Enabled = false;
                    FootSensor fs = new FootSensor();
                    string str = comboPort.Text;
                    string portNum = str.Substring(str.Length - 1, 1);
                    int baud = Convert.ToInt32(comboBaudrate.Text);
                    isFootConnected = fs.Sport_Open(serialFoot, portNum, baud);

                    /*if (KinectSensor.KinectSensors.Count > 0)
                    {
                        kSensor = KinectSensor.KinectSensors[0];
                        KinectSensor.KinectSensors.StatusChanged += KinectSensors_StatusChanged;
                    }
                    kSensor.Start();
                    //                this.lblConnectionID.Text = kSensor.DeviceConnectionId;
                    kSensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                    kSensor.DepthStream.Enable();
                    //kSensor.DepthStream.Range = DepthRange.Near;
                    kSensor.AllFramesReady += kSensor_AllFramesReady;
                    kSensor.SkeletonStream.Enable();
                    kSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Default;*/
                    thread1 = new Thread(new ThreadStart(Thread_Test1));
                    thread2 = new Thread(new ThreadStart(Thread_Test2));
                    thread1.Start();
                    thread2.Start();

                   
                        process = new Process();
                    
                    process.StartInfo.FileName = "Medi_VR.exe";

                        process.StartInfo.Arguments = "-parentHWND " + selectablePanel.Handle.ToInt32() + " " + Environment.CommandLine;
                        process.StartInfo.UseShellExecute = true;
                        process.StartInfo.CreateNoWindow = true;

                        process.Start();

                        process.WaitForInputIdle();

                        EnumChildWindows(selectablePanel.Handle, WindowEnum, IntPtr.Zero);
                    NAudio.Wave.WaveStream pcm1 = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(Application.StartupPath + "\\Audio\\시작_스키.mp3"));
                    stream = new NAudio.Wave.BlockAlignReductionStream(pcm1);
                    output = new NAudio.Wave.DirectSoundOut();
                    output.Init(stream);
                    output.Play();
                }
                else if (rdbCoach.Checked)
                {
                    //initMotor();
                    //initHomming();
                    rdbSki.Enabled = false;
                    rdbCoach.Enabled = false;
                    btn상지운동.Enabled = true;
                    btn하지운동.Enabled = true;
                    

                    /*if (KinectSensor.KinectSensors.Count > 0)
                    {
                        kSensor = KinectSensor.KinectSensors[0];
                        KinectSensor.KinectSensors.StatusChanged += KinectSensors_StatusChanged;                       
                    }
                    kSensor.Start();
                    //                this.lblConnectionID.Text = kSensor.DeviceConnectionId;
                    kSensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                    kSensor.DepthStream.Enable();
                    //kSensor.DepthStream.Range = DepthRange.Near;
                    kSensor.AllFramesReady += kSensor_AllFramesReady;
                    kSensor.SkeletonStream.Enable();
                    kSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Default;*/
                    thread1 = new Thread(new ThreadStart(Thread_Test1));
                    thread1.Start();

                    
                            /*process.CloseMainWindow();

                            Thread.Sleep(1000);
                            while (process.HasExited == false)
                                process.Kill();*/
                        

                        process = new Process();
                    
                    process.StartInfo.FileName = "VR_Avatar_2.exe";

                        process.StartInfo.Arguments = "-parentHWND " + selectablePanel.Handle.ToInt32() + " " + Environment.CommandLine;
                        process.StartInfo.UseShellExecute = true;
                        process.StartInfo.CreateNoWindow = true;

                        process.Start();

                        process.WaitForInputIdle();

                        EnumChildWindows(selectablePanel.Handle, WindowEnum, IntPtr.Zero);
                        processflag1 = true;
                        processflag2 = false;

                    NAudio.Wave.WaveStream pcm2 = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(Application.StartupPath + "\\Audio\\시작_코치.mp3"));
                    stream = new NAudio.Wave.BlockAlignReductionStream(pcm2);
                    output = new NAudio.Wave.DirectSoundOut();
                    output.Init(stream);
                    output.Play();

                    FootSensor fs = new FootSensor();
                    string str = comboPort.Text;
                    string portNum = str.Substring(str.Length - 1, 1);
                    int baud = Convert.ToInt32(comboBaudrate.Text);
                    isFootConnected = fs.Sport_Open(serialFoot, portNum, baud);
                }
                


            }
            catch (Exception)
            {
                MessageBox.Show("Kinect is not ready!");
            }
        }

        private void ContainerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {



                if (rdbCoach.Checked)
                {
                    double pos0 = 30;
                    double pos1 = 30;
                    double pos2 = 30;
                    long[] addr = { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
                    short[] axes = new short[4] { 0, 1, 2, 3 };                            //회전할 축 설정
                    short[] accel = new short[4] { 200, 200, 200, 200 };                     //accel값이 높아질수록 스므스하게 감속 (값이 너무 작으면 감속기 혹은 링크부분에 충격이 클 수 있음)
                    double[] pos = new double[4] { ATP(pos0), ATP(pos1), ATP(pos2), 0 };      //각 축의 위치값 (이후에 각도와 모터 위치값의 상관관계를 찾아 define해주면 됨 -> Window에서는 각도만 입력해서 움직일 수 있도록)
                    double[] vel = new double[4] { 80000.0, 80000.0, 80000.0, 80000.0 };
                    short err = MMCLib.mmc_initx(4, addr);  //초기화
                    MMCLib.move_all(4, axes, pos, vel, accel);

                    MMCLib.set_amp_enable(0, 0);        //Amp on
                    MMCLib.set_amp_enable(1, 0);
                    MMCLib.set_amp_enable(2, 0);
                    MMCLib.set_amp_enable(3, 0);

                    process.CloseMainWindow();
                    Thread.Sleep(1000);
                    while (process.HasExited == false)
                        process.Kill();
                    threadend = true;
                    client1.Close();
                    thread1.Abort();
                    kSensor.AllFramesReady -= kSensor_AllFramesReady;
                    kSensor.Dispose();
                }
                else if (rdbSki.Checked)
                {
                    double pos0 = 30;
                    double pos1 = 30;
                    double pos2 = 30;
                    long[] addr = { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
                    short[] axes = new short[4] { 0, 1, 2, 3 };                            //회전할 축 설정
                    short[] accel = new short[4] { 200, 200, 200, 200 };                     //accel값이 높아질수록 스므스하게 감속 (값이 너무 작으면 감속기 혹은 링크부분에 충격이 클 수 있음)
                    double[] pos = new double[4] { ATP(pos0), ATP(pos1), ATP(pos2), 0 };      //각 축의 위치값 (이후에 각도와 모터 위치값의 상관관계를 찾아 define해주면 됨 -> Window에서는 각도만 입력해서 움직일 수 있도록)
                    double[] vel = new double[4] { 80000.0, 80000.0, 80000.0, 80000.0 };
                    short err = MMCLib.mmc_initx(4, addr);  //초기화
                    MMCLib.move_all(4, axes, pos, vel, accel);

                    MMCLib.set_amp_enable(0, 0);        //Amp on
                    MMCLib.set_amp_enable(1, 0);
                    MMCLib.set_amp_enable(2, 0);
                    MMCLib.set_amp_enable(3, 0);

                    process.CloseMainWindow();
                    Thread.Sleep(1000);
                    while (process.HasExited == false)
                        process.Kill();
                    threadend = true;
                    client1.Close();
                    thread1.Abort();
                    client2.Close();
                    thread2.Abort();
                }
                NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(Application.StartupPath + "\\Audio\\종료_운동.mp3"));
                stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
                output = new NAudio.Wave.DirectSoundOut();
                output.Init(stream);
                output.Play();

            }
            catch (Exception)
            {

            }
        }

        private void ContainerForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btn설정_Click(object sender, EventArgs e)
        {
            panSetting.Visible = !panSetting.Visible;
        }

        private void btn족압측정_Click(object sender, EventArgs e)
        {
            fixguidelineflag = true;
            lblStatus.Text = "Stabilizing";
            FootSensor fs = new FootSensor();
            tmrDraw.Enabled = true;
            double maxLeft, maxRight;
            maxLeft = fs.getLeft(dataOrg);
            maxRight = fs.getRight(dataOrg);
            if (maxRight < maxLeft)
            {
                lblStatus.Text = "Left press";
                RPTrans(5, 0);
                LeftWeight = true;
                RightWeight = false;
                NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(Application.StartupPath + "\\Audio\\족저압_왼쪽.mp3"));
                stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
                output = new NAudio.Wave.DirectSoundOut();
                output.Init(stream);
                output.Play();
            }
            else
            {
                lblStatus.Text = "Right press";
                RPTrans(-5, 0);
                LeftWeight = false;
                RightWeight = true;
                NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(Application.StartupPath + "\\Audio\\족저압_오른쪽.mp3"));
                stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
                output = new NAudio.Wave.DirectSoundOut();
                output.Init(stream);
                output.Play();
            }
        }

        private void ArmPortConnect()
        {

        }

        private void btn상지운동_Click(object sender, EventArgs e)
        {

            

            int strL = 0, strR = 0;

            if (radLLight.Checked) strL = 1;
            else if (radLNormal.Checked) strL = 2;
            else if (radLHeavy.Checked) strL = 3;

            if (radRLight.Checked) strR = 1;
            else if (radRNormal.Checked) strR = 2;
            else if (radRHeavy.Checked) strR = 3;

            string text = strL.ToString() + "," + strR.ToString() + "\n";

            if (!serialArm.IsOpen)
            {
                lblStatus.Text = "상체 운동 포트가 닫혀있습니다.";
                return;
            }
            try
            {
                serialArm.Write(text);
                lblStatus.Text = "상체 운동 준비 완료";
                lblStatus.Text = "Elbow Exercise - 5 time left";
                clientStream1.WriteString("ElbowModeOn");
                ElbowModeReachdFlag = false;
                NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(Application.StartupPath + "\\Audio\\시작_상체운동.mp3"));
                stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
                output = new NAudio.Wave.DirectSoundOut();
                output.Init(stream);
                output.Play();
            }
            catch
            {
                lblStatus.Text = "오류가 발생했습니다";
            }
            

        }

        private void comboArm_MouseDown(object sender, MouseEventArgs e)
        {
            comboArm.Items.Clear();
            comboArm.Items.AddRange(SerialPort.GetPortNames());
        }

        private void chkConnect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkConnect.Checked)
                {
                    bool isConnected = Sport.OpenPorts(serialArm, comboArm.Text);
                    lblStatus.Text = "포트를 열었습니다.";
                    tmrArm.Enabled = true;
                    if (!isConnected) lblStatus.Text = "포트를 열지 못했습니다.";
                }
                else
                {
                    Sport.ClosePorts(serialArm);
                    lblStatus.Text = "포트를 닫았습니다.";
                    tmrArm.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Error occurred.");
            }
        }

        private void serialArm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {         
            if (serialArm.IsOpen)
            {
                try
                {
                    rxBuffer = serialArm.ReadLine();
                }
                catch
                {
                    
                }                
            }
        }

        private void tmrArm_Tick(object sender, EventArgs e)
        {
            if (rxBuffer != "")
            {
                try
                {
                    
                    string txtRaw = rxBuffer;
                    //lblPsdL.Text = txtRaw;
                    int psdL = 0, psdR = 0;
                    string[] proto = txtRaw.Split(',');
                    psdL = Convert.ToInt32(proto[0]);
                    psdR = Convert.ToInt32(proto[1]);
                    
                    lblPsdL.Text = proto[0];
                    lblPsdR.Text = proto[1];
                }
                catch { }
            }
            
        }

        private void lblPsdL_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPsdR_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn일시정지_Click(object sender, EventArgs e)
        {
            //process.CloseMainWindow();

            //Thread.Sleep(1000);
            while (process.HasExited == false)
                process.Kill();
        }

        private void btn하지운동_Click(object sender, EventArgs e)
        {
            clientStream1.WriteString("SitDown");
            lblStatus.Text = "Sit Down - 5 time left";
            UpFlag = false;
            /*NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(Application.StartupPath + "\\Audio\\시작_하체운동.mp3"));
            stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(stream);
            output.Play();*/
        }

        private void btn긴급종료_Click(object sender, EventArgs e)
        {
            //이부분은 명인이에게
            MMCLib.v_move_stop(0);
            MMCLib.v_move_stop(1);
            MMCLib.v_move_stop(2);
            MMCLib.v_move_stop(3);
            Thread.Sleep(50);
            MMCLib.set_amp_enable(0, 0);
            MMCLib.set_amp_enable(1, 0);
            MMCLib.set_amp_enable(2, 0);
            MMCLib.set_amp_enable(3, 0);
        }

        private void btnM0ccw_MouseDown(object sender, MouseEventArgs e)
        {
            long[] addr = { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
            short err = MMCLib.mmc_initx(4, addr);  //초기화
            MMCLib.set_amp_enable(0, 1);        //Amp on
            MMCLib.set_amp_enable(1, 1);
            MMCLib.set_amp_enable(2, 1);
            MMCLib.set_amp_enable(3, 1);
            MMCLib.v_move(0, 10000.0, 200);
        }

        private void btnM0ccw_MouseUp(object sender, MouseEventArgs e)
        {
            MMCLib.v_move_stop(0);
        }

        private void btnM1ccw_MouseDown(object sender, MouseEventArgs e)
        {
            long[] addr = { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
            short err = MMCLib.mmc_initx(4, addr);  //초기화
            MMCLib.set_amp_enable(0, 1);        //Amp on
            MMCLib.set_amp_enable(1, 1);
            MMCLib.set_amp_enable(2, 1);
            MMCLib.set_amp_enable(3, 1);
            MMCLib.v_move(1, 10000.0, 200);
        }

        private void btnM1ccw_MouseUp(object sender, MouseEventArgs e)
        {
            MMCLib.v_move_stop(1);
        }

        private void btnM2ccw_MouseDown(object sender, MouseEventArgs e)
        {
            long[] addr = { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
            short err = MMCLib.mmc_initx(4, addr);  //초기화
            MMCLib.set_amp_enable(0, 1);        //Amp on
            MMCLib.set_amp_enable(1, 1);
            MMCLib.set_amp_enable(2, 1);
            MMCLib.set_amp_enable(3, 1);
            MMCLib.v_move(2, 10000.0, 200);
        }

        private void btnM2ccw_MouseUp(object sender, MouseEventArgs e)
        {
            MMCLib.v_move_stop(2);
        }

        private void btnM3ccw_MouseDown(object sender, MouseEventArgs e)
        {
            long[] addr = { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
            short err = MMCLib.mmc_initx(4, addr);  //초기화
            MMCLib.set_amp_enable(0, 1);        //Amp on
            MMCLib.set_amp_enable(1, 1);
            MMCLib.set_amp_enable(2, 1);
            MMCLib.set_amp_enable(3, 1);
            MMCLib.v_move(3, 10000.0, 200);
        }

        private void btnM3ccw_MouseUp(object sender, MouseEventArgs e)
        {
            MMCLib.v_move_stop(3);
        }

        private void btnM0cw_MouseDown(object sender, MouseEventArgs e)
        {
            long[] addr = { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
            short err = MMCLib.mmc_initx(4, addr);  //초기화
            MMCLib.set_amp_enable(0, 1);        //Amp on
            MMCLib.set_amp_enable(1, 1);
            MMCLib.set_amp_enable(2, 1);
            MMCLib.set_amp_enable(3, 1);
            MMCLib.v_move(0, -10000.0, 200);
        }

        private void btnM0cw_MouseUp(object sender, MouseEventArgs e)
        {
            MMCLib.v_move_stop(0);
        }

        private void btnM1cw_MouseDown(object sender, MouseEventArgs e)
        {
            long[] addr = { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
            short err = MMCLib.mmc_initx(4, addr);  //초기화
            MMCLib.set_amp_enable(0, 1);        //Amp on
            MMCLib.set_amp_enable(1, 1);
            MMCLib.set_amp_enable(2, 1);
            MMCLib.set_amp_enable(3, 1);
            MMCLib.v_move(1, -10000.0, 200);
        }

        private void btnM1cw_MouseUp(object sender, MouseEventArgs e)
        {
            MMCLib.v_move_stop(1);
        }

        private void btnM2cw_MouseDown(object sender, MouseEventArgs e)
        {
            long[] addr = { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
            short err = MMCLib.mmc_initx(4, addr);  //초기화
            MMCLib.set_amp_enable(0, 1);        //Amp on
            MMCLib.set_amp_enable(1, 1);
            MMCLib.set_amp_enable(2, 1);
            MMCLib.set_amp_enable(3, 1);
            MMCLib.v_move(2, -10000.0, 200);
        }

        private void btnM2cw_MouseUp(object sender, MouseEventArgs e)
        {
            MMCLib.v_move_stop(2);
        }

        private void btnM3cw_MouseDown(object sender, MouseEventArgs e)
        {
            long[] addr = { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
            short err = MMCLib.mmc_initx(4, addr);  //초기화
            MMCLib.set_amp_enable(0, 1);        //Amp on
            MMCLib.set_amp_enable(1, 1);
            MMCLib.set_amp_enable(2, 1);
            MMCLib.set_amp_enable(3, 1);
            MMCLib.v_move(3, -10000.0, 200);
        }

        private void btnM3cw_MouseUp(object sender, MouseEventArgs e)
        {
            MMCLib.v_move_stop(3);
        }

        private void btnM0Set_Click(object sender, EventArgs e)
        {
            MMCLib.set_position(0, 0.0);
        }

        private void btnM1Set_Click(object sender, EventArgs e)
        {
            MMCLib.set_position(1, 0.0);
        }

        private void btnM2Set_Click(object sender, EventArgs e)
        {
            MMCLib.set_position(2, 0.0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                chkHomm.Text = dataFromServer;
            }           
            skicount++;
        }

        private void btnM3Set_Click(object sender, EventArgs e)
        {
            MMCLib.set_position(3, 0.0);
        }

        private void btn코치모드_Click(object sender, EventArgs e)
        {
            try
            {
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ".\nCheck if Container.exe is placed next to Child.exe.");
            }
        }

        private void btn스키모드_Click(object sender, EventArgs e)
        {
            try
            {
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ".\nCheck if Container.exe is placed next to Child.exe.");
            }
        }
        #endregion

        #region KinectFunction

        void KinectSensors_StatusChanged(object sender, StatusChangedEventArgs e)
        {
        }

        void kSensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {

            using (var frame = e.OpenSkeletonFrame())
            {
                try
                {
                    if (frame != null)
                    {
                        Graphics g = pbStream.CreateGraphics();
                        var skeletons = new Skeleton[frame.SkeletonArrayLength];
                        frame.CopySkeletonDataTo(skeletons);

                        var TrackedSkeleton = skeletons.FirstOrDefault(s => s.TrackingState == SkeletonTrackingState.Tracked);
                        if (TrackedSkeleton != null)
                        {
                            g.FillRectangle(Brushes.Black, 0, 0, pbStream.Width, pbStream.Height);
                            foreach (Skeleton skel in skeletons) this.DrawBonesAndJoints(skel, g);
                            
                            var ShoulderCenter = TrackedSkeleton.Joints[JointType.ShoulderCenter].Position;
                            var ShoulderRight = TrackedSkeleton.Joints[JointType.ShoulderRight].Position;
                            var ElbowRight = TrackedSkeleton.Joints[JointType.ElbowRight].Position;
                            var WristRight = TrackedSkeleton.Joints[JointType.WristRight].Position;
                            var ShoulderLeft = TrackedSkeleton.Joints[JointType.ShoulderLeft].Position;
                            var ElbowLeft = TrackedSkeleton.Joints[JointType.ElbowLeft].Position;
                            var WristLeft = TrackedSkeleton.Joints[JointType.WristLeft].Position;
                            //for reaction test
                            var KneeLeft = TrackedSkeleton.Joints[JointType.KneeLeft].Position;
                            var KneeRight = TrackedSkeleton.Joints[JointType.KneeRight].Position;
                            var AnkleLeft = TrackedSkeleton.Joints[JointType.AnkleLeft].Position;
                            var AnkleRight = TrackedSkeleton.Joints[JointType.AnkleRight].Position;
                            var HipLeft = TrackedSkeleton.Joints[JointType.HipLeft].Position;
                            var HipRight = TrackedSkeleton.Joints[JointType.HipRight].Position;
                            //for guideline
                            var Spine = TrackedSkeleton.Joints[JointType.Spine].Position;


                            var coordinateMapper = new CoordinateMapper(kSensor);
                            var ShoulderCenterPoint = coordinateMapper.MapSkeletonPointToColorPoint(ShoulderCenter, ColorImageFormat.InfraredResolution640x480Fps30);
                            var ShoulderRightPoint = coordinateMapper.MapSkeletonPointToColorPoint(ShoulderRight, ColorImageFormat.InfraredResolution640x480Fps30);
                            var ElbowRightPoint = coordinateMapper.MapSkeletonPointToColorPoint(ElbowRight, ColorImageFormat.InfraredResolution640x480Fps30);
                            var WristRightPoint = coordinateMapper.MapSkeletonPointToColorPoint(WristRight, ColorImageFormat.InfraredResolution640x480Fps30);
                            var ShoulderLeftPoint = coordinateMapper.MapSkeletonPointToColorPoint(ShoulderLeft, ColorImageFormat.InfraredResolution640x480Fps30);
                            var ElbowLeftPoint = coordinateMapper.MapSkeletonPointToColorPoint(ElbowLeft, ColorImageFormat.InfraredResolution640x480Fps30);
                            var WristLeftPoint = coordinateMapper.MapSkeletonPointToColorPoint(WristLeft, ColorImageFormat.InfraredResolution640x480Fps30);
                            //for reaction test
                            var KneeLeftPoint = coordinateMapper.MapSkeletonPointToColorPoint(KneeLeft, ColorImageFormat.InfraredResolution640x480Fps30);
                            var KneeRightPoint = coordinateMapper.MapSkeletonPointToColorPoint(KneeRight, ColorImageFormat.InfraredResolution640x480Fps30);
                            var AnkleLeftPoint = coordinateMapper.MapSkeletonPointToColorPoint(AnkleLeft, ColorImageFormat.InfraredResolution640x480Fps30);
                            var AnkleRightPoint = coordinateMapper.MapSkeletonPointToColorPoint(AnkleRight, ColorImageFormat.InfraredResolution640x480Fps30);
                            var HipLeftPoint = coordinateMapper.MapSkeletonPointToColorPoint(HipLeft, ColorImageFormat.InfraredResolution640x480Fps30);
                            var HipRightPoint = coordinateMapper.MapSkeletonPointToColorPoint(HipRight, ColorImageFormat.InfraredResolution640x480Fps30);
                            //for guideline
                            var SpinePoint = coordinateMapper.MapSkeletonPointToColorPoint(Spine, ColorImageFormat.InfraredResolution640x480Fps30);


                            Center_Right = Math.Atan2((double)(ShoulderRightPoint.Y - ShoulderCenterPoint.Y), (double)(ShoulderRightPoint.X - ShoulderCenterPoint.X));
                            Right_Elbow_R = Math.Atan2((double)(ElbowRightPoint.Y - ShoulderRightPoint.Y), (double)(ElbowRightPoint.X - ShoulderRightPoint.X));
                            Elbow_Wrist_R = Math.Atan2((double)(WristRightPoint.Y - ElbowRightPoint.Y), (double)(WristRightPoint.X - ElbowRightPoint.X));

                            Center_Left = Math.Atan2((double)(ShoulderCenterPoint.Y - ShoulderLeftPoint.Y), (double)(ShoulderCenterPoint.X - ShoulderLeftPoint.X));
                            Left_Elbow_L = Math.Atan2((double)(ShoulderLeftPoint.Y - ElbowLeftPoint.Y), (double)(ShoulderLeftPoint.X - ElbowLeftPoint.X));
                            Elbow_Wrist_L = Math.Atan2((double)(ElbowLeftPoint.Y - WristLeftPoint.Y), (double)(ElbowLeftPoint.X - WristLeftPoint.X));

                            //for reaction test
                            RightLegUp = Math.Atan2((double)(KneeRightPoint.Y - HipRightPoint.Y), (double)(KneeRightPoint.X - HipRightPoint.X));
                            LeftLegUp = Math.Atan2((double)(KneeLeftPoint.Y - HipLeftPoint.Y), (double)(KneeLeftPoint.X - HipLeftPoint.X));
                            RightLegDown = Math.Atan2((double)(AnkleRightPoint.Y - KneeRightPoint.Y), (double)(AnkleRightPoint.X - KneeRightPoint.X));
                            LeftLegDown = Math.Atan2((double)(AnkleLeftPoint.Y - KneeLeftPoint.Y), (double)(AnkleLeftPoint.X - KneeLeftPoint.X));
                            CenterSpine = Math.Atan2((double)(SpinePoint.Y - ShoulderCenterPoint.Y), (double)(SpinePoint.X - ShoulderCenterPoint.X));


                            // fixguidelineflag
                            if (!CenterfixedFlag) CenterSpineContainer = CenterSpine;
                            //20 degree
                            //g.DrawLine(new Pen(Brushes.Magenta), (float)(SpinePoint.X - 200 * Math.Cos(CenterSpineContainer + 20 * Math.PI / 180)), (float)(SpinePoint.Y - 200 * Math.Sin(CenterSpineContainer + 20 * Math.PI / 180)), (float)(SpinePoint.X + 100 * Math.Cos(CenterSpineContainer + 20 * Math.PI / 180)), (float)(SpinePoint.Y + 100 * Math.Sin(CenterSpineContainer + 20 * Math.PI / 180)));
                            //g.DrawLine(new Pen(Brushes.Magenta), (float)(SpinePoint.X - 200 * Math.Cos(CenterSpineContainer - 20 * Math.PI / 180)), (float)(SpinePoint.Y - 200 * Math.Sin(CenterSpineContainer - 20 * Math.PI / 180)), (float)(SpinePoint.X + 100 * Math.Cos(CenterSpineContainer - 20 * Math.PI / 180)), (float)(SpinePoint.Y + 100 * Math.Sin(CenterSpineContainer - 20 * Math.PI / 180)));

                            /*if (CenterSpineContainer < CenterSpine - 20 * Math.PI / 180 || CenterSpineContainer > CenterSpine + 20 * Math.PI / 180)
                            {
                                lblStatus.Text = "you need to fix center";
                            }*/
                            /*if(CenterSpine - CenterSpineFixed > 20 * Math.PI/180 || CenterSpine - CenterSpineFixed < - 20 * Math.PI / 180)
                            {
                                lblStatus.Text = "you need to fix center";
                            }*/


                            //g.DrawLine(new Pen(Brushes.MediumSlateBlue), (float)SpinePoint.X + 40, SpinePoint.Y - 40 * (float)(CenterSpine-0.5), (float)SpinePoint.X - 20, SpinePoint.Y + 20 * (float)(CenterSpine-0.5));

                            //lblRightPosition.Text = Convert.ToString((RightLegUp- RightLegDown) * 180 / Math.PI);//Convert.ToString((Right_Elbow_R - Center_Right) * 180 / Math.PI);
                            //lblLeftPosition.Text = Convert.ToString((LeftLegUp - LeftLegDown) * 180 / Math.PI);
                            if ((Right_Elbow_R - Center_Right) * 180 / Math.PI < -35 && !RightHandReachdFlag)
                            {
                                clientStream1.WriteString("RightHandReached");
                                RightHandReachdFlag = true;
                                RightHandCount++;
                                if (RightHandCount < 5)
                                {
                                    lblStatus.Text = "Right Hand up - " + Convert.ToString(5 - RightHandCount) + " time left";                                                                        
                                    
                                }
                                else
                                {
                                    //RightHandCount = 0;
                                    RightWeight = false;
                                    ExerciseRightFlageStart = false;
                                    //RPTrans(0, 0);
                                    Thread.Sleep(1000);
                                    lblStatus.Text = "Elbow Exercise - 5 time left";
                                    clientStream1.WriteString("ElbowModeOn");
                                    ElbowModeReachdFlag = false;
                                }
                            }
                            else if ((Center_Left - Left_Elbow_L) * 180 / Math.PI < -35 && !LeftHandReachdFlag)
                            {
                                clientStream1.WriteString("LeftHandReached");
                                LeftHandReachdFlag = true;
                                LeftHandCount++;
                                if (LeftHandCount < 5)
                                {
                                    lblStatus.Text = "Left Hand up - " + Convert.ToString(5 - LeftHandCount) + " time left";
                                }
                                else
                                {

                                    LeftWeight = false;
                                    ExerciseLeftFlageStart = false;
                                    //RPTrans(0, 0);
                                    Thread.Sleep(1000);
                                    lblStatus.Text = "Elbow Exercise - 5 time left";
                                    clientStream1.WriteString("ElbowModeOn");
                                    ElbowModeReachdFlag = false;

                                }
                            }
                            else if (Math.Abs(RightLegDown - LeftLegDown) * 180 / Math.PI > 30 && !RightLegReachdFlag)
                            {
                                clientStream1.WriteString("RightLegReached");
                                RightLegReachdFlag = true;
                                RightLegCount++;
                            }
                            else if (Math.Abs(RightLegDown - LeftLegDown) * 180 / Math.PI > 30 && !LeftLegReachdFlag)
                            {
                                clientStream1.WriteString("LeftLegReached");
                                LeftLegReachdFlag = true;
                                LeftLegCount++;
                            }
                            else if ((Right_Elbow_R - Center_Right) * 180 / Math.PI > 20 && RightLegReachdFlag && ExerciseRightFlageStart)
                            {
                                clientStream1.WriteString("HandRight");
                                RightHandReachdFlag = false;
                            }
                            else if ((Center_Left - Left_Elbow_L) * 180 / Math.PI > 20 && LeftLegReachdFlag && ExerciseLeftFlageStart)
                            {
                                clientStream1.WriteString("HandLeft");
                                LeftHandReachdFlag = false;
                            }
                            //--------------------------------------------------------------------Elbow-------------------------------------------------------------------
                            //elbow mode reachedflag
                            else if ((Right_Elbow_R - Center_Right) * 180 / Math.PI < -35 && (Elbow_Wrist_R - Right_Elbow_R) * 180 / Math.PI < -30 &&
                                (Center_Left - Left_Elbow_L) * 180 / Math.PI < -35 && (Left_Elbow_L - Elbow_Wrist_L) * 180 / Math.PI < -30 && !ElbowModeReachdFlag && !ElbowExModeFlag)
                            {
                                ElbowExModeFlag = true;
                                clientStream1.WriteString("ElbowDown");
                            }
                            //elbowdown
                            else if ((Right_Elbow_R - Center_Right) * 180 / Math.PI < 10 && (Elbow_Wrist_R - Right_Elbow_R) * 180 / Math.PI < -80 &&
                                (Center_Left - Left_Elbow_L) * 180 / Math.PI < 10 && (Left_Elbow_L - Elbow_Wrist_L) * 180 / Math.PI < -80 && ElbowExModeFlag)
                            {
                                ElbowExModeFlag = false;
                                clientStream1.WriteString("ElbowUp");
                                ElbowCount++;
                                if (ElbowCount < 5)
                                {
                                    lblStatus.Text = "Elbow Reached - " + Convert.ToString(5 - ElbowCount) + " time left";
                                    switch (5 - RightHandCount)
                                    {
                                        case 1:
                                            NAudio.Wave.WaveStream pcm1 = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(Application.StartupPath + "\\Audio\\1회남음.mp3"));
                                            stream = new NAudio.Wave.BlockAlignReductionStream(pcm1);
                                            output = new NAudio.Wave.DirectSoundOut();
                                            output.Init(stream);
                                            output.Play();
                                            break;
                                        case 2:
                                            NAudio.Wave.WaveStream pcm2 = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(Application.StartupPath + "\\Audio\\1회남음.mp3"));
                                            stream = new NAudio.Wave.BlockAlignReductionStream(pcm2);
                                            output = new NAudio.Wave.DirectSoundOut();
                                            output.Init(stream);
                                            output.Play();
                                            break;
                                        case 3:
                                            NAudio.Wave.WaveStream pcm3 = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(Application.StartupPath + "\\Audio\\1회남음.mp3"));
                                            stream = new NAudio.Wave.BlockAlignReductionStream(pcm3);
                                            output = new NAudio.Wave.DirectSoundOut();
                                            output.Init(stream);
                                            output.Play();
                                            break;
                                        case 4:
                                            NAudio.Wave.WaveStream pcm4 = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(Application.StartupPath + "\\Audio\\1회남음.mp3"));
                                            stream = new NAudio.Wave.BlockAlignReductionStream(pcm4);
                                            output = new NAudio.Wave.DirectSoundOut();
                                            output.Init(stream);
                                            output.Play();
                                            break;
                                        default:

                                            break;
                                    }
                                }
                                else
                                {
                                    Thread.Sleep(1000);
                                    ElbowCount = 0;
                                    lblStatus.Text = "Exercise Done";
                                    clientStream1.WriteString("ElbowModeOff");
                                    RPTrans(0, 0);
                                }
                            }
                            //-------------------------------------------------stand up down-----------------------------------------------------------
                            //for reaction test
                            if ((RightLegUp - RightLegDown) * 180 / Math.PI < -65 && (LeftLegUp - LeftLegDown) * 180 / Math.PI > 65 && !UpFlag)
                            {
                                UpFlag = true;
                                clientStream1.WriteString("StandUp");
                                DownFlag = false;
                            }
                            else if ((RightLegUp - RightLegDown) * 180 / Math.PI > -10 && (LeftLegUp - LeftLegDown) * 180 / Math.PI < 10 && !DownFlag)
                            {
                                
                                DownFlag = true;
                                UpFlag = false;
                                UpDownCount++;
                                if (UpDownCount < 5)
                                {
                                    clientStream1.WriteString("SitDown");
                                    lblStatus.Text = "Sit Down - " + Convert.ToString(5 - UpDownCount) + " time left";
                                    switch (5 - RightHandCount)
                                    {
                                        case 1:
                                            NAudio.Wave.WaveStream pcm1 = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(Application.StartupPath + "\\Audio\\1회남음.mp3"));
                                            stream = new NAudio.Wave.BlockAlignReductionStream(pcm1);
                                            output = new NAudio.Wave.DirectSoundOut();
                                            output.Init(stream);
                                            output.Play();
                                            break;
                                        case 2:
                                            NAudio.Wave.WaveStream pcm2 = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(Application.StartupPath + "\\Audio\\1회남음.mp3"));
                                            stream = new NAudio.Wave.BlockAlignReductionStream(pcm2);
                                            output = new NAudio.Wave.DirectSoundOut();
                                            output.Init(stream);
                                            output.Play();
                                            break;
                                        case 3:
                                            NAudio.Wave.WaveStream pcm3 = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(Application.StartupPath + "\\Audio\\1회남음.mp3"));
                                            stream = new NAudio.Wave.BlockAlignReductionStream(pcm3);
                                            output = new NAudio.Wave.DirectSoundOut();
                                            output.Init(stream);
                                            output.Play();
                                            break;
                                        case 4:
                                            NAudio.Wave.WaveStream pcm4 = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(Application.StartupPath + "\\Audio\\1회남음.mp3"));
                                            stream = new NAudio.Wave.BlockAlignReductionStream(pcm4);
                                            output = new NAudio.Wave.DirectSoundOut();
                                            output.Init(stream);
                                            output.Play();
                                            break;
                                        default:

                                            break;
                                    }
                                }
                                else
                                {
                                    UpDownCount = 0;
                                    UpFlag = true;
                                    lblStatus.Text = "Exercise Done";
                                }
                            }
                            //-------------------------------------------------Standing Yoga-----------------------------------------------------------
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    lblMonitoring.Text = Convert.ToString(CenterSpine) + ',' + Convert.ToString(Right_Elbow_R)
                                    + ',' + Convert.ToString(Left_Elbow_L) + ',' + Convert.ToString(KneeLeft) + ',' + Convert.ToString(AnkleRight);
                                }));
                            }
                            //발꿈치 포인트 무릎이상, 양팔 75도 이상 들기
                            /*if ((CenterSpine - RightLegUp) * 180 / Math.PI < -65 && (LeftLegUp - LeftLegDown) * 180 / Math.PI > 65 && !UpFlag)
                            {
                                UpFlag = true;
                                clientStream1.WriteString("StandUp");
                                DownFlag = false;
                            }
                            else if ((RightLegUp - RightLegDown) * 180 / Math.PI > -10 && (LeftLegUp - LeftLegDown) * 180 / Math.PI < 10 && !DownFlag)
                            {

                                DownFlag = true;
                                UpFlag = false;
                                UpDownCount++;
                                if (UpDownCount < 5)
                                {
                                    clientStream1.WriteString("SitDown");
                                    lblStatus.Text = "Sit Down - " + Convert.ToString(5 - UpDownCount) + " time left";
                                }
                                else
                                {
                                    UpDownCount = 0;
                                    UpFlag = true;
                                    lblStatus.Text = "Exercise Done";
                                }
                            }*/


                        }
                    }
                }
                catch { }
            }
        }



        private Bitmap CreateBitmapFremSensor(ColorImageFrame frame)
        {
            var pixelData = new byte[frame.PixelDataLength];
            frame.CopyPixelDataTo(pixelData);

            return pixelData.ToBitmap(frame.Width, frame.Height);

        }
        private void DrawBonesAndJoints(Skeleton skeleton, Graphics drawingContext)
        {
            // Render Torso
            this.DrawBone(skeleton, drawingContext, JointType.Head, JointType.ShoulderCenter);
            this.DrawBone(skeleton, drawingContext, JointType.ShoulderCenter, JointType.ShoulderLeft);
            this.DrawBone(skeleton, drawingContext, JointType.ShoulderCenter, JointType.ShoulderRight);
            this.DrawBone(skeleton, drawingContext, JointType.ShoulderCenter, JointType.Spine);
            this.DrawBone(skeleton, drawingContext, JointType.Spine, JointType.HipCenter);
            this.DrawBone(skeleton, drawingContext, JointType.HipCenter, JointType.HipLeft);
            this.DrawBone(skeleton, drawingContext, JointType.HipCenter, JointType.HipRight);

            // Left Arm
            this.DrawBone(skeleton, drawingContext, JointType.ShoulderLeft, JointType.ElbowLeft);
            this.DrawBone(skeleton, drawingContext, JointType.ElbowLeft, JointType.WristLeft);
            this.DrawBone(skeleton, drawingContext, JointType.WristLeft, JointType.HandLeft);

            // Right Arm
            this.DrawBone(skeleton, drawingContext, JointType.ShoulderRight, JointType.ElbowRight);
            this.DrawBone(skeleton, drawingContext, JointType.ElbowRight, JointType.WristRight);
            this.DrawBone(skeleton, drawingContext, JointType.WristRight, JointType.HandRight);

            // Left Leg
            this.DrawBone(skeleton, drawingContext, JointType.HipLeft, JointType.KneeLeft);
            this.DrawBone(skeleton, drawingContext, JointType.KneeLeft, JointType.AnkleLeft);
            this.DrawBone(skeleton, drawingContext, JointType.AnkleLeft, JointType.FootLeft);

            // Right Leg
            this.DrawBone(skeleton, drawingContext, JointType.HipRight, JointType.KneeRight);
            this.DrawBone(skeleton, drawingContext, JointType.KneeRight, JointType.AnkleRight);
            this.DrawBone(skeleton, drawingContext, JointType.AnkleRight, JointType.FootRight);

            // Render Joints
            foreach (Joint joint in skeleton.Joints)
            {
                Brush drawBrush = null;

                if (joint.TrackingState == JointTrackingState.Tracked)
                {
                    drawBrush = this.trackedJointBrush;
                }
                else if (joint.TrackingState == JointTrackingState.Inferred)
                {
                    drawBrush = this.inferredJointBrush;
                }

                if (drawBrush != null)
                {
                    drawingContext.DrawCircle(drawBrush, this.SkeletonPointToScreen(joint.Position), 3);
                }
            }
        }
        private void DrawBone(Skeleton skeleton, Graphics drawingContext, JointType jointType0, JointType jointType1)
        {
            Joint joint0 = skeleton.Joints[jointType0];
            Joint joint1 = skeleton.Joints[jointType1];

            // If we can't find either of these joints, exit
            if (joint0.TrackingState == JointTrackingState.NotTracked ||
                joint1.TrackingState == JointTrackingState.NotTracked)
            {
                return;
            }

            // Don't draw if both points are inferred
            if (joint0.TrackingState == JointTrackingState.Inferred &&
                joint1.TrackingState == JointTrackingState.Inferred)
            {
                return;
            }

            // We assume all drawn bones are inferred unless BOTH joints are tracked
            Pen drawPen = this.inferredBonePen;
            if (joint0.TrackingState == JointTrackingState.Tracked && joint1.TrackingState == JointTrackingState.Tracked)
            {
                drawPen = this.trackedBonePen;
            }

            drawingContext.DrawLine(drawPen, this.SkeletonPointToScreen(joint0.Position), this.SkeletonPointToScreen(joint1.Position));
        }
        private Point SkeletonPointToScreen(SkeletonPoint skelpoint)
        {
            // Convert point to depth space.  
            // We are not using depth directly, but we do want the points in our 640x480 output resolution.
            DepthImagePoint depthPoint = this.kSensor.CoordinateMapper.MapSkeletonPointToDepthPoint(skelpoint, DepthImageFormat.Resolution640x480Fps30);
            return new Point(depthPoint.X, depthPoint.Y);
        }

        #endregion

        #region UnityFunction
        private void ActivateUnityWindow()
        {
            SendMessage(unityHWND, WM_ACTIVATE, WA_ACTIVE, IntPtr.Zero);
        }

        private void DeactivateUnityWindow()
        {
            SendMessage(unityHWND, WM_ACTIVATE, WA_INACTIVE, IntPtr.Zero);
        }

        private int WindowEnum(IntPtr hwnd, IntPtr lparam)
        {
            unityHWND = hwnd;
            ActivateUnityWindow();
            return 0;
        }

        private void selectablePanel1_Resize(object sender, EventArgs e)
        {
            MoveWindow(unityHWND, 0, 0, selectablePanel.Width, selectablePanel.Height, true);
            ActivateUnityWindow();
        }


        private void ContainerForm_Activated(object sender, EventArgs e)
        {
            ActivateUnityWindow();
        }

        private void ContainerForm_Deactivate(object sender, EventArgs e)
        {
            DeactivateUnityWindow();
        }


        #endregion

        #region Communication Threadzone
        void Thread_Test1()
        {
            client1 = new NamedPipeClientStream(".", "MyCOMApp1",
               PipeDirection.InOut, PipeOptions.Asynchronous,
               TokenImpersonationLevel.Impersonation);
            //Connect to server
            client1.Connect();
            //Thread.Sleep(20);
            //MessageBox.Show("Thread_1 Connected");
            //Created stream for reading and writing
            clientStream1 = new StreamString(client1);
            if (this.InvokeRequired)
            {
                
            }
            else
            {
                //lblConnection.Text = "Connected!";
            }

        }


        public static double roll = 0;
        public static double pitch = 0;
        public static int skicount = 0;

        void Thread_Test2()
        {
            client2 = new NamedPipeClientStream(".", "MyCOMApp2",
               PipeDirection.InOut, PipeOptions.Asynchronous,
               TokenImpersonationLevel.Impersonation);
            //Connect to server`
            client2.Connect();
            //Thread.Sleep(20);
            //MessageBox.Show("Thread_2 Connected");
            //Created stream for reading and writing
            clientStream2 = new StreamString(client2);
            //Read from Server
            while (!threadend)
            {
                int count = 0;
                dataFromServer = clientStream2.ReadString();
                
                string[] words = dataFromServer.Split(',');
                
                string str1 = words[0];
                string str2 = words[1];
                string str3 = words[2];
                string str4 = words[3];
                if (u)
                {
                    firstyaw = (int)Math.Round(float.Parse(str3));
                    u = false;
                    continue;
                }
                int roll= -(int)Math.Round(float.Parse(str1));
                int pitch = (int)Math.Round(float.Parse(str2));
                int yaw=  90-((int)Math.Round(float.Parse(str3))-firstyaw);
                count= (int)Math.Round(float.Parse(str4));


                if (count < 800)
                {
                    if (skicount > 2)
                    {
                        RPTrans(roll, pitch);
                        MMCLib.start_move(3, ATP(yaw), 80000, 200);
                        skicount = 0;
                    }
                    
                }
                else
                {

                    MMCLib.frames_clear(0);
                    MMCLib.frames_clear(1);
                    MMCLib.frames_clear(2);
                    MMCLib.frames_clear(3);
                    /*
                    MMCLib.set_stop(0);
                    MMCLib.set_stop(1);
                    MMCLib.set_stop(2);
                    MMCLib.set_stop(3);*/

                }

                
                
                


                /*this.Invoke(new MethodInvoker(delegate ()
                {
                    chkHomm.Text = dataFromServer;

                }));*/
            }
        }




        #endregion

        #region MotorControl

        private double[] getpi(double roll, double pitch)
        {
            double[] pi = new double[3];

            roll = -roll;
            pitch = -pitch;

            int psi_1 = 60;
            int psi_2 = 180;
            int psi_3 = 300;

            double[,] H = new double[3, 1] { {0},
                {0},
                {204} };

            int R_u = 380;
            int R_I = 380;
            int link_1 = 65;
            int link_2 = 200;

            double[,] P1 = new double[3, 1] { { Math.Cos(psi_1 * Math.PI / 180) * R_u },
                { Math.Sin(psi_1 * Math.PI / 180) * R_u },
                { 0 } };
            double[,] P2 = new double[3, 1] { { Math.Cos(psi_2 * Math.PI / 180) * R_u },
                { Math.Sin(psi_2 * Math.PI / 180) * R_u },
                { 0 } };
            double[,] P3 = new double[3, 1] { { Math.Cos(psi_3 * Math.PI / 180) * R_u },
                { Math.Sin(psi_3 * Math.PI / 180) * R_u },
                { 0 } };

            double[,] M1 = new double[3, 1] { { Math.Cos(psi_1 * Math.PI / 180) * R_I },
                { Math.Sin(psi_1 * Math.PI / 180) * R_I },
                { 0 } };
            double[,] M2 = new double[3, 1] { { Math.Cos(psi_2 * Math.PI / 180) * R_I },
                { Math.Sin(psi_2 * Math.PI / 180) * R_I },
                { 0 } };
            double[,] M3 = new double[3, 1] { { Math.Cos(psi_3 * Math.PI / 180) * R_I },
                { Math.Sin(psi_3 * Math.PI / 180) * R_I },
                { 0 } };

            double[,] Rx_roll = new double[3, 3] { { 1, 0, 0 },
                { 0, Math.Cos(roll * Math.PI / 180), -Math.Sin(roll * Math.PI / 180) },
                { 0, Math.Sin(roll * Math.PI / 180), Math.Cos(roll * Math.PI / 180) } };
            double[,] Ry_pitch = new double[3, 3] { {Math.Cos(pitch*Math.PI/180),0,Math.Sin(pitch*Math.PI/180)},
                {0,1,0},
                {-Math.Sin(pitch*Math.PI/180),0,Math.Cos(pitch*Math.PI/180)} };
            double[,] Rbp = new double[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

            multiplying(Rx_roll, Ry_pitch, Rbp, 3, 3, 3, 3);

            double[,] Rz_psi1 = new double[3, 3] { { Math.Cos(psi_1 * Math.PI / 180), -Math.Sin(psi_1 * Math.PI / 180), 0  },
            {Math.Sin(psi_1 * Math.PI / 180), Math.Cos(psi_1 * Math.PI / 180), 0   },
            {0,0,1 } };
            double[,] Rz_psi2 = new double[3, 3] { { Math.Cos(psi_2 * Math.PI / 180), -Math.Sin(psi_2 * Math.PI / 180), 0  },
            {Math.Sin(psi_2 * Math.PI / 180), Math.Cos(psi_2 * Math.PI / 180), 0   },
            {0,0,1 } };
            double[,] Rz_psi3 = new double[3, 3] { { Math.Cos(psi_3 * Math.PI / 180), -Math.Sin(psi_3 * Math.PI / 180), 0  },
            {Math.Sin(psi_3 * Math.PI / 180), Math.Cos(psi_3 * Math.PI / 180), 0   },
            {0,0,1 } };
            double[,] Ry = new double[3, 3] { { Math.Cos(90*Math.PI/180),0, Math.Sin(90 * Math.PI / 180) },
            {0,1,0 },
            {-Math.Sin(90*Math.PI/180),0, Math.Cos(90 * Math.PI / 180) } };

            double[,] Rmb1 = new double[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            double[,] Rmb2 = new double[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            double[,] Rmb3 = new double[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

            multiplying(Rz_psi1, Ry, Rmb1, 3, 3, 3, 3);
            multiplying(Rz_psi2, Ry, Rmb2, 3, 3, 3, 3);
            multiplying(Rz_psi3, Ry, Rmb3, 3, 3, 3, 3);

            double[,] U1_1 = new double[3, 1] { { 0 }, { 0 }, { 0 } };
            double[,] U2_1 = new double[3, 1] { { 0 }, { 0 }, { 0 } };
            double[,] U3_1 = new double[3, 1] { { 0 }, { 0 }, { 0 } };

            multiplying(Rbp, P1, U1_1, 3, 3, 3, 1);
            multiplying(Rbp, P2, U2_1, 3, 3, 3, 1);
            multiplying(Rbp, P3, U3_1, 3, 3, 3, 1);

            double[,] U1_2 = new double[3, 1] { { 0 }, { 0 }, { 0 } };
            double[,] U2_2 = new double[3, 1] { { 0 }, { 0 }, { 0 } };
            double[,] U3_2 = new double[3, 1] { { 0 }, { 0 }, { 0 } };

            addition(H, U1_1, U1_2, 3, 1);
            addition(H, U2_1, U2_2, 3, 1);
            addition(H, U3_1, U3_2, 3, 1);

            double[,] U1 = new double[3, 1] { { 0 }, { 0 }, { 0 } };
            double[,] U2 = new double[3, 1] { { 0 }, { 0 }, { 0 } };
            double[,] U3 = new double[3, 1] { { 0 }, { 0 }, { 0 } };

            submission(U1_2, M1, U1, 3, 1);
            submission(U2_2, M2, U2, 3, 1);
            submission(U3_2, M3, U3, 3, 1);

            double[,] T1 = new double[3, 1] { { 0 }, { 0 }, { 0 } };
            double[,] T2 = new double[3, 1] { { 0 }, { 0 }, { 0 } };
            double[,] T3 = new double[3, 1] { { 0 }, { 0 }, { 0 } };

            multiplying(Rmb1, U1, T1, 3, 3, 3, 1);
            multiplying(Rmb2, U2, T2, 3, 3, 3, 1);
            multiplying(Rmb3, U3, T3, 3, 3, 3, 1);


            double normT1 = norm(T1);
            double normT2 = norm(T2);
            double normT3 = norm(T3);




            double pi1 = Math.Acos((Math.Pow(normT1, 2) + (Math.Pow(link_1, 2) - Math.Pow(link_2, 2))) / (2 * (normT1) * link_1)) * 180 / Math.PI;
            double pi2 = Math.Acos((Math.Pow(normT2, 2) + (Math.Pow(link_1, 2) - Math.Pow(link_2, 2))) / (2 * (normT2) * link_1)) * 180 / Math.PI;
            double pi3 = Math.Acos((Math.Pow(normT3, 2) + (Math.Pow(link_1, 2) - Math.Pow(link_2, 2))) / (2 * (normT3) * link_1)) * 180 / Math.PI;

            pi[0] = pi1;
            pi[1] = pi2;
            pi[2] = pi3;

            return pi;
        }
        private double norm(double[,] m)
        {
            double normed = Math.Sqrt(Math.Pow(m[0, 0], 2) + Math.Pow(m[1, 0], 2) + Math.Pow(m[2, 0], 2));
            return normed;
        }
        private void multiplying(double[,] m1, double[,] m2, double[,] mult, int rowFirst, int columnFirst, int rowSecond, int columnSecond)
        {

            for (int i = 0; i < rowFirst; i++)
            {
                for (int j = 0; j < columnSecond; j++)
                {
                    for (int k = 0; k < columnFirst; k++)
                    {
                        mult[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
        }
        private void addition(double[,] m1, double[,] m2, double[,] add, int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    add[i, j] = m1[i, j] + m2[i, j];
                }
            }
        }
        private void submission(double[,] m1, double[,] m2, double[,] sub, int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    sub[i, j] = m1[i, j] - m2[i, j];
                }
            }
        }


        private double ATP(double angle)
        {
            double pose = 2867.2 * (angle) - 258048;
            return pose;
        }
        private double PTA(double pos)
        {
            double angle = (3.48772 / 10000) * pos + 90;
            return angle;
        }

        private void RPTrans(double R, double P)
        {
            double roll_past = roll;
            double pitch_past = pitch;
            double[] A = getpi(R, P);
            if (double.IsNaN(A[0]) || double.IsNaN(A[1]) || double.IsNaN(A[2]))
            {
                A = getpi(roll_past, pitch_past);
                RPMove(A[0], A[1], A[2]);
            }
            else
            {
                RPMove(A[0], A[1], A[2]);
                roll = R;
                pitch = P;
            }
        }

        private void RPMove(double angle0, double angle1, double angle2)
        {
            //long[] addr = { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
            short[] axes = new short[3] { 0, 1, 2 };                            //회전할 축 설정
            short[] accel = new short[3] { 200, 200, 200 };                     //accel값이 높아질수록 스므스하게 감속 (값이 너무 작으면 감속기 혹은 링크부분에 충격이 클 수 있음)
            double[] pos = new double[3] { ATP(angle0), ATP(angle1), ATP(angle2) };      //각 축의 위치값 (이후에 각도와 모터 위치값의 상관관계를 찾아 define해주면 됨 -> Window에서는 각도만 입력해서 움직일 수 있도록)
            double[] vel = new double[3] { 40000.0, 40000.0, 40000.0 };
            //short err = MMCLib.mmc_initx(4, addr);  //초기화
            //MMCLib.set_amp_enable(0, 1);        //Amp on
            //MMCLib.set_amp_enable(1, 1);
           // MMCLib.set_amp_enable(2, 1);
            //MMCLib.set_amp_enable(3, 1);
            // MMCLib.mmcDelay(50);
            //MMCLib.set_coordinate_direction(0, 1);                              //각 축의 방향 => 0 : CW,    1 : CCW
           // MMCLib.set_coordinate_direction(1, 1);
            //MMCLib.set_coordinate_direction(2, 1);                              //각 축의 방향 => 0 : CW,    1 : CCW
            //MMCLib.set_coordinate_direction(3, 1);
            MMCLib.start_move_all(3, axes, pos, vel, accel);
        }

        private void initMotor()
        {
            MMCLib.mmcDelay(10);
            long[] addr = new long[4] { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
            short e = MMCLib.mmc_initx(4, addr);

            MMCLib.set_amp_enable(0, 1);
            MMCLib.set_amp_enable(1, 1);
            MMCLib.set_amp_enable(2, 1);
            MMCLib.set_amp_enable(3, 1);
            MMCLib.set_coordinate_direction(0, 1);                              //각 축의 방향 => 0 : CW,    1 : CCW
            MMCLib.set_coordinate_direction(1, 1);
            MMCLib.set_coordinate_direction(2, 1);
            MMCLib.set_coordinate_direction(3, 1);
        }

        private void btnStopEmergency_Click(object sender, EventArgs e)
        {
            MMCLib.set_e_stop(0);
        }

        private void turnOffMotor()
        {
            //long[] addr = new long[4] { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
            short e = MMCLib.mmc_initx(4, addr);
            MMCLib.set_amp_enable(0, 0);
            MMCLib.set_amp_enable(1, 0);
            MMCLib.set_amp_enable(2, 0);
            MMCLib.set_amp_enable(3, 0);        //Yawing Axis
        }



        private void btnOffMotors_Click(object sender, EventArgs e)
        {

        }



        private void initHomming()
        {
            if (chkHomm.Checked)
            {
                MotorInitFlag = true;
                double pos0 = 59424.0;
                double pos1 = 42310.0;
                double pos2 = 45826.0;

                MMCLib.mmcDelay(50);
                long[] addr = { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
                short[] axes = new short[3] { 0, 1, 2 };                            //회전할 축 설정
                short[] accel = new short[3] { 200, 200, 200 };                     //accel값이 높아질수록 스므스하게 감속 (값이 너무 작으면 감속기 혹은 링크부분에 충격이 클 수 있음)
                double[] pos = new double[3] { pos0, pos1, pos2 };      //각 축의 위치값 (이후에 각도와 모터 위치값의 상관관계를 찾아 define해주면 됨 -> Window에서는 각도만 입력해서 움직일 수 있도록)
                double[] vel = new double[3] { 60000.0, 60000.0, 60000.0 };
                short err = MMCLib.mmc_initx(4, addr);  //초기화
                MMCLib.set_amp_enable(0, 1);        //Amp on
                MMCLib.set_amp_enable(1, 1);
                MMCLib.set_amp_enable(2, 1);
                MMCLib.set_amp_enable(3, 1);
                MMCLib.mmcDelay(50);
                MMCLib.set_coordinate_direction(0, 1);                              //각 축의 방향 => 0 : CW,    1 : CCW
                MMCLib.set_coordinate_direction(1, 1);
                MMCLib.set_coordinate_direction(2, 1);
                MMCLib.set_coordinate_direction(3, 1);
                MMCLib.mmcDelay(50);
                MMCLib.set_position(0, 0.0);                //각 축의 Encoder 값 초기화
                MMCLib.set_position(1, 0.0);
                MMCLib.set_position(2, 0.0);
                MMCLib.set_position(3, 0.0);
                int homesen0 = MMCLib.home_switch(0);
                int homesen1 = MMCLib.home_switch(1);
                int homesen2 = MMCLib.home_switch(2);
                MMCLib.v_move(0, 60000.0, 200);
                while (homesen0 == 0)
                {
                    homesen0 = MMCLib.home_switch(0);
                    MMCLib.mmcDelay(50);
                }
                MMCLib.v_move_stop(0);
                MMCLib.v_move(1, 60000.0, 200);
                while (homesen1 == 0)
                {
                    homesen1 = MMCLib.home_switch(1);
                    MMCLib.mmcDelay(50);
                }
                MMCLib.v_move_stop(1);
                MMCLib.v_move(2, 60000.0, 200);
                while (homesen2 == 0)
                {
                    homesen2 = MMCLib.home_switch(2);
                    MMCLib.mmcDelay(50);
                }
                MMCLib.v_move_stop(2);
                MMCLib.wait_for_done(2);
                MMCLib.mmcDelay(50);
                MMCLib.set_position(0, 0.0);
                MMCLib.set_position(1, 0.0);
                MMCLib.set_position(2, 0.0);
                MMCLib.mmcDelay(50);

                MMCLib.move_all(3, axes, pos, vel, accel);
                MMCLib.mmcDelay(50);
                MMCLib.set_position(0, 0.0);
                MMCLib.set_position(1, 0.0);
                MMCLib.set_position(2, 0.0);
                RPMove(77, 77, 77);
            }
            else if (!chkHomm.Checked)
            {
                MMCLib.mmcDelay(50);
                double pos0 = 77;
                double pos1 = 77;
                double pos2 = 77;
                long[] addr = { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
                short[] axes = new short[3] { 0, 1, 2 };                            //회전할 축 설정
                short[] accel = new short[3] { 200, 200, 200 };                     //accel값이 높아질수록 스므스하게 감속 (값이 너무 작으면 감속기 혹은 링크부분에 충격이 클 수 있음)
                double[] pos = new double[3] { ATP(pos0), ATP(pos1), ATP(pos2) };      //각 축의 위치값 (이후에 각도와 모터 위치값의 상관관계를 찾아 define해주면 됨 -> Window에서는 각도만 입력해서 움직일 수 있도록)
                double[] vel = new double[3] { 80000.0, 80000.0, 80000.0 };
                short err = MMCLib.mmc_initx(4, addr);  //초기화
                MMCLib.set_amp_enable(0, 1);        //Amp on
                MMCLib.set_amp_enable(1, 1);
                MMCLib.set_amp_enable(2, 1);
                MMCLib.set_amp_enable(3, 1);
                // MMCLib.mmcDelay(50);
                MMCLib.set_coordinate_direction(0, 1);                              //각 축의 방향 => 0 : CW,    1 : CCW
                MMCLib.set_coordinate_direction(1, 1);
                MMCLib.set_coordinate_direction(2, 1);                              //각 축의 방향 => 0 : CW,    1 : CCW
                MMCLib.set_coordinate_direction(3, 1);
                MMCLib.mmcDelay(50);
                MMCLib.start_move_all(3, axes, pos, vel, accel);
                MMCLib.start_move(3, 0, 8000, 200);
            }
        }






        #endregion

        #region Foot Pressure
        private void comboPort_MouseDown(object sender, MouseEventArgs e)
        {
            comboPort.Items.Clear();
            comboPort.Items.AddRange(SerialPort.GetPortNames());
        }
        private void serialFoot_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int offset = 0;
            while (isFootConnected)
            {
                if (offset >= 48 * 48) break;
                try
                {
                    sensors[offset++] = serialFoot.ReadByte();
                }
                catch { break; }
            }
        }
        private void tmrDraw_Tick(object sender, EventArgs e)
        {
            if (isFootConnected)
            {
                serialFoot.Write("A");
            }
            converting();
            BicubicInterpolation();
            colorjetInterp();
            drawInterp();
        }
        private void converting()
        {
            int k = 0;
            for (int i = 47; i >= 0; i--)
                for (int j = 47; j >= 0; j--)
                    dataOrg[i, j] = Convert.ToDouble(sensors[k++]);
        }
        private void BicubicInterpolation()
        {
            double rowOrg = 48.0; double colOrg = 48.0; double rowTrans = 48.0 * 3.0; double colTrans = 48.0 * 3.0;
            int x1, x2, x3, x4, y1, y2, y3, y4;
            double xx, yy, p, q, v1, v2, v3, v4, v;

            for (int i = 0; i <= rowTrans - 2; i++)
            {
                for (int j = 0; j <= colTrans - 2; j++)
                {
                    xx = (colOrg * j) / colTrans;
                    x2 = (int)Math.Round(xx);

                    x1 = x2 - 1;
                    if (x1 < 0) x1 = 0;

                    x3 = x2 + 1;
                    if (x3 >= colOrg) x3 = (int)Math.Round(colOrg - 1);

                    x4 = x2 + 2;
                    if (x4 >= colOrg) x4 = (int)Math.Round(colOrg - 1);

                    p = xx - x2;

                    yy = (rowOrg * i) / rowTrans;
                    y2 = (int)Math.Round(yy);

                    y1 = y2 - 1;
                    if (y1 < 0) y1 = 0;

                    y3 = y2 + 1;
                    if (y3 >= rowOrg) y3 = (int)Math.Round(rowOrg - 1);

                    y4 = y2 + 2;
                    if (y4 >= rowOrg) y4 = (int)Math.Round(rowOrg - 1);

                    q = yy - y2;

                    v1 = Cubic(dataOrg[y1, x1], dataOrg[y1, x2], dataOrg[y1, x3], dataOrg[y1, x4], p);
                    v2 = Cubic(dataOrg[y2, x1], dataOrg[y2, x2], dataOrg[y2, x3], dataOrg[y2, x4], p);
                    v3 = Cubic(dataOrg[y3, x1], dataOrg[y3, x2], dataOrg[y3, x3], dataOrg[y3, x4], p);
                    v4 = Cubic(dataOrg[y4, x1], dataOrg[y4, x2], dataOrg[y4, x3], dataOrg[y4, x4], p);

                    v = Cubic(v1, v2, v3, v4, q);
                    if (v < 0) v = 0;
                    dataInterp[i, j] = v;
                }
            }
        }
        private void colorjetInterp()
        {
            double pr = 1.0, pg = 1.0, pb = 1.0, min = 3.0, max = 0.0, dx = 0.0;
            FootSensor fs = new FootSensor();
            max = fs.getMax(dataOrg);
            min = fs.getMin(dataOrg);
            dx = max - min;
            if (dx < 15)
            {
                max = 5.0; min = 0.0; dx = 40.0;
            }

            for (int i = 0; i < 48 * 3; i++)
            {
                for (int j = 0; j < 48 * 3; j++)
                {
                    pr = 1.0; pg = 1.0; pb = 1.0;

                    if (dataInterp[i, j] < (min + 0.25 * dx))
                    {
                        pr = 0.0;
                        pg = 4.0 * (dataInterp[i, j] - min) / dx;
                    }

                    else if (dataInterp[i, j] < (min + 0.5 * dx))  //0.4
                    {
                        pr = 0.0;
                        pb = 1.0 + 4.0 * (min + 0.25 * dx - dataInterp[i, j]) / dx;
                    }

                    else if (dataInterp[i, j] < (min + 0.75 * dx))  //0.6
                    {
                        pr = 4.0 * (dataInterp[i, j] - min - 0.5 * dx) / dx;
                        pb = 0.0;
                    }

                    else
                    {
                        pg = 1.0 + 4.0 * (min + 0.75 * dx - dataInterp[i, j]) / dx;
                        pb = 0.0;
                    }


                    rr[i, j] = Convert.ToInt16(255 * pr);
                    gg[i, j] = Convert.ToInt16(255 * pg);
                    bb[i, j] = Convert.ToInt16(255 * pb);

                    if (rr[i, j] <= 0) rr[i, j] = 0;
                    else if (rr[i, j] >= 255) rr[i, j] = 255;

                    if (gg[i, j] <= 0) gg[i, j] = 0;
                    else if (gg[i, j] >= 255) gg[i, j] = 255;

                    if (bb[i, j] <= 0) bb[i, j] = 0;
                    else if (bb[i, j] >= 255) bb[i, j] = 255;

                    if (dataInterp[i, j] < 5)
                    {
                        rr[i, j] = 0; gg[i, j] = 0; bb[i, j] = 0;
                    }
                }
            }
        }
        private void drawInterp()
        {
            const int scaleInterp = 4;
            Bitmap bmapScale = new Bitmap(bmapOrg.Width * scaleInterp, bmapOrg.Height * scaleInterp);

            for (int i = 0; i < bmapOrg.Width - 1; i++)
            {
                for (int j = 0; j < bmapOrg.Height - 1; j++)
                {
                    bmapOrg.SetPixel(j, i, Color.FromArgb(rr[i, j], gg[i, j], bb[i, j]));
                }
            }

            Graphics Gra = Graphics.FromImage(bmapScale);
            Gra.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            Gra.DrawImage(bmapOrg, new Rectangle(System.Drawing.Point.Empty, bmapScale.Size));

            picBicubic.Image = bmapScale;
        }
        private double Cubic(double v1, double v2, double v3, double v4, double d)
        {
            double v, p1, p2, p3, p4;
            p1 = v2;
            p2 = -v1 + v3;
            p3 = 2 * (v1 - v2) + v3 - v4;
            p4 = -v1 + v2 - v3 + v4;
            v = p1 + d * (p2 + d * (p3 + d * p4));
            return v;
        }

        #endregion

        #region GUI Contents
        private void btnFormClose_Click(object sender, EventArgs e)
        {
            MMCLib.set_amp_enable(0, 1);
            MMCLib.set_amp_enable(1, 1);
            MMCLib.set_amp_enable(2, 1);
            MMCLib.set_amp_enable(3, 1);
            double pos0 = 15;
            double pos1 = 15;
            double pos2 = 15;
            long[] addr = { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
            short[] axes = new short[3] { 0, 1, 2 };                            //회전할 축 설정
            short[] accel = new short[3] { 200, 200, 200 };                     //accel값이 높아질수록 스므스하게 감속 (값이 너무 작으면 감속기 혹은 링크부분에 충격이 클 수 있음)
            double[] pos = new double[3] { ATP(pos0), ATP(pos1), ATP(pos2) };      //각 축의 위치값 (이후에 각도와 모터 위치값의 상관관계를 찾아 define해주면 됨 -> Window에서는 각도만 입력해서 움직일 수 있도록)
            double[] vel = new double[3] { 80000.0, 80000.0, 80000.0 };
            short err = MMCLib.mmc_initx(4, addr);  //초기화
            MMCLib.move_all(3, axes, pos, vel, accel);
            MMCLib.set_amp_enable(0, 0);        //Amp on
            MMCLib.set_amp_enable(1, 0);
            MMCLib.set_amp_enable(2, 0);
            MMCLib.set_amp_enable(3, 0);
            this.Close();
        }
        #endregion

        #region SettingForm
        private void btnSetting_Click(object sender, EventArgs e)
        {
        }
        public void ActionSettingForm(string param)
        {
            //listbox.Items.Add(param);

            if (param == "RightHandReachdFlag")
            {
                RightHandReachdFlag = false;
            }
            else if (param == "LeftHandReachdFlag")
            {
                LeftHandReachdFlag = false;
            }
            else if (param == "RightLegReachdFlag")
            {
                RightLegReachdFlag = false;
            }
            else if (param == "LeftLegReachdFlag")
            {
                LeftLegReachdFlag = false;
            }
            else
            {
                clientStream1.WriteString(param);
            }
        }
        #endregion

        #region Sinario
        private void btnStabilize_Click(object sender, EventArgs e)
        {
            //clientStream1.WriteString("CamChange");
        }
        private void btnExercise_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Elbow Exercise - 5 time left";
            clientStream1.WriteString("ElbowModeOn");
            ElbowModeReachdFlag = false;
        }

        private void btnExercise_Hand_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExerciseUpdown_Click(object sender, EventArgs e)
        {

            /*if(cnt%2==0)clientStream1.WriteString("SitDown");
            else clientStream1.WriteString("StandUp");
            cnt++;*/
            
        }

        private void btnExerciseStand_Click(object sender, EventArgs e)
        {
            //fix standing data
            CenterfixedFlag = true;
        }

        #endregion
    }


}
