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
    public partial class passengermessage : Form
    {
        MySqlCommand cm;
        MySqlDataReader dr;


        private Label admin;
        private Label replytext;
        private Label adminmessage;
        private Label date;
        private Label time;
        private Label container = new Label();
        private Label pasusername;
        private Label pasheading;
        private Label pasdate;
        private Label pastime;
        private Label panel;
        

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
        public passengermessage()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panelNav.Height = SendMessageButton.Height;
            panelNav.Top = SendMessageButton.Top;
            panelNav.Left = SendMessageButton.Left;
            SendMessageButton.BackColor = Color.WhiteSmoke;

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

        private void passengermessage_Load(object sender, EventArgs e)
        {
            labelUsername.Text = loginpassenger.recall;
            labelUsername.Text = labelUsername.Text.ToUpper();
            if (labelUsername.Text == "")
            {
                MessageBox.Show("Only registered passengers can send messages ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Hide();
                loginpassenger f8 = new loginpassenger();
                f8.ShowDialog();
                this.Close();
            }

            GetData();
        }

        private void GetData()
        {

            flowLayoutPanel1.Controls.Clear();

            Db db = new Db();
            db.openConnection();
            cm = new MySqlCommand("SELECT `id`, `pas_username`, `pas_heading`, `pas_message`, `pas_date`, `pas_time`, `admin_name`, `admin_message`, `admin_date`, `admin_time` FROM `adminreply` WHERE `pas_username`='" + labelUsername.Text + "'", db.getConnection());
            dr = cm.ExecuteReader();
            while (dr.Read())
            {

                container = new Label();
                container.BackColor = Color.White;
                container.Width = 809;
                container.Height = 390;
                container.Cursor = Cursors.Hand;
                container.AutoSize = false;
                container.BorderStyle = BorderStyle.None;
                container.Margin = new Padding(13);
                container.Tag = dr["id"].ToString();
                container.BackgroundImage = Properties.Resources.download__2_;
                container.BackgroundImageLayout = ImageLayout.Zoom;

                pasusername = new Label();
                pasusername.BackColor = Color.Transparent;
                pasusername.AutoSize = true;
                pasusername.TextAlign = ContentAlignment.MiddleCenter;
                pasusername.Text = dr["pas_username"].ToString();
                pasusername.Location = new Point(150, 10);
                pasusername.Font = new Font("Nirmala", 10, FontStyle.Regular);
                pasusername.ForeColor = Color.Black;

             

                panel = new Label();
                panel.BackColor = Color.Gold;
                panel.Text = "";
                panel.Width = 3;
                panel.Height = 340;
                panel.Location = new Point(8, 25);

                replytext = new Label();
                replytext.BackColor = Color.Transparent;
                replytext.AutoSize = true;
                replytext.TextAlign = ContentAlignment.MiddleCenter;
                replytext.Text = "Replying To: ";
                replytext.Location = new Point(35, 10);
                replytext.Font = new Font("Nirmala", 10, FontStyle.Regular);
                replytext.ForeColor = Color.Black;


                pasheading = new Label();
                pasheading.BackColor = Color.Transparent;
                pasheading.AutoSize = true;
                pasheading.TextAlign = ContentAlignment.MiddleCenter;
                pasheading.Text = dr["pas_heading"].ToString();
                pasheading.Location = new Point(45, 34);
                pasheading.Font = new Font("Nirmala", 10, FontStyle.Regular);
                pasheading.ForeColor = Color.Black;


                pasdate = new Label();
                pasdate.BackColor = Color.Transparent;
                pasdate.AutoSize = true;
                pasdate.TextAlign = ContentAlignment.MiddleCenter;
                pasdate.Text = dr["pas_date"].ToString();
                pasdate.Location = new Point(49, 59);
                pasdate.Font = new Font("Nirmala", 10, FontStyle.Regular);
                pasdate.ForeColor = Color.Black;


                pastime = new Label();
                pastime.BackColor = Color.Transparent;
                pastime.AutoSize = true;
                pastime.TextAlign = ContentAlignment.MiddleCenter;
                pastime.Text = dr["pas_time"].ToString();
                pastime.Location = new Point(123, 59);
                pastime.Font = new Font("Nirmala", 10, FontStyle.Regular);
                pastime.ForeColor = Color.Black;

                admin = new Label();
                admin.Text = dr["admin_name"].ToString();
                //destination.Text = "To: " + dr["destination"].ToString();
                admin.BackColor = Color.Transparent;
                admin.TextAlign = ContentAlignment.MiddleCenter;
                admin.Location = new Point(35, 97); //35, 16  609, 59
                admin.AutoSize = true;
                admin.Font = new Font("Nirmala", 10, FontStyle.Regular);
                admin.ForeColor = Color.Black;


                adminmessage = new Label();
                adminmessage.Text = dr["admin_message"].ToString();
                adminmessage.BackColor = Color.Transparent;
                adminmessage.TextAlign = ContentAlignment.TopLeft;
                adminmessage.Location = new Point(45, 120);
                adminmessage.Height = 220;
                adminmessage.Width = 730;
                //adminmessage.Dock = DockStyle.None;
                adminmessage.AutoSize = false;
                adminmessage.Font = new Font("Nirmala", 10, FontStyle.Regular);
                adminmessage.ForeColor = Color.Black;



                date = new Label();
                date.Text = dr["admin_date"].ToString();
                date.BackColor = Color.Transparent;
                date.TextAlign = ContentAlignment.MiddleCenter;
                date.Location = new Point(45, 345);
                date.AutoSize = true;
                date.Font = new Font("Nirmala", 10, FontStyle.Regular);
                date.ForeColor = Color.Black;


                time = new Label();
                time.Text = dr["admin_time"].ToString();
                time.BackColor = Color.Transparent;
                time.TextAlign = ContentAlignment.MiddleCenter;
                time.Location = new Point(125, 345);
                time.AutoSize = true;
                time.Font = new Font("Nirmala", 10, FontStyle.Regular);
                time.ForeColor = Color.Black;








          
                container.Controls.Add(panel);
                container.Controls.Add(time);
                container.Controls.Add(date);
                container.Controls.Add(pastime);
                container.Controls.Add(pasdate);
                container.Controls.Add(pasheading);
                container.Controls.Add(replytext);
                container.Controls.Add(pasusername);
                container.Controls.Add(adminmessage);
                container.Controls.Add(admin);
                flowLayoutPanel1.Controls.Add(container);





            }

            dr.Close();

            db.closeConnection();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            this.labelpasdate.Text = date.ToShortDateString();

            DateTime datetime = DateTime.Now;
            this.labelpastime.Text = datetime.ToString("hh:mm:ss tt");
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

                TextBoxHea.BackColor = Color.Black;
                TextBoxHea.ForeColor = Color.White;
                TextBoxMes.BackColor = Color.Black;
                TextBoxMes.ForeColor = Color.White;
                labelpasdate.ForeColor = Color.White;
                labelpastime.ForeColor = Color.White;
                flowLayoutPanel1.BackColor = Color.Black;


                TextBoxHea.BorderColor = Color.White;
                TextBoxMes.BorderColor = Color.White;

                Cancel.ForeColor = Color.White;
                label4.BackColor = Color.White;
                this.BackColor = Color.Black;

                

                panelNav.Height = SendMessageButton.Height;
                panelNav.Top = SendMessageButton.Top;
                panelNav.Left = SendMessageButton.Left;
                SendMessageButton.BackColor = Color.Black;


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

                TextBoxHea.BackColor = Color.White;
                TextBoxHea.ForeColor = Color.Black;
                TextBoxMes.BackColor = Color.White;
                TextBoxMes.ForeColor = Color.Black;
                labelpasdate.ForeColor = Color.Black;
                labelpastime.ForeColor = Color.Black;

                flowLayoutPanel1.BackColor = Color.WhiteSmoke;

                TextBoxHea.BorderColor = Color.WhiteSmoke;
                TextBoxMes.BorderColor = Color.WhiteSmoke;

                panelNav.Height = SendMessageButton.Height;
                panelNav.Top = SendMessageButton.Top;
                panelNav.Left = SendMessageButton.Left;
                SendMessageButton.BackColor = Color.WhiteSmoke;

            }
        }

        private void alfredButton1_Click(object sender, EventArgs e)
        {
            Db db = new Db();
            MySqlCommand command = new MySqlCommand("INSERT INTO `message`(`username`, `heading`, `message`, `time`, `date`) VALUES( @usn, @hea, @mess, @time, @date)", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = labelUsername.Text;
            command.Parameters.Add("@hea", MySqlDbType.VarChar).Value = TextBoxHea.Texts;
            command.Parameters.Add("@mess", MySqlDbType.VarChar).Value = TextBoxMes.Texts;
            command.Parameters.Add("@time", MySqlDbType.VarChar).Value = labelpastime.Text;
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = labelpasdate.Text;

            db.openConnection();


            if (labelUsername.Text == "")
            {
                MessageBox.Show("Please create an account first before you can send messages ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (TextBoxHea.Texts == "")
            {
                MessageBox.Show("The heading field is empty ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (TextBoxMes.Texts == "")
            {
                MessageBox.Show("The message field is empty", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Your Message has been sent to Via Rail successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    MessageBox.Show("ERROR");
                }
            }
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

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginpassenger f1 = new loginpassenger();
            f1.ShowDialog();
            this.Close();
        }
    }
}
