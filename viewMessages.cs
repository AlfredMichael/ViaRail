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

    public partial class viewMessages : Form
    {
        MySqlCommand cm;
        MySqlDataReader dr;

        private Label username;
        private Label panel;
        private Label heading;
        private Label date;
        private PictureBox pic;
        private Label time;
        private Label container = new Label();

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
        public viewMessages()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panelNav.Height = MessagesButton.Height;
            panelNav.Top = MessagesButton.Top;
            panelNav.Left = MessagesButton.Left;
            MessagesButton.BackColor = Color.WhiteSmoke;
        }
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string SetValueForText3 = "";
        public static string SetValueForText4 = "";
        public static string SetValueForText5 = "";
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
                this.BackColor = Color.Black;
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
                this.BackColor = Color.WhiteSmoke;
                Cancel.ForeColor = Color.Black;
                label4.BackColor = Color.Black;
                


                panelNav.Height = MessagesButton.Height;
                panelNav.Top = MessagesButton.Top;
                panelNav.Left = MessagesButton.Left;
                MessagesButton.BackColor = Color.WhiteSmoke;

            }
        }

        private void viewMessages_Load(object sender, EventArgs e)
        {
            labelUsername.Text = loginAdministrator.recall;
            labelUsername.Text = labelUsername.Text.ToUpper();
            GetData();
        }

        private void GetData()
        {

            flowLayoutPanel1.Controls.Clear();

            Db db = new Db();
            db.openConnection();
            cm = new MySqlCommand("SELECT  `username`, `message`, `heading`, `id`, `date`, `time` FROM `message`  WHERE username LIKE'" + alfredTextBox1.Texts + "%' ORDER BY username ", db.getConnection());
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
             

                container = new Label();
                container.BackColor = Color.White;
                container.Width = 795;
                container.Height = 150;
                container.Cursor = Cursors.Hand;
                container.AutoSize = false;
                container.BorderStyle = BorderStyle.None;
                container.Margin = new Padding(13);
                container.Tag = dr["id"].ToString();

                pic = new PictureBox();
                pic.Width = 80;
                pic.Height = 55;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BorderStyle = BorderStyle.None;
                pic.Cursor = Cursors.Hand;
                pic.Location = new Point(30,5);
                pic.BackgroundImage= Properties.Resources.download__2_;


                username = new Label();
                username.BackColor = Color.Transparent;
                username.Text = dr["username"].ToString();
                username.TextAlign = ContentAlignment.MiddleCenter;
                username.Location = new Point(305, 29);
                username.AutoSize = true;
                username.Font = new Font("Nirmala", 11, FontStyle.Bold);

                panel = new Label();
                panel.BackColor = Color.Gold;
                panel.Text = "";
                panel.Width = 3;
                panel.Height = 120;
                panel.Location = new Point(10,20);

                heading = new Label();
                heading.BackColor = Color.Transparent;
                heading.Text = dr["heading"].ToString();
                heading.Height = 59;
                heading.Width = 770;
                heading.Location = new Point(13, 60);
                heading.TextAlign = ContentAlignment.MiddleCenter;
                heading.Font = new Font("Nirmala", 10, FontStyle.Bold);

                date = new Label();
                date.BackColor = Color.Transparent;
                date.Text = dr["date"].ToString();
                date.AutoSize = true;
                date.TextAlign = ContentAlignment.MiddleCenter;
                date.Location = new Point(14, 110);
                date.Font = new Font("Nirmala", 10, FontStyle.Bold);


                time = new Label();
                time.BackColor = Color.Transparent;
                time.Text = dr["time"].ToString();
                time.AutoSize = true;
                time.TextAlign = ContentAlignment.MiddleCenter;
                time.Location = new Point(670, 110);
                time.Font = new Font("Nirmala", 10, FontStyle.Bold);

                container.Controls.Add(pic);
                container.Controls.Add(panel);
                container.Controls.Add(time);
                container.Controls.Add(date);
                container.Controls.Add(heading);
                container.Controls.Add(username);
                flowLayoutPanel1.Controls.Add(container);

                container.Click += new EventHandler(OnClick);
            }

            dr.Close();

            db.closeConnection();
        }
        public void OnClick(object sender, EventArgs e)
        {
            String tag = ((Label)sender).Tag.ToString();
            Db db = new Db();
            db.openConnection();
            cm = new MySqlCommand("SELECT * FROM `message` WHERE `id` LIKE '" + tag + "'", db.getConnection());
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                textBoxUsername.Text = dr["username"].ToString();
                textBoxHeading.Text = dr["heading"].ToString();
                textBoxDate.Text = dr["date"].ToString();
                textBoxTime.Text = dr["time"].ToString();
                textBoxMessage.Text = dr["message"].ToString();


                SetValueForText1 = textBoxUsername.Text;
                SetValueForText2 = textBoxHeading.Text;
                SetValueForText3 = textBoxDate.Text;
                SetValueForText4 = textBoxTime.Text;
                SetValueForText5 = textBoxMessage.Text;

                this.Hide();
                replyPassenger F6 = new replyPassenger();
                F6.ShowDialog();
                this.Close();

            }



            dr.Close();

            db.closeConnection();
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

        private void alfredTextBox1__TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void alfredButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
