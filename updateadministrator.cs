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
    public partial class updateadministrator : Form
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
        public updateadministrator()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panelNav.Height = AdministratorSettingsButton.Height;
            panelNav.Top = AdministratorSettingsButton.Top;
            panelNav.Left = AdministratorSettingsButton.Left;
            AdministratorSettingsButton.BackColor = Color.WhiteSmoke;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void alfredToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
          
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


                panelNav.Height = AdministratorSettingsButton.Height;
                panelNav.Top = AdministratorSettingsButton.Top;
                panelNav.Left = AdministratorSettingsButton.Left;
                AdministratorSettingsButton.BackColor = Color.Black;
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


                panelNav.Height = AdministratorSettingsButton.Height;
                panelNav.Top = AdministratorSettingsButton.Top;
                panelNav.Left = AdministratorSettingsButton.Left;
                AdministratorSettingsButton.BackColor = Color.WhiteSmoke;

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

        private void RegisteredPassengersButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewPassengers f3 = new viewPassengers();
            f3.ShowDialog();
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

        private void updateadministrator_Load(object sender, EventArgs e)
        {
            labelUsername.Text = loginAdministrator.recall;
            labelUsername.Text = labelUsername.Text.ToUpper();
        }

        private void labelUsername_TextChanged(object sender, EventArgs e)
        {
            Db db = new Db();
            //MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database= railwayreservationsystem");

            db.openConnection();
            if (labelUsername.Text != "")
            {
                MySqlCommand command = new MySqlCommand("SELECT  `adminname`, `adminpin`, `adminemail`, `adminphonenumber`, `adminpassword`  FROM `adminregistration` WHERE `adminname`= @an", db.getConnection());
                command.Parameters.AddWithValue("@an", Convert.ToString(labelUsername.Text));
                MySqlDataReader da = command.ExecuteReader();
                while (da.Read())
                {
                    TextBoxAdminName.Text = da.GetValue(0).ToString();
                    TextBoxAdminPin.Text = da.GetValue(1).ToString();
                    TextBoxAdminEmail.Text = da.GetValue(2).ToString();
                    TextBoxAdminPhonenumber.Text = da.GetValue(3).ToString();
                    TextBoxPassword.Text = da.GetValue(4).ToString();



                }
                db.closeConnection();
            }
        }

        public Boolean Adminname()
        {
            Db db = new Db();
            String adminnamee = TextBoxAdminName.Text;


            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `adminregistration` WHERE `adminname` = @an", db.getConnection());

            command.Parameters.Add("@an", MySqlDbType.VarChar).Value = adminnamee;


            adapter.SelectCommand = command;

            adapter.Fill(table);

            // To check if the Administrator's Name already exists in the database 
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;

            }



        }



        // UPDATE `adminregistration`  SET `adminname`=[TextBoxAdminName.Text],`adminemail`=[TextBoxAdminEmail.Text],`adminphonenumber`=[TextBoxAdminPhonenumber.Text],`adminpassword`=[TextBoxPassword.Text] WHERE

        private void AddStationButton_Click(object sender, EventArgs e)
        {
            Db db = new Db();
            //MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=railwayreservationsystem");
            try
            {
                db.openConnection();
                if (Adminname())
                {
                    MessageBox.Show("This Name Already Exists, Select A Different One", "Duplicate Names found", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    TextBoxAdminName.Text = "";
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE `adminregistration`  SET `adminname`='" + TextBoxAdminName.Text + "',`adminemail`='" + TextBoxAdminEmail.Text + "',`adminphonenumber`='" + TextBoxAdminPhonenumber.Text + "' WHERE adminpin='" + TextBoxAdminPin.Text + "'", db.getConnection());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your account has been updated, login to access your updated account");


                    this.Hide();
                    loginAdministrator f8 = new loginAdministrator();
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


        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
