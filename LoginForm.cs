using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinformUnity
{
    public partial class LoginForm : Form
    {
        Log PersonalLog = new Log();
        private List<Log> lg; bool TrueID = false;
        AzureMobileService AMS = new AzureMobileService();
        Thread th;
        public LoginForm()
        {
            InitializeComponent();
            th = new Thread(OpenNewForm);
            th.SetApartmentState(ApartmentState.STA);
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            
            pnlSignUp.Visible = !pnlSignUp.Visible;
        }

        private async void btnSignUpandIn_Click(object sender, EventArgs e)
        {
            lg = await AMS.GetAllLogs();
            PersonalLog.names = txtName.Text;
            PersonalLog.passwords = txtPW.Text;
            PersonalLog.age = txtAge.Text;
            if (radMale.Checked) PersonalLog.sex = radMale.Text;
            else if (radFemale.Checked) PersonalLog.sex = radFemale.Text;
            PersonalLog.weight = txtWeight.Text;
            PersonalLog.height = txtHeight.Text;
            th.Start();
            this.Close();
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                lg = await AMS.GetAllLogs();
                foreach (Log logs in lg)
                {
                    if (txtNamein.Text == logs.names && txtPWin.Text == logs.passwords)
                    {
                        PersonalLog.names = logs.names;
                        PersonalLog.passwords = logs.passwords;
                        PersonalLog.age = logs.age;
                        PersonalLog.sex = logs.sex;
                        PersonalLog.weight = logs.weight;
                        PersonalLog.height = logs.height;
                        TrueID = true;
                        th.Start();
                        this.Close();
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Server Data Access Error");
                this.Close();
            }
            
            if(!TrueID)MessageBox.Show("잘못된 이름과 비밀번호입니다");
        }

        private void OpenNewForm(object obj)
        {
            Application.Run(new ContainerForm(PersonalLog, AMS));
        }

    }
}
