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
    public partial class MyTrips : Form
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
        private Label fullname;
        private Label username;
        private Label source;
        private Label destination;
        private Label date;
        private Label container = new Label();
        private Label time;
        private RadioButton buttonsource;
        private RadioButton buttondestination;
        private Label linesource;
        private Label departuretime;
        private Label ticketfare;
        private Label bookingcode;
        private Label seatno;
        private Label tripcode;

        public MyTrips()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panelNav.Height = MyTripsButton.Height;
            panelNav.Top = MyTripsButton.Top;
            panelNav.Left = MyTripsButton.Left;
            MyTripsButton.BackColor = Color.WhiteSmoke;
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
        public static string setValueForText15 = "";

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginpassenger f8 = new loginpassenger();
            f8.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
            this.WindowState = FormWindowState.Minimized;
        }
        private void GetData()
        {



            flowLayoutPanel1.Controls.Clear();

            Db db = new Db();
            db.openConnection();
            cm = new MySqlCommand("SELECT `id`, `fullname`, `username`, `phonenumber`, `email`, `bookingcode`, `seatno`, `trainname`, `source`, `destination`, `date`, `arrivaltime`, `trainid`, `departuretime`, `totaltime`, `ticketfare`, `distance`, `time`, `station`, `tripcode` FROM `booking` WHERE `username`='" + labelUsername.Text + "' ORDER by `date`", db.getConnection());
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
                container.Height = 340;
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
                destination.Location = new Point(621, 47);
                destination.AutoSize = false;
                destination.Width = 120;
                destination.Height = 21;
                destination.Font = new Font("Nirmala", 12, FontStyle.Regular);
                destination.ForeColor = Color.Gray;

                source = new Label();
                source.Text = dr["source"].ToString();
                source.BackColor = Color.Transparent;
                source.TextAlign = ContentAlignment.MiddleCenter;
                source.Location = new Point(9, 47);
                source.AutoSize = false;
                source.Width = 120;
                source.Height = 21;
                source.Font = new Font("Nirmala", 12, FontStyle.Regular);
                source.ForeColor = Color.Gray;



                buttonsource = new RadioButton();
                buttonsource.Text = "";
                buttonsource.BackColor = Color.Transparent;
                buttonsource.AutoSize = false;
                buttonsource.Height = 37;
                buttonsource.Width = 30;
                buttonsource.Location = new Point(141, 47);
                buttonsource.ForeColor = Color.Gray;


                linesource = new Label();
                linesource.Text = "";
                linesource.BackColor = Color.LightGray;
                linesource.Height = 2;
                linesource.Width = 422;
                linesource.Location = new Point(169, 65);


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
                buttondestination.Location = new Point(600, 47);
                buttondestination.ForeColor = Color.Gray;

             


                

                fullname = new Label();
                fullname.Text =  dr["fullname"].ToString();
                fullname.BackColor = Color.Transparent;
                fullname.TextAlign = ContentAlignment.MiddleCenter;
                fullname.Location = new Point(16, 15);
                fullname.AutoSize = true;
                fullname.Font = new Font("Nirmala", 12, FontStyle.Regular);
                fullname.ForeColor = Color.Gray;

                username = new Label();
                username.Text = dr["username"].ToString();
                username.BackColor = Color.Transparent;
                username.TextAlign = ContentAlignment.MiddleCenter;
                username.Location = new Point(610, 15);
                username.AutoSize = true;
                username.Font = new Font("Nirmala", 12, FontStyle.Regular);
                username.ForeColor = Color.Gray;


                trainname = new Label();
                trainname.Text = "Train Name:\n" + dr["trainname"].ToString();
                trainname.BackColor = Color.Transparent;
                trainname.TextAlign = ContentAlignment.MiddleCenter;
                trainname.Location = new Point(13, 190);
                trainname.AutoSize = true;
                trainname.Font = new Font("Nirmala", 12, FontStyle.Regular);
                trainname.ForeColor = Color.Gray;

                bookingcode = new Label();
                bookingcode.Text = "Booking Code:\n" + dr["bookingcode"].ToString();
                bookingcode.BackColor = Color.Transparent;
                bookingcode.TextAlign = ContentAlignment.MiddleCenter;
                bookingcode.Location = new Point(13, 269);
                bookingcode.AutoSize = true;
                bookingcode.Font = new Font("Nirmala", 12, FontStyle.Regular);
                bookingcode.ForeColor = Color.Gray;

                ticketfare = new Label();
                ticketfare.Text = "Ticket Fare:\n"+ dr["ticketfare"].ToString();
                ticketfare.BackColor = Color.Transparent;
                ticketfare.TextAlign = ContentAlignment.MiddleCenter;
                ticketfare.Location = new Point(623, 190);
                ticketfare.AutoSize = true;
                ticketfare.Font = new Font("Nirmala", 12, FontStyle.Regular);
                ticketfare.ForeColor = Color.Gray;

                tripcode = new Label();
                tripcode.Text = "Trip Code:\n" + dr["tripcode"].ToString();
                tripcode.BackColor = Color.Transparent;
                tripcode.TextAlign = ContentAlignment.MiddleCenter;
                tripcode.Location = new Point(623, 269);
                tripcode.AutoSize = true;
                tripcode.Font = new Font("Nirmala", 12, FontStyle.Regular);
                tripcode.ForeColor = Color.Gray;



                departuretime = new Label();
                departuretime.Text = "Departure Time:\n" + dr["departuretime"].ToString();
                departuretime.BackColor = Color.Transparent;
                departuretime.TextAlign = ContentAlignment.MiddleCenter;
                departuretime.Location = new Point(621, 100); 
                departuretime.AutoSize = true;
                departuretime.Font = new Font("Nirmala", 12, FontStyle.Regular);
                departuretime.ForeColor = Color.Gray;



              

                date = new Label();
                date.Text = "Date:\n" + dr["date"].ToString();
                date.BackColor = Color.Transparent;
                date.Height = 74;
                date.Width = 114;
                date.Location = new Point(13, 100);
                date.Font = new Font("Nirmala", 12, FontStyle.Regular);
                date.ForeColor = Color.Gray;
                date.TextAlign = ContentAlignment.MiddleCenter;



                time = new Label();
                time.Text = "Arrival Time:\n" + dr["arrivaltime"].ToString();
                time.BackColor = Color.Transparent;
                time.AutoSize = true;
                time.Location = new Point(325, 100); 
                time.Font = new Font("Nirmala", 12, FontStyle.Regular);
                time.ForeColor = Color.Gray;
                time.TextAlign = ContentAlignment.MiddleCenter;

                seatno = new Label();
                seatno.Text = "Seat Number:\n" + dr["seatno"].ToString();
                seatno.BackColor = Color.Transparent;
                seatno.AutoSize = true;
                seatno.Location = new Point(325, 269); 
                seatno.Font = new Font("Nirmala", 12, FontStyle.Regular);
                seatno.ForeColor = Color.Gray;
                seatno.TextAlign = ContentAlignment.MiddleCenter;








                container.Controls.Add(tripcode);
                container.Controls.Add(time);
                container.Controls.Add(date);
                container.Controls.Add(bookingcode);
                container.Controls.Add(departuretime);
                container.Controls.Add(seatno);
                container.Controls.Add(trainname);
                container.Controls.Add(source);
                container.Controls.Add(ticketfare);
                container.Controls.Add(buttondestination);
                container.Controls.Add(buttonsource);
                container.Controls.Add(linesource);
                container.Controls.Add(destination);
                container.Controls.Add(fullname);
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
            cm = new MySqlCommand("SELECT * FROM `booking` WHERE `id` LIKE '" + tag + "'", db.getConnection());
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {


                textBoxId.Text = dr["id"].ToString();
                textBoxFullname.Text= dr["fullname"].ToString();
                textBoxUsername.Text = dr["username"].ToString();
                textBoxTrainName.Text = dr["trainname"].ToString();
                textBoxPhonenumber.Text = dr["Phonenumber"].ToString();
                textBoxBookingCode.Text = dr["bookingcode"].ToString();
                textBoxTripCode.Text = dr["tripcode"].ToString();
                textBoxSeatNo.Text = dr["seatno"].ToString();
                textBoxTicketFare.Text = dr["ticketfare"].ToString();
                textBoxSource.Text = dr["source"].ToString();
                textBoxDestination.Text = dr["destination"].ToString();
                textBoxDate.Text = dr["date"].ToString();
                textBoxArrivalTime.Text = dr["arrivaltime"].ToString();
                textBoxDepartureTime.Text = dr["departuretime"].ToString();
              
                textBoxTicketFare.Text = dr["ticketfare"].ToString();
                textBoxDistance.Text = dr["distance"].ToString();
                
                textBoxStation.Text = dr["station"].ToString();



            


            }











            dr.Close();

            db.closeConnection();
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

                panelNav.Height = MyTripsButton.Height;
                panelNav.Top = MyTripsButton.Top;
                panelNav.Left = MyTripsButton.Left;
                MyTripsButton.BackColor = Color.Black;


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

                panelNav.Height = MyTripsButton.Height;
                panelNav.Top = MyTripsButton.Top;
                panelNav.Left = MyTripsButton.Left;
                MyTripsButton.BackColor = Color.WhiteSmoke;

            }
        }

        private void MyTrips_Load(object sender, EventArgs e)
        {
            labelUsername.Text = loginpassenger.recall;
            labelUsername.Text = labelUsername.Text.ToUpper();
            GetData();

            if (labelUsername.Text == "")
            {
                MessageBox.Show("You have to be registered before you can view your trips!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                this.Hide();
                loginpassenger F6 = new loginpassenger();
                F6.ShowDialog();
                this.Close();
            }
        }

        private void PassengersSettingsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            passengerssettings f1 = new passengerssettings();
            f1.ShowDialog();
            this.Close();
        }

        private void alfredButton2_Click(object sender, EventArgs e)
        {
            SetValueForText1 = textBoxFullname.Text;
            SetValueForText2 = textBoxUsername.Text;
            SetValueForText3 = textBoxSource.Text;
            SetValueForText4 = textBoxDestination.Text;
            SetValueForText5 = textBoxPhonenumber.Text;
            SetValueForText6 = textBoxBookingCode.Text;
            SetValueForText7 = textBoxTripCode.Text;
            SetValueForText8 = textBoxSeatNo.Text;
            SetValueForText9 = textBoxTicketFare.Text;
            SetValueForText10 = textBoxTrainName.Text;
            SetValueForText11 = textBoxStation.Text;
            setValueForText12 = textBoxDate.Text;
            setValueForText13 = textBoxArrivalTime.Text;
            setValueForText14 = textBoxDepartureTime.Text;
            setValueForText15 = textBoxDistance.Text;




            this.Hide();
            ticket2 F1 = new ticket2();
            F1.ShowDialog();
            this.Close();
        }

        private void alfredButton1_Click(object sender, EventArgs e)
        {
            Db db = new Db();
            //MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=railwayreservationsystem");
            try
            {
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM `booking` WHERE id='" + textBoxId.Text + "'", db.getConnection());

                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Trip has been deleted successfully","Success",MessageBoxButtons.OK, MessageBoxIcon.Information);


                GetData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            db.closeConnection();
        }
    }
}
