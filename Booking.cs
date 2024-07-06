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
    public partial class Booking : Form
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
        public Booking()
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
        public static string setValueForText15 = "";

        private void Booking_Load(object sender, EventArgs e)
        {
            labelUsername.Text = loginpassenger.recall;
            labelUsername.Text = labelUsername.Text.ToUpper();
            if (labelUsername.Text!="")
            {


                textBoxId.Text = BookTrips.SetValueForText1;
                textBoxTrainName.Text = BookTrips.SetValueForText2;
                textBoxSource.Text = BookTrips.SetValueForText3;
                textBoxDestination.Text = BookTrips.SetValueForText4;
                textBoxDate.Text = BookTrips.SetValueForText5;
                textBoxArrivalTime.Text = BookTrips.SetValueForText6;
                textBoxDepartureTime.Text = BookTrips.SetValueForText7;
                textBoxTotalTime.Text = BookTrips.SetValueForText8;
                textBoxNoOfSeats.Text = BookTrips.SetValueForText9;

                textBoxTicketFare.Text = BookTrips.SetValueForText10;
                textBoxDistance.Text = BookTrips.SetValueForText11;
                textBoxArrivalDestination.Text = BookTrips.setValueForText12;
                textBoxStation.Text = BookTrips.setValueForText13;
                textBoxTripCode.Text = BookTrips.setValueForText14;

                int length = 10;

                //creating a string builder object()
                StringBuilder str_build = new StringBuilder();
                Random random = new Random();

                char letter;
                for (int i = 0; i < length; i++)
                {
                    double flt = random.NextDouble();
                    int shift = Convert.ToInt32(Math.Floor(25 * flt));
                    letter = Convert.ToChar(shift + 65);
                    str_build.Append(letter);

                }
                textBoxBookingCode.Text = str_build.ToString();
                textBoxBookingCode.ReadOnly = true;

                Db db = new Db();
                db.openConnection();
                MySqlCommand fredthedeve = new MySqlCommand("SELECT COUNT(*) FROM `booking` WHERE trainid='" + textBoxId.Text + "'", db.getConnection());
                int count = (int)(long)fredthedeve.ExecuteScalar();

                int valve = int.Parse(textBoxNoOfSeats.Text);
                //fredthedevs.Text = "following records" + count + "";

                if (count == valve)
                {
                    MessageBox.Show("please select another train going to your destination!", "This train is full", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    BookTrips F6 = new BookTrips();
                    F6.ShowDialog();
                    this.Close();

                }



                else
                {
                    Random rnd = new Random();
                    int generate = rnd.Next(0, Convert.ToInt32(textBoxNoOfSeats.Text) + 1);
                    textBoxSeatno.Text = Convert.ToString(generate);


                    if (checkseatno())
                    {
                        this.Hide();
                        Booking F7 = new Booking();
                        F7.ShowDialog();
                        this.Close();

                    }


                }
            }
            else
            {
                MessageBox.Show("Only Registered passengers can book tickets", "Booking Failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                this.Hide();
                loginpassenger F7 = new loginpassenger();
                F7.ShowDialog();
                this.Close();
            }




        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public Boolean checkseatno()
        {

            Db db = new Db();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT `id`, `fullname`, `username`, `phonenumber`, `email`, `bookingcode`, `seatno`, `trainname`, `source`, `destination`,  `arrivaltime`, `trainid`, `departuretime`, `totaltime`, `ticketfare`, `distance`, `time`, `station`, `tripcode` FROM `booking` WHERE `seatno` ='" + textBoxSeatno.Text + "' AND `trainid` ='" + textBoxId.Text + "'", db.getConnection());

            command.Parameters.Add(textBoxSeatno.Text, MySqlDbType.VarChar).Value = textBoxSeatno.Text;
            adapter.SelectCommand = command;

            adapter.Fill(table);

            // check if the seat no already exists in the database 
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean checkBookingCode()
        {

            Db db = new Db();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT `id`, `fullname`, `username`, `phonenumber`, `email`, `bookingcode`, `seatno`, `trainname`, `source`, `destination`,  `arrivaltime`, `trainid`, `departuretime`, `totaltime`, `ticketfare`, `distance`, `time`, `station`, `tripcode` FROM `booking` WHERE `bookingcode` ='" + textBoxBookingCode.Text + "'", db.getConnection());

            command.Parameters.Add(textBoxBookingCode.Text, MySqlDbType.VarChar).Value = textBoxBookingCode.Text;
            adapter.SelectCommand = command;

            adapter.Fill(table);

            // check if the Booking Code already exists in the database 
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            PassengersDashboard f8 = new PassengersDashboard();
            f8.ShowDialog();
            this.Close();

        }

        private void BookingButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookTrips f8 = new BookTrips();
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
                textBoxId.ForeColor = Color.Black;

                Cancel.ForeColor = Color.White;
                label4.BackColor = Color.White;
                this.BackColor = Color.Black;


                textBoxTrainName.BackColor = Color.Black;
                textBoxTrainName.ForeColor = Color.White;
                textBoxSource.BackColor = Color.Black;
                textBoxSource.ForeColor = Color.White;
                textBoxDestination.BackColor = Color.Black;
                textBoxDestination.ForeColor = Color.White;
                textBoxDate.BackColor = Color.Black;
                textBoxDate.ForeColor = Color.White;
                textBoxArrivalTime.BackColor = Color.Black;
                textBoxArrivalTime.ForeColor = Color.White;
                textBoxDepartureTime.BackColor = Color.Black;
                textBoxDepartureTime.ForeColor = Color.White;
                textBoxTotalTime.BackColor = Color.Black;
                textBoxTotalTime.ForeColor = Color.White;
                textBoxNoOfSeats.BackColor = Color.Black;
                textBoxNoOfSeats.ForeColor = Color.White;
                textBoxTicketFare.BackColor = Color.Black;
                textBoxTicketFare.ForeColor = Color.White;
                textBoxDistance.BackColor = Color.Black;
                textBoxDistance.ForeColor = Color.White;
                textBoxArrivalDestination.BackColor = Color.Black;
                textBoxArrivalDestination.ForeColor = Color.White;
                textBoxStation.BackColor = Color.Black;
                textBoxStation.ForeColor = Color.White;
                textBoxFullname.BackColor = Color.Black;
                textBoxFullname.ForeColor = Color.WhiteSmoke;
                textBoxUsername.BackColor = Color.Black;
                textBoxUsername.ForeColor = Color.WhiteSmoke;
                textBoxPhonenumber.BackColor = Color.Black;
                textBoxPhonenumber.ForeColor = Color.WhiteSmoke;
                textBoxEmail.BackColor = Color.Black;
                textBoxEmail.ForeColor = Color.WhiteSmoke;
                textBoxSeatno.BackColor = Color.Black;
                textBoxSeatno.ForeColor = Color.WhiteSmoke;
                textBoxBookingCode.BackColor = Color.Black;
                textBoxBookingCode.ForeColor = Color.WhiteSmoke;
                textBoxTripCode.BackColor = Color.Black;
                textBoxTripCode.ForeColor = Color.White;
                label17.BackColor = Color.White;
                label18.BackColor = Color.White;
                label19.BackColor = Color.White;
                label20.BackColor = Color.White;
                label21.BackColor = Color.White;
                label22.BackColor = Color.White;
                panel3.BackColor = Color.Black;


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
                textBoxId.ForeColor = Color.WhiteSmoke;

                textBoxTrainName.BackColor = Color.White;
                textBoxTrainName.ForeColor = Color.Black;
                textBoxSource.BackColor = Color.White;
                textBoxSource.ForeColor = Color.Black;
                textBoxDestination.BackColor = Color.White;
                textBoxDestination.ForeColor = Color.Black;
                textBoxDate.BackColor = Color.White;
                textBoxDate.ForeColor = Color.Black;
                textBoxArrivalTime.BackColor = Color.White;
                textBoxArrivalTime.ForeColor = Color.Black ;
                textBoxDepartureTime.BackColor = Color.White;
                textBoxDepartureTime.ForeColor = Color.Black;
                textBoxTotalTime.BackColor = Color.White;
                textBoxTotalTime.ForeColor = Color.Black;
                textBoxNoOfSeats.BackColor = Color.White;
                textBoxNoOfSeats.ForeColor = Color.Black;
                textBoxTicketFare.BackColor = Color.White;
                textBoxTicketFare.ForeColor = Color.Black;
                textBoxDistance.BackColor = Color.White;
                textBoxDistance.ForeColor = Color.Black;
                textBoxArrivalDestination.BackColor = Color.White;
                textBoxArrivalDestination.ForeColor = Color.Black;
                textBoxStation.BackColor = Color.White;
                textBoxStation.ForeColor = Color.Black;
                textBoxFullname.BackColor = Color.White;
                textBoxFullname.ForeColor = Color.Black;
                textBoxUsername.BackColor = Color.White;
                textBoxUsername.ForeColor = Color.Black;
                textBoxPhonenumber.BackColor = Color.White;
                textBoxPhonenumber.ForeColor = Color.Black;
                textBoxEmail.BackColor = Color.White;
                textBoxEmail.ForeColor = Color.Black;
                textBoxSeatno.BackColor = Color.White;
                textBoxSeatno.ForeColor = Color.Black;
                textBoxBookingCode.BackColor = Color.White;
                textBoxBookingCode.ForeColor = Color.Black;
                textBoxTripCode.BackColor = Color.White;
                textBoxTripCode.ForeColor = Color.Black;
                label17.BackColor = Color.Black;
                label18.BackColor = Color.Black;
                label19.BackColor = Color.Black;
                label20.BackColor = Color.Black;
                label21.BackColor = Color.Black;
                label22.BackColor = Color.Black;
                panel3.BackColor = Color.White;



                panelNav.Height = BookingButton.Height;
                panelNav.Top = BookingButton.Top;
                panelNav.Left = BookingButton.Left;
                BookingButton.BackColor = Color.WhiteSmoke;

            }
        }

        private void labelUsername_TextChanged(object sender, EventArgs e)
        {
            Db db = new Db();
            //MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database= railwayreservationsystem");

            db.openConnection();
            if (labelUsername.Text != "")
            {
                MySqlCommand command = new MySqlCommand("SELECT  `fullname`, `username`, `email`, `phonenumber`  FROM `passengersregistration` WHERE `username`= @un", db.getConnection());
                command.Parameters.AddWithValue("@un", Convert.ToString(labelUsername.Text));
                MySqlDataReader da = command.ExecuteReader();
                while (da.Read())
                {
                    textBoxFullname.Text = da.GetValue(0).ToString();
                    textBoxUsername.Text = da.GetValue(1).ToString();
                    textBoxEmail.Text = da.GetValue(2).ToString();
                    textBoxPhonenumber.Text = da.GetValue(3).ToString();
                    



                }
                db.closeConnection();
            }
        }

        private void alfredButton1_Click(object sender, EventArgs e)
        {
            Db db = new Db();
            db.openConnection();
            MySqlCommand command = new MySqlCommand("INSERT INTO`booking` (  `fullname`, `username`, `phonenumber`, `email`, `bookingcode`, `trainid`, `seatno`, `trainname`, `source`, `destination`, `arrivaltime`, `departuretime`, `totaltime`, `date`, `ticketfare`, `distance`, `time`, `station`,`tripcode`)" +
                " VALUES( @full, @usn, @pho, @ema, @book, @tra, @sn, @tn, @so, @de, @at, @dt, @tt, @da, @tf, @di, @time, @st, @tc)", db.getConnection());
            MySqlCommand fredthedev = new MySqlCommand("SELECT COUNT(*) FROM `booking` WHERE trainid='" + textBoxId.Text + "'", db.getConnection());
            int count = (int)(long)fredthedev.ExecuteScalar();
            int valve = int.Parse(textBoxNoOfSeats.Text);
            //fredthedevs.Text = "following records" + count + "";

            command.Parameters.Add("@full", MySqlDbType.VarChar).Value = textBoxFullname.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pho", MySqlDbType.VarChar).Value = textBoxPhonenumber.Text;
            command.Parameters.Add("@ema", MySqlDbType.VarChar).Value = textBoxEmail.Text;
            command.Parameters.Add("@tra", MySqlDbType.Int32).Value = textBoxId.Text;
            command.Parameters.Add("@book", MySqlDbType.VarChar).Value = textBoxBookingCode.Text;
            command.Parameters.Add("@sn", MySqlDbType.Int32).Value = textBoxSeatno.Text;
            command.Parameters.Add("@tn", MySqlDbType.VarChar).Value = textBoxTrainName.Text;
            command.Parameters.Add("@so", MySqlDbType.VarChar).Value = textBoxSource.Text;
            command.Parameters.Add("@de", MySqlDbType.VarChar).Value = textBoxDestination.Text;
            command.Parameters.Add("@at", MySqlDbType.VarChar).Value = textBoxArrivalTime.Text;
            command.Parameters.Add("@dt", MySqlDbType.VarChar).Value = textBoxDepartureTime.Text;
            command.Parameters.Add("@tt", MySqlDbType.VarChar).Value = textBoxTotalTime.Text;
            command.Parameters.Add("@da", MySqlDbType.Date).Value = textBoxDate.Text;
            command.Parameters.Add("@tf", MySqlDbType.Int32).Value = textBoxTicketFare.Text;
            command.Parameters.Add("@di", MySqlDbType.VarChar).Value = textBoxDistance.Text;
            command.Parameters.Add("@time", MySqlDbType.VarChar).Value = textBoxArrivalDestination.Text;
            command.Parameters.Add("@st", MySqlDbType.VarChar).Value = textBoxStation.Text;
            command.Parameters.Add("@tc", MySqlDbType.VarChar).Value = textBoxTripCode.Text;




            db.openConnection();

            if (textBoxFullname.Text == "" || textBoxEmail.Text == "" || textBoxPhonenumber.Text == "" || textBoxUsername.Text == "")
            {
                MessageBox.Show("A field is empty", "Booking Failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);


            }
            else if (count == valve)
            {
                MessageBox.Show("please select another train going to your destination!", "The train is full", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                BookTrips F3 = new BookTrips();
                F3.ShowDialog();
                this.Close();
            }
            else if (checkseatno())
            {
                MessageBox.Show("Please wait while we refresh the page!", "The seat no has already been taken", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Booking F3 = new Booking();
                F3.ShowDialog();
                this.Close();

            }
            else if (checkBookingCode())
            {
                MessageBox.Show("Please wait while we refresh the page!", "The Booking Code has already been taken", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Booking F3 = new Booking();
                F3.ShowDialog();
                this.Close();

            }
            else
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Your booking has been placed Successfully!", "Booking Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    SetValueForText1 = textBoxFullname.Text;
                    SetValueForText2 = textBoxUsername.Text;
                    SetValueForText3 = textBoxSource.Text;
                    SetValueForText4 = textBoxDestination.Text;
                    SetValueForText5 = textBoxPhonenumber.Text;
                    SetValueForText6 = textBoxBookingCode.Text;
                    SetValueForText7 = textBoxTripCode.Text;
                    SetValueForText8 = textBoxSeatno.Text;
                    SetValueForText9 = textBoxTicketFare.Text;
                    SetValueForText10 = textBoxTrainName.Text;
                    SetValueForText11 = textBoxStation.Text;
                    setValueForText12 = textBoxDate.Text;
                    setValueForText13 = textBoxArrivalTime.Text;
                    setValueForText14 = textBoxDepartureTime.Text;
                    setValueForText15 = textBoxDistance.Text;


                    this.Hide();
                    ticket F1 = new ticket();
                    F1.ShowDialog();
                    this.Close();





                    Random rnd = new Random();
                    int generate = rnd.Next(1, Convert.ToInt32(textBoxNoOfSeats.Text) + 1);
                    textBoxSeatno.Text = Convert.ToString(generate);


                    if (checkseatno())
                    {
                        this.Hide();
                        Booking F7 = new Booking();
                        F7.ShowDialog();
                        this.Close();

                    }


                    int length = 10;

                    //creating a string builder object()
                    StringBuilder str_build = new StringBuilder();
                    Random random = new Random();

                    char letter;
                    for (int i = 0; i < length; i++)
                    {
                        double flt = random.NextDouble();
                        int shift = Convert.ToInt32(Math.Floor(25 * flt));
                        letter = Convert.ToChar(shift + 65);
                        str_build.Append(letter);

                    }
                    textBoxBookingCode.Text = str_build.ToString();
                    textBoxBookingCode.ReadOnly = true;




                }
                else
                {
                    MessageBox.Show("ERROR");
                }
            }
            db.closeConnection();
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

        private void textBoxSeatno_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
