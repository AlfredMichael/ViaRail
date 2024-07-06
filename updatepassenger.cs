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
    public partial class updatepassenger : Form
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

        public updatepassenger()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panelNav.Height = PassengersSettingsButton.Height;
            panelNav.Top = PassengersSettingsButton.Top;
            panelNav.Left = PassengersSettingsButton.Left;
            PassengersSettingsButton.BackColor = Color.WhiteSmoke;
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

        private void updatepassenger_Load(object sender, EventArgs e)
        {
            labelUsername.Text = loginpassenger.recall;
            labelUsername.Text = labelUsername.Text.ToUpper();


            if (labelUsername.Text == "")
            {
                MessageBox.Show("You must have an account before you can edit passengers settings!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Hide();
                loginpassenger F6 = new loginpassenger();
                F6.ShowDialog();
                this.Close();
            }
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

        private void PassengersSettingsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            passengerssettings f1 = new passengerssettings();
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

                panelNav.Height = PassengersSettingsButton.Height;
                panelNav.Top = PassengersSettingsButton.Top;
                panelNav.Left = PassengersSettingsButton.Left;
                PassengersSettingsButton.BackColor = Color.Black;

                TextBoxPassengerFullname.ForeColor = Color.White;
                TextBoxPassengerFullname.BackColor = Color.Black;
                TextBoxPassengerUsername.ForeColor = Color.White;
                TextBoxPassengerUsername.BackColor = Color.Black;
                TextBoxPassengerPhonenumber.ForeColor = Color.White;
                TextBoxPassengerPhonenumber.BackColor = Color.Black;
                TextBoxPassengerEmail.ForeColor = Color.White;
                TextBoxPassengerEmail.BackColor = Color.Black;
                TextBoxPassengerPassword.ForeColor = Color.White;
                TextBoxPassengerPassword.BackColor = Color.Black;

                label6.BackColor = Color.White;
                label7.BackColor = Color.White;
                label8.BackColor = Color.White;
                label9.BackColor = Color.White;
                label10.BackColor = Color.White;


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

                panelNav.Height = PassengersSettingsButton.Height;
                panelNav.Top = PassengersSettingsButton.Top;
                panelNav.Left = PassengersSettingsButton.Left;
                PassengersSettingsButton.BackColor = Color.WhiteSmoke;

                TextBoxPassengerFullname.ForeColor = Color.Black;
                TextBoxPassengerFullname.BackColor = Color.WhiteSmoke;
                TextBoxPassengerUsername.ForeColor = Color.Black;
                TextBoxPassengerUsername.BackColor = Color.WhiteSmoke;
                TextBoxPassengerPhonenumber.ForeColor = Color.Black;
                TextBoxPassengerPhonenumber.BackColor = Color.WhiteSmoke;
                TextBoxPassengerEmail.ForeColor = Color.Black;
                TextBoxPassengerEmail.BackColor = Color.WhiteSmoke;
                TextBoxPassengerPassword.ForeColor = Color.Black;
                TextBoxPassengerPassword.BackColor = Color.WhiteSmoke;

                label6.BackColor = Color.Black;
                label7.BackColor = Color.Black;
                label8.BackColor = Color.Black;
                label9.BackColor = Color.Black;
                label10.BackColor = Color.Black;


            }
        }

        private void labelUsername_Click(object sender, EventArgs e)
        {

        }

        private void labelUsername_TextChanged(object sender, EventArgs e)
        {
            Db db = new Db();
           // MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database= railwayreservationsystem");

            db.openConnection();
            if (labelUsername.Text != "")
            {
                MySqlCommand command = new MySqlCommand("SELECT `fullname`, `username`, `phonenumber`, `email`, `password` FROM `passengersregistration` WHERE `username`= @un", db.getConnection());
                command.Parameters.AddWithValue("@un", Convert.ToString(labelUsername.Text));
                MySqlDataReader da = command.ExecuteReader();
                while (da.Read())
                {
                    TextBoxPassengerFullname.Text = da.GetValue(0).ToString();
                    TextBoxPassengerUsername.Text = da.GetValue(1).ToString();
                    TextBoxPassengerPhonenumber.Text = da.GetValue(2).ToString();
                    TextBoxPassengerEmail.Text = da.GetValue(3).ToString();           
                    TextBoxPassengerPassword.Text = da.GetValue(4).ToString();



                }
                db.closeConnection();
            }
        }

        private void AddStationButton_Click(object sender, EventArgs e)
        {
            Db db = new Db();
            //MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=railwayreservationsystem");
            try
            {
                db.openConnection();
                if (TextBoxPassengerFullname.Text==""||TextBoxPassengerEmail.Text==""||TextBoxPassengerPhonenumber.Text=="")
                {
                    MessageBox.Show("A field is empty", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                   
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE  `passengersregistration`  SET `fullname`='" + TextBoxPassengerFullname.Text + "',`email`='" + TextBoxPassengerEmail.Text + "',`phonenumber`='" + TextBoxPassengerPhonenumber.Text + "' WHERE username='" + labelUsername.Text + "'", db.getConnection());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your account has been updated, login to access your updated account", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


                    this.Hide();
                    loginpassenger f8 = new loginpassenger();
                    f8.ShowDialog();
                    this.Close();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            db.closeConnection();
        }
    }
}
