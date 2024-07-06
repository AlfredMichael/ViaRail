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
    public partial class addadministrator : Form
    {
       


        Db db = new Db();
        HashPass hc = new HashPass();

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
        public addadministrator()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panelNav.Height = AdministratorSettingsButton.Height;
            panelNav.Top = AdministratorSettingsButton.Top;
            panelNav.Left = AdministratorSettingsButton.Left;
            AdministratorSettingsButton.BackColor = Color.WhiteSmoke;

            TextBoxAdminName.Focus();
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

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void alfredToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (alfredToggleButton1.Checked)
            {
                TextBoxAdminPassword.PasswordChar = false;
                TextBoxAdminConfirmPassword.PasswordChar = false;
                ShowPasLabel.Text = "Hide Password";
            }
            else
            {
                TextBoxAdminPassword.PasswordChar = true;
                TextBoxAdminConfirmPassword.PasswordChar = true;
                ShowPasLabel.Text = "Show Password";
            }
        }

        private void TextBoxAddStation__TextChanged(object sender, EventArgs e)
        {

        }

        private void addadministrator_Load(object sender, EventArgs e)
        {
            labelUsername.Text = loginAdministrator.recall;
            labelUsername.Text = labelUsername.Text.ToUpper();
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

        private void AddStationButton_Click(object sender, EventArgs e)
        {
            //Add new Administrator

            Db db = new Db();
            MySqlCommand command = new MySqlCommand("INSERT INTO`adminregistration` ( `adminname`,`adminpin`, `adminemail`, `adminphonenumber`, `adminpassword`) VALUES( @an, @ap, @ae, @apn, @apw)", db.getConnection());



            command.Parameters.Add("@an", MySqlDbType.VarChar).Value = TextBoxAdminName.Texts;
            command.Parameters.Add("@ap", MySqlDbType.VarChar).Value = TextBoxAdminPin.Texts;
            command.Parameters.Add("@ae", MySqlDbType.VarChar).Value = TextBoxAdminEmail.Texts;
            command.Parameters.Add("@apn", MySqlDbType.VarChar).Value = TextBoxAdminPhoneNumber.Texts;
            command.Parameters.Add("@apw", MySqlDbType.VarChar).Value = hc.PassHash(TextBoxAdminPassword.Texts);

            // open the connection so i can connect to my database
            db.openConnection();


            if (TextBoxAdminName.Texts == "" || TextBoxAdminPin.Texts == "" || TextBoxAdminEmail.Texts == "" || TextBoxAdminPhoneNumber.Texts == "" || TextBoxAdminPassword.Texts == "" || TextBoxAdminConfirmPassword.Texts == "" )
            {
                MessageBox.Show("A field is empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
            else
            {

                if (Adminpin())
                {
                    MessageBox.Show("This Pin Already Exists, Select A Different One", "Duplicate Pins found", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    TextBoxAdminPin.Texts = "";
                }
                else if (Adminname())
                {
                    MessageBox.Show("This Name Already Exists, Select A Different One", "Duplicate Names found", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    TextBoxAdminName.Texts = "";
                }

                else if (TextBoxAdminPassword.Texts == TextBoxAdminConfirmPassword.Texts)
                {

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("A new administrator has been added Successfully!", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
                    }
                    else
                    {
                        MessageBox.Show("ERROR");
                    }


                    TextBoxAdminName.Texts = "";
                    TextBoxAdminPin.Texts = "";
                    TextBoxAdminEmail.Texts = "";
                    TextBoxAdminPhoneNumber.Texts = "";
                    TextBoxAdminPassword.Texts = "";
                    TextBoxAdminConfirmPassword.Texts = "";







                }
                else
                {
                    MessageBox.Show("Passwords does not match, Please Re-type your password", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextBoxAdminPassword.Texts = "";
                    TextBoxAdminConfirmPassword.Texts = "";
                    TextBoxAdminPassword.Focus();


                }
                db.closeConnection();
            }

        }
        public Boolean Adminpin()
        {
            Db db = new Db();
            String adminpinn = TextBoxAdminPin.Texts;


            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `adminregistration` WHERE `adminpin` = @ap", db.getConnection());

            command.Parameters.Add("@ap", MySqlDbType.VarChar).Value = adminpinn;


            adapter.SelectCommand = command;

            adapter.Fill(table);

            // To check if the Administrator's pin already exists in the database 
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;

            }



        }
        public Boolean Adminname()
        {
            Db db = new Db();
            String adminnamee = TextBoxAdminName.Texts;


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
    }
}
