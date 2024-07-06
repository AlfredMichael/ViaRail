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
    public partial class replyPassenger : Form
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
        public replyPassenger()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panelNav.Height = MessagesButton.Height;
            panelNav.Top = MessagesButton.Top;
            panelNav.Left = MessagesButton.Left;
            MessagesButton.BackColor = Color.WhiteSmoke;


            timer1.Start();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
                
                Cancel.ForeColor = Color.White;
                label4.BackColor = Color.White;



                panelNav.Height = MessagesButton.Height;
                panelNav.Top = MessagesButton.Top;
                panelNav.Left = MessagesButton.Left;
                MessagesButton.BackColor = Color.Black;
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
             
                Cancel.ForeColor = Color.Black;
                label4.BackColor = Color.Black;



                panelNav.Height = MessagesButton.Height;
                panelNav.Top = MessagesButton.Top;
                panelNav.Left = MessagesButton.Left;
                MessagesButton.BackColor = Color.WhiteSmoke;

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

        private void MessagesButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMessages f4 = new AdminMessages();
            f4.ShowDialog();
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

        private void labeladmindate_Click(object sender, EventArgs e)
        {

        }

        private void replyPassenger_Load(object sender, EventArgs e)
        {
            labelUsername.Text = loginAdministrator.recall;
            labelUsername.Text = labelUsername.Text.ToUpper();

            TextBoxPas2.Text = viewMessages.SetValueForText1;
            TextBoxHea2.Text = viewMessages.SetValueForText2;
            labelpasdate.Text = viewMessages.SetValueForText3;
            labelpastime.Text = viewMessages.SetValueForText4;
            TextBoxMes2.Text = viewMessages.SetValueForText5;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            this.labeladmindate.Text = date.ToShortDateString();

            DateTime datetime = DateTime.Now;
            this.labeladmintime.Text = datetime.ToString("hh:mm:ss tt");
        }

        private void alfredButton1_Click(object sender, EventArgs e)
        {
            Db db = new Db();
            MySqlCommand command = new MySqlCommand("INSERT INTO`adminreply`( `pas_username`, `pas_heading`, `pas_message`, `pas_date`, `pas_time`, `admin_name`, `admin_message`, `admin_date`, `admin_time`) VALUES( @pu, @ph, @pm, @pd, @pt, @an, @am, @ad, @at)", db.getConnection());
            command.Parameters.Add("@pu", MySqlDbType.VarChar).Value = TextBoxPas2.Text;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = TextBoxHea2.Text;
            command.Parameters.Add("@pm", MySqlDbType.VarChar).Value = TextBoxMes2.Text;
            command.Parameters.Add("@pd", MySqlDbType.VarChar).Value = labelpasdate.Text;
            command.Parameters.Add("@pt", MySqlDbType.VarChar).Value = labelpastime.Text;
            command.Parameters.Add("@an", MySqlDbType.VarChar).Value = labelAdmin.Text;
            command.Parameters.Add("@am", MySqlDbType.VarChar).Value = TextBoxReply.Texts;
            command.Parameters.Add("@ad", MySqlDbType.VarChar).Value = labeladmindate.Text;
            command.Parameters.Add("@at", MySqlDbType.VarChar).Value = labeladmintime.Text;


            db.openConnection();

            if (TextBoxReply.Texts == "")
            {
                MessageBox.Show("Message field is empty, please reply the passenger", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
            else
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Your reply has been sent Successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("ERROR");
                }

            }

            db.closeConnection();


        }
    }
}
