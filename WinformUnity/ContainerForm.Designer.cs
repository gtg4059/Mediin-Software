namespace WinformUnity
{
    partial class ContainerForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContainerForm));
            this.serialFoot = new System.IO.Ports.SerialPort(this.components);
            this.chkHomm = new System.Windows.Forms.CheckBox();
            this.comboBaudrate = new System.Windows.Forms.ComboBox();
            this.comboPort = new System.Windows.Forms.ComboBox();
            this.tmrDraw = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkConnect = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.comboArm = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.picBicubic = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panSetting = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnM3Set = new System.Windows.Forms.Button();
            this.btnM3ccw = new System.Windows.Forms.Button();
            this.btnM3cw = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnM2Set = new System.Windows.Forms.Button();
            this.btnM2ccw = new System.Windows.Forms.Button();
            this.btnM2cw = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnM1Set = new System.Windows.Forms.Button();
            this.btnM1ccw = new System.Windows.Forms.Button();
            this.btnM1cw = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnM0Set = new System.Windows.Forms.Button();
            this.btnM0ccw = new System.Windows.Forms.Button();
            this.btnM0cw = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radRHeavy = new System.Windows.Forms.RadioButton();
            this.radRNormal = new System.Windows.Forms.RadioButton();
            this.radRLight = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radLHeavy = new System.Windows.Forms.RadioButton();
            this.radLNormal = new System.Windows.Forms.RadioButton();
            this.radLLight = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radMpFast = new System.Windows.Forms.RadioButton();
            this.radMpNormal = new System.Windows.Forms.RadioButton();
            this.radMpSlow = new System.Windows.Forms.RadioButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn사용자등록 = new System.Windows.Forms.Button();
            this.btn족압측정 = new System.Windows.Forms.Button();
            this.btn긴급종료 = new System.Windows.Forms.Button();
            this.btn일시정지 = new System.Windows.Forms.Button();
            this.btn데이터 = new System.Windows.Forms.Button();
            this.btn종료 = new System.Windows.Forms.Button();
            this.btn설정 = new System.Windows.Forms.Button();
            this.btn하지운동 = new System.Windows.Forms.Button();
            this.btn상지운동 = new System.Windows.Forms.Button();
            this.btn스키모드 = new System.Windows.Forms.Button();
            this.btn코치모드 = new System.Windows.Forms.Button();
            this.btn초기화 = new System.Windows.Forms.Button();
            this.pbStream = new System.Windows.Forms.PictureBox();
            this.serialArm = new System.IO.Ports.SerialPort(this.components);
            this.tmrArm = new System.Windows.Forms.Timer(this.components);
            this.lblPsdL = new System.Windows.Forms.Label();
            this.lblPsdR = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rdbCoach = new System.Windows.Forms.RadioButton();
            this.rdbSki = new System.Windows.Forms.RadioButton();
            this.lblMonitoring = new System.Windows.Forms.Label();
            this.selectablePanel = new WinformUnity.SelectablePanel();
            this.TimWait = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBicubic)).BeginInit();
            this.panSetting.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStream)).BeginInit();
            this.SuspendLayout();
            // 
            // serialFoot
            // 
            this.serialFoot.BaudRate = 115200;
            this.serialFoot.PortName = "COM10";
            this.serialFoot.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialFoot_DataReceived);
            // 
            // chkHomm
            // 
            this.chkHomm.AutoSize = true;
            this.chkHomm.ForeColor = System.Drawing.Color.Black;
            this.chkHomm.Location = new System.Drawing.Point(217, 257);
            this.chkHomm.Name = "chkHomm";
            this.chkHomm.Size = new System.Drawing.Size(72, 16);
            this.chkHomm.TabIndex = 170;
            this.chkHomm.Text = "최초호밍";
            this.chkHomm.UseVisualStyleBackColor = true;
            // 
            // comboBaudrate
            // 
            this.comboBaudrate.FormattingEnabled = true;
            this.comboBaudrate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "56000",
            "115200",
            "921600"});
            this.comboBaudrate.Location = new System.Drawing.Point(138, 64);
            this.comboBaudrate.Name = "comboBaudrate";
            this.comboBaudrate.Size = new System.Drawing.Size(136, 24);
            this.comboBaudrate.TabIndex = 169;
            this.comboBaudrate.Text = "921600";
            // 
            // comboPort
            // 
            this.comboPort.FormattingEnabled = true;
            this.comboPort.Location = new System.Drawing.Point(138, 34);
            this.comboPort.Name = "comboPort";
            this.comboPort.Size = new System.Drawing.Size(136, 24);
            this.comboPort.TabIndex = 168;
            this.comboPort.Text = "포트를 선택하세요.";
            this.comboPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboPort_MouseDown);
            // 
            // tmrDraw
            // 
            this.tmrDraw.Interval = 40;
            this.tmrDraw.Tick += new System.EventHandler(this.tmrDraw_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(27, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 42;
            this.label1.Text = "초기화";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(105, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 42;
            this.label2.Text = "프로그램리셋";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(227, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "긴급종료";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(327, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 42;
            this.label4.Text = "가상 코치";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(431, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 42;
            this.label5.Text = "가상 스키";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(535, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 42;
            this.label6.Text = "상체 운동";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(639, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 16);
            this.label7.TabIndex = 42;
            this.label7.Text = "하체 운동";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(755, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 16);
            this.label8.TabIndex = 42;
            this.label8.Text = "데이터";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(866, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 16);
            this.label9.TabIndex = 42;
            this.label9.Text = "설정";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("휴먼둥근헤드라인", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(470, 612);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 19);
            this.label10.TabIndex = 43;
            this.label10.Text = "자세 측정";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("휴먼둥근헤드라인", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(870, 612);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 19);
            this.label11.TabIndex = 44;
            this.label11.Text = "화면";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkConnect);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.comboArm);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.comboPort);
            this.panel2.Controls.Add(this.picBicubic);
            this.panel2.Controls.Add(this.comboBaudrate);
            this.panel2.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel2.Location = new System.Drawing.Point(8, 278);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 328);
            this.panel2.TabIndex = 45;
            // 
            // chkConnect
            // 
            this.chkConnect.AutoSize = true;
            this.chkConnect.Font = new System.Drawing.Font("휴먼둥근헤드라인", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkConnect.Location = new System.Drawing.Point(5, 64);
            this.chkConnect.Name = "chkConnect";
            this.chkConnect.Size = new System.Drawing.Size(59, 21);
            this.chkConnect.TabIndex = 54;
            this.chkConnect.Text = "상체";
            this.chkConnect.UseVisualStyleBackColor = true;
            this.chkConnect.CheckedChanged += new System.EventHandler(this.chkConnect_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.Location = new System.Drawing.Point(3, 11);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 16);
            this.label18.TabIndex = 170;
            this.label18.Text = "상체 운동";
            // 
            // comboArm
            // 
            this.comboArm.FormattingEnabled = true;
            this.comboArm.Location = new System.Drawing.Point(5, 34);
            this.comboArm.Name = "comboArm";
            this.comboArm.Size = new System.Drawing.Size(115, 24);
            this.comboArm.TabIndex = 171;
            this.comboArm.Text = "포트를 선택하세요.";
            this.comboArm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboArm_MouseDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.Location = new System.Drawing.Point(136, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 16);
            this.label17.TabIndex = 54;
            this.label17.Text = "족 저압 센서";
            // 
            // picBicubic
            // 
            this.picBicubic.BackColor = System.Drawing.Color.White;
            this.picBicubic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBicubic.Location = new System.Drawing.Point(0, 94);
            this.picBicubic.Name = "picBicubic";
            this.picBicubic.Size = new System.Drawing.Size(271, 229);
            this.picBicubic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBicubic.TabIndex = 30;
            this.picBicubic.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("휴먼둥근헤드라인", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(86, 612);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 19);
            this.label12.TabIndex = 46;
            this.label12.Text = "족 저압 측정";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(4, 254);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 16);
            this.label13.TabIndex = 48;
            this.label13.Text = "족 저압 측정";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(112, 254);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 16);
            this.label14.TabIndex = 50;
            this.label14.Text = "사용자 등록";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(972, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 16);
            this.label15.TabIndex = 42;
            this.label15.Text = "종료";
            // 
            // panSetting
            // 
            this.panSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSetting.Controls.Add(this.groupBox7);
            this.panSetting.Controls.Add(this.groupBox6);
            this.panSetting.Controls.Add(this.groupBox5);
            this.panSetting.Controls.Add(this.groupBox4);
            this.panSetting.Controls.Add(this.groupBox3);
            this.panSetting.Controls.Add(this.groupBox2);
            this.panSetting.Controls.Add(this.label16);
            this.panSetting.Controls.Add(this.groupBox1);
            this.panSetting.Font = new System.Drawing.Font("휴먼둥근헤드라인", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panSetting.Location = new System.Drawing.Point(1047, 4);
            this.panSetting.Name = "panSetting";
            this.panSetting.Size = new System.Drawing.Size(165, 602);
            this.panSetting.TabIndex = 52;
            this.panSetting.Visible = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnM3Set);
            this.groupBox7.Controls.Add(this.btnM3ccw);
            this.groupBox7.Controls.Add(this.btnM3cw);
            this.groupBox7.Location = new System.Drawing.Point(3, 532);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(157, 67);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "모터 3";
            // 
            // btnM3Set
            // 
            this.btnM3Set.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_checked_480;
            this.btnM3Set.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnM3Set.Location = new System.Drawing.Point(57, 21);
            this.btnM3Set.Name = "btnM3Set";
            this.btnM3Set.Size = new System.Drawing.Size(45, 40);
            this.btnM3Set.TabIndex = 2;
            this.btnM3Set.UseVisualStyleBackColor = true;
            this.btnM3Set.Click += new System.EventHandler(this.btnM3Set_Click);
            // 
            // btnM3ccw
            // 
            this.btnM3ccw.BackgroundImage = global::WinformUnity.Properties.Resources.ccw;
            this.btnM3ccw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnM3ccw.Location = new System.Drawing.Point(6, 21);
            this.btnM3ccw.Name = "btnM3ccw";
            this.btnM3ccw.Size = new System.Drawing.Size(45, 40);
            this.btnM3ccw.TabIndex = 1;
            this.btnM3ccw.UseVisualStyleBackColor = true;
            this.btnM3ccw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnM3ccw_MouseDown);
            this.btnM3ccw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnM3ccw_MouseUp);
            // 
            // btnM3cw
            // 
            this.btnM3cw.BackgroundImage = global::WinformUnity.Properties.Resources.cw;
            this.btnM3cw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnM3cw.Location = new System.Drawing.Point(106, 21);
            this.btnM3cw.Name = "btnM3cw";
            this.btnM3cw.Size = new System.Drawing.Size(45, 40);
            this.btnM3cw.TabIndex = 0;
            this.btnM3cw.UseVisualStyleBackColor = true;
            this.btnM3cw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnM3cw_MouseDown);
            this.btnM3cw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnM3cw_MouseUp);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnM2Set);
            this.groupBox6.Controls.Add(this.btnM2ccw);
            this.groupBox6.Controls.Add(this.btnM2cw);
            this.groupBox6.Location = new System.Drawing.Point(3, 464);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(157, 67);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "모터 2";
            // 
            // btnM2Set
            // 
            this.btnM2Set.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_checked_480;
            this.btnM2Set.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnM2Set.Location = new System.Drawing.Point(57, 21);
            this.btnM2Set.Name = "btnM2Set";
            this.btnM2Set.Size = new System.Drawing.Size(45, 40);
            this.btnM2Set.TabIndex = 2;
            this.btnM2Set.UseVisualStyleBackColor = true;
            this.btnM2Set.Click += new System.EventHandler(this.btnM2Set_Click);
            // 
            // btnM2ccw
            // 
            this.btnM2ccw.BackgroundImage = global::WinformUnity.Properties.Resources.ccw;
            this.btnM2ccw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnM2ccw.Location = new System.Drawing.Point(6, 21);
            this.btnM2ccw.Name = "btnM2ccw";
            this.btnM2ccw.Size = new System.Drawing.Size(45, 40);
            this.btnM2ccw.TabIndex = 1;
            this.btnM2ccw.UseVisualStyleBackColor = true;
            this.btnM2ccw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnM2ccw_MouseDown);
            this.btnM2ccw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnM2ccw_MouseUp);
            // 
            // btnM2cw
            // 
            this.btnM2cw.BackgroundImage = global::WinformUnity.Properties.Resources.cw;
            this.btnM2cw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnM2cw.Location = new System.Drawing.Point(106, 21);
            this.btnM2cw.Name = "btnM2cw";
            this.btnM2cw.Size = new System.Drawing.Size(45, 40);
            this.btnM2cw.TabIndex = 0;
            this.btnM2cw.UseVisualStyleBackColor = true;
            this.btnM2cw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnM2cw_MouseDown);
            this.btnM2cw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnM2cw_MouseUp);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnM1Set);
            this.groupBox5.Controls.Add(this.btnM1ccw);
            this.groupBox5.Controls.Add(this.btnM1cw);
            this.groupBox5.Location = new System.Drawing.Point(3, 396);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(157, 67);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "모터 1";
            // 
            // btnM1Set
            // 
            this.btnM1Set.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_checked_480;
            this.btnM1Set.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnM1Set.Location = new System.Drawing.Point(57, 21);
            this.btnM1Set.Name = "btnM1Set";
            this.btnM1Set.Size = new System.Drawing.Size(45, 40);
            this.btnM1Set.TabIndex = 2;
            this.btnM1Set.UseVisualStyleBackColor = true;
            this.btnM1Set.Click += new System.EventHandler(this.btnM1Set_Click);
            // 
            // btnM1ccw
            // 
            this.btnM1ccw.BackgroundImage = global::WinformUnity.Properties.Resources.ccw;
            this.btnM1ccw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnM1ccw.Location = new System.Drawing.Point(6, 21);
            this.btnM1ccw.Name = "btnM1ccw";
            this.btnM1ccw.Size = new System.Drawing.Size(45, 40);
            this.btnM1ccw.TabIndex = 1;
            this.btnM1ccw.UseVisualStyleBackColor = true;
            this.btnM1ccw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnM1ccw_MouseDown);
            this.btnM1ccw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnM1ccw_MouseUp);
            // 
            // btnM1cw
            // 
            this.btnM1cw.BackgroundImage = global::WinformUnity.Properties.Resources.cw;
            this.btnM1cw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnM1cw.Location = new System.Drawing.Point(106, 21);
            this.btnM1cw.Name = "btnM1cw";
            this.btnM1cw.Size = new System.Drawing.Size(45, 40);
            this.btnM1cw.TabIndex = 0;
            this.btnM1cw.UseVisualStyleBackColor = true;
            this.btnM1cw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnM1cw_MouseDown);
            this.btnM1cw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnM1cw_MouseUp);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnM0Set);
            this.groupBox4.Controls.Add(this.btnM0ccw);
            this.groupBox4.Controls.Add(this.btnM0cw);
            this.groupBox4.Location = new System.Drawing.Point(3, 328);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(157, 67);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "모터 0";
            // 
            // btnM0Set
            // 
            this.btnM0Set.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_checked_480;
            this.btnM0Set.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnM0Set.Location = new System.Drawing.Point(57, 21);
            this.btnM0Set.Name = "btnM0Set";
            this.btnM0Set.Size = new System.Drawing.Size(45, 40);
            this.btnM0Set.TabIndex = 2;
            this.btnM0Set.UseVisualStyleBackColor = true;
            this.btnM0Set.Click += new System.EventHandler(this.btnM0Set_Click);
            // 
            // btnM0ccw
            // 
            this.btnM0ccw.BackgroundImage = global::WinformUnity.Properties.Resources.ccw;
            this.btnM0ccw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnM0ccw.Location = new System.Drawing.Point(6, 21);
            this.btnM0ccw.Name = "btnM0ccw";
            this.btnM0ccw.Size = new System.Drawing.Size(45, 40);
            this.btnM0ccw.TabIndex = 1;
            this.btnM0ccw.UseVisualStyleBackColor = true;
            this.btnM0ccw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnM0ccw_MouseDown);
            this.btnM0ccw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnM0ccw_MouseUp);
            // 
            // btnM0cw
            // 
            this.btnM0cw.BackgroundImage = global::WinformUnity.Properties.Resources.cw;
            this.btnM0cw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnM0cw.Location = new System.Drawing.Point(106, 21);
            this.btnM0cw.Name = "btnM0cw";
            this.btnM0cw.Size = new System.Drawing.Size(45, 40);
            this.btnM0cw.TabIndex = 0;
            this.btnM0cw.UseVisualStyleBackColor = true;
            this.btnM0cw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnM0cw_MouseDown);
            this.btnM0cw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnM0cw_MouseUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radRHeavy);
            this.groupBox3.Controls.Add(this.radRNormal);
            this.groupBox3.Controls.Add(this.radRLight);
            this.groupBox3.Location = new System.Drawing.Point(3, 226);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(157, 101);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "우측 상체운동 강도";
            // 
            // radRHeavy
            // 
            this.radRHeavy.AutoSize = true;
            this.radRHeavy.Location = new System.Drawing.Point(21, 70);
            this.radRHeavy.Name = "radRHeavy";
            this.radRHeavy.Size = new System.Drawing.Size(72, 17);
            this.radRHeavy.TabIndex = 2;
            this.radRHeavy.Text = "Heavy";
            this.radRHeavy.UseVisualStyleBackColor = true;
            // 
            // radRNormal
            // 
            this.radRNormal.AutoSize = true;
            this.radRNormal.Checked = true;
            this.radRNormal.Location = new System.Drawing.Point(21, 47);
            this.radRNormal.Name = "radRNormal";
            this.radRNormal.Size = new System.Drawing.Size(79, 17);
            this.radRNormal.TabIndex = 1;
            this.radRNormal.TabStop = true;
            this.radRNormal.Text = "Normal";
            this.radRNormal.UseVisualStyleBackColor = true;
            // 
            // radRLight
            // 
            this.radRLight.AutoSize = true;
            this.radRLight.Location = new System.Drawing.Point(21, 24);
            this.radRLight.Name = "radRLight";
            this.radRLight.Size = new System.Drawing.Size(66, 17);
            this.radRLight.TabIndex = 0;
            this.radRLight.Text = "Light";
            this.radRLight.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radLHeavy);
            this.groupBox2.Controls.Add(this.radLNormal);
            this.groupBox2.Controls.Add(this.radLLight);
            this.groupBox2.Location = new System.Drawing.Point(3, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 101);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "좌측 상체운동 강도";
            // 
            // radLHeavy
            // 
            this.radLHeavy.AutoSize = true;
            this.radLHeavy.Location = new System.Drawing.Point(21, 70);
            this.radLHeavy.Name = "radLHeavy";
            this.radLHeavy.Size = new System.Drawing.Size(72, 17);
            this.radLHeavy.TabIndex = 2;
            this.radLHeavy.Text = "Heavy";
            this.radLHeavy.UseVisualStyleBackColor = true;
            // 
            // radLNormal
            // 
            this.radLNormal.AutoSize = true;
            this.radLNormal.Checked = true;
            this.radLNormal.Location = new System.Drawing.Point(21, 47);
            this.radLNormal.Name = "radLNormal";
            this.radLNormal.Size = new System.Drawing.Size(79, 17);
            this.radLNormal.TabIndex = 1;
            this.radLNormal.TabStop = true;
            this.radLNormal.Text = "Normal";
            this.radLNormal.UseVisualStyleBackColor = true;
            // 
            // radLLight
            // 
            this.radLLight.AutoSize = true;
            this.radLLight.Location = new System.Drawing.Point(21, 24);
            this.radLLight.Name = "radLLight";
            this.radLLight.Size = new System.Drawing.Size(66, 17);
            this.radLLight.TabIndex = 0;
            this.radLLight.Text = "Light";
            this.radLLight.UseVisualStyleBackColor = false;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(163, 16);
            this.label16.TabIndex = 53;
            this.label16.Text = "설정";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radMpFast);
            this.groupBox1.Controls.Add(this.radMpNormal);
            this.groupBox1.Controls.Add(this.radMpSlow);
            this.groupBox1.Location = new System.Drawing.Point(3, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "모션 플랫폼 속도";
            // 
            // radMpFast
            // 
            this.radMpFast.AutoSize = true;
            this.radMpFast.Location = new System.Drawing.Point(21, 70);
            this.radMpFast.Name = "radMpFast";
            this.radMpFast.Size = new System.Drawing.Size(59, 17);
            this.radMpFast.TabIndex = 2;
            this.radMpFast.Text = "Fast";
            this.radMpFast.UseVisualStyleBackColor = true;
            // 
            // radMpNormal
            // 
            this.radMpNormal.AutoSize = true;
            this.radMpNormal.Checked = true;
            this.radMpNormal.Location = new System.Drawing.Point(21, 47);
            this.radMpNormal.Name = "radMpNormal";
            this.radMpNormal.Size = new System.Drawing.Size(79, 17);
            this.radMpNormal.TabIndex = 1;
            this.radMpNormal.TabStop = true;
            this.radMpNormal.Text = "Normal";
            this.radMpNormal.UseVisualStyleBackColor = true;
            // 
            // radMpSlow
            // 
            this.radMpSlow.AutoSize = true;
            this.radMpSlow.Location = new System.Drawing.Point(21, 24);
            this.radMpSlow.Name = "radMpSlow";
            this.radMpSlow.Size = new System.Drawing.Size(61, 17);
            this.radMpSlow.TabIndex = 0;
            this.radMpSlow.Text = "Slow";
            this.radMpSlow.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Silver;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStatus.Location = new System.Drawing.Point(0, 689);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1220, 51);
            this.lblStatus.TabIndex = 53;
            this.lblStatus.Text = "대기중입니다.";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Location = new System.Drawing.Point(3, 676);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 10);
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // btn사용자등록
            // 
            this.btn사용자등록.BackColor = System.Drawing.Color.White;
            this.btn사용자등록.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_name_tag_96;
            this.btn사용자등록.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn사용자등록.ForeColor = System.Drawing.Color.White;
            this.btn사용자등록.Location = new System.Drawing.Point(107, 151);
            this.btn사용자등록.Name = "btn사용자등록";
            this.btn사용자등록.Size = new System.Drawing.Size(100, 100);
            this.btn사용자등록.TabIndex = 49;
            this.btn사용자등록.UseVisualStyleBackColor = false;
            // 
            // btn족압측정
            // 
            this.btn족압측정.BackColor = System.Drawing.Color.White;
            this.btn족압측정.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_baby_feet_96;
            this.btn족압측정.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn족압측정.ForeColor = System.Drawing.Color.White;
            this.btn족압측정.Location = new System.Drawing.Point(3, 151);
            this.btn족압측정.Name = "btn족압측정";
            this.btn족압측정.Size = new System.Drawing.Size(100, 100);
            this.btn족압측정.TabIndex = 47;
            this.btn족압측정.UseVisualStyleBackColor = false;
            this.btn족압측정.Click += new System.EventHandler(this.btn족압측정_Click);
            // 
            // btn긴급종료
            // 
            this.btn긴급종료.BackColor = System.Drawing.Color.White;
            this.btn긴급종료.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_cancel_480;
            this.btn긴급종료.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn긴급종료.ForeColor = System.Drawing.Color.White;
            this.btn긴급종료.Location = new System.Drawing.Point(211, 4);
            this.btn긴급종료.Name = "btn긴급종료";
            this.btn긴급종료.Size = new System.Drawing.Size(100, 100);
            this.btn긴급종료.TabIndex = 41;
            this.btn긴급종료.UseVisualStyleBackColor = false;
            this.btn긴급종료.Click += new System.EventHandler(this.btn긴급종료_Click);
            // 
            // btn일시정지
            // 
            this.btn일시정지.BackColor = System.Drawing.Color.White;
            this.btn일시정지.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_sleep_mode_96;
            this.btn일시정지.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn일시정지.ForeColor = System.Drawing.Color.White;
            this.btn일시정지.Location = new System.Drawing.Point(107, 4);
            this.btn일시정지.Name = "btn일시정지";
            this.btn일시정지.Size = new System.Drawing.Size(100, 100);
            this.btn일시정지.TabIndex = 40;
            this.btn일시정지.UseVisualStyleBackColor = false;
            this.btn일시정지.Click += new System.EventHandler(this.btn일시정지_Click);
            // 
            // btn데이터
            // 
            this.btn데이터.BackColor = System.Drawing.Color.White;
            this.btn데이터.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_combo_chart_96;
            this.btn데이터.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn데이터.ForeColor = System.Drawing.Color.White;
            this.btn데이터.Location = new System.Drawing.Point(731, 4);
            this.btn데이터.Name = "btn데이터";
            this.btn데이터.Size = new System.Drawing.Size(100, 100);
            this.btn데이터.TabIndex = 39;
            this.btn데이터.UseVisualStyleBackColor = false;
            // 
            // btn종료
            // 
            this.btn종료.BackColor = System.Drawing.Color.White;
            this.btn종료.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_shutdown_96;
            this.btn종료.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn종료.ForeColor = System.Drawing.Color.White;
            this.btn종료.Location = new System.Drawing.Point(941, 4);
            this.btn종료.Name = "btn종료";
            this.btn종료.Size = new System.Drawing.Size(100, 100);
            this.btn종료.TabIndex = 38;
            this.btn종료.UseVisualStyleBackColor = false;
            // 
            // btn설정
            // 
            this.btn설정.BackColor = System.Drawing.Color.White;
            this.btn설정.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_settings_480;
            this.btn설정.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn설정.ForeColor = System.Drawing.Color.White;
            this.btn설정.Location = new System.Drawing.Point(835, 4);
            this.btn설정.Name = "btn설정";
            this.btn설정.Size = new System.Drawing.Size(100, 100);
            this.btn설정.TabIndex = 38;
            this.btn설정.UseVisualStyleBackColor = false;
            this.btn설정.Click += new System.EventHandler(this.btn설정_Click);
            // 
            // btn하지운동
            // 
            this.btn하지운동.BackColor = System.Drawing.Color.White;
            this.btn하지운동.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_leg_96;
            this.btn하지운동.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn하지운동.Enabled = false;
            this.btn하지운동.ForeColor = System.Drawing.Color.White;
            this.btn하지운동.Location = new System.Drawing.Point(627, 4);
            this.btn하지운동.Name = "btn하지운동";
            this.btn하지운동.Size = new System.Drawing.Size(100, 100);
            this.btn하지운동.TabIndex = 37;
            this.btn하지운동.UseVisualStyleBackColor = false;
            this.btn하지운동.Click += new System.EventHandler(this.btn하지운동_Click);
            // 
            // btn상지운동
            // 
            this.btn상지운동.BackColor = System.Drawing.Color.White;
            this.btn상지운동.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_torso_96;
            this.btn상지운동.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn상지운동.ForeColor = System.Drawing.Color.White;
            this.btn상지운동.Location = new System.Drawing.Point(523, 4);
            this.btn상지운동.Name = "btn상지운동";
            this.btn상지운동.Size = new System.Drawing.Size(100, 100);
            this.btn상지운동.TabIndex = 36;
            this.btn상지운동.UseVisualStyleBackColor = false;
            this.btn상지운동.Click += new System.EventHandler(this.btn상지운동_Click);
            // 
            // btn스키모드
            // 
            this.btn스키모드.BackColor = System.Drawing.Color.White;
            this.btn스키모드.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_ski_simulator_96;
            this.btn스키모드.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn스키모드.ForeColor = System.Drawing.Color.White;
            this.btn스키모드.Location = new System.Drawing.Point(419, 4);
            this.btn스키모드.Name = "btn스키모드";
            this.btn스키모드.Size = new System.Drawing.Size(100, 100);
            this.btn스키모드.TabIndex = 35;
            this.btn스키모드.UseVisualStyleBackColor = false;
            this.btn스키모드.Click += new System.EventHandler(this.btn스키모드_Click);
            // 
            // btn코치모드
            // 
            this.btn코치모드.BackColor = System.Drawing.Color.White;
            this.btn코치모드.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_personal_trainer_96;
            this.btn코치모드.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn코치모드.ForeColor = System.Drawing.Color.White;
            this.btn코치모드.Location = new System.Drawing.Point(315, 4);
            this.btn코치모드.Name = "btn코치모드";
            this.btn코치모드.Size = new System.Drawing.Size(100, 100);
            this.btn코치모드.TabIndex = 34;
            this.btn코치모드.UseVisualStyleBackColor = false;
            this.btn코치모드.Click += new System.EventHandler(this.btn코치모드_Click);
            // 
            // btn초기화
            // 
            this.btn초기화.BackColor = System.Drawing.Color.White;
            this.btn초기화.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_restart_filled_480;
            this.btn초기화.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn초기화.ForeColor = System.Drawing.Color.White;
            this.btn초기화.Location = new System.Drawing.Point(3, 4);
            this.btn초기화.Name = "btn초기화";
            this.btn초기화.Size = new System.Drawing.Size(100, 100);
            this.btn초기화.TabIndex = 33;
            this.btn초기화.UseVisualStyleBackColor = false;
            this.btn초기화.Click += new System.EventHandler(this.btn초기화_Click);
            // 
            // pbStream
            // 
            this.pbStream.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbStream.Image = global::WinformUnity.Properties.Resources.sk;
            this.pbStream.InitialImage = null;
            this.pbStream.Location = new System.Drawing.Point(295, 140);
            this.pbStream.Name = "pbStream";
            this.pbStream.Size = new System.Drawing.Size(445, 466);
            this.pbStream.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStream.TabIndex = 15;
            this.pbStream.TabStop = false;
            // 
            // serialArm
            // 
            this.serialArm.BaudRate = 115200;
            this.serialArm.RtsEnable = true;
            this.serialArm.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialArm_DataReceived);
            // 
            // tmrArm
            // 
            this.tmrArm.Tick += new System.EventHandler(this.tmrArm_Tick);
            // 
            // lblPsdL
            // 
            this.lblPsdL.AutoSize = true;
            this.lblPsdL.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPsdL.Location = new System.Drawing.Point(227, 155);
            this.lblPsdL.Name = "lblPsdL";
            this.lblPsdL.Size = new System.Drawing.Size(18, 16);
            this.lblPsdL.TabIndex = 54;
            this.lblPsdL.Text = "L";
            // 
            // lblPsdR
            // 
            this.lblPsdR.AutoSize = true;
            this.lblPsdR.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPsdR.Location = new System.Drawing.Point(227, 199);
            this.lblPsdR.Name = "lblPsdR";
            this.lblPsdR.Size = new System.Drawing.Size(19, 16);
            this.lblPsdR.TabIndex = 55;
            this.lblPsdR.Text = "R";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rdbCoach
            // 
            this.rdbCoach.AutoSize = true;
            this.rdbCoach.Checked = true;
            this.rdbCoach.Location = new System.Drawing.Point(15, 129);
            this.rdbCoach.Name = "rdbCoach";
            this.rdbCoach.Size = new System.Drawing.Size(71, 16);
            this.rdbCoach.TabIndex = 171;
            this.rdbCoach.TabStop = true;
            this.rdbCoach.Text = "가상코치";
            this.rdbCoach.UseVisualStyleBackColor = true;
            // 
            // rdbSki
            // 
            this.rdbSki.AutoSize = true;
            this.rdbSki.Location = new System.Drawing.Point(126, 129);
            this.rdbSki.Name = "rdbSki";
            this.rdbSki.Size = new System.Drawing.Size(71, 16);
            this.rdbSki.TabIndex = 172;
            this.rdbSki.Text = "가상스키";
            this.rdbSki.UseVisualStyleBackColor = true;
            // 
            // lblMonitoring
            // 
            this.lblMonitoring.AutoSize = true;
            this.lblMonitoring.Location = new System.Drawing.Point(214, 231);
            this.lblMonitoring.Name = "lblMonitoring";
            this.lblMonitoring.Size = new System.Drawing.Size(44, 12);
            this.lblMonitoring.TabIndex = 173;
            this.lblMonitoring.Text = "label19";
            // 
            // selectablePanel
            // 
            this.selectablePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectablePanel.Location = new System.Drawing.Point(746, 140);
            this.selectablePanel.Name = "selectablePanel";
            this.selectablePanel.Size = new System.Drawing.Size(295, 466);
            this.selectablePanel.TabIndex = 0;
            this.selectablePanel.TabStop = true;
            this.selectablePanel.Resize += new System.EventHandler(this.selectablePanel1_Resize);
            // 
            // TimWait
            // 
            this.TimWait.Interval = 5000;
            // 
            // ContainerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1220, 740);
            this.Controls.Add(this.lblMonitoring);
            this.Controls.Add(this.rdbSki);
            this.Controls.Add(this.rdbCoach);
            this.Controls.Add(this.lblPsdR);
            this.Controls.Add(this.lblPsdL);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panSetting);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chkHomm);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btn사용자등록);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btn족압측정);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn긴급종료);
            this.Controls.Add(this.btn일시정지);
            this.Controls.Add(this.btn데이터);
            this.Controls.Add(this.btn종료);
            this.Controls.Add(this.btn설정);
            this.Controls.Add(this.btn하지운동);
            this.Controls.Add(this.btn상지운동);
            this.Controls.Add(this.btn스키모드);
            this.Controls.Add(this.btn코치모드);
            this.Controls.Add(this.btn초기화);
            this.Controls.Add(this.selectablePanel);
            this.Controls.Add(this.pbStream);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContainerForm";
            this.Text = "Health Care System";
            this.Activated += new System.EventHandler(this.ContainerForm_Activated);
            this.Deactivate += new System.EventHandler(this.ContainerForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ContainerForm_FormClosing);
            this.Load += new System.EventHandler(this.ContainerForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBicubic)).EndInit();
            this.panSetting.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStream)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SelectablePanel selectablePanel;
        private System.IO.Ports.SerialPort serialFoot;
        private System.Windows.Forms.PictureBox pbStream;
        private System.Windows.Forms.PictureBox picBicubic;
        public System.Windows.Forms.ComboBox comboBaudrate;
        private System.Windows.Forms.ComboBox comboPort;
        private System.Windows.Forms.Timer tmrDraw;
        private System.Windows.Forms.CheckBox chkHomm;
        private System.Windows.Forms.Button btn초기화;
        private System.Windows.Forms.Button btn코치모드;
        private System.Windows.Forms.Button btn스키모드;
        private System.Windows.Forms.Button btn상지운동;
        private System.Windows.Forms.Button btn하지운동;
        private System.Windows.Forms.Button btn설정;
        private System.Windows.Forms.Button btn데이터;
        private System.Windows.Forms.Button btn일시정지;
        private System.Windows.Forms.Button btn긴급종료;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn족압측정;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn사용자등록;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn종료;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panSetting;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.RadioButton radMpSlow;
        private System.Windows.Forms.RadioButton radMpFast;
        private System.Windows.Forms.RadioButton radMpNormal;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnM0cw;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radRHeavy;
        private System.Windows.Forms.RadioButton radRNormal;
        private System.Windows.Forms.RadioButton radRLight;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radLHeavy;
        private System.Windows.Forms.RadioButton radLNormal;
        private System.Windows.Forms.RadioButton radLLight;
        private System.Windows.Forms.Button btnM0Set;
        private System.Windows.Forms.Button btnM0ccw;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnM3Set;
        private System.Windows.Forms.Button btnM3ccw;
        private System.Windows.Forms.Button btnM3cw;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnM2Set;
        private System.Windows.Forms.Button btnM2ccw;
        private System.Windows.Forms.Button btnM2cw;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnM1Set;
        private System.Windows.Forms.Button btnM1ccw;
        private System.Windows.Forms.Button btnM1cw;
        private System.IO.Ports.SerialPort serialArm;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboArm;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkConnect;
        private System.Windows.Forms.Timer tmrArm;
        private System.Windows.Forms.Label lblPsdL;
        private System.Windows.Forms.Label lblPsdR;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton rdbCoach;
        private System.Windows.Forms.RadioButton rdbSki;
        private System.Windows.Forms.Label lblMonitoring;
        private System.Windows.Forms.Timer TimWait;
    }
}

