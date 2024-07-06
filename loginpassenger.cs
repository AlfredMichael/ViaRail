using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;



namespace RailwayReservationSystem
{
    public partial class loginpassenger : Form
    {
        Db db = new Db();
        HashPass hc = new HashPass();
        public loginpassenger()
        {
            InitializeComponent();
        }
        public static string username;
        public static string recall
        {
            get { return username; }
            set { username = value; }
        }

        private void loginpassenger_Load(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void alfredToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (alfredToggleButton1.Checked)
            {
                TextBoxPassword.PasswordChar = false;
                showpaslabel.Text = "Hide Password";
            }
            else
            {
                TextBoxPassword.PasswordChar = true;
                showpaslabel.Text = "Show Password";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void alfredToggleButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (alfredToggleButton2.Checked)
            {
                this.BackColor = Color.Black;
                pictureBox1.BackgroundImage = Properties.Resources.Capture7;
                label3.Text = "Light theme";
                label3.ForeColor = Color.White;
                TextBoxUsername.BorderColor = Color.White;
                TextBoxPassword.BorderColor = Color.White;
                showpaslabel.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                AdminLink.ForeColor = Color.White;
                TextBoxUsername.ForeColor = Color.White;
                TextBoxPassword.ForeColor = Color.White;
                TextBoxUsername.BackColor = Color.Black;
                TextBoxPassword.BackColor = Color.Black;
                alfredToggleButton1.OnBackColor = Color.White;
            }
            else
            {
                this.BackColor = Color.White;
                pictureBox1.BackgroundImage = Properties.Resources.download__2_;
                label3.Text = "Dark theme";
                label3.ForeColor = Color.DarkGray;
                TextBoxUsername.BorderColor = Color.Black;
                TextBoxPassword.BorderColor = Color.Black;
                showpaslabel.ForeColor = Color.DarkGray;
                label1.ForeColor = Color.DarkGray;
                AdminLink.ForeColor = Color.DarkGray;
                TextBoxUsername.ForeColor = Color.Black;
                TextBoxPassword.ForeColor = Color.Black;
                TextBoxUsername.BackColor = Color.White;
                TextBoxPassword.BackColor = Color.White;
                alfredToggleButton1.OnBackColor = Color.Black;
            }

        }

        private void SignUpLink_Click(object sender, EventArgs e)
        {
            this.Hide();
            registerpassenger f1 = new registerpassenger();
            f1.ShowDialog();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Db db = new Db();

            recall = TextBoxUsername.Texts;

            db.openConnection();

            String UserName = TextBoxUsername.Texts;
            String UserPass = hc.PassHash(TextBoxPassword.Texts);
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `passengersregistration` WHERE `username` = @un and `password` = @pa", db.getConnection());

            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = UserName;
            command.Parameters.Add("@pa", MySqlDbType.VarChar).Value = UserPass;

            adapter.SelectCommand = command;

            adapter.Fill(table);
            MySqlDataReader dr = command.ExecuteReader();


            if (dr.Read() == true)
            {
                this.Hide();
                PassengersDashboard F5 = new PassengersDashboard();
                F5.ShowDialog();
                this.Close();
            }

            else
            {

                MessageBox.Show("Invalid Username or Password! ", "Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxUsername.Texts = "";
                TextBoxPassword.Texts = "";
                TextBoxUsername.Focus();

            }


            // check if the  Username field is empty
            if (UserName.Trim().Equals(""))
            {
                MessageBox.Show("Enter Your Username To Login", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // check if the password field is empty
            else if (UserPass.Trim().Equals(""))
            {
                MessageBox.Show("Enter Your Password To Login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminLink_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginAdministrator F5 = new loginAdministrator();
            F5.ShowDialog();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            PassengersDashboard F5 = new PassengersDashboard();
            F5.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            pictureBox2.Dispose();
            pictureBox3.Dispose();
        }
    }
}

