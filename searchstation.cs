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
    public partial class searchstation : Form
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

        MySqlCommand cm;
        MySqlDataReader dr;

        private Label container = new Label();
        private Label textstation;
        private Label station;
        private Label line;
        private Label textcity;
        private Label city;
        private Label textstreet;
        private Label street;
        public searchstation()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panelNav.Height = StationsButton.Height;
            panelNav.Top = StationsButton.Top;
            panelNav.Left = StationsButton.Left;
            StationsButton.BackColor = Color.WhiteSmoke;
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

        private void searchstation_Load(object sender, EventArgs e)
        {
            labelUsername.Text = loginpassenger.recall;
            labelUsername.Text = labelUsername.Text.ToUpper();

            GetData();


        }
        private void GetData()
        {

            flowLayoutPanel1.Controls.Clear();

            Db db = new Db();
            db.openConnection();
            cm = new MySqlCommand("SELECT `stationname`, `opens`, `closes`, `city`, `street`, `id` FROM `stations`  ", db.getConnection());
            dr = cm.ExecuteReader();
            while (dr.Read())
            {



                container = new Label();
                container.BackColor = Color.White;
                container.Width = 668;
                container.Height = 204;
                container.Cursor = Cursors.Hand;
                container.AutoSize = false;
                container.BorderStyle = BorderStyle.None;
                container.Margin = new Padding(13);
                container.Tag = dr["id"].ToString();
                container.Image = Properties.Resources.download__2_;



                textstation = new Label();
                textstation.Text = "STATION:";
                textstation.BackColor = Color.Transparent;
                textstation.TextAlign = ContentAlignment.MiddleCenter;
                textstation.Location = new Point(270, 15);
                textstation.Height = 25;
                textstation.Width = 126;
                textstation.Font = new Font("Nirmala", 12, FontStyle.Bold);
                textstation.ForeColor = Color.Black;


                station = new Label();
                station.Text = dr["stationname"].ToString();
                station.BackColor = Color.Transparent;
                station.TextAlign = ContentAlignment.MiddleCenter;
                station.Location = new Point(180, 43);
                station.Height = 29;
                station.Width = 303;
                station.Font = new Font("Nirmala", 12, FontStyle.Bold);
                station.ForeColor = Color.Black;

                line = new Label();
                line.Text = "";
                line.BackColor = Color.Gold;
                line.Width = 3;
                line.Height = 164;
                line.Location = new Point(9, 20);

                textcity = new Label();
                textcity.Text = "CITY:";
                textcity.BackColor = Color.Transparent;
                textcity.TextAlign = ContentAlignment.MiddleCenter;
                textcity.Width = 147;
                textcity.Height = 22;
                textcity.Location = new Point(40, 120);
                textcity.Font = new Font("Nirmala", 12, FontStyle.Bold);
                textcity.ForeColor = Color.Black;

                city = new Label();
                city.Text = dr["city"].ToString();
                city.BackColor = Color.Transparent;
                city.TextAlign = ContentAlignment.MiddleCenter;
                city.Width = 198;
                city.Height = 25;
                city.Location = new Point(12, 145);
                city.Font = new Font("Nirmala", 12, FontStyle.Bold);
                city.ForeColor = Color.Black;


                textstreet = new Label();
                textstreet.Text = "STREET:";
                textstreet.BackColor = Color.Transparent;
                textstreet.TextAlign = ContentAlignment.MiddleCenter;
                textstreet.Width = 147;
                textstreet.Height = 22;
                textstreet.Location = new Point(477, 120);
                textstreet.Font = new Font("Nirmala", 12, FontStyle.Bold);
                textstreet.ForeColor = Color.Black;


                street = new Label();
                street.Text = dr["street"].ToString();
                street.BackColor = Color.Transparent;
                street.TextAlign = ContentAlignment.MiddleCenter;
                street.Width = 198;
                street.Height = 25;
                street.Location = new Point(446, 145);
                street.Font = new Font("Nirmala", 12, FontStyle.Bold);
                street.ForeColor = Color.Black;



                container.Controls.Add(textstreet);
                container.Controls.Add(street);
                container.Controls.Add(textcity);
                container.Controls.Add(city);
                container.Controls.Add(station);
                container.Controls.Add(line);
                container.Controls.Add(textstation);
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
            cm = new MySqlCommand("SELECT * FROM `stations` WHERE `id` LIKE '" + tag + "'", db.getConnection());
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {



                textBoxStation.Text = dr["stationname"].ToString();
                textBoxOpens.Text = dr["opens"].ToString();
                textBoxCloses.Text = dr["closes"].ToString();
                textBoxStreet.Text = dr["street"].ToString();
                textBoxCity.Text = dr["city"].ToString();


                SetValueForText1 = textBoxStation.Text;
                SetValueForText2 = textBoxOpens.Text;
                SetValueForText3 = textBoxCloses.Text;
                SetValueForText4 = textBoxStreet.Text;
                SetValueForText5 = textBoxCity.Text;

                this.Hide();
                stationinfo F1 = new stationinfo();
                F1.ShowDialog();
                this.Close();


            }



        }

        private void alfredTextBox1__TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            Db db = new Db();
            db.openConnection();
            cm = new MySqlCommand("SELECT `stationname`, `opens`, `closes`, `city`, `street`, `id` FROM `stations`  WHERE `stationname`  LIKE'" + alfredTextBox1.Texts + "%' ORDER BY stationname ", db.getConnection());
            dr = cm.ExecuteReader();
            while (dr.Read())
            {



                container = new Label();
                container.BackColor = Color.White;
                container.Width = 668;
                container.Height = 204;
                container.Cursor = Cursors.Hand;
                container.AutoSize = false;
                container.BorderStyle = BorderStyle.None;
                container.Margin = new Padding(13);
                container.Tag = dr["id"].ToString();
                container.Image = Properties.Resources.download__2_;



                textstation = new Label();
                textstation.Text = "STATION:";
                textstation.BackColor = Color.Transparent;
                textstation.TextAlign = ContentAlignment.MiddleCenter;
                textstation.Location = new Point(270, 15);
                textstation.Height = 25;
                textstation.Width = 126;
                textstation.Font = new Font("Nirmala", 12, FontStyle.Bold);
                textstation.ForeColor = Color.Black;


                station = new Label();
                station.Text = dr["stationname"].ToString();
                station.BackColor = Color.Transparent;
                station.TextAlign = ContentAlignment.MiddleCenter;
                station.Location = new Point(180, 43);
                station.Height = 29;
                station.Width = 303;
                station.Font = new Font("Nirmala", 12, FontStyle.Bold);
                station.ForeColor = Color.Black;

                line = new Label();
                line.Text = "";
                line.BackColor = Color.Gold;
                line.Width = 3;
                line.Height = 164;
                line.Location = new Point(9, 20);

                textcity = new Label();
                textcity.Text = "CITY:";
                textcity.BackColor = Color.Transparent;
                textcity.TextAlign = ContentAlignment.MiddleCenter;
                textcity.Width = 147;
                textcity.Height = 22;
                textcity.Location = new Point(40, 120);
                textcity.Font = new Font("Nirmala", 12, FontStyle.Bold);
                textcity.ForeColor = Color.Black;

                city = new Label();
                city.Text = dr["city"].ToString();
                city.BackColor = Color.Transparent;
                city.TextAlign = ContentAlignment.MiddleCenter;
                city.Width = 198;
                city.Height = 25;
                city.Location = new Point(12, 145);
                city.Font = new Font("Nirmala", 12, FontStyle.Bold);
                city.ForeColor = Color.Black;


                textstreet = new Label();
                textstreet.Text = "STREET:";
                textstreet.BackColor = Color.Transparent;
                textstreet.TextAlign = ContentAlignment.MiddleCenter;
                textstreet.Width = 147;
                textstreet.Height = 22;
                textstreet.Location = new Point(477, 120);
                textstreet.Font = new Font("Nirmala", 12, FontStyle.Bold);
                textstreet.ForeColor = Color.Black;


                street = new Label();
                street.Text = dr["street"].ToString();
                street.BackColor = Color.Transparent;
                street.TextAlign = ContentAlignment.MiddleCenter;
                street.Width = 198;
                street.Height = 25;
                street.Location = new Point(446, 145);
                street.Font = new Font("Nirmala", 12, FontStyle.Bold);
                street.ForeColor = Color.Black;



                container.Controls.Add(textstreet);
                container.Controls.Add(street);
                container.Controls.Add(textcity);
                container.Controls.Add(city);
                container.Controls.Add(station);
                container.Controls.Add(line);
                container.Controls.Add(textstation);
                flowLayoutPanel1.Controls.Add(container);


                container.Click += new EventHandler(OnClick);

            }

            dr.Close();

            db.closeConnection();
        }

        private void alfredTextBox2__TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            Db db = new Db();
            db.openConnection();
            cm = new MySqlCommand("SELECT `stationname`, `opens`, `closes`, `city`, `street`, `id` FROM `stations`  WHERE `city`  LIKE'" + alfredTextBox2.Texts + "%' ORDER BY city ", db.getConnection());
            dr = cm.ExecuteReader();
            while (dr.Read())
            {



                container = new Label();
                container.BackColor = Color.White;
                container.Width = 668;
                container.Height = 204;
                container.Cursor = Cursors.Hand;
                container.AutoSize = false;
                container.BorderStyle = BorderStyle.None;
                container.Margin = new Padding(13);
                container.Tag = dr["id"].ToString();
                container.Image = Properties.Resources.download__2_;



                textstation = new Label();
                textstation.Text = "STATION:";
                textstation.BackColor = Color.Transparent;
                textstation.TextAlign = ContentAlignment.MiddleCenter;
                textstation.Location = new Point(270, 15);
                textstation.Height = 25;
                textstation.Width = 126;
                textstation.Font = new Font("Nirmala", 12, FontStyle.Bold);
                textstation.ForeColor = Color.Black;


                station = new Label();
                station.Text = dr["stationname"].ToString();
                station.BackColor = Color.Transparent;
                station.TextAlign = ContentAlignment.MiddleCenter;
                station.Location = new Point(180, 43);
                station.Height = 29;
                station.Width = 303;
                station.Font = new Font("Nirmala", 12, FontStyle.Bold);
                station.ForeColor = Color.Black;

                line = new Label();
                line.Text = "";
                line.BackColor = Color.Gold;
                line.Width = 3;
                line.Height = 164;
                line.Location = new Point(9, 20);

                textcity = new Label();
                textcity.Text = "CITY:";
                textcity.BackColor = Color.Transparent;
                textcity.TextAlign = ContentAlignment.MiddleCenter;
                textcity.Width = 147;
                textcity.Height = 22;
                textcity.Location = new Point(40, 120);
                textcity.Font = new Font("Nirmala", 12, FontStyle.Bold);
                textcity.ForeColor = Color.Black;

                city = new Label();
                city.Text = dr["city"].ToString();
                city.BackColor = Color.Transparent;
                city.TextAlign = ContentAlignment.MiddleCenter;
                city.Width = 198;
                city.Height = 25;
                city.Location = new Point(12, 145);
                city.Font = new Font("Nirmala", 12, FontStyle.Bold);
                city.ForeColor = Color.Black;


                textstreet = new Label();
                textstreet.Text = "STREET:";
                textstreet.BackColor = Color.Transparent;
                textstreet.TextAlign = ContentAlignment.MiddleCenter;
                textstreet.Width = 147;
                textstreet.Height = 22;
                textstreet.Location = new Point(477, 120);
                textstreet.Font = new Font("Nirmala", 12, FontStyle.Bold);
                textstreet.ForeColor = Color.Black;


                street = new Label();
                street.Text = dr["street"].ToString();
                street.BackColor = Color.Transparent;
                street.TextAlign = ContentAlignment.MiddleCenter;
                street.Width = 198;
                street.Height = 25;
                street.Location = new Point(446, 145);
                street.Font = new Font("Nirmala", 12, FontStyle.Bold);
                street.ForeColor = Color.Black;



                container.Controls.Add(textstreet);
                container.Controls.Add(street);
                container.Controls.Add(textcity);
                container.Controls.Add(city);
                container.Controls.Add(station);
                container.Controls.Add(line);
                container.Controls.Add(textstation);
                flowLayoutPanel1.Controls.Add(container);


                container.Click += new EventHandler(OnClick);

            }

            dr.Close();

            db.closeConnection();
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

            }
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
    }
}
