﻿using System;
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
    public partial class BookTrips : Form
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

        

        private Label trainname;
        private Label time;
        private Label source;
        private Label destination;
        private Label date;
        private Label container = new Label();
        private Label textdestination;
        private Label textsource;
        private RadioButton buttonsource;
        private RadioButton buttondestination;
        private Label linesource;
        private Label departuretime;
        private Label arrivaldestinationtime;
        private Label timetext;
        private Label station;
        public BookTrips()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panelNav.Height = BookingButton.Height;
            panelNav.Top = BookingButton.Top;
            panelNav.Left = BookingButton.Left;
            BookingButton.BackColor = Color.WhiteSmoke;
        }
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string SetValueForText3 = "";
        public static string SetValueForText4 = "";
        public static string SetValueForText5 = "";
        public static string SetValueForText6 = "";
        public static string SetValueForText7 = "";
        public static string SetValueForText8 = "";
        public static string SetValueForText9 = "";
        public static string SetValueForText10 = "";
        public static string SetValueForText11 = "";
        public static string setValueForText12 = "";
        public static string setValueForText13 = "";
        public static string setValueForText14 = "";

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BookTrips_Load(object sender, EventArgs e)
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
            cm = new MySqlCommand("SELECT  `trainname`, `source`, `destination`, `date`, `arrivaltime`, `departuretime`, `arrivalatdestinationtime`, `totaltime`, `noofseats`, `ticketfare`, `distance`, `station`, `id` FROM `traintrips`  ", db.getConnection());
            dr = cm.ExecuteReader();
            while (dr.Read())
            {

             
                 /*pic = new PictureBox();
                 pic.Width = 800;
                 pic.Height = 600;
                 pic.BackgroundImageLayout = ImageLayout.Stretch;
                 pic.BorderStyle = BorderStyle.Fixed3D;
                 pic.Cursor = Cursors.Hand;
                 pic.Image = Properties.Resources.download__2_;
                 pic.Location = new Point(300, 20);*/


                container = new Label();
                container.BackColor = Color.White;
                container.Width = 795;
                container.Height = 210;
                container.Cursor = Cursors.Hand;
                container.AutoSize = false;
                container.BorderStyle = BorderStyle.None;
                container.Margin = new Padding(13);
                container.Tag = dr["id"].ToString();
                container.Image= Properties.Resources.download__2_;

                destination = new Label();
                destination.Text = dr["destination"].ToString();
                //destination.Text = "To: " + dr["destination"].ToString();
                destination.BackColor = Color.Transparent;
                destination.TextAlign = ContentAlignment.MiddleCenter;
                destination.Location = new Point(621, 48);
                destination.AutoSize = false;
                destination.Width = 120;
                destination.Height = 21;
                destination.Font= new Font("Nirmala", 12, FontStyle.Regular);
                destination.ForeColor = Color.Gray;


                textsource = new Label();
                textsource.Text = "Source:";
                textsource.BackColor = Color.Transparent;
                textsource.TextAlign = ContentAlignment.MiddleCenter;
                textsource.Location = new Point(35, 16);
                textsource.AutoSize = true;
                textsource.Font = new Font("Nirmala", 12, FontStyle.Regular);
                textsource.ForeColor = Color.Gray;

                buttonsource = new RadioButton();
                buttonsource.Text = "";
                buttonsource.BackColor = Color.Transparent;
                buttonsource.AutoSize = false;
                buttonsource.Height = 37;
                buttonsource.Width = 30;
                buttonsource.Location = new Point(121, 20);
                buttonsource.ForeColor= Color.Gray;


                linesource = new Label();
                linesource.Text = "";
                linesource.BackColor = Color.LightGray;
                linesource.Height = 2;
                linesource.Width = 422;
                linesource.Location = new Point(147, 38);


                /*division = new Label();
                division.Text = "";
                division.BackColor = Color.Gray;
                division.Height = 4;
                division.Width = 744;
                division.Location = new Point(22, 140);*/

                buttondestination = new RadioButton();
                buttondestination.Text = "";
                buttondestination.BackColor = Color.Transparent;
                buttondestination.AutoSize = false;
                buttondestination.Height = 37;
                buttondestination.Width = 30;
                buttondestination.Location = new Point(578, 20);
                buttondestination.ForeColor = Color.Gray;

                textdestination = new Label();
                textdestination.Text = "Destination:";
                textdestination.BackColor = Color.Transparent;
                textdestination.TextAlign = ContentAlignment.MiddleCenter;
                textdestination.Location = new Point(635, 16);
                textdestination.AutoSize = true;
                textdestination.Font = new Font("Nirmala", 12, FontStyle.Regular);
                textdestination.ForeColor = Color.Gray;


                source = new Label();
                source.Text = dr["source"].ToString();
                source.BackColor = Color.Transparent;
                source.TextAlign = ContentAlignment.MiddleCenter;
                source.Location = new Point(13, 48);
                source.AutoSize = false;
                source.Width = 120;
                source.Height = 21;
                source.Font = new Font("Nirmala", 12, FontStyle.Regular);
                source.ForeColor = Color.Gray;




                trainname = new Label();
                trainname.Text = "Train Name:\n"+ dr["trainname"].ToString();
                trainname.BackColor = Color.Transparent;
                trainname.TextAlign = ContentAlignment.MiddleCenter;
                trainname.Location = new Point(337, 159);
                trainname.AutoSize = true;
                trainname.Font = new Font("Nirmala", 12, FontStyle.Regular);
                trainname.ForeColor = Color.Gray;


                station = new Label();
                station.Text = dr["station"].ToString();
                station.BackColor = Color.Transparent;
                station.TextAlign = ContentAlignment.MiddleCenter;
                station.Location = new Point(13, 173);
                station.AutoSize = true;
                station.Font = new Font("Nirmala", 12, FontStyle.Regular);
                station.ForeColor = Color.Gray;


                departuretime = new Label();
                departuretime.Text = "Departure Time:\n" + dr["departuretime"].ToString();
                departuretime.BackColor = Color.Transparent;
                departuretime.TextAlign = ContentAlignment.MiddleCenter;
                departuretime.Location = new Point(621, 95); //25, 95
                departuretime.AutoSize = true;
                departuretime.Font = new Font("Nirmala", 12, FontStyle.Regular);
                departuretime.ForeColor = Color.Gray;



                arrivaldestinationtime = new Label();
                arrivaldestinationtime.Text =  dr["arrivalatdestinationtime"].ToString();
                arrivaldestinationtime.BackColor = Color.Transparent;
                arrivaldestinationtime.TextAlign = ContentAlignment.MiddleCenter;
                arrivaldestinationtime.Location = new Point(669, 179); //540 , 95
                arrivaldestinationtime.AutoSize = true;
                arrivaldestinationtime.Font = new Font("Nirmala", 12, FontStyle.Regular);
                arrivaldestinationtime.ForeColor = Color.Gray;

                timetext = new Label();
                timetext.Text = "Date And Time:";
                timetext.BackColor = Color.Transparent;
                timetext.AutoSize = false;
                timetext.AutoSize = true;
                timetext.Location = new Point(618, 159);
                timetext.TextAlign = ContentAlignment.MiddleCenter;
                timetext.Font = new Font("Nirmala", 12, FontStyle.Regular);
                timetext.ForeColor = Color.Gray;

                date = new Label();
                date.Text = dr["date"].ToString();
                date.BackColor = Color.Transparent;
                date.Width = 120;
                date.Height = 30;
                date.Location = new Point(550, 179);
                date.Font = new Font("Nirmala", 12, FontStyle.Regular);
                date.ForeColor = Color.Gray;



                time = new Label();
                time.Text = "Arrival Time:\n" + dr["arrivaltime"].ToString();
                time.BackColor = Color.Transparent;
                time.AutoSize = true;
                time.Location = new Point(25, 95); //640,179
                time.Font = new Font("Nirmala", 12, FontStyle.Regular);
                time.ForeColor = Color.Gray;
                time.TextAlign = ContentAlignment.MiddleCenter;







                /* MemoryStream ms = new MemoryStream(array);
                 Bitmap bitmap = new Bitmap(ms);
                 pic.BackgroundImage = bitmap;*/


                container.Controls.Add(timetext);
                container.Controls.Add(time);
                container.Controls.Add(date);
                container.Controls.Add(arrivaldestinationtime);
                container.Controls.Add(departuretime);
                container.Controls.Add(station);
                container.Controls.Add(trainname);
                
                container.Controls.Add(source);
                container.Controls.Add(textdestination);
                
                
                container.Controls.Add(buttondestination);
                container.Controls.Add(buttonsource);
                container.Controls.Add(linesource);
               
                container.Controls.Add(destination);
                container.Controls.Add(textsource);
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
            cm = new MySqlCommand("SELECT * FROM `traintrips` WHERE `id` LIKE '" + tag + "'", db.getConnection());
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {


                textBoxId.Text = dr["id"].ToString();
                textBoxTrainName.Text = dr["trainname"].ToString();
                textBoxSource.Text = dr["source"].ToString();
                textBoxDestination.Text = dr["destination"].ToString();
                textBoxDate.Text = dr["date"].ToString();
                textBoxArrivalTime.Text = dr["arrivaltime"].ToString();
                textBoxDepartureTime.Text = dr["departuretime"].ToString();
                textBoxTotalTime.Text = dr["totaltime"].ToString();
                textBoxNoOfSeats.Text = dr["noofseats"].ToString();
                textBoxTicketFare.Text = dr["ticketfare"].ToString();
                textBoxDistance.Text = dr["distance"].ToString();
                textBoxarrivaldestination.Text = dr["arrivalatdestinationtime"].ToString();
                textBoxStation.Text = dr["station"].ToString();
                textBoxTripCode.Text = dr["tripcode"].ToString();


                SetValueForText1 = textBoxId.Text;
                SetValueForText2 = textBoxTrainName.Text;
                SetValueForText3 = textBoxSource.Text;
                SetValueForText4 = textBoxDestination.Text;
                SetValueForText5 = textBoxDate.Text;
                SetValueForText6 = textBoxArrivalTime.Text;
                SetValueForText7 = textBoxDepartureTime.Text;
                SetValueForText8 = textBoxTotalTime.Text;
                SetValueForText9 = textBoxNoOfSeats.Text;
                SetValueForText10 = textBoxTicketFare.Text;
                SetValueForText11 = textBoxDistance.Text;
                setValueForText12 = textBoxarrivaldestination.Text;
                setValueForText13 = textBoxStation.Text;
                setValueForText14 = textBoxTripCode.Text;


               this.Hide();
               Booking F1 = new Booking();
               F1.ShowDialog();
                this.Close();
                

            }











            dr.Close();

            db.closeConnection();
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

        private void labelUsername_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void alfredTextBox1__TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            Db db = new Db();
            db.openConnection();
            cm = new MySqlCommand("SELECT  `trainname`, `source`, `destination`, `date`, `arrivaltime`, `departuretime`, `arrivalatdestinationtime`, `totaltime`, `noofseats`, `ticketfare`, `distance`, `station`, `id` FROM `traintrips` WHERE `source`  LIKE'" + alfredTextBox1.Texts + "%' ORDER BY source  ", db.getConnection());
            dr = cm.ExecuteReader();
            while (dr.Read())
            {

                container = new Label();
                container.BackColor = Color.White;
                container.Width = 795;
                container.Height = 210;
                container.Cursor = Cursors.Hand;
                container.AutoSize = false;
                container.BorderStyle = BorderStyle.None;
                container.Margin = new Padding(13);
                container.Tag = dr["id"].ToString();
                container.Image = Properties.Resources.download__2_;

                destination = new Label();
                destination.Text = dr["destination"].ToString();
                destination.BackColor = Color.Transparent;
                destination.TextAlign = ContentAlignment.MiddleCenter;
                destination.Location = new Point(621, 48);
                destination.AutoSize = false;
                destination.Width = 120;
                destination.Height = 21;
                destination.Font = new Font("Nirmala", 12, FontStyle.Regular);
                destination.ForeColor = Color.Gray;


                textsource = new Label();
                textsource.Text = "Source:";
                textsource.BackColor = Color.Transparent;
                textsource.TextAlign = ContentAlignment.MiddleCenter;
                textsource.Location = new Point(35, 16);
                textsource.AutoSize = true;
                textsource.Font = new Font("Nirmala", 12, FontStyle.Regular);
                textsource.ForeColor = Color.Gray;

                buttonsource = new RadioButton();
                buttonsource.Text = "";
                buttonsource.BackColor = Color.Transparent;
                buttonsource.AutoSize = false;
                buttonsource.Height = 37;
                buttonsource.Width = 30;
                buttonsource.Location = new Point(121, 20);
                buttonsource.ForeColor = Color.Gray;


                linesource = new Label();
                linesource.Text = "";
                linesource.BackColor = Color.LightGray;
                linesource.Height = 2;
                linesource.Width = 422;
                linesource.Location = new Point(147, 38);



                buttondestination = new RadioButton();
                buttondestination.Text = "";
                buttondestination.BackColor = Color.Transparent;
                buttondestination.AutoSize = false;
                buttondestination.Height = 37;
                buttondestination.Width = 30;
                buttondestination.Location = new Point(578, 20);
                buttondestination.ForeColor = Color.Gray;

                textdestination = new Label();
                textdestination.Text = "Destination:";
                textdestination.BackColor = Color.Transparent;
                textdestination.TextAlign = ContentAlignment.MiddleCenter;
                textdestination.Location = new Point(635, 16);
                textdestination.AutoSize = true;
                textdestination.Font = new Font("Nirmala", 12, FontStyle.Regular);
                textdestination.ForeColor = Color.Gray;


                source = new Label();
                source.Text = dr["source"].ToString();
                source.BackColor = Color.Transparent;
                source.TextAlign = ContentAlignment.MiddleCenter;
                source.Location = new Point(13, 48);
                source.AutoSize = false;
                source.Width = 120;
                source.Height = 21;
                source.Font = new Font("Nirmala", 12, FontStyle.Regular);
                source.ForeColor = Color.Gray;




                trainname = new Label();
                trainname.Text = "Train Name:\n" + dr["trainname"].ToString();
                trainname.BackColor = Color.Transparent;
                trainname.TextAlign = ContentAlignment.MiddleCenter;
                trainname.Location = new Point(337, 159);
                trainname.AutoSize = true;
                trainname.Font = new Font("Nirmala", 12, FontStyle.Regular);
                trainname.ForeColor = Color.Gray;


                station = new Label();
                station.Text = dr["station"].ToString();
                station.BackColor = Color.Transparent;
                station.TextAlign = ContentAlignment.MiddleCenter;
                station.Location = new Point(13, 173);
                station.AutoSize = true;
                station.Font = new Font("Nirmala", 12, FontStyle.Regular);
                station.ForeColor = Color.Gray;


                departuretime = new Label();
                departuretime.Text = "Departure Time:\n" + dr["departuretime"].ToString();
                departuretime.BackColor = Color.Transparent;
                departuretime.TextAlign = ContentAlignment.MiddleCenter;
                departuretime.Location = new Point(621, 95); //25, 95
                departuretime.AutoSize = true;
                departuretime.Font = new Font("Nirmala", 12, FontStyle.Regular);
                departuretime.ForeColor = Color.Gray;



                arrivaldestinationtime = new Label();
                arrivaldestinationtime.Text = dr["arrivalatdestinationtime"].ToString();
                arrivaldestinationtime.BackColor = Color.Transparent;
                arrivaldestinationtime.TextAlign = ContentAlignment.MiddleCenter;
                arrivaldestinationtime.Location = new Point(669, 179); //540 , 95
                arrivaldestinationtime.AutoSize = true;
                arrivaldestinationtime.Font = new Font("Nirmala", 12, FontStyle.Regular);
                arrivaldestinationtime.ForeColor = Color.Gray;

                timetext = new Label();
                timetext.Text = "Date And Time:";
                timetext.BackColor = Color.Transparent;
                timetext.AutoSize = false;
                timetext.AutoSize = true;
                timetext.Location = new Point(618, 159);
                timetext.TextAlign = ContentAlignment.MiddleCenter;
                timetext.Font = new Font("Nirmala", 12, FontStyle.Regular);
                timetext.ForeColor = Color.Gray;

                date = new Label();
                date.Text = dr["date"].ToString();
                date.BackColor = Color.Transparent;
                date.Width = 120;
                date.Height = 30;
                date.Location = new Point(550, 179);
                date.Font = new Font("Nirmala", 12, FontStyle.Regular);
                date.ForeColor = Color.Gray;



                time = new Label();
                time.Text = "Arrival Time:\n" + dr["arrivaltime"].ToString();
                time.BackColor = Color.Transparent;
                time.AutoSize = true;
                time.Location = new Point(25, 95); //640,179
                time.Font = new Font("Nirmala", 12, FontStyle.Regular);
                time.ForeColor = Color.Gray;
                time.TextAlign = ContentAlignment.MiddleCenter;



              



                container.Controls.Add(timetext);
                container.Controls.Add(time);
                container.Controls.Add(date);
                container.Controls.Add(arrivaldestinationtime);
                container.Controls.Add(departuretime);
                container.Controls.Add(station);
                container.Controls.Add(trainname);
               
                container.Controls.Add(source);
                container.Controls.Add(textdestination);


                container.Controls.Add(buttondestination);
                container.Controls.Add(buttonsource);
                container.Controls.Add(linesource);

                container.Controls.Add(destination);
                container.Controls.Add(textsource);
                flowLayoutPanel1.Controls.Add(container);



                container.Click += new EventHandler(OnClick);

            }

            dr.Close();

            db.closeConnection();

        }

        private void alfredButton1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            Db db = new Db();
            db.openConnection();
            cm = new MySqlCommand("SELECT  `trainname`, `source`, `destination`, `date`, `arrivaltime`, `departuretime`, `arrivalatdestinationtime`, `totaltime`, `noofseats`, `ticketfare`, `distance`, `station`, `id` FROM `traintrips` WHERE `source`  LIKE'" + alfredTextBox1.Texts + "%' ORDER BY source  ", db.getConnection());
            dr = cm.ExecuteReader();
            while (dr.Read())
            {

                container = new Label();
                container.BackColor = Color.White;
                container.Width = 795;
                container.Height = 210;
                container.Cursor = Cursors.Hand;
                container.AutoSize = false;
                container.BorderStyle = BorderStyle.None;
                container.Margin = new Padding(13);
                container.Tag = dr["id"].ToString();
                container.Image = Properties.Resources.download__2_;

                destination = new Label();
                destination.Text = dr["destination"].ToString();
                destination.BackColor = Color.Transparent;
                destination.TextAlign = ContentAlignment.MiddleCenter;
                destination.Location = new Point(621, 48);
                destination.AutoSize = false;
                destination.Width = 120;
                destination.Height = 21;
                destination.Font = new Font("Nirmala", 12, FontStyle.Regular);
                destination.ForeColor = Color.Gray;


                textsource = new Label();
                textsource.Text = "Source:";
                textsource.BackColor = Color.Transparent;
                textsource.TextAlign = ContentAlignment.MiddleCenter;
                textsource.Location = new Point(35, 16);
                textsource.AutoSize = true;
                textsource.Font = new Font("Nirmala", 12, FontStyle.Regular);
                textsource.ForeColor = Color.Gray;

                buttonsource = new RadioButton();
                buttonsource.Text = "";
                buttonsource.BackColor = Color.Transparent;
                buttonsource.AutoSize = false;
                buttonsource.Height = 37;
                buttonsource.Width = 30;
                buttonsource.Location = new Point(121, 20);
                buttonsource.ForeColor = Color.Gray;


                linesource = new Label();
                linesource.Text = "";
                linesource.BackColor = Color.LightGray;
                linesource.Height = 2;
                linesource.Width = 422;
                linesource.Location = new Point(147, 38);



                buttondestination = new RadioButton();
                buttondestination.Text = "";
                buttondestination.BackColor = Color.Transparent;
                buttondestination.AutoSize = false;
                buttondestination.Height = 37;
                buttondestination.Width = 30;
                buttondestination.Location = new Point(578, 20);
                buttondestination.ForeColor = Color.Gray;

                textdestination = new Label();
                textdestination.Text = "Destination:";
                textdestination.BackColor = Color.Transparent;
                textdestination.TextAlign = ContentAlignment.MiddleCenter;
                textdestination.Location = new Point(635, 16);
                textdestination.AutoSize = true;
                textdestination.Font = new Font("Nirmala", 12, FontStyle.Regular);
                textdestination.ForeColor = Color.Gray;


                source = new Label();
                source.Text = dr["source"].ToString();
                source.BackColor = Color.Transparent;
                source.TextAlign = ContentAlignment.MiddleCenter;
                source.Location = new Point(13, 48);
                source.AutoSize = false;
                source.Width = 120;
                source.Height = 21;
                source.Font = new Font("Nirmala", 12, FontStyle.Regular);
                source.ForeColor = Color.Gray;




                trainname = new Label();
                trainname.Text = "Train Name:\n" + dr["trainname"].ToString();
                trainname.BackColor = Color.Transparent;
                trainname.TextAlign = ContentAlignment.MiddleCenter;
                trainname.Location = new Point(337, 159);
                trainname.AutoSize = true;
                trainname.Font = new Font("Nirmala", 12, FontStyle.Regular);
                trainname.ForeColor = Color.Gray;


                station = new Label();
                station.Text = dr["station"].ToString();
                station.BackColor = Color.Transparent;
                station.TextAlign = ContentAlignment.MiddleCenter;
                station.Location = new Point(13, 173);
                station.AutoSize = true;
                station.Font = new Font("Nirmala", 12, FontStyle.Regular);
                station.ForeColor = Color.Gray;


                departuretime = new Label();
                departuretime.Text = "Departure Time:\n" + dr["departuretime"].ToString();
                departuretime.BackColor = Color.Transparent;
                departuretime.TextAlign = ContentAlignment.MiddleCenter;
                departuretime.Location = new Point(621, 95); //25, 95
                departuretime.AutoSize = true;
                departuretime.Font = new Font("Nirmala", 12, FontStyle.Regular);
                departuretime.ForeColor = Color.Gray;



                arrivaldestinationtime = new Label();
                arrivaldestinationtime.Text = dr["arrivalatdestinationtime"].ToString();
                arrivaldestinationtime.BackColor = Color.Transparent;
                arrivaldestinationtime.TextAlign = ContentAlignment.MiddleCenter;
                arrivaldestinationtime.Location = new Point(669, 179); //540 , 95
                arrivaldestinationtime.AutoSize = true;
                arrivaldestinationtime.Font = new Font("Nirmala", 12, FontStyle.Regular);
                arrivaldestinationtime.ForeColor = Color.Gray;

                timetext = new Label();
                timetext.Text = "Date And Time:";
                timetext.BackColor = Color.Transparent;
                timetext.AutoSize = false;
                timetext.AutoSize = true;
                timetext.Location = new Point(618, 159);
                timetext.TextAlign = ContentAlignment.MiddleCenter;
                timetext.Font = new Font("Nirmala", 12, FontStyle.Regular);
                timetext.ForeColor = Color.Gray;

                date = new Label();
                date.Text = dr["date"].ToString();
                date.BackColor = Color.Transparent;
                date.Width = 120;
                date.Height = 30;
                date.Location = new Point(550, 179);
                date.Font = new Font("Nirmala", 12, FontStyle.Regular);
                date.ForeColor = Color.Gray;



                time = new Label();
                time.Text = "Arrival Time:\n" + dr["arrivaltime"].ToString();
                time.BackColor = Color.Transparent;
                time.AutoSize = true;
                time.Location = new Point(25, 95); //640,179
                time.Font = new Font("Nirmala", 12, FontStyle.Regular);
                time.ForeColor = Color.Gray;
                time.TextAlign = ContentAlignment.MiddleCenter;




                container.Controls.Add(timetext);
                container.Controls.Add(time);
                container.Controls.Add(date);
                container.Controls.Add(arrivaldestinationtime);
                container.Controls.Add(departuretime);
                container.Controls.Add(station);
                container.Controls.Add(trainname);
               
                container.Controls.Add(source);
                container.Controls.Add(textdestination);


                container.Controls.Add(buttondestination);
                container.Controls.Add(buttonsource);
                container.Controls.Add(linesource);

                container.Controls.Add(destination);
                container.Controls.Add(textsource);
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
            cm = new MySqlCommand("SELECT  `trainname`, `source`, `destination`, `date`, `arrivaltime`, `departuretime`, `arrivalatdestinationtime`, `totaltime`, `noofseats`, `ticketfare`, `distance`, `station`, `id` FROM `traintrips` WHERE `destination`  LIKE'" + alfredTextBox2.Texts + "%' ORDER BY destination  ", db.getConnection());
            dr = cm.ExecuteReader();
            while (dr.Read())
            {

                container = new Label();
                container.BackColor = Color.White;
                container.Width = 795;
                container.Height = 210;
                container.Cursor = Cursors.Hand;
                container.AutoSize = false;
                container.BorderStyle = BorderStyle.None;
                container.Margin = new Padding(13);
                container.Tag = dr["id"].ToString();
                container.Image = Properties.Resources.download__2_;

                destination = new Label();
                destination.Text = dr["destination"].ToString();
                destination.BackColor = Color.Transparent;
                destination.TextAlign = ContentAlignment.MiddleCenter;
                destination.Location = new Point(621, 48);
                destination.AutoSize = false;
                destination.Width = 120;
                destination.Height = 21;
                destination.Font = new Font("Nirmala", 12, FontStyle.Regular);
                destination.ForeColor = Color.Gray;


                textsource = new Label();
                textsource.Text = "Source:";
                textsource.BackColor = Color.Transparent;
                textsource.TextAlign = ContentAlignment.MiddleCenter;
                textsource.Location = new Point(35, 16);
                textsource.AutoSize = true;
                textsource.Font = new Font("Nirmala", 12, FontStyle.Regular);
                textsource.ForeColor = Color.Gray;

                buttonsource = new RadioButton();
                buttonsource.Text = "";
                buttonsource.BackColor = Color.Transparent;
                buttonsource.AutoSize = false;
                buttonsource.Height = 37;
                buttonsource.Width = 30;
                buttonsource.Location = new Point(121, 20);
                buttonsource.ForeColor = Color.Gray;


                linesource = new Label();
                linesource.Text = "";
                linesource.BackColor = Color.LightGray;
                linesource.Height = 2;
                linesource.Width = 422;
                linesource.Location = new Point(147, 38);



                buttondestination = new RadioButton();
                buttondestination.Text = "";
                buttondestination.BackColor = Color.Transparent;
                buttondestination.AutoSize = false;
                buttondestination.Height = 37;
                buttondestination.Width = 30;
                buttondestination.Location = new Point(578, 20);
                buttondestination.ForeColor = Color.Gray;

                textdestination = new Label();
                textdestination.Text = "Destination:";
                textdestination.BackColor = Color.Transparent;
                textdestination.TextAlign = ContentAlignment.MiddleCenter;
                textdestination.Location = new Point(635, 16);
                textdestination.AutoSize = true;
                textdestination.Font = new Font("Nirmala", 12, FontStyle.Regular);
                textdestination.ForeColor = Color.Gray;


                source = new Label();
                source.Text = dr["source"].ToString();
                source.BackColor = Color.Transparent;
                source.TextAlign = ContentAlignment.MiddleCenter;
                source.Location = new Point(13, 48);
                source.AutoSize = false;
                source.Width = 120;
                source.Height = 21;
                source.Font = new Font("Nirmala", 12, FontStyle.Regular);
                source.ForeColor = Color.Gray;




                trainname = new Label();
                trainname.Text = "Train Name:\n" + dr["trainname"].ToString();
                trainname.BackColor = Color.Transparent;
                trainname.TextAlign = ContentAlignment.MiddleCenter;
                trainname.Location = new Point(337, 159);
                trainname.AutoSize = true;
                trainname.Font = new Font("Nirmala", 12, FontStyle.Regular);
                trainname.ForeColor = Color.Gray;


                station = new Label();
                station.Text = dr["station"].ToString();
                station.BackColor = Color.Transparent;
                station.TextAlign = ContentAlignment.MiddleCenter;
                station.Location = new Point(13, 173);
                station.AutoSize = true;
                station.Font = new Font("Nirmala", 12, FontStyle.Regular);
                station.ForeColor = Color.Gray;


                departuretime = new Label();
                departuretime.Text = "Departure Time:\n" + dr["departuretime"].ToString();
                departuretime.BackColor = Color.Transparent;
                departuretime.TextAlign = ContentAlignment.MiddleCenter;
                departuretime.Location = new Point(621, 95); //25, 95
                departuretime.AutoSize = true;
                departuretime.Font = new Font("Nirmala", 12, FontStyle.Regular);
                departuretime.ForeColor = Color.Gray;



                arrivaldestinationtime = new Label();
                arrivaldestinationtime.Text = dr["arrivalatdestinationtime"].ToString();
                arrivaldestinationtime.BackColor = Color.Transparent;
                arrivaldestinationtime.TextAlign = ContentAlignment.MiddleCenter;
                arrivaldestinationtime.Location = new Point(669, 179); //540 , 95
                arrivaldestinationtime.AutoSize = true;
                arrivaldestinationtime.Font = new Font("Nirmala", 12, FontStyle.Regular);
                arrivaldestinationtime.ForeColor = Color.Gray;

                timetext = new Label();
                timetext.Text = "Date And Time:";
                timetext.BackColor = Color.Transparent;
                timetext.AutoSize = false;
                timetext.AutoSize = true;
                timetext.Location = new Point(618, 159);
                timetext.TextAlign = ContentAlignment.MiddleCenter;
                timetext.Font = new Font("Nirmala", 12, FontStyle.Regular);
                timetext.ForeColor = Color.Gray;

                date = new Label();
                date.Text = dr["date"].ToString();
                date.BackColor = Color.Transparent;
                date.Width = 120;
                date.Height = 30;
                date.Location = new Point(550, 179);
                date.Font = new Font("Nirmala", 12, FontStyle.Regular);
                date.ForeColor = Color.Gray;



                time = new Label();
                time.Text = "Arrival Time:\n" + dr["arrivaltime"].ToString();
                time.BackColor = Color.Transparent;
                time.AutoSize = true;
                time.Location = new Point(25, 95); //640,179
                time.Font = new Font("Nirmala", 12, FontStyle.Regular);
                time.ForeColor = Color.Gray;
                time.TextAlign = ContentAlignment.MiddleCenter;




                container.Controls.Add(timetext);
                container.Controls.Add(time);
                container.Controls.Add(date);
                container.Controls.Add(arrivaldestinationtime);
                container.Controls.Add(departuretime);
                container.Controls.Add(station);
                container.Controls.Add(trainname);
                
                container.Controls.Add(source);
                container.Controls.Add(textdestination);


                container.Controls.Add(buttondestination);
                container.Controls.Add(buttonsource);
                container.Controls.Add(linesource);

                container.Controls.Add(destination);
                container.Controls.Add(textsource);
                flowLayoutPanel1.Controls.Add(container);



                container.Click += new EventHandler(OnClick);

            }

            dr.Close();

            db.closeConnection();
        }

        private void alfredButton2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            Db db = new Db();
            db.openConnection();
            cm = new MySqlCommand("SELECT  `trainname`, `source`, `destination`, `date`, `arrivaltime`, `departuretime`, `arrivalatdestinationtime`, `totaltime`, `noofseats`, `ticketfare`, `distance`, `station`, `id` FROM `traintrips` WHERE `destination`  LIKE'" + alfredTextBox2.Texts + "%' ORDER BY destination  ", db.getConnection());
            dr = cm.ExecuteReader();
            while (dr.Read())
            {

                container = new Label();
                container.BackColor = Color.White;
                container.Width = 795;
                container.Height = 210;
                container.Cursor = Cursors.Hand;
                container.AutoSize = false;
                container.BorderStyle = BorderStyle.None;
                container.Margin = new Padding(13);
                container.Tag = dr["id"].ToString();
                container.Image = Properties.Resources.download__2_;

                destination = new Label();
                destination.Text = dr["destination"].ToString();
                destination.BackColor = Color.Transparent;
                destination.TextAlign = ContentAlignment.MiddleCenter;
                destination.Location = new Point(621, 48);
                destination.AutoSize = false;
                destination.Width = 120;
                destination.Height = 21;
                destination.Font = new Font("Nirmala", 12, FontStyle.Regular);
                destination.ForeColor = Color.Gray;


                textsource = new Label();
                textsource.Text = "Source:";
                textsource.BackColor = Color.Transparent;
                textsource.TextAlign = ContentAlignment.MiddleCenter;
                textsource.Location = new Point(35, 16);
                textsource.AutoSize = true;
                textsource.Font = new Font("Nirmala", 12, FontStyle.Regular);
                textsource.ForeColor = Color.Gray;

                buttonsource = new RadioButton();
                buttonsource.Text = "";
                buttonsource.BackColor = Color.Transparent;
                buttonsource.AutoSize = false;
                buttonsource.Height = 37;
                buttonsource.Width = 30;
                buttonsource.Location = new Point(121, 20);
                buttonsource.ForeColor = Color.Gray;


                linesource = new Label();
                linesource.Text = "";
                linesource.BackColor = Color.LightGray;
                linesource.Height = 2;
                linesource.Width = 422;
                linesource.Location = new Point(147, 38);



                buttondestination = new RadioButton();
                buttondestination.Text = "";
                buttondestination.BackColor = Color.Transparent;
                buttondestination.AutoSize = false;
                buttondestination.Height = 37;
                buttondestination.Width = 30;
                buttondestination.Location = new Point(578, 20);
                buttondestination.ForeColor = Color.Gray;

                textdestination = new Label();
                textdestination.Text = "Destination:";
                textdestination.BackColor = Color.Transparent;
                textdestination.TextAlign = ContentAlignment.MiddleCenter;
                textdestination.Location = new Point(635, 16);
                textdestination.AutoSize = true;
                textdestination.Font = new Font("Nirmala", 12, FontStyle.Regular);
                textdestination.ForeColor = Color.Gray;


                source = new Label();
                source.Text = dr["source"].ToString();
                source.BackColor = Color.Transparent;
                source.TextAlign = ContentAlignment.MiddleCenter;
                source.Location = new Point(13, 48);
                source.AutoSize = false;
                source.Width = 120;
                source.Height = 21;
                source.Font = new Font("Nirmala", 12, FontStyle.Regular);
                source.ForeColor = Color.Gray;




                trainname = new Label();
                trainname.Text = "Train Name:\n" + dr["trainname"].ToString();
                trainname.BackColor = Color.Transparent;
                trainname.TextAlign = ContentAlignment.MiddleCenter;
                trainname.Location = new Point(337, 159);
                trainname.AutoSize = true;
                trainname.Font = new Font("Nirmala", 12, FontStyle.Regular);
                trainname.ForeColor = Color.Gray;


                station = new Label();
                station.Text = dr["station"].ToString();
                station.BackColor = Color.Transparent;
                station.TextAlign = ContentAlignment.MiddleCenter;
                station.Location = new Point(13, 173);
                station.AutoSize = true;
                station.Font = new Font("Nirmala", 12, FontStyle.Regular);
                station.ForeColor = Color.Gray;


                departuretime = new Label();
                departuretime.Text = "Departure Time:\n" + dr["departuretime"].ToString();
                departuretime.BackColor = Color.Transparent;
                departuretime.TextAlign = ContentAlignment.MiddleCenter;
                departuretime.Location = new Point(621, 95); //25, 95
                departuretime.AutoSize = true;
                departuretime.Font = new Font("Nirmala", 12, FontStyle.Regular);
                departuretime.ForeColor = Color.Gray;



                arrivaldestinationtime = new Label();
                arrivaldestinationtime.Text = dr["arrivalatdestinationtime"].ToString();
                arrivaldestinationtime.BackColor = Color.Transparent;
                arrivaldestinationtime.TextAlign = ContentAlignment.MiddleCenter;
                arrivaldestinationtime.Location = new Point(669, 179); //540 , 95
                arrivaldestinationtime.AutoSize = true;
                arrivaldestinationtime.Font = new Font("Nirmala", 12, FontStyle.Regular);
                arrivaldestinationtime.ForeColor = Color.Gray;

                timetext = new Label();
                timetext.Text = "Date And Time:";
                timetext.BackColor = Color.Transparent;
                timetext.AutoSize = false;
                timetext.AutoSize = true;
                timetext.Location = new Point(618, 159);
                timetext.TextAlign = ContentAlignment.MiddleCenter;
                timetext.Font = new Font("Nirmala", 12, FontStyle.Regular);
                timetext.ForeColor = Color.Gray;

                date = new Label();
                date.Text = dr["date"].ToString();
                date.BackColor = Color.Transparent;
                date.Width = 120;
                date.Height = 30;
                date.Location = new Point(550, 179);
                date.Font = new Font("Nirmala", 12, FontStyle.Regular);
                date.ForeColor = Color.Gray;



                time = new Label();
                time.Text = "Arrival Time:\n" + dr["arrivaltime"].ToString();
                time.BackColor = Color.Transparent;
                time.AutoSize = true;
                time.Location = new Point(25, 95); //640,179
                time.Font = new Font("Nirmala", 12, FontStyle.Regular);
                time.ForeColor = Color.Gray;
                time.TextAlign = ContentAlignment.MiddleCenter;



                container.Controls.Add(timetext);
                container.Controls.Add(time);
                container.Controls.Add(date);
                container.Controls.Add(arrivaldestinationtime);
                container.Controls.Add(departuretime);
                container.Controls.Add(station);
                container.Controls.Add(trainname);
                
                container.Controls.Add(source);
                container.Controls.Add(textdestination);


                container.Controls.Add(buttondestination);
                container.Controls.Add(buttonsource);
                container.Controls.Add(linesource);

                container.Controls.Add(destination);
                container.Controls.Add(textsource);
                flowLayoutPanel1.Controls.Add(container);



                container.Click += new EventHandler(OnClick);

            }

            dr.Close();

            db.closeConnection();
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            passengermessage f1 = new passengermessage();
            f1.ShowDialog();
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
