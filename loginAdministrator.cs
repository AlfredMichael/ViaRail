using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace RailwayReservationSystem
{
    public partial class loginAdministrator : Form
    {
        Db db = new Db();
        HashPass hc = new HashPass();
        public loginAdministrator()
        {
            InitializeComponent();
        }
        public static string adminname;
        public static string recall
        {
            get { return adminname; }
            set { adminname = value; }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Db db = new Db();

            recall = TextBoxAdminName.Texts;

            db.openConnection();

            String AdminName = TextBoxAdminName.Texts;
            String AdminPass = hc.PassHash(TextBoxPassword.Texts);

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `adminregistration` WHERE `adminname` = @an and `adminpassword` = @apw", db.getConnection());

            command.Parameters.Add("@an", MySqlDbType.VarChar).Value = AdminName;
            command.Parameters.Add("@apw", MySqlDbType.VarChar).Value = AdminPass;

            adapter.SelectCommand = command;

            adapter.Fill(table);
            MySqlDataReader dr = command.ExecuteReader();


            if (dr.Read() == true)
            {
                this.Hide();
                AdminDashboard F5 = new AdminDashboard();
                F5.ShowDialog();
                this.Close();
            }

            else
            {

                MessageBox.Show("Invalid Admin name or Password! ", "Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxAdminName.Texts = "";
                TextBoxPassword.Texts = "";
                TextBoxAdminName.Focus();

            }


            // check if the Admin name field is empty
            if (AdminName.Trim().Equals(""))
            {
                MessageBox.Show("Enter Your Admin Name To Login", "Empty Admin name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // check if the password field is empty
            else if (AdminPass.Trim().Equals(""))
            {
                MessageBox.Show("Enter Your Password To Login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showpaslabel_Click(object sender, EventArgs e)
        {

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

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void alfredToggleButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (alfredToggleButton2.Checked)
            {
                this.BackColor = Color.Black;
                pictureBox1.BackgroundImage = Properties.Resources.Capture7;
                label3.Text = "Light theme";
                label3.ForeColor = Color.White;
                TextBoxAdminName.BorderColor = Color.White;
                TextBoxPassword.BorderColor = Color.White;
                showpaslabel.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                
                TextBoxAdminName.ForeColor = Color.White;
                TextBoxPassword.ForeColor = Color.White;
                TextBoxAdminName.BackColor = Color.Black;
                TextBoxPassword.BackColor = Color.Black;
                alfredToggleButton1.OnBackColor = Color.White;
            }
            else
            {
                this.BackColor = Color.White;
                pictureBox1.BackgroundImage = Properties.Resources.download__2_;
                label3.Text = "Dark theme";
                label3.ForeColor = Color.DarkGray;
                TextBoxAdminName.BorderColor = Color.Black;
                TextBoxPassword.BorderColor = Color.Black;
                showpaslabel.ForeColor = Color.DarkGray;
                label1.ForeColor = Color.DarkGray;
                
                TextBoxAdminName.ForeColor = Color.Black;
                TextBoxPassword.ForeColor = Color.Black;
                TextBoxAdminName.BackColor = Color.White;
                TextBoxPassword.BackColor = Color.White;
                alfredToggleButton1.OnBackColor = Color.Black;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void loginAdministrator_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginpassenger F5 = new loginpassenger();
            F5.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginAdministrator F5 = new loginAdministrator();
            F5.ShowDialog();
            this.Close();
        }
    }
}
