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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.serialFoot = new System.IO.Ports.SerialPort(this.components);
            this.chkHomm = new System.Windows.Forms.CheckBox();
            this.comboPort = new System.Windows.Forms.ComboBox();
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
            this.chkConnect = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.comboArm = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.picBicubic = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panSetting = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.chkFoot = new System.Windows.Forms.CheckBox();
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
            this.radRzero = new System.Windows.Forms.RadioButton();
            this.radRHeavy = new System.Windows.Forms.RadioButton();
            this.radRNormal = new System.Windows.Forms.RadioButton();
            this.radRLight = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radLzero = new System.Windows.Forms.RadioButton();
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
            this.btn족압측정 = new System.Windows.Forms.Button();
            this.btn긴급종료 = new System.Windows.Forms.Button();
            this.btn전환 = new System.Windows.Forms.Button();
            this.btn데이터 = new System.Windows.Forms.Button();
            this.btn종료 = new System.Windows.Forms.Button();
            this.btn설정 = new System.Windows.Forms.Button();
            this.btn하지운동 = new System.Windows.Forms.Button();
            this.btn상지운동 = new System.Windows.Forms.Button();
            this.btn스키모드 = new System.Windows.Forms.Button();
            this.btn코치모드 = new System.Windows.Forms.Button();
            this.pbStream = new System.Windows.Forms.PictureBox();
            this.serialArm = new System.IO.Ports.SerialPort(this.components);
            this.lblPsdL = new System.Windows.Forms.Label();
            this.lblPsdR = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radVoyage = new System.Windows.Forms.RadioButton();
            this.btnUNreset = new System.Windows.Forms.Button();
            this.radCometDodge = new System.Windows.Forms.RadioButton();
            this.radSKI = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBalancing = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.panData = new System.Windows.Forms.Panel();
            this.chtArm = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.selectablePanel = new WinformUnity.SelectablePanel();
            ((System.ComponentModel.ISupportInitialize)(this.picBicubic)).BeginInit();
            this.panSetting.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStream)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtArm)).BeginInit();
            this.SuspendLayout();
            // 
            // serialFoot
            // 
            this.serialFoot.BaudRate = 921600;
            this.serialFoot.PortName = "COM17";
            this.serialFoot.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialFoot_DataReceived);
            // 
            // chkHomm
            // 
            this.chkHomm.AutoSize = true;
            this.chkHomm.ForeColor = System.Drawing.Color.Black;
            this.chkHomm.Location = new System.Drawing.Point(166, 172);
            this.chkHomm.Name = "chkHomm";
            this.chkHomm.Size = new System.Drawing.Size(82, 17);
            this.chkHomm.TabIndex = 170;
            this.chkHomm.Text = "Homing";
            this.chkHomm.UseVisualStyleBackColor = true;
            // 
            // comboPort
            // 
            this.comboPort.FormattingEnabled = true;
            this.comboPort.Location = new System.Drawing.Point(6, 106);
            this.comboPort.Name = "comboPort";
            this.comboPort.Size = new System.Drawing.Size(161, 21);
            this.comboPort.TabIndex = 168;
            this.comboPort.Text = "포트를 선택하세요.";
            this.comboPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboPort_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(322, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 42;
            this.label2.Text = "코치-VR전환";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(443, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "긴급종료";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(17, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 42;
            this.label4.Text = "가상 코치";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(121, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 42;
            this.label5.Text = "가상 게임";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(545, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 42;
            this.label6.Text = "상체 운동";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(651, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 16);
            this.label7.TabIndex = 42;
            this.label7.Text = "체조 운동";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(769, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 16);
            this.label8.TabIndex = 42;
            this.label8.Text = "데이터";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(882, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 16);
            this.label9.TabIndex = 42;
            this.label9.Text = "설정";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("휴먼둥근헤드라인", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(470, 641);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 19);
            this.label10.TabIndex = 43;
            this.label10.Text = "자세 측정";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("휴먼둥근헤드라인", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(885, 641);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 19);
            this.label11.TabIndex = 44;
            this.label11.Text = "화면";
            // 
            // chkConnect
            // 
            this.chkConnect.AutoSize = true;
            this.chkConnect.Font = new System.Drawing.Font("휴먼둥근헤드라인", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkConnect.Location = new System.Drawing.Point(108, 21);
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
            this.label18.Location = new System.Drawing.Point(4, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 16);
            this.label18.TabIndex = 170;
            this.label18.Text = "상체 운동:";
            // 
            // comboArm
            // 
            this.comboArm.FormattingEnabled = true;
            this.comboArm.Location = new System.Drawing.Point(6, 46);
            this.comboArm.Name = "comboArm";
            this.comboArm.Size = new System.Drawing.Size(161, 21);
            this.comboArm.TabIndex = 171;
            this.comboArm.Text = "포트를 선택하세요.";
            this.comboArm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboArm_MouseDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.Location = new System.Drawing.Point(6, 84);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 16);
            this.label17.TabIndex = 54;
            this.label17.Text = "족 저압 센서:";
            // 
            // picBicubic
            // 
            this.picBicubic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.picBicubic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBicubic.BackgroundImage")));
            this.picBicubic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBicubic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBicubic.Location = new System.Drawing.Point(5, 321);
            this.picBicubic.Name = "picBicubic";
            this.picBicubic.Size = new System.Drawing.Size(302, 313);
            this.picBicubic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBicubic.TabIndex = 30;
            this.picBicubic.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("휴먼둥근헤드라인", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(88, 641);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 19);
            this.label12.TabIndex = 46;
            this.label12.Text = "족 저압 측정";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(2, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 16);
            this.label13.TabIndex = 48;
            this.label13.Text = "족 저압 측정";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(988, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 16);
            this.label15.TabIndex = 42;
            this.label15.Text = "종료";
            // 
            // panSetting
            // 
            this.panSetting.BackColor = System.Drawing.Color.White;
            this.panSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSetting.Controls.Add(this.groupBox8);
            this.panSetting.Controls.Add(this.groupBox7);
            this.panSetting.Controls.Add(this.groupBox6);
            this.panSetting.Controls.Add(this.groupBox5);
            this.panSetting.Controls.Add(this.groupBox4);
            this.panSetting.Controls.Add(this.groupBox3);
            this.panSetting.Controls.Add(this.groupBox2);
            this.panSetting.Controls.Add(this.label16);
            this.panSetting.Controls.Add(this.groupBox1);
            this.panSetting.Controls.Add(this.chkHomm);
            this.panSetting.Font = new System.Drawing.Font("휴먼둥근헤드라인", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panSetting.Location = new System.Drawing.Point(1078, 4);
            this.panSetting.Name = "panSetting";
            this.panSetting.Size = new System.Drawing.Size(369, 480);
            this.panSetting.TabIndex = 52;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.chkFoot);
            this.groupBox8.Controls.Add(this.chkConnect);
            this.groupBox8.Controls.Add(this.comboArm);
            this.groupBox8.Controls.Add(this.label17);
            this.groupBox8.Controls.Add(this.comboPort);
            this.groupBox8.Controls.Add(this.label18);
            this.groupBox8.Location = new System.Drawing.Point(166, 23);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(173, 142);
            this.groupBox8.TabIndex = 171;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "포트설정";
            // 
            // chkFoot
            // 
            this.chkFoot.AutoSize = true;
            this.chkFoot.Font = new System.Drawing.Font("휴먼둥근헤드라인", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkFoot.Location = new System.Drawing.Point(108, 82);
            this.chkFoot.Name = "chkFoot";
            this.chkFoot.Size = new System.Drawing.Size(59, 21);
            this.chkFoot.TabIndex = 172;
            this.chkFoot.Text = "족압";
            this.chkFoot.UseVisualStyleBackColor = true;
            this.chkFoot.CheckedChanged += new System.EventHandler(this.chkFoot_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnM3Set);
            this.groupBox7.Controls.Add(this.btnM3ccw);
            this.groupBox7.Controls.Add(this.btnM3cw);
            this.groupBox7.Location = new System.Drawing.Point(166, 404);
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
            this.groupBox6.Location = new System.Drawing.Point(166, 336);
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
            this.groupBox5.Location = new System.Drawing.Point(166, 268);
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
            this.btnM1ccw.Click += new System.EventHandler(this.btnM1ccw_Click);
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
            this.btnM1cw.Click += new System.EventHandler(this.btnM1cw_Click);
            this.btnM1cw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnM1cw_MouseDown);
            this.btnM1cw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnM1cw_MouseUp);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnM0Set);
            this.groupBox4.Controls.Add(this.btnM0ccw);
            this.groupBox4.Controls.Add(this.btnM0cw);
            this.groupBox4.Location = new System.Drawing.Point(166, 200);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(157, 67);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "모터 0";
            // 
            // btnM0Set
            // 
            this.btnM0Set.BackColor = System.Drawing.Color.Transparent;
            this.btnM0Set.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_checked_480;
            this.btnM0Set.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnM0Set.Location = new System.Drawing.Point(57, 21);
            this.btnM0Set.Name = "btnM0Set";
            this.btnM0Set.Size = new System.Drawing.Size(45, 40);
            this.btnM0Set.TabIndex = 2;
            this.btnM0Set.UseVisualStyleBackColor = false;
            this.btnM0Set.Click += new System.EventHandler(this.btnM0Set_Click);
            // 
            // btnM0ccw
            // 
            this.btnM0ccw.BackColor = System.Drawing.Color.Transparent;
            this.btnM0ccw.BackgroundImage = global::WinformUnity.Properties.Resources.ccw;
            this.btnM0ccw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnM0ccw.Location = new System.Drawing.Point(6, 21);
            this.btnM0ccw.Name = "btnM0ccw";
            this.btnM0ccw.Size = new System.Drawing.Size(45, 40);
            this.btnM0ccw.TabIndex = 1;
            this.btnM0ccw.UseVisualStyleBackColor = false;
            this.btnM0ccw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnM0ccw_MouseDown);
            this.btnM0ccw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnM0ccw_MouseUp);
            // 
            // btnM0cw
            // 
            this.btnM0cw.BackColor = System.Drawing.Color.Transparent;
            this.btnM0cw.BackgroundImage = global::WinformUnity.Properties.Resources.cw;
            this.btnM0cw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnM0cw.Location = new System.Drawing.Point(106, 21);
            this.btnM0cw.Name = "btnM0cw";
            this.btnM0cw.Size = new System.Drawing.Size(45, 40);
            this.btnM0cw.TabIndex = 0;
            this.btnM0cw.UseVisualStyleBackColor = false;
            this.btnM0cw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnM0cw_MouseDown);
            this.btnM0cw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnM0cw_MouseUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radRzero);
            this.groupBox3.Controls.Add(this.radRHeavy);
            this.groupBox3.Controls.Add(this.radRNormal);
            this.groupBox3.Controls.Add(this.radRLight);
            this.groupBox3.Location = new System.Drawing.Point(3, 256);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(157, 126);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "우측 상체운동 강도";
            // 
            // radRzero
            // 
            this.radRzero.AutoSize = true;
            this.radRzero.Location = new System.Drawing.Point(21, 93);
            this.radRzero.Name = "radRzero";
            this.radRzero.Size = new System.Drawing.Size(67, 17);
            this.radRzero.TabIndex = 4;
            this.radRzero.Text = "Basic";
            this.radRzero.UseVisualStyleBackColor = false;
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
            this.groupBox2.Controls.Add(this.radLzero);
            this.groupBox2.Controls.Add(this.radLHeavy);
            this.groupBox2.Controls.Add(this.radLNormal);
            this.groupBox2.Controls.Add(this.radLLight);
            this.groupBox2.Location = new System.Drawing.Point(3, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 126);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "좌측 상체운동 강도";
            // 
            // radLzero
            // 
            this.radLzero.AutoSize = true;
            this.radLzero.Location = new System.Drawing.Point(21, 93);
            this.radLzero.Name = "radLzero";
            this.radLzero.Size = new System.Drawing.Size(67, 17);
            this.radLzero.TabIndex = 3;
            this.radLzero.Text = "Basic";
            this.radLzero.UseVisualStyleBackColor = false;
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
            this.label16.Size = new System.Drawing.Size(367, 16);
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
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Font = new System.Drawing.Font("휴먼둥근헤드라인", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblStatus.Location = new System.Drawing.Point(0, 689);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1447, 51);
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
            // btn족압측정
            // 
            this.btn족압측정.BackColor = System.Drawing.Color.Transparent;
            this.btn족압측정.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_baby_feet_96;
            this.btn족압측정.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn족압측정.FlatAppearance.BorderSize = 0;
            this.btn족압측정.ForeColor = System.Drawing.Color.White;
            this.btn족압측정.Location = new System.Drawing.Point(1, 3);
            this.btn족압측정.Name = "btn족압측정";
            this.btn족압측정.Size = new System.Drawing.Size(100, 100);
            this.btn족압측정.TabIndex = 47;
            this.btn족압측정.UseVisualStyleBackColor = false;
            this.btn족압측정.Click += new System.EventHandler(this.btn족압측정_Click);
            // 
            // btn긴급종료
            // 
            this.btn긴급종료.BackColor = System.Drawing.Color.Transparent;
            this.btn긴급종료.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_cancel_480;
            this.btn긴급종료.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn긴급종료.FlatAppearance.BorderSize = 0;
            this.btn긴급종료.ForeColor = System.Drawing.Color.White;
            this.btn긴급종료.Location = new System.Drawing.Point(427, 5);
            this.btn긴급종료.Name = "btn긴급종료";
            this.btn긴급종료.Size = new System.Drawing.Size(100, 100);
            this.btn긴급종료.TabIndex = 41;
            this.btn긴급종료.UseVisualStyleBackColor = false;
            this.btn긴급종료.Click += new System.EventHandler(this.btn긴급종료_Click);
            // 
            // btn전환
            // 
            this.btn전환.BackColor = System.Drawing.Color.Transparent;
            this.btn전환.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_sleep_mode_96;
            this.btn전환.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn전환.Enabled = false;
            this.btn전환.FlatAppearance.BorderSize = 0;
            this.btn전환.ForeColor = System.Drawing.Color.White;
            this.btn전환.Location = new System.Drawing.Point(321, 5);
            this.btn전환.Name = "btn전환";
            this.btn전환.Size = new System.Drawing.Size(100, 100);
            this.btn전환.TabIndex = 40;
            this.btn전환.UseVisualStyleBackColor = false;
            this.btn전환.Click += new System.EventHandler(this.btn일시정지_Click);
            // 
            // btn데이터
            // 
            this.btn데이터.BackColor = System.Drawing.Color.Transparent;
            this.btn데이터.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_combo_chart_96;
            this.btn데이터.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn데이터.FlatAppearance.BorderSize = 0;
            this.btn데이터.ForeColor = System.Drawing.Color.White;
            this.btn데이터.Location = new System.Drawing.Point(745, 4);
            this.btn데이터.Name = "btn데이터";
            this.btn데이터.Size = new System.Drawing.Size(100, 100);
            this.btn데이터.TabIndex = 39;
            this.btn데이터.UseVisualStyleBackColor = false;
            this.btn데이터.Click += new System.EventHandler(this.btn데이터_Click);
            // 
            // btn종료
            // 
            this.btn종료.BackColor = System.Drawing.Color.Transparent;
            this.btn종료.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_shutdown_96;
            this.btn종료.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn종료.FlatAppearance.BorderSize = 0;
            this.btn종료.ForeColor = System.Drawing.Color.White;
            this.btn종료.Location = new System.Drawing.Point(957, 4);
            this.btn종료.Name = "btn종료";
            this.btn종료.Size = new System.Drawing.Size(100, 100);
            this.btn종료.TabIndex = 38;
            this.btn종료.UseVisualStyleBackColor = false;
            this.btn종료.Click += new System.EventHandler(this.btn종료_Click);
            // 
            // btn설정
            // 
            this.btn설정.BackColor = System.Drawing.Color.Transparent;
            this.btn설정.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_settings_480;
            this.btn설정.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn설정.FlatAppearance.BorderSize = 0;
            this.btn설정.ForeColor = System.Drawing.Color.White;
            this.btn설정.Location = new System.Drawing.Point(851, 4);
            this.btn설정.Name = "btn설정";
            this.btn설정.Size = new System.Drawing.Size(100, 100);
            this.btn설정.TabIndex = 38;
            this.btn설정.UseVisualStyleBackColor = false;
            this.btn설정.Click += new System.EventHandler(this.btn설정_Click);
            // 
            // btn하지운동
            // 
            this.btn하지운동.BackColor = System.Drawing.Color.Transparent;
            this.btn하지운동.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn하지운동.BackgroundImage")));
            this.btn하지운동.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn하지운동.Enabled = false;
            this.btn하지운동.FlatAppearance.BorderSize = 0;
            this.btn하지운동.ForeColor = System.Drawing.Color.White;
            this.btn하지운동.Location = new System.Drawing.Point(639, 4);
            this.btn하지운동.Name = "btn하지운동";
            this.btn하지운동.Size = new System.Drawing.Size(100, 100);
            this.btn하지운동.TabIndex = 37;
            this.btn하지운동.UseVisualStyleBackColor = false;
            this.btn하지운동.Click += new System.EventHandler(this.btn하지운동_Click);
            // 
            // btn상지운동
            // 
            this.btn상지운동.BackColor = System.Drawing.Color.Transparent;
            this.btn상지운동.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn상지운동.BackgroundImage")));
            this.btn상지운동.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn상지운동.Enabled = false;
            this.btn상지운동.FlatAppearance.BorderSize = 0;
            this.btn상지운동.ForeColor = System.Drawing.Color.White;
            this.btn상지운동.Location = new System.Drawing.Point(533, 4);
            this.btn상지운동.Name = "btn상지운동";
            this.btn상지운동.Size = new System.Drawing.Size(100, 100);
            this.btn상지운동.TabIndex = 36;
            this.btn상지운동.UseVisualStyleBackColor = false;
            this.btn상지운동.Click += new System.EventHandler(this.btn상지운동_Click);
            // 
            // btn스키모드
            // 
            this.btn스키모드.BackColor = System.Drawing.Color.Transparent;
            this.btn스키모드.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_ski_simulator_96;
            this.btn스키모드.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn스키모드.FlatAppearance.BorderSize = 0;
            this.btn스키모드.ForeColor = System.Drawing.Color.White;
            this.btn스키모드.Location = new System.Drawing.Point(109, 4);
            this.btn스키모드.Name = "btn스키모드";
            this.btn스키모드.Size = new System.Drawing.Size(100, 100);
            this.btn스키모드.TabIndex = 35;
            this.btn스키모드.UseVisualStyleBackColor = false;
            this.btn스키모드.Click += new System.EventHandler(this.btn스키모드_Click);
            // 
            // btn코치모드
            // 
            this.btn코치모드.BackColor = System.Drawing.Color.Transparent;
            this.btn코치모드.BackgroundImage = global::WinformUnity.Properties.Resources.icons8_personal_trainer_96;
            this.btn코치모드.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn코치모드.FlatAppearance.BorderSize = 0;
            this.btn코치모드.ForeColor = System.Drawing.Color.White;
            this.btn코치모드.Location = new System.Drawing.Point(5, 4);
            this.btn코치모드.Name = "btn코치모드";
            this.btn코치모드.Size = new System.Drawing.Size(100, 100);
            this.btn코치모드.TabIndex = 34;
            this.btn코치모드.UseVisualStyleBackColor = false;
            this.btn코치모드.Click += new System.EventHandler(this.btn코치모드_Click);
            // 
            // pbStream
            // 
            this.pbStream.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbStream.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbStream.Image = ((System.Drawing.Image)(resources.GetObject("pbStream.Image")));
            this.pbStream.InitialImage = null;
            this.pbStream.Location = new System.Drawing.Point(311, 158);
            this.pbStream.Name = "pbStream";
            this.pbStream.Size = new System.Drawing.Size(445, 476);
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
            // lblPsdL
            // 
            this.lblPsdL.AutoSize = true;
            this.lblPsdL.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPsdL.Location = new System.Drawing.Point(21, 2);
            this.lblPsdL.Name = "lblPsdL";
            this.lblPsdL.Size = new System.Drawing.Size(18, 16);
            this.lblPsdL.TabIndex = 54;
            this.lblPsdL.Text = "L";
            // 
            // lblPsdR
            // 
            this.lblPsdR.AutoSize = true;
            this.lblPsdR.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPsdR.Location = new System.Drawing.Point(207, 2);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(582, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 174;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radVoyage);
            this.panel1.Controls.Add(this.btnUNreset);
            this.panel1.Controls.Add(this.radCometDodge);
            this.panel1.Controls.Add(this.radSKI);
            this.panel1.Controls.Add(this.btn코치모드);
            this.panel1.Controls.Add(this.btn스키모드);
            this.panel1.Controls.Add(this.btn상지운동);
            this.panel1.Controls.Add(this.btn하지운동);
            this.panel1.Controls.Add(this.btn설정);
            this.panel1.Controls.Add(this.btn종료);
            this.panel1.Controls.Add(this.btn데이터);
            this.panel1.Controls.Add(this.btn전환);
            this.panel1.Controls.Add(this.btn긴급종료);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1069, 147);
            this.panel1.TabIndex = 175;
            // 
            // radVoyage
            // 
            this.radVoyage.AutoSize = true;
            this.radVoyage.Location = new System.Drawing.Point(215, 57);
            this.radVoyage.Name = "radVoyage";
            this.radVoyage.Size = new System.Drawing.Size(66, 16);
            this.radVoyage.TabIndex = 46;
            this.radVoyage.Text = "Voyage";
            this.radVoyage.UseVisualStyleBackColor = true;
            // 
            // btnUNreset
            // 
            this.btnUNreset.Font = new System.Drawing.Font("휴먼둥근헤드라인", 9F);
            this.btnUNreset.Location = new System.Drawing.Point(215, 102);
            this.btnUNreset.Name = "btnUNreset";
            this.btnUNreset.Size = new System.Drawing.Size(96, 29);
            this.btnUNreset.TabIndex = 45;
            this.btnUNreset.Text = "UnityReset";
            this.btnUNreset.UseVisualStyleBackColor = true;
            this.btnUNreset.Click += new System.EventHandler(this.btnUNreset_Click);
            // 
            // radCometDodge
            // 
            this.radCometDodge.AutoSize = true;
            this.radCometDodge.Location = new System.Drawing.Point(215, 35);
            this.radCometDodge.Name = "radCometDodge";
            this.radCometDodge.Size = new System.Drawing.Size(96, 16);
            this.radCometDodge.TabIndex = 44;
            this.radCometDodge.Text = "CometDodge";
            this.radCometDodge.UseVisualStyleBackColor = true;
            // 
            // radSKI
            // 
            this.radSKI.AutoSize = true;
            this.radSKI.Checked = true;
            this.radSKI.Location = new System.Drawing.Point(215, 8);
            this.radSKI.Name = "radSKI";
            this.radSKI.Size = new System.Drawing.Size(42, 16);
            this.radSKI.TabIndex = 43;
            this.radSKI.TabStop = true;
            this.radSKI.Text = "SKI";
            this.radSKI.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnBalancing);
            this.panel3.Controls.Add(this.btn족압측정);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Location = new System.Drawing.Point(3, 158);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(218, 141);
            this.panel3.TabIndex = 176;
            // 
            // btnBalancing
            // 
            this.btnBalancing.BackColor = System.Drawing.Color.Transparent;
            this.btnBalancing.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBalancing.BackgroundImage")));
            this.btnBalancing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBalancing.Location = new System.Drawing.Point(107, 3);
            this.btnBalancing.Name = "btnBalancing";
            this.btnBalancing.Size = new System.Drawing.Size(100, 100);
            this.btnBalancing.TabIndex = 177;
            this.btnBalancing.UseVisualStyleBackColor = false;
            this.btnBalancing.Click += new System.EventHandler(this.btnBalancing_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("휴먼둥근헤드라인", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(119, 106);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 16);
            this.label14.TabIndex = 48;
            this.label14.Text = "균형 운동";
            // 
            // panData
            // 
            this.panData.BackColor = System.Drawing.Color.White;
            this.panData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panData.Controls.Add(this.chtArm);
            this.panData.Controls.Add(this.lblPsdL);
            this.panData.Controls.Add(this.lblPsdR);
            this.panData.Location = new System.Drawing.Point(1078, 482);
            this.panData.Name = "panData";
            this.panData.Size = new System.Drawing.Size(369, 204);
            this.panData.TabIndex = 3;
            // 
            // chtArm
            // 
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.Name = "draw";
            this.chtArm.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtArm.Legends.Add(legend1);
            this.chtArm.Location = new System.Drawing.Point(3, 21);
            this.chtArm.Name = "chtArm";
            series1.BorderWidth = 2;
            series1.ChartArea = "draw";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Left";
            series2.BorderWidth = 2;
            series2.ChartArea = "draw";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Right";
            this.chtArm.Series.Add(series1);
            this.chtArm.Series.Add(series2);
            this.chtArm.Size = new System.Drawing.Size(336, 182);
            this.chtArm.TabIndex = 177;
            this.chtArm.Text = "chart1";
            // 
            // selectablePanel
            // 
            this.selectablePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.selectablePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectablePanel.Location = new System.Drawing.Point(762, 157);
            this.selectablePanel.Name = "selectablePanel";
            this.selectablePanel.Size = new System.Drawing.Size(310, 477);
            this.selectablePanel.TabIndex = 0;
            this.selectablePanel.TabStop = true;
            this.selectablePanel.Resize += new System.EventHandler(this.selectablePanel1_Resize);
            // 
            // ContainerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1447, 740);
            this.Controls.Add(this.panData);
            this.Controls.Add(this.picBicubic);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panSetting);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
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
            ((System.ComponentModel.ISupportInitialize)(this.picBicubic)).EndInit();
            this.panSetting.ResumeLayout(false);
            this.panSetting.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panData.ResumeLayout(false);
            this.panData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtArm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SelectablePanel selectablePanel;
        private System.IO.Ports.SerialPort serialFoot;
        private System.Windows.Forms.PictureBox pbStream;
        private System.Windows.Forms.PictureBox picBicubic;
        private System.Windows.Forms.ComboBox comboPort;
        private System.Windows.Forms.CheckBox chkHomm;
        private System.Windows.Forms.Button btn코치모드;
        private System.Windows.Forms.Button btn스키모드;
        private System.Windows.Forms.Button btn상지운동;
        private System.Windows.Forms.Button btn하지운동;
        private System.Windows.Forms.Button btn설정;
        private System.Windows.Forms.Button btn데이터;
        private System.Windows.Forms.Button btn전환;
        private System.Windows.Forms.Button btn긴급종료;
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
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn족압측정;
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
        private System.Windows.Forms.Label lblPsdL;
        private System.Windows.Forms.Label lblPsdR;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Panel panData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtArm;
        private System.Windows.Forms.Button btnBalancing;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton radRzero;
        private System.Windows.Forms.RadioButton radLzero;
        private System.Windows.Forms.CheckBox chkFoot;
        private System.Windows.Forms.RadioButton radCometDodge;
        private System.Windows.Forms.RadioButton radSKI;
        private System.Windows.Forms.Button btnUNreset;
        private System.Windows.Forms.RadioButton radVoyage;
    }
}

