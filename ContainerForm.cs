using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.IO.Pipes;
using MMCWHPNET;
using System.Security.Principal;
using Microsoft.Kinect;
using Coding4Fun.Kinect.WinForm;
using System.IO.Ports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WinformUnity
{
    /// <summary>
    /// https://docs.unity3d.com/Manual/CommandLineArguments.html
    /// </summary>
    public partial class ContainerForm : Form
    {

        bool timDraw = false, timWait = false, timArm = false, timWaitA = false, timWaitB = false; List<string> LS = new List<string>();
        Log log;
        AzureMobileService AMS;
        bool ModeFlag = false, Coachretry = false, Skiretry = false;
        FootSensor fs = new FootSensor();
        int exerciseCount = 2;
        #region Kinect Declaration
        MediaPlayer.MediaPlayerClass _player = new MediaPlayer.MediaPlayerClass();
        
        ListBox listbox = new ListBox();
        bool elbowSF = true, praiseSF = true, sitSF = true, yogaSF = true;
        bool isFootConnected, LeftTiltFlag, RightTiltFlag, LeftWeight, RightWeight, ExerciseLeftFlageStart = false, ExerciseRightFlageStart = false;
        Bitmap bmapOrg = new Bitmap(48 * 3, 48 * 3);
        Int32 ColorLeftSum = 0, ColorRightSum = 0, timcount = 0, timcountA = 0, timcountB = 0;
        short LeftLegCount = 0, RightLegCount = 0, LeftHandCount = 0, RightHandCount = 0, cnt = 0, ElbowCount = 0, UpDownCount = 0, Yogacount = 0, Suncount = 0;
        bool fixguidelineflag = false; //int firstyaw = 0;
        string rxBuffer = "";

        private KinectSensor kSensor;
        private readonly Brush inferredJointBrush = Brushes.Yellow;
        private readonly Brush trackedJointBrush = new SolidBrush(Color.FromArgb(255, 68, 192, 68));
        private readonly Pen trackedBonePen = new Pen(Brushes.Green, 6);
        private readonly Pen inferredBonePen = new Pen(Brushes.Gray, 1);
        private bool LeftHandReachdFlag = true, RightHandReachdFlag = true, LeftLegReachdFlag = true, RightLegReachdFlag = true, LegReachdFlag = true;
        private bool ElbowModeReachdFlag = false, ElbowDownReachdFlag = false, ElbowExModeFlag = false, UpFlag = false, DownFlag = false,
            CenterfixedFlag = false, threadend = false, Sunflag = false, yogaflag = false, Sunreachflag = false, yogareachflag = false;
        double Center_Right, Right_Elbow_R, Elbow_Wrist_R;
        double Center_Left, Left_Elbow_L, Elbow_Wrist_L, RightLegDown, LeftLegDown, RightLegUp, LeftLegUp, CenterSpine, KneeLeft, AnkleRight;
        #endregion

        #region Unity Declaration
        [DllImport("User32.dll")]
        static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool redraw);

        internal delegate int WindowEnumProc(IntPtr hwnd, IntPtr lparam);
        [DllImport("user32.dll")]
        internal static extern bool EnumChildWindows(IntPtr hwnd, WindowEnumProc func, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int FindWindow(string ClassName, string WindowName);

        //private Process process;
        private IntPtr unityHWND = IntPtr.Zero;

        private const int WM_ACTIVATE = 0x0006;
        private readonly IntPtr WA_ACTIVE = new IntPtr(1);
        private readonly IntPtr WA_INACTIVE = new IntPtr(0);

        //Declaration for Communication
        NamedPipeClientStream client1;
        StreamString clientStream1, clientStream2;
        string dataFromServer = "";

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

        private void borderBtn()
        {
            btn긴급종료.TabStop = false;
            btn긴급종료.FlatStyle = FlatStyle.Flat;
            btn긴급종료.FlatAppearance.BorderSize = 0;

            btn데이터.TabStop = false;
            btn데이터.FlatStyle = FlatStyle.Flat;
            btn데이터.FlatAppearance.BorderSize = 0;


            btn상지운동.TabStop = false;
            btn상지운동.FlatStyle = FlatStyle.Flat;
            btn상지운동.FlatAppearance.BorderSize = 0;

            btnBalancing.TabStop = false;
            btnBalancing.FlatStyle = FlatStyle.Flat;
            btnBalancing.FlatAppearance.BorderSize = 0;

            btn설정.TabStop = false;
            btn설정.FlatStyle = FlatStyle.Flat;
            btn설정.FlatAppearance.BorderSize = 0;

            btn스키모드.TabStop = false;
            btn스키모드.FlatStyle = FlatStyle.Flat;
            btn스키모드.FlatAppearance.BorderSize = 0;

            btn전환.TabStop = false;
            btn전환.FlatStyle = FlatStyle.Flat;
            btn전환.FlatAppearance.BorderSize = 0;

            btn족압측정.TabStop = false;
            btn족압측정.FlatStyle = FlatStyle.Flat;
            btn족압측정.FlatAppearance.BorderSize = 0;

            btn종료.TabStop = false;
            btn종료.FlatStyle = FlatStyle.Flat;
            btn종료.FlatAppearance.BorderSize = 0;

            btn코치모드.TabStop = false;
            btn코치모드.FlatStyle = FlatStyle.Flat;
            btn코치모드.FlatAppearance.BorderSize = 0;

            btn하지운동.TabStop = false;
            btn하지운동.FlatStyle = FlatStyle.Flat;
            btn하지운동.FlatAppearance.BorderSize = 0;
        }

        public ContainerForm(Log PersonalLog, AzureMobileService ams)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(300, 300);
            InitializeComponent();
            borderBtn();
            AMS = ams;
            log = PersonalLog;
            //btn상지운동.Enabled = false;
            //btn하지운동.Enabled = false;

            if (KinectSensor.KinectSensors.Count > 0)
            {
                kSensor = KinectSensor.KinectSensors[0];
                KinectSensor.KinectSensors.StatusChanged += KinectSensors_StatusChanged;
            }
            kSensor.Start();
            kSensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
            kSensor.DepthStream.Enable();
            kSensor.AllFramesReady += kSensor_AllFramesReady;
            kSensor.SkeletonStream.Enable();
            kSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Default;
            
            //ThreadPool.QueueUserWorkItem(Thread_Coach);
            //ThreadPool.QueueUserWorkItem(Thread_VR);
            

        }


        private void btn종료_Click(object sender, EventArgs e)
        {
            
        }
        private void ContainerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //_player = new MediaPlayer.MediaPlayerClass();
                _player.FileName = Application.StartupPath + "\\Audio\\종료_운동.wav";
                _player.Play();

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
                if(kSensor != null)
                {
                    if (kSensor.IsRunning)
                    {
                        kSensor.AllFramesReady -= kSensor_AllFramesReady;
                        kSensor.Dispose();
                    }
                }

                Process[] localByName = Process.GetProcessesByName("Medi_VR");
                if (localByName.Count() >= 1) foreach (Process lo in localByName) lo.Kill();

                Process[] localByName2 = Process.GetProcessesByName("VR_Avatar_2");
                try
                {
                    if (localByName.Count() >= 1) foreach (Process lo in localByName) localByName[1]?.Kill();
                }
                catch
                {
                }
                try
                {
                    if (localByName.Count() >= 1) foreach (Process lo in localByName) localByName[0].Kill();
                }
                catch
                {
                }

                //process.CloseMainWindow();
                Thread.Sleep(1000);
                threadend = true;
                
                if(client1 != null)
                {
                    client1.Close();
                }
                log.Id = Guid.NewGuid().ToString();
                log.date = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss");
                try
                {
                    Task.Run(() => AMS.UpdateLog(log)).Wait(8000);
                }
                catch(TimeoutException)
                {
                    
                }
                
                
                
                


            }
            catch (Exception)
            {

            }




        }

        private void ContainerForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
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
                    string strOrg = comboArm.Text;
                    int idxEnd = strOrg.IndexOf("M");
                    string portName = "COM" + strOrg.Substring(idxEnd + 1, (strOrg.Length - 1) - idxEnd);
                    bool isConnected = Sport.OpenPorts(serialArm, portName);
                    lblStatus.Text = "포트를 열었습니다.";
                    timArm = true;
                    if (!isConnected) lblStatus.Text = "포트를 열지 못했습니다.";
                }
                else
                {
                    Sport.ClosePorts(serialArm);
                    lblStatus.Text = "포트를 닫았습니다.";
                    timArm = false;
                }
            }
            catch
            {
                MessageBox.Show("Error occurred.");
            }
        }





        private void lblPsdL_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPsdR_TextChanged(object sender, EventArgs e)
        {

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

                            
                            //--------------------------------------------------------------------Elbow-------------------------------------------------------------------
                            //elbow mode reachedflag
                            if ((Right_Elbow_R - Center_Right) * 180 / Math.PI < -5 && (Elbow_Wrist_R - Right_Elbow_R) * 180 / Math.PI > -100 &&
                                (Center_Left - Left_Elbow_L) * 180 / Math.PI < -5 && (Left_Elbow_L - Elbow_Wrist_L) * 180 / Math.PI > -100 && ElbowModeReachdFlag && !ElbowExModeFlag)
                            {
                                ElbowExModeFlag = true;
                                clientStream1.WriteString("ElbowDown");
                                timWaitA = true;
                                timcountB = 0;
                                if (elbowSF)
                                {

                                    _player.FileName = Application.StartupPath + "\\Audio\\상체 근력 운동 10.mp3";
                                    _player.Play();
                                    elbowSF = false;
                                }

                            }
                            //elbowdown
                            else if ((Right_Elbow_R - Center_Right) * 180 / Math.PI > 15 && (Elbow_Wrist_R - Right_Elbow_R) * 180 / Math.PI < -110 &&
                                (Center_Left - Left_Elbow_L) * 180 / Math.PI > 15 && (Left_Elbow_L - Elbow_Wrist_L) * 180 / Math.PI < -110 && ElbowExModeFlag)
                            {
                                timcountA = 0;
                                timWaitB = true;
                                ElbowExModeFlag = false;
                                clientStream1.WriteString("ElbowUp");
                                ElbowCount++;
                                log.arm += 1;
                                if (ElbowCount < exerciseCount)
                                {
                                    lblStatus.Text = "Elbow Reached - " + Convert.ToString(exerciseCount - ElbowCount) + " time left";
                                    AudioCount(exerciseCount - ElbowCount);
                                }
                                else
                                {
                                    timWaitA = false;
                                    timWaitB = false;
                                    ElbowModeReachdFlag = false;
                                    Thread.Sleep(1000);
                                    ElbowCount = 0;
                                    elbowSF = true;
                                    lblStatus.Text = "Exercise Done";
                                    clientStream1.WriteString("ElbowModeOff");
                                    RPTrans(0, 0);
                                    _player.FileName = Application.StartupPath + "\\Audio\\종료_운동.wav";
                                    _player.Play();
                                    praiseSF = false;
                                }
                            }
                            
                            //-------------------------------------------------stand up down-----------------------------------------------------------
                            //for reaction test
                            if (Math.Abs(RightLegUp - RightLegDown) * 180 / Math.PI < 10 && Math.Abs(LeftLegUp - LeftLegDown) * 180 / Math.PI < 10 && UpFlag)
                            {
                                UpFlag = false;
                                clientStream1.WriteString("SitDown");
                                DownFlag = true;
                                timWait = true;

                            }
                            else if (Math.Abs(RightLegUp - RightLegDown) * 180 / Math.PI > 35 && Math.Abs(LeftLegUp - LeftLegDown) * 180 / Math.PI > 35 && DownFlag)
                            {
                                timcount = 0;
                                DownFlag = false;
                                UpFlag = true;
                                UpDownCount++;
                                log.sit += 1;
                                if (UpDownCount < exerciseCount)
                                {
                                    clientStream1.WriteString("StandUp");
                                    lblStatus.Text = "Sit Down - " + Convert.ToString(exerciseCount - UpDownCount) + " time left";
                                    AudioCount(exerciseCount - UpDownCount);
                                }
                                else
                                {
                                    clientStream1.WriteString("StandUp");
                                    lblStatus.Text = $"Next step - Yoga {exerciseCount} time";
                                    timWait = false;
                                    UpDownCount = 0;
                                    UpFlag = false;
                                    yogaflag = true;
                                    Thread.Sleep(1000);
                                    clientStream1.WriteString("Yoga");
                                    
                                    //TimWait.Enabled = true;

                                }
                            }
                            //-------------------------------------------------Standing Yoga-----------------------------------------------------------
                            if ((RightLegUp - RightLegDown) * 180 / Math.PI > -10 && (LeftLegUp - LeftLegDown) * 180 / Math.PI < 10 && yogaflag)
                            {
                                yogaflag = false;
                                yogareachflag = true;
                                clientStream1.WriteString("Yoga");
                                timWait = true;
                                if (yogaSF)
                                {
                                    
                                    _player.FileName = Application.StartupPath + "\\Audio\\요가 자세 10.mp3";
                                    _player.Play();
                                    yogaSF = false;
                                }
                            }
                            else if ((CenterSpine - Right_Elbow_R) * 180 / Math.PI > 70 && (CenterSpine - Left_Elbow_L) * 180 / Math.PI < 110
                                && Math.Abs(RightLegUp - RightLegDown) * 180 / Math.PI < 10 && Math.Abs(LeftLegUp - LeftLegDown) * 180 / Math.PI > 60 && yogareachflag)
                            {
                                timcount = 0;
                                yogaflag = true;
                                yogareachflag = false;
                                Yogacount++;
                                log.yoga += 1;
                                if (Yogacount < exerciseCount)
                                {
                                    clientStream1.WriteString("YogaReturn");
                                    AudioCount(exerciseCount - Yogacount);
                                    lblStatus.Text = $"Yoga Exercise - {exerciseCount} time left";

                                }
                                else
                                {
                                    timWait = false;
                                    clientStream1.WriteString("YogaReturn");
                                    Yogacount = 0;
                                    yogaflag = false;
                                    Sunflag = true;
                                    lblStatus.Text = $"Next step - praise {exerciseCount} time";
                                    //lblStatus.Text = "Exercise Done";
                                    //RPTrans(0, 0);
                                }
                            }
                            //-------------------------------------------------Praise The Sun-----------------------------------------------------------
                            if ((CenterSpine - Right_Elbow_R) * 180 / Math.PI < 20 && (CenterSpine - Left_Elbow_L) * 180 / Math.PI > 130 && Sunflag)
                            {
                                Sunflag = false;
                                Sunreachflag = true;
                                timWait = true;
                                clientStream1.WriteString("PraiseTheSun");
                                if (praiseSF)
                                {
                                    
                                    _player.FileName = Application.StartupPath + "\\Audio\\만세 자세 운동 10.wav";
                                    Thread.Sleep(5);
                                    _player.Play();
                                    praiseSF = false;
                                }
                            }
                            else if ((CenterSpine - Right_Elbow_R) * 180 / Math.PI > 120 && (CenterSpine - Left_Elbow_L) * 180 / Math.PI < 50 &&
                                Math.Abs(Elbow_Wrist_R - Right_Elbow_R) * 180 / Math.PI < 10 && Math.Abs(Left_Elbow_L - Elbow_Wrist_L) * 180 / Math.PI < 10 && Sunreachflag)
                            {
                                timcount = 0;
                                Sunflag = true;
                                Sunreachflag = false;
                                log.praise += 1;
                                Suncount++;
                                if (Suncount < exerciseCount)
                                {
                                    clientStream1.WriteString("PraiseTheSunReturn");
                                    lblStatus.Text = "praise - " + Convert.ToString(exerciseCount - Suncount) + " time left";
                                    AudioCount(exerciseCount - Suncount);

                                }
                                else
                                {
                                    timWait = false;
                                    clientStream1.WriteString("PraiseTheSunReturn");
                                    Suncount = 0;
                                    Sunflag = false;
                                    lblStatus.Text = "Exercise Done";
                                    praiseSF = true;
                                    sitSF = true;
                                    yogaSF = true;
                                    RPTrans(0, 0);
                                    _player.FileName = Application.StartupPath + "\\Audio\\종료_운동.wav";
                                    _player.Play();
                                }
                            }

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

        public void Thread_Coach(object o)
        {
            client1 = new NamedPipeClientStream(".", "MyCOMApp1",
               PipeDirection.InOut, PipeOptions.Asynchronous,
               TokenImpersonationLevel.Impersonation);
            //Connect to server
            
                
            try
            {
                client1.Connect(1000);
                Thread.Sleep(20);
                clientStream1 = new StreamString(client1);

            }
            catch
            {
                ThreadPool.QueueUserWorkItem(Thread_Coach);
                return;
            }


        }

        public static double roll = 0;
        public static double pitch = 0;
        public static int skicount = 0;
        public static int framecount = 0;

        public void Thread_VR(object o)
        {
            using (NamedPipeClientStream client2 = new NamedPipeClientStream(".", "MyCOMApp2",
               PipeDirection.InOut, PipeOptions.Asynchronous,
               TokenImpersonationLevel.Impersonation))
            {
                /*client2 = new NamedPipeClientStream(".", "MyCOMApp2",
                  PipeDirection.InOut, PipeOptions.Asynchronous,
                  TokenImpersonationLevel.Impersonation);*/
                    int firstyaw = 0; bool u = true;
                //Connect to server`

                try
                {
                    client2.Connect(1000);
                }
                catch (TimeoutException)
                {
                    ThreadPool.QueueUserWorkItem(Thread_VR);
                    return;
                }
                Thread.Sleep(20);
                //MessageBox.Show("Thread_2 Connected");
                //Created stream for reading and writing
                clientStream2 = new StreamString(client2);
                //Read from Server
                while (!threadend)
                {
                    int count = 0;
                    dataFromServer = null;
                    dataFromServer = clientStream2.ReadString();

                    string[] words = dataFromServer?.Split(',');
                    if (words == null) continue;
                    if (words.Count() == 6)
                    {
                        string str0 = words[0];
                        string str1 = words[1];
                        string str2 = words[2];
                        string str3 = words[3];
                        string str4 = words[4];
                        string str5 = words[5];

                        if (u)
                        {
                            firstyaw = (int)Math.Round(float.Parse(str3));
                            u = false;
                            continue;
                        }

                        int roll = -(int)Math.Round(float.Parse(str1));
                        int pitch = (int)Math.Round(float.Parse(str2));
                        int yaw = 90 - ((int)Math.Round(float.Parse(str3)) - firstyaw);
                        count = (int)Math.Round(float.Parse(str4));
                        Console.Write(str1);
                        Console.Write(',');
                        Console.Write(str2);
                        Console.Write(',');
                        Console.WriteLine(yaw);


                        if (skicount > 1)
                        {
                            RPTrans(roll, pitch);
                            MMCLib.start_move(3, ATP(yaw), 100000, 200);

                            skicount = 0;
                        }
                        if (framecount > 5)
                        {
                            MMCLib.frames_clear(0);
                            MMCLib.frames_clear(1);
                            MMCLib.frames_clear(2);
                            MMCLib.frames_clear(3);
                            framecount = 0;
                        }

                    }


                }
                clientStream2.StreamClear(client2);
                client2.Close();
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

        private void btnUNreset_Click(object sender, EventArgs e)
        {
            fs.Sport_Close(serialFoot);
            //스키리셋
            if (!ModeFlag)
            {

                
                threadend = true;
                Thread.Sleep(500);
                threadend = false;
                ThreadPool.QueueUserWorkItem(Thread_VR);
                using (Process process = new Process())
                {
                    Process[] localByName1 = Process.GetProcessesByName("Medi_VR");
                    if (localByName1.Count() >= 1) foreach (Process lo in localByName1) lo.Kill();
                    Process[] localByName2 = Process.GetProcessesByName("BoatAttack");
                    if (localByName2.Count() >= 1) foreach (Process lo in localByName2) lo.Kill();
                    //Process[] localByName3 = Process.GetProcessesByName("BoatAttack");
                    //if (localByName3.Count() >= 1) foreach (Process lo in localByName3) lo.Kill();
                    Thread.Sleep(500);
                    if (radCometDodge.Checked)
                    {
                        process.StartInfo.WorkingDirectory = Application.StartupPath + @"\CometDodge";
                        process.StartInfo.FileName = @"Medi_VR.exe";
                        _player.FileName = Application.StartupPath + "\\Audio\\가상 우주모드.mp3";
                    }
                    else if (radSKI.Checked)
                    {
                        process.StartInfo.WorkingDirectory = Application.StartupPath + @"\Ski";
                        process.StartInfo.FileName = @"Medi_VR.exe";
                        _player.FileName = Application.StartupPath + "\\Audio\\시작_스키.wav";
                    }
                    else if (radVoyage.Checked)
                    {                      
                        process.StartInfo.WorkingDirectory = Application.StartupPath + @"\Boat";
                        process.StartInfo.FileName = @"BoatAttack.exe";
                        _player.FileName = Application.StartupPath + "\\Audio\\가상 항해모드.mp3";
                    }

                    process.StartInfo.Arguments = "-parentHWND " + selectablePanel.Handle.ToInt32() + " " + Environment.CommandLine;
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();

                    process.WaitForInputIdle();

                    EnumChildWindows(selectablePanel.Handle, WindowEnum, IntPtr.Zero);
                    _player.Play();



                }
            }
            //코치모드
            else if (ModeFlag)
            {
                timWait = false;
                timWaitA = false;
                timWaitB = false;
                yogaflag = false;
                yogareachflag = false;
                ElbowExModeFlag = false;
                ElbowModeReachdFlag = false;
                UpFlag = false;
                DownFlag = false;
                Sunflag = false;
                Sunreachflag = false;
                if (clientStream1 != null) clientStream1.StreamClear(client1);
                client1?.Close();
                Thread.Sleep(500);
                
                using (Process process = new Process())
                {
                    Process[] localByName = Process.GetProcessesByName("VR_Avatar_2");

                    try
                    {
                        if (localByName.Count() >= 1) foreach (Process lo in localByName) localByName[1]?.Kill();
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (localByName.Count() >= 1) foreach (Process lo in localByName) localByName[0].Kill();
                    }
                    catch
                    {
                    }

                    process.StartInfo.WorkingDirectory = Application.StartupPath + @"\Coach";
                    process.StartInfo.FileName = "VR_Avatar_2.exe";

                    process.StartInfo.Arguments = "-parentHWND " + selectablePanel.Handle.ToInt32() + " " + Environment.CommandLine;
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();
                    process.WaitForInputIdle();

                    EnumChildWindows(selectablePanel.Handle, WindowEnum, IntPtr.Zero);
                    ThreadPool.QueueUserWorkItem(Thread_Coach);
                }
            }
            try
            {
                string strOrg = comboPort.Text;
                int idxEnd = strOrg.IndexOf("M");
                string portNum = strOrg.Substring(idxEnd + 1, (strOrg.Length - 1) - idxEnd);
                int baud = 921600;
                isFootConnected = fs.Sport_Open(serialFoot, portNum, baud);

                timDraw = true;
            }
            catch
            {
                MessageBox.Show("포트 설정이 잘못되었습니다.");
            }
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

        private void btnM1cw_Click(object sender, EventArgs e)
        {

        }

        private void btn데이터_Click(object sender, EventArgs e)
        {
            panData.Visible = !panData.Visible;
        }

        private void btnM1ccw_Click(object sender, EventArgs e)
        {

        }

        private void btnBalancing_Click(object sender, EventArgs e)
        {
            RPTrans(0, 0);
            //_player = new MediaPlayer.MediaPlayerClass();
            _player.FileName = Application.StartupPath + "\\Audio\\시작_균형.wav";
            _player.Play();
            isBalancing = true;
            se1 = true;

        }

        private void RPMove(double angle0, double angle1, double angle2)
        {
            //long[] addr = { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
            short[] axes = new short[3] { 0, 1, 2 };                            //회전할 축 설정
            short[] accel = new short[3] { 200, 200, 200 };                     //accel값이 높아질수록 스므스하게 감속 (값이 너무 작으면 감속기 혹은 링크부분에 충격이 클 수 있음)
            double[] pos = new double[3] { ATP(angle0), ATP(angle1), ATP(angle2) };      //각 축의 위치값 (이후에 각도와 모터 위치값의 상관관계를 찾아 define해주면 됨 -> Window에서는 각도만 입력해서 움직일 수 있도록)
            double[] vel = new double[3] { 100000.0, 100000.0, 100000.0 };
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

        private void chkFoot_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                string strOrg = comboPort.Text;
                int idxEnd = strOrg.IndexOf("M");
                string portNum = strOrg.Substring(idxEnd + 1, (strOrg.Length - 1) - idxEnd);
                int baud = 921600;
                isFootConnected = fs.Sport_Open(serialFoot, portNum, baud);

                timDraw = true;
            }
            catch
            {
                MessageBox.Show("포트 설정이 잘못되었습니다.");
            }
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

        private void btn사용자등록_Click(object sender, EventArgs e)
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
        private void rollMinus()
        {
            RPTrans(-7, 0);
            lblStatus.Text = "왼 발에 힘을 줘 균형을 잡으세요.";
            //_player = new MediaPlayer.MediaPlayerClass();
            _player.FileName = Application.StartupPath + "\\Audio\\족저압이 왼쪽.mp3";
            _player.Play();
        }

        private void rollPlus()
        {
            RPTrans(7, 0);
            lblStatus.Text = "오른 발에 힘을 줘 균형을 잡으세요.";
            //_player = new MediaPlayer.MediaPlayerClass();
            _player.FileName = Application.StartupPath + "\\Audio\\족저압이 오른쪽.mp3";
            _player.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool leftMore = false;
            lblStatus.Text = "균형운동 시작합니다.";
            //_player = new MediaPlayer.MediaPlayerClass();
            _player.FileName = Application.StartupPath + "\\Audio\\시작_균형.mp3";
            _player.Play();

            if (timDraw == false) timDraw = true;
            double maxLeft, maxRight, maxFront, maxBack;
            maxLeft = fs.getLeft(dataOrg); maxRight = fs.getRight(dataOrg);
            if (maxLeft < maxRight)
            {
                rollMinus();                            //오른쪽이 높음 - 왼쪽으로 내림            
                leftMore = false;
            }
            else
            {
                rollPlus();
                leftMore = true;
            }
            int i = 5;
            lblStatus.Text = i.ToString() + "회 남았습니다.";
            AudioCount(i);
            while (i > 0)
            {
                maxLeft = fs.getLeft(dataOrg);
                maxRight = fs.getRight(dataOrg);
                if (leftMore)
                {
                    rollPlus();
                    if (maxLeft < maxRight)
                    {
                        i--;
                        lblStatus.Text = i.ToString() + "회 남았습니다.";
                        AudioCount(i);
                        leftMore = false;
                    }
                }

                else
                {
                    rollMinus();
                    if (maxLeft > maxRight)
                    {
                        i--;
                        lblStatus.Text = i.ToString() + "회 남았습니다.";
                        AudioCount(i);
                        leftMore = true;
                    }

                }
            }
            lblStatus.Text = "운동 종료하였습니다.";
        }
        private void comboPort_MouseDown(object sender, MouseEventArgs e)
        {
            comboPort.Items.Clear();
            comboPort.Items.AddRange(SerialPort.GetPortNames());
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

        #region ContentsButtonEvent       
        private void btn족압측정_Click(object sender, EventArgs e)
        {
            fixguidelineflag = true;
            lblStatus.Text = "Stabilizing";


            double maxLeft, maxRight;
            maxLeft = fs.getLeft(dataOrg);
            maxRight = fs.getRight(dataOrg);
            log.foot = (100 * maxRight / (maxLeft + maxRight)).ToString();
            if (maxRight < maxLeft)
            {
                lblStatus.Text = "Left press";
                RPTrans(7, 0);
                LeftWeight = true;
                RightWeight = false;
                //_player = new MediaPlayer.MediaPlayerClass();
                _player.FileName = Application.StartupPath + "\\Audio\\족저압이 왼쪽.mp3";
                _player.Play();
            }
            else
            {
                lblStatus.Text = "Right press";
                RPTrans(-7, 0);
                LeftWeight = false;
                RightWeight = true;
                //_player = new MediaPlayer.MediaPlayerClass();
                _player.FileName = Application.StartupPath + "\\Audio\\족저압이 오른쪽.mp3";
                _player.Play();
            }
        }

        private void btn설정_Click(object sender, EventArgs e)
        {
            panSetting.Visible = !panSetting.Visible;
        }

        private void ArmPortConnect()
        {

        }

        private void btn상지운동_Click(object sender, EventArgs e)
        {


            if (clientStream1 != null)
            {
                int strL = 0, strR = 0;

                if (radLLight.Checked) strL = 1;
                else if (radLNormal.Checked) strL = 2;
                else if (radLHeavy.Checked) strL = 3;
                else if (radLzero.Checked) strL = 0;

                if (radRLight.Checked) strR = 1;
                else if (radRNormal.Checked) strR = 2;
                else if (radRHeavy.Checked) strR = 3;
                else if (radRzero.Checked) strL = 0;

                string text = strL.ToString() + "," + strR.ToString() + "\n";

                if (!serialArm.IsOpen)
                {
                    lblStatus.Text = "상체 운동 포트가 닫혀있습니다.";
                    return;
                }

                serialArm.Write(text);
                lblStatus.Text = "상체 운동 준비 완료";
                lblStatus.Text = "Elbow Exercise - " + exerciseCount + " time left";
                clientStream1?.WriteString("ElbowModeOn");
                ElbowModeReachdFlag = true;
                /*_player = new MediaPlayer.MediaPlayerClass();
                _player.FileName = Application.StartupPath + "\\Audio\\시작_상체운동.wav";
                _player.Play();*/
            }


        }

        private void btn일시정지_Click(object sender, EventArgs e)
        {
            //process.CloseMainWindow();
            //코치모드 -> 스키모드
            //thread1->thread2  VR_Avatar->Medi_VR   Kinect off  
            if (serialFoot.IsOpen) fs.Sport_Close(serialFoot);
            if (ModeFlag) //0 2 4
            {
                timWait=false;
                timWaitA = false;
                timWaitB = false;
                yogaflag = false;
                yogareachflag = false;
                ElbowExModeFlag = false;
                ElbowModeReachdFlag = false;
                UpFlag = false;
                DownFlag = false;
                Sunflag = false;
                Sunreachflag = false;
                lblStatus.Text = "GAME";
                clientStream1.StreamClear(client1);
                client1.Close();
                threadend = false;
                /*while (process.HasExited == false)
                    process.Kill();
                process.Close();*/
                //Thread.Sleep(6000);
                double pos0 = 77;
                double pos1 = 77;
                double pos2 = 77;
                long[] addr = { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
                short[] axes = new short[4] { 0, 1, 2, 3 };                            //회전할 축 설정
                short[] accel = new short[4] { 200, 200, 200, 200 };                     //accel값이 높아질수록 스므스하게 감속 (값이 너무 작으면 감속기 혹은 링크부분에 충격이 클 수 있음)
                double[] pos = new double[4] { ATP(pos0), ATP(pos1), ATP(pos2), 0 };      //각 축의 위치값 (이후에 각도와 모터 위치값의 상관관계를 찾아 define해주면 됨 -> Window에서는 각도만 입력해서 움직일 수 있도록)
                double[] vel = new double[4] { 80000.0, 80000.0, 80000.0, 80000.0 };
                short err = MMCLib.mmc_initx(4, addr);  //초기화
                MMCLib.move_all(4, axes, pos, vel, accel);
                
                
                

                using (Process process = new Process())
                {
                    Process[] localByName = Process.GetProcessesByName("VR_Avatar_2");
                    try
                    {
                        if (localByName.Count() >= 1) foreach (Process lo in localByName) localByName[1]?.Kill();
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (localByName.Count() >= 1) foreach (Process lo in localByName) localByName[0].Kill();
                    }
                    catch
                    {
                    }
                    Thread.Sleep(1000);

                    if (radCometDodge.Checked)
                    {
                        process.StartInfo.WorkingDirectory = Application.StartupPath + @"\CometDodge";
                        process.StartInfo.FileName = @"Medi_VR.exe";
                        _player.FileName = Application.StartupPath + "\\Audio\\가상 우주모드.mp3";
                    }
                    else if (radSKI.Checked)
                    {
                        process.StartInfo.WorkingDirectory = Application.StartupPath + @"\Ski";
                        process.StartInfo.FileName = @"Medi_VR.exe";
                        _player.FileName = Application.StartupPath + "\\Audio\\시작_스키.wav";
                    }
                    else if (radVoyage.Checked)
                    {
                        process.StartInfo.WorkingDirectory = Application.StartupPath + @"\Boat";
                        process.StartInfo.FileName = @"BoatAttack.exe";
                        _player.FileName = Application.StartupPath + "\\Audio\\가상 항해모드.mp3";
                    }

                    process.StartInfo.Arguments = "-parentHWND " + selectablePanel.Handle.ToInt32() + " " + Environment.CommandLine;
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();

                    process.WaitForInputIdle();

                    EnumChildWindows(selectablePanel.Handle, WindowEnum, IntPtr.Zero);
                    
                    _player.Play();
                }
                Skiretry = true;
                ThreadPool.QueueUserWorkItem(Thread_VR);
                    
                //thread2.Start();
                ModeFlag = !ModeFlag;
                
            }
            //스키모드 -> 코치모드
            //thread2->thread1  Medi_VR->VR_Avatar   Kinect on  
            else if (!ModeFlag)//1 3 5
            {
                
                
                btn상지운동.Enabled = true;
                btn하지운동.Enabled = true;
                threadend = true;
                lblStatus.Text = "대기중입니다";
                
                //thread 전환
                //threadend = true;
                //client2.Close();
                //thread2.Abort();
                /*while (process.HasExited == false)
                    process.Kill();
                process.Close();*/
                //Thread.Sleep(4000);
                double pos0 = 77;
                double pos1 = 77;
                double pos2 = 77;
                long[] addr = { 0xD8000000, 0xD8400000, 0xD8800000, 0xD8C00000 };
                short[] axes = new short[4] { 0, 1, 2, 3 };                            //회전할 축 설정
                short[] accel = new short[4] { 200, 200, 200, 200 };                     //accel값이 높아질수록 스므스하게 감속 (값이 너무 작으면 감속기 혹은 링크부분에 충격이 클 수 있음)
                double[] pos = new double[4] { ATP(pos0), ATP(pos1), ATP(pos2), 0 };      //각 축의 위치값 (이후에 각도와 모터 위치값의 상관관계를 찾아 define해주면 됨 -> Window에서는 각도만 입력해서 움직일 수 있도록)
                double[] vel = new double[4] { 80000.0, 80000.0, 80000.0, 80000.0 };
                short err = MMCLib.mmc_initx(4, addr);  //초기화
                MMCLib.move_all(4, axes, pos, vel, accel);


                using (Process process = new Process())
                {
                    Process[] localByName = Process.GetProcessesByName("Medi_VR");

                    if (localByName.Count() >= 1) foreach (Process lo in localByName) lo.Kill();
                    Process[] localByNames = Process.GetProcessesByName("BoatAttack");

                    if (localByNames.Count() >= 1) foreach (Process lo in localByNames) lo.Kill();

                    Thread.Sleep(500);

                    process.StartInfo.WorkingDirectory = Application.StartupPath + @"\Coach";
                    process.StartInfo.FileName = "VR_Avatar_2.exe";

                    process.StartInfo.Arguments = "-parentHWND " + selectablePanel.Handle.ToInt32() + " " + Environment.CommandLine;
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();
                    

                    process.WaitForInputIdle();

                    EnumChildWindows(selectablePanel.Handle, WindowEnum, IntPtr.Zero);

                    _player.FileName = Application.StartupPath + "\\Audio\\시작_코치.wav";
                    _player.Play();

                    /*Thread.Sleep(5000);
                    Process[] isrun = Process.GetProcessesByName("VR_Avatar_2");
                    if (isrun.Count() == 0)
                        process.Start();*/
                }

                Coachretry = true;
                ThreadPool.QueueUserWorkItem(Thread_Coach);

                //thread1.Start();
                ModeFlag = !ModeFlag;
            }
            try
            {
                string strOrg = comboPort.Text;
                int idxEnd = strOrg.IndexOf("M");
                string portNum = strOrg.Substring(idxEnd + 1, (strOrg.Length - 1) - idxEnd);
                int baud = 921600;
                isFootConnected = fs.Sport_Open(serialFoot, portNum, baud);

                timDraw = true;
            }
            catch
            {
                MessageBox.Show("포트 설정이 잘못되었습니다.");
            }
            //MessageBox.Show("프로그램 리셋 완료");
        }

        private void btn하지운동_Click(object sender, EventArgs e)
        {
            clientStream1?.WriteString("SitDown");
            if (clientStream1 != null)
            {
                lblStatus.Text = "Sit Down - " + exerciseCount + " time left";
                DownFlag = true;
                timWait = true;
                if (sitSF)
                {
                    //_player = new MediaPlayer.MediaPlayerClass();
                    _player.FileName = Application.StartupPath + "\\Audio\\앉았다 일어나는 운동 10.wav";
                    _player.Play();
                    sitSF = false;
                }
            }
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

        private void btn코치모드_Click(object sender, EventArgs e)
        {
            try
            {
                
                ModeFlag = true;
                initMotor();
                initHomming();
                btn상지운동.Enabled = true;
                btn하지운동.Enabled = true;
                btn스키모드.Enabled = false;
                btn코치모드.Enabled = false;
                btn전환.Enabled = true;
                ThreadPool.QueueUserWorkItem(Thread_Coach);
                try
                {
                    string strOrg = comboPort.Text;
                    int idxEnd = strOrg.IndexOf("M");
                    string portNum = strOrg.Substring(idxEnd + 1, (strOrg.Length - 1) - idxEnd);
                    int baud = 921600;
                    isFootConnected = fs.Sport_Open(serialFoot, portNum, baud);

                    timDraw = true;
                }
                catch
                {
                    MessageBox.Show("포트 설정이 잘못되었습니다.");
                }



                using (Process process = new Process())
                {
                    Process[] localByName = Process.GetProcessesByName("Medi_VR");

                    if (localByName.Count() >= 1) foreach (Process lo in localByName) lo.Kill();
                    Thread.Sleep(1000);

                    process.StartInfo.WorkingDirectory = Application.StartupPath + @"\Coach";
                    process.StartInfo.FileName = @"VR_Avatar_2.exe";

                    process.StartInfo.Arguments = "-parentHWND " + selectablePanel.Handle.ToInt32() + " " + Environment.CommandLine;
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();                    

                    process.WaitForInputIdle();

                    EnumChildWindows(selectablePanel.Handle, WindowEnum, IntPtr.Zero);

                    /*Thread.Sleep(10000);
                    Process[] isrun = Process.GetProcessesByName("VR_Avatar_2");
                    if (isrun.Count() == 0)
                    {
                        process.Start();
                        clientStream1.StreamClear(client1);
                        ThreadPool.QueueUserWorkItem(Thread_Coach);
                    }*/
                        
                }

                //_player = new MediaPlayer.MediaPlayerClass();
                _player.FileName = Application.StartupPath + "\\Audio\\시작_코치.wav";
                _player.Play();
                
                //thread1.Start();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + ".\nCheck if Container.exe is placed next to Child.exe.");
            }
        }

        private void btn스키모드_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialFoot.IsOpen) fs.Sport_Close(serialFoot);
                ModeFlag = false;
                btn코치모드.Enabled = false;
                btn스키모드.Enabled = false;
                btn전환.Enabled = true;
                initMotor();
                initHomming();
                ThreadPool.QueueUserWorkItem(Thread_VR);
                using (Process process = new Process())
                {                   
                    if (radCometDodge.Checked)
                    {
                        process.StartInfo.WorkingDirectory = Application.StartupPath + @"\CometDodge";
                        process.StartInfo.FileName = @"Medi_VR.exe";
                        _player.FileName = Application.StartupPath + "\\Audio\\가상 우주모드.mp3";
                    }
                    else if (radSKI.Checked)
                    {
                        process.StartInfo.WorkingDirectory = Application.StartupPath + @"\Ski";
                        process.StartInfo.FileName = @"Medi_VR.exe";
                        _player.FileName = Application.StartupPath + "\\Audio\\시작_스키.wav";
                    }
                    else if (radVoyage.Checked)
                    {
                        process.StartInfo.WorkingDirectory = Application.StartupPath + @"\Boat";
                        process.StartInfo.FileName = @"BoatAttack.exe";
                        _player.FileName = Application.StartupPath + "\\Audio\\가상 항해모드.mp3";
                    }

                    process.StartInfo.Arguments = "-parentHWND " + selectablePanel.Handle.ToInt32() + " " + Environment.CommandLine;
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();
                    
                    process.WaitForInputIdle();

                    EnumChildWindows(selectablePanel.Handle, WindowEnum, IntPtr.Zero);
                }
                
                //thread2.Start();

                try
                {
                    string strOrg = comboPort.Text;
                    int idxEnd = strOrg.IndexOf("M");
                    string portNum = strOrg.Substring(idxEnd + 1, (strOrg.Length - 1) - idxEnd);
                    int baud = 921600;
                    isFootConnected = fs.Sport_Open(serialFoot, portNum, baud);

                    timDraw = true;
                }
                catch
                {
                    MessageBox.Show("포트 설정이 잘못되었습니다.");
                }
                //_player = new MediaPlayer.MediaPlayerClass();
                
                _player.Play();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + ".\nCheck if Container.exe is placed next to Child.exe.");
            }
        }

        #endregion

        #region SettingButtonEvent

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



        private void btnM3Set_Click(object sender, EventArgs e)
        {
            MMCLib.set_position(3, 0.0);
        }

        #endregion

        #region timer and serialdata

        public static Boolean isBalancing = false;
        public static Boolean se1 = false;
        public static Boolean se2 = false;
        public static Boolean se3 = false;
        public static int balcount = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            skicount++;
            framecount++;

            if (isBalancing == true)
            {
                balcount++;
            }
            if (balcount >= 10 && balcount < 25)
            {
                if (se1 == true)
                {
                    RPTrans(6, 0);
                    se1 = false;
                    se2 = true;
                }
            }
            if (balcount >= 25 && balcount <= 40)
            {
                if (se2 == true)
                {
                    RPTrans(-6, 0);
                    se2 = false;
                    se3 = true;
                }
            }
            if (balcount >= 40)
            {
                if (se3 == true)
                {
                    RPTrans(6, 0);
                    se3 = false;
                    isBalancing = false;
                    balcount = 0;
                }
            }
            if (timDraw)
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

            if (timWait)
            {
                timcount++;
                if (timcount > 80)
                {
                    //_player = new MediaPlayer.MediaPlayerClass();
                    _player.FileName = Application.StartupPath + "\\Audio\\자세. 코치의 자세를 따라해보세요.mp3";
                    _player.Play();


                    timcount = 0;
                    timWait = false;
                }
            }
            if (timWaitA)
            {
                timcountA++;
                if (timcountA > 80)
                {
                    //_player = new MediaPlayer.MediaPlayerClass();
                    _player.FileName = Application.StartupPath + "\\Audio\\자세. 손을 더 내려주세요..mp3";
                    _player.Play();


                    timcountA = 0;
                    timWaitA = false;
                }
            }
            if (timWaitB)
            {
                timcountB++;
                if (timcountB > 80)
                {

                    //_player = new MediaPlayer.MediaPlayerClass();
                    _player.FileName = Application.StartupPath + "\\Audio\\자세. 손을 더 올려주세요..mp3";
                    _player.Play();


                    timcountB = 0;
                    timWaitB = false;
                }
            }

            /*if ((Right_Elbow_R - Center_Right) * 180 / Math.PI < 10 && (Elbow_Wrist_R - Right_Elbow_R) * 180 / Math.PI < -80 &&
                                (Center_Left - Left_Elbow_L) * 180 / Math.PI < 10 && (Left_Elbow_L - Elbow_Wrist_L) * 180 / Math.PI < -80 && ElbowModeReachdFlag && !ElbowExModeFlag)*/

            if (timArm)
            {
                /*label19.Text = Convert.ToString((Right_Elbow_R - Center_Right) * 180 / Math.PI) + "  " + Convert.ToString((Elbow_Wrist_R - Right_Elbow_R) * 180 / Math.PI)
            + " " + Convert.ToString((Center_Left - Left_Elbow_L) * 180 / Math.PI) + "  " + Convert.ToString((Left_Elbow_L - Elbow_Wrist_L) * 180 / Math.PI);*/
                if (rxBuffer != "")
                {
                    try
                    {

                        if (chtArm.Series[0].Points.Count > 150)
                        {
                            chtArm.Series[0].Points.RemoveAt(0);
                            chtArm.Series[1].Points.RemoveAt(0);
                            chtArm.Series[0].Points.RemoveAt(0);
                            chtArm.Series[1].Points.RemoveAt(0);
                        }

                        string txtRaw = rxBuffer;
                        //lblPsdL.Text = txtRaw;
                        double psdL = 0, psdR = 0;

                        string[] proto = txtRaw.Split(',');
                        psdL = Convert.ToDouble(proto[0]);
                        psdR = Convert.ToDouble(proto[1]);
                        chtArm.Series[0].Points.AddY(psdL);
                        chtArm.Series[1].Points.AddY(psdR);
                        lblPsdL.Text = proto[0];
                        lblPsdR.Text = proto[1];
                    }
                    catch { }
                }

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
        #endregion

        private void AudioCount(int i)
        {
            switch (i)
            {
                case 1:
                    //_player = new MediaPlayer.MediaPlayerClass();
                    _player.FileName = Application.StartupPath + "\\Audio\\1회남음.wav";
                    _player.Play();
                    break;
                case 2:
                    //_player = new MediaPlayer.MediaPlayerClass();
                    _player.FileName = Application.StartupPath + "\\Audio\\2회남음.wav";
                    _player.Play();
                    break;
                case 3:
                    //_player = new MediaPlayer.MediaPlayerClass();
                    _player.FileName = Application.StartupPath + "\\Audio\\3회남음.wav";
                    _player.Play();
                    break;
                case 4:
                    //_player = new MediaPlayer.MediaPlayerClass();
                    _player.FileName = Application.StartupPath + "\\Audio\\4회남음.wav";
                    _player.Play();
                    break;
                case 5:
                    //_player = new MediaPlayer.MediaPlayerClass();
                    _player.FileName = Application.StartupPath + "\\Audio\\5회남음.wav";
                    _player.Play();
                    break;
                case 6:
                    //_player = new MediaPlayer.MediaPlayerClass();
                    _player.FileName = Application.StartupPath + "\\Audio\\6회남음.wav";
                    _player.Play();
                    break;
                case 7:
                    //_player = new MediaPlayer.MediaPlayerClass();
                    _player.FileName = Application.StartupPath + "\\Audio\\7회남음.wav";
                    _player.Play();
                    break;
                case 8:
                    //_player = new MediaPlayer.MediaPlayerClass();
                    _player.FileName = Application.StartupPath + "\\Audio\\8회남음.wav";
                    _player.Play();
                    break;
                case 9:
                    //_player = new MediaPlayer.MediaPlayerClass();
                    _player.FileName = Application.StartupPath + "\\Audio\\9회남음.wav";
                    _player.Play();
                    break;
                default:

                    break;
            }
        }
        
    }


}
