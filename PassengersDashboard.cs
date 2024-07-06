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
using Tulpep.NotificationWindow;
using MySqlConnector;

namespace RailwayReservationSystem
{
    public partial class PassengersDashboard : Form
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
        public PassengersDashboard()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panelNav.Height = DashboardButton.Height;
            panelNav.Top = DashboardButton.Top;
            panelNav.Left = DashboardButton.Left;
            DashboardButton.BackColor = Color.WhiteSmoke;
        }

        private void PassengersDashboard_Load(object sender, EventArgs e)
        {
            labelUsername.Text = loginpassenger.recall;
            labelUsername.Text = labelUsername.Text.ToUpper();
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
                this.BackColor = Color.Black;
                Cancel.ForeColor = Color.White;
                label4.BackColor = Color.White;
                panel3.BackColor = Color.Black;

                panelNav.Height = DashboardButton.Height;
                panelNav.Top = DashboardButton.Top;
                panelNav.Left = DashboardButton.Left;
                DashboardButton.BackColor = Color.Black;


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
                this.BackColor = Color.WhiteSmoke;
                Cancel.ForeColor = Color.Black;
                label4.BackColor = Color.Black;
                panel3.BackColor = Color.White;

                panelNav.Height = DashboardButton.Height;
                panelNav.Top = DashboardButton.Top;
                panelNav.Left = DashboardButton.Left;
                DashboardButton.BackColor = Color.WhiteSmoke;

            }
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

        private void BookingButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookTrips f1 = new BookTrips();
            f1.ShowDialog();
            this.Close();
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            PassengersDashboard f1 = new PassengersDashboard();
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

        private void MyTripsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyTrips f1 = new MyTrips();
            f1.ShowDialog();
            this.Close();
        }

        private void PassengersSettingsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            passengerssettings f1 = new passengerssettings();
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

        private void labelUsername_TextChanged(object sender, EventArgs e)
        {
            Db db = new Db();
            //MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database= railwayreservationsystem");

            db.openConnection();
            if (labelUsername.Text != "")
            {
                MySqlCommand command = new MySqlCommand("SELECT  `fullname`, `username`, `arrivaltime`, `date`  FROM `booking` WHERE `username`= @un", db.getConnection());
                command.Parameters.AddWithValue("@un", Convert.ToString(labelUsername.Text));
                MySqlDataReader da = command.ExecuteReader();
                while (da.Read())
                {
                    

                    PopupNotifier popup = new PopupNotifier();
                    popup.Size = new Size(419, 99);//w,h
                    popup.BodyColor = Color.Black;
                    popup.Image = Properties.Resources.brd3;
                    popup.HeaderColor = Color.Black;
                    popup.ImageSize = new Size(82, 38);
                    
                    popup.TitleFont = new Font("Nirmala", 18, FontStyle.Bold);
                    popup.TitleText = da.GetValue(1).ToString();
                    popup.TitleColor = Color.White;
                    popup.ContentFont = new Font("Nirmala", 13, FontStyle.Regular);
                    popup.ContentColor = Color.White;
                    popup.ContentText = "Hey " + da.GetValue(0).ToString()+ "  your train will arrive at " + "  "  + da.GetValue(2).ToString() +   " " + da.GetValue(3).ToString() ;
                    popup.Popup();

                }
                db.closeConnection();
            }
        }
    }
}
