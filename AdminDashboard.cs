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
using MySqlConnector;

namespace RailwayReservationSystem
{
    public partial class AdminDashboard : Form
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

        public AdminDashboard()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panelNav.Height = DashboardButton.Height;
            panelNav.Top = DashboardButton.Top;
            panelNav.Left = DashboardButton.Left;
            DashboardButton.BackColor = Color.WhiteSmoke;
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            labelName.Text = loginAdministrator.recall;
            labelName.Text = labelName.Text.ToUpper();

            Db db = new Db();
            db.openConnection();
            MySqlCommand fredthedeve = new MySqlCommand("SELECT COUNT(*) FROM `passengersregistration` ", db.getConnection());
            int count = (int)(long)fredthedeve.ExecuteScalar();
            RegisteredPassengersAmount.Text = count + "";
            label8.Text = count + " Passengers";


            MySqlCommand fredthedevel = new MySqlCommand("SELECT COUNT(*) FROM `traintrips` ", db.getConnection());
            int counte = (int)(long)fredthedevel.ExecuteScalar();
            label11.Text = counte + "";
            label12.Text = counte + " Train Trips";

            MySqlCommand fredthedevelo = new MySqlCommand("SELECT COUNT(*) FROM `booking` ", db.getConnection());
            int counter = (int)(long)fredthedevelo.ExecuteScalar();
            label14.Text = counter + "";
            label16.Text = counter + " Bookings";

            MySqlCommand fredthedevelop = new MySqlCommand("SELECT COUNT(*) FROM `stations` ", db.getConnection());
            int counters = (int)(long)fredthedevelop.ExecuteScalar();
            label18.Text = counters + "";
            label19.Text = counters + " Stations";

        }

        private void MessagesButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMessages f4 = new AdminMessages();
            f4.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
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
                TripsButton.BackColor = Color.Black;
                RegisteredPassengersButton.BackColor = Color.Black;
                MessagesButton.BackColor = Color.Black;
                StationsButton.BackColor = Color.Black;
                AdministratorSettingsButton.BackColor = Color.Black;
                LogOutButton.BackColor = Color.Black;
                this.BackColor = Color.Black;
                Cancel.ForeColor = Color.White;
                label4.BackColor = Color.White;

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
                TripsButton.BackColor = Color.White;
                RegisteredPassengersButton.BackColor = Color.White;
                MessagesButton.BackColor = Color.White;
                StationsButton.BackColor = Color.White;
                AdministratorSettingsButton.BackColor = Color.White;
                LogOutButton.BackColor = Color.White;
                this.BackColor = Color.WhiteSmoke;
                Cancel.ForeColor = Color.Black;
                label4.BackColor = Color.Black;

                panelNav.Height = DashboardButton.Height;
                panelNav.Top = DashboardButton.Top;
                panelNav.Left = DashboardButton.Left;
                DashboardButton.BackColor = Color.WhiteSmoke;

            }

        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard f1 = new AdminDashboard();
            f1.ShowDialog();
            this.Close();
        }

        private void TripsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            trainTrips f2 = new trainTrips();
            f2.ShowDialog();
            this.Close();
        }

        private void RegisteredPassengersButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewPassengers f3 = new viewPassengers();
            f3.ShowDialog();
            this.Close();
        }

        private void StationsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Station f5 = new Station();
            f5.ShowDialog();
            this.Close();
        }

        private void AdministratorSettingsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminsettings f6 = new adminsettings();
            f6.ShowDialog();
            this.Close();
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginAdministrator f7 = new loginAdministrator();
            f7.ShowDialog();
            this.Close();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginAdministrator f8 = new loginAdministrator();
            f8.ShowDialog();
            this.Close();
        }

        private void labelUsername_Click(object sender, EventArgs e)
        {

        }

        private void RegisteredPassengersAmount_Click(object sender, EventArgs e)
        {

        }
    }
}
