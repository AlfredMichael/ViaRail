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
    public partial class Addtraintrips : Form
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

        public Addtraintrips()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panelNav.Height = TripsButton.Height;
            panelNav.Top = TripsButton.Top;
            panelNav.Left = TripsButton.Left;
            TripsButton.BackColor = Color.WhiteSmoke;
        }

        private void randomcode__TextChanged(object sender, EventArgs e)
        {

        }

        private void Addtraintrips_Load(object sender, EventArgs e)
        {
            labelUsername.Text = loginAdministrator.recall;
            labelUsername.Text = labelUsername.Text.ToUpper();
            int length = 7;

            //creating a string builder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;
            for(int i=0; i<length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);

            }
            TextBoxTripCode.Texts = str_build.ToString();
            TextBoxTripCode.ReadOnly = true;

            
        }

        private void noofseats_ValueChanged(object sender, EventArgs e)
        {

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
                

                panelNav.Height = TripsButton.Height;
                panelNav.Top = TripsButton.Top;
                panelNav.Left = TripsButton.Left;
                TripsButton.BackColor = Color.Black;
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
                

                panelNav.Height = TripsButton.Height;
                panelNav.Top = TripsButton.Top;
                panelNav.Left = TripsButton.Left;
                TripsButton.BackColor = Color.WhiteSmoke;

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

        private void Addtrips_Click(object sender, EventArgs e)
        {
            Db db = new Db();
            MySqlCommand command = new MySqlCommand("INSERT INTO`traintrips` ( `trainname`, `source`, `destination`, `arrivaltime`, `departuretime`, `arrivalatdestinationtime`, `totaltime`, `date`, `noofseats`,`ticketfare`,`tripcode`,`distance`, `station` ) VALUES( @tn, @so, @de, @ar, @dr, @adt, @tt, @da, @nos, @tfa, @tc, @dis,  @stat)", db.getConnection());



            command.Parameters.Add("@tn", MySqlDbType.VarChar).Value = TextBoxTrainName.Texts;
            command.Parameters.Add("@so", MySqlDbType.VarChar).Value = TextBoxSource.Texts;
            command.Parameters.Add("@de", MySqlDbType.VarChar).Value = TextBoxDestination.Texts;
            command.Parameters.Add("@ar", MySqlDbType.Text).Value = textArrivalTime.Text;
            command.Parameters.Add("@dr", MySqlDbType.Text).Value = textDepartureTime.Text;
            command.Parameters.Add("@adt", MySqlDbType.Text).Value = textArrivalDestinationTime.Text;
            command.Parameters.Add("@tt", MySqlDbType.VarChar).Value = TextBoxTotalTime.Texts;
            command.Parameters.Add("@da", MySqlDbType.Date).Value = textDate.Text;
            command.Parameters.Add("@nos", MySqlDbType.Int16).Value = noofseats.Text;
            command.Parameters.Add("@tfa", MySqlDbType.Int16).Value = TextBoxTicketFare.Texts;
            command.Parameters.Add("@dis", MySqlDbType.VarChar).Value = TextBoxDistance.Texts;
            command.Parameters.Add("@tc", MySqlDbType.VarChar).Value = TextBoxTripCode.Texts;
            command.Parameters.Add("@stat", MySqlDbType.VarChar).Value = TextBoxStation.Texts;

            // open connection to the database
            db.openConnection();
            if (TextBoxTrainName.Texts == "" || TextBoxSource.Texts == "" || TextBoxDestination.Texts == "" || textArrivalTime.Text == "" || textDepartureTime.Text == "" || TextBoxTotalTime.Texts == "" || textDate.Text == "" || TextBoxTicketFare.Texts == "" || TextBoxDistance.Texts == "" || TextBoxStation.Texts == "" || TextBoxTripCode.Texts == "")
            {
                MessageBox.Show("A field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (checkTripCode())
            {
                this.Hide();
                Addtraintrips F7 = new Addtraintrips();
                F7.ShowDialog();
                this.Close();
            }
            else
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("The Train Trip has been added sucessfully!", " Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TextBoxTrainName.Texts = "";
                    TextBoxSource.Texts = "";
                    TextBoxDestination.Texts = "";
                    TextBoxStation.Texts = "";
                    TextBoxTotalTime.Texts = "";
                    TextBoxDistance.Texts = "";
                    TextBoxTicketFare.Texts = "";

                    int length = 7;

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
                    TextBoxTripCode.Texts = str_build.ToString();
                    TextBoxTripCode.ReadOnly = true;

                }
                else
                {
                    MessageBox.Show("ERROR");
                }


            }

        }
        public Boolean checkTripCode()
        {

            Db db = new Db();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `traintrips` WHERE `tripcode` ='" + TextBoxTripCode.Text + "'", db.getConnection());

            command.Parameters.Add(TextBoxTripCode.Text, MySqlDbType.VarChar).Value = TextBoxTripCode.Text;
            adapter.SelectCommand = command;

            adapter.Fill(table);

            // check if the Trip Code already exists in the database 
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
