using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailwayReservationSystem
{
    public partial class stationinfo : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn

        (
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse

        );
        public stationinfo()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panelNav.Height = StationsButton.Height;
            panelNav.Top = StationsButton.Top;
            panelNav.Left = StationsButton.Left;
            StationsButton.BackColor = Color.WhiteSmoke;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginpassenger f8 = new loginpassenger();
            f8.ShowDialog();
            this.Close();
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginpassenger f8 = new loginpassenger();
            f8.ShowDialog();
            this.Close();
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            PassengersDashboard f1 = new PassengersDashboard();
            f1.ShowDialog();
            this.Close();
        }

        private void BookingButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookTrips f1 = new BookTrips();
            f1.ShowDialog();
            this.Close();
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            passengermessage f1 = new passengermessage();
            f1.ShowDialog();
            this.Close();
        }

        private void StationsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            searchstation f1 = new searchstation();
            f1.ShowDialog();
            this.Close();
        }

        private void MyTripsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyTrips f1 = new MyTrips();
            f1.ShowDialog();
            this.Close();
        }

        private void alfredToggleButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (alfredToggleButton2.Checked)
            {
                pictureBox1.BackgroundImage = Properties.Resources.Capture7;
                label3.Text = "light theme";
                panel1.BackColor = Color.Black;
                DashboardButton.BackColor = Color.Black;
                BookingButton.BackColor = Color.Black;
                SendMessageButton.BackColor = Color.Black;
                MyTripsButton.BackColor = Color.Black;
                StationsButton.BackColor = Color.Black;
                PassengersSettingsButton.BackColor = Color.Black;
                LogOutButton.BackColor = Color.Black;

                Cancel.ForeColor = Color.White;
                label4.BackColor = Color.White;
                this.BackColor = Color.Black;

                panelNav.Height = BookingButton.Height;
                panelNav.Top = BookingButton.Top;
                panelNav.Left = BookingButton.Left;
                BookingButton.BackColor = Color.Black;


                pictureBox2.BackColor = Color.Black;
                TextBoxStationName.ForeColor = Color.White;
                TextBoxCity.ForeColor = Color.White;
                TextBoxStreet.ForeColor = Color.White;
                TextBoxOpens.ForeColor = Color.White;
                TextBoxCloses.ForeColor = Color.White;

                TextBoxStationName.BackColor = Color.Black;
                TextBoxCity.BackColor = Color.Black;
                TextBoxStreet.BackColor = Color.Black;
                TextBoxOpens.BackColor = Color.Black;
                TextBoxCloses.BackColor = Color.Black;

                label6.BackColor = Color.White;
                label5.BackColor = Color.White;
                label7.BackColor = Color.White;
                label8.BackColor = Color.White;
                label9.BackColor = Color.White;
                



            }
            else
            {
                pictureBox1.BackgroundImage = Properties.Resources.download__2_;
                label3.Text = "Dark theme";
                panel1.BackColor = Color.White;
                DashboardButton.BackColor = Color.White;
                BookingButton.BackColor = Color.White;
                SendMessageButton.BackColor = Color.White;
                MyTripsButton.BackColor = Color.White;
                StationsButton.BackColor = Color.White;
                PassengersSettingsButton.BackColor = Color.White;
                LogOutButton.BackColor = Color.White;

                Cancel.ForeColor = Color.Black;
                label4.BackColor = Color.Black;
                this.BackColor = Color.WhiteSmoke;

                panelNav.Height = BookingButton.Height;
                panelNav.Top = BookingButton.Top;
                panelNav.Left = BookingButton.Left;
                BookingButton.BackColor = Color.WhiteSmoke;

                pictureBox2.BackColor = Color.White;
                TextBoxStationName.ForeColor = Color.Black;
                TextBoxCity.ForeColor = Color.Black;
                TextBoxStreet.ForeColor = Color.Black;
                TextBoxOpens.ForeColor = Color.Black;
                TextBoxCloses.ForeColor = Color.Black;

                TextBoxStationName.BackColor = Color.WhiteSmoke;
                TextBoxCity.BackColor = Color.WhiteSmoke;
                TextBoxStreet.BackColor = Color.WhiteSmoke;
                TextBoxOpens.BackColor = Color.WhiteSmoke;
                TextBoxCloses.BackColor = Color.WhiteSmoke;


                label6.BackColor = Color.Black;
                label5.BackColor = Color.Black;
                label7.BackColor = Color.Black;
                label8.BackColor = Color.Black;
                label9.BackColor = Color.Black;

            }
        }

        private void stationinfo_Load(object sender, EventArgs e)
        {
            labelUsername.Text = loginpassenger.recall;
            labelUsername.Text = labelUsername.Text.ToUpper();

            TextBoxStationName.Text ="STATION NAME:"+ searchstation.SetValueForText1;
            TextBoxOpens.Text = "OPENS AT:" + searchstation.SetValueForText2;
            TextBoxCloses.Text = "CLOSES AT:" + searchstation.SetValueForText3;
            TextBoxStreet.Text = "STREET:" + searchstation.SetValueForText4;
            TextBoxCity.Text = "CITY:" + searchstation.SetValueForText5;
        }

        private void PassengersSettingsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            passengerssettings f1 = new passengerssettings();
            f1.ShowDialog();
            this.Close();
        }
    }
}
