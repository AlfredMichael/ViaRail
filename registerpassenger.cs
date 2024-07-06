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
    public partial class registerpassenger : Form
    {
        Db db = new Db();
        HashPass hc = new HashPass();
        public registerpassenger()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void alfredToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (alfredToggleButton1.Checked)
            {
                TextBoxPassword.PasswordChar = false;
                TextBoxConfirmPassword.PasswordChar = false;
                showpaslabel.Text = "Hide Password";
            }
            else
            {
                TextBoxPassword.PasswordChar = true;
                TextBoxConfirmPassword.PasswordChar = true;
                showpaslabel.Text = "Show Password";
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cancel_MouseHover(object sender, EventArgs e)
        {
            
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
                TextBoxFullname.BorderColor = Color.White;
                TextBoxUsername.BorderColor = Color.White;
                
                TextBoxPhoneNumber.BorderColor = Color.White;
                
                TextBoxPassword.BorderColor = Color.White;
                TextBoxEmail.BorderColor = Color.White;
                TextBoxConfirmPassword.BorderColor = Color.White;
                TextBoxFullname.ForeColor = Color.White;
                TextBoxUsername.ForeColor = Color.White;
                TextBoxEmail.ForeColor = Color.White;
                TextBoxPhoneNumber.ForeColor = Color.White;
                
                TextBoxPassword.ForeColor = Color.White;
                TextBoxConfirmPassword.ForeColor = Color.White;
                TextBoxFullname.BackColor = Color.Black;
                TextBoxUsername.BackColor = Color.Black;
                TextBoxEmail.BackColor = Color.Black;
                TextBoxPhoneNumber.BackColor = Color.Black;
                
                TextBoxPassword.BackColor = Color.Black;
                TextBoxConfirmPassword.BackColor = Color.Black;
                showpaslabel.ForeColor = Color.White;
                label1.ForeColor = Color.White;

                

               
                alfredToggleButton1.OnBackColor = Color.White;
            }
            else
            {
                this.BackColor = Color.White;
                pictureBox1.BackgroundImage = Properties.Resources.download__2_;
                label3.Text = "Dark theme";
                label3.ForeColor = Color.DarkGray;
                TextBoxFullname.BorderColor = Color.Black;
                TextBoxUsername.BorderColor = Color.Black;
                
                TextBoxPhoneNumber.BorderColor = Color.Black;
                TextBoxEmail.BorderColor = Color.Black;
                TextBoxPassword.BorderColor = Color.Black;
                TextBoxConfirmPassword.BorderColor = Color.Black;
                TextBoxFullname.ForeColor = Color.Black;
                TextBoxUsername.ForeColor = Color.Black;
                TextBoxEmail.ForeColor = Color.Black;
                TextBoxPhoneNumber.ForeColor = Color.Black;
               
                TextBoxPassword.ForeColor = Color.Black;
                TextBoxConfirmPassword.ForeColor = Color.Black;
                TextBoxFullname.BackColor = Color.White;
                TextBoxUsername.BackColor = Color.White;
                TextBoxEmail.BackColor = Color.White;
                TextBoxPhoneNumber.BackColor = Color.White;
                
                TextBoxPassword.BackColor = Color.White;
                TextBoxConfirmPassword.BackColor = Color.White;
                showpaslabel.ForeColor = Color.DarkGray;
                label1.ForeColor = Color.DarkGray;

                

                alfredToggleButton1.OnBackColor = Color.Black;
            }

        }

        private void LoginLink_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginpassenger f1 = new loginpassenger();
            f1.ShowDialog();
            this.Close();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            //Add a new Passenger

            Db db = new Db();
            MySqlCommand command = new MySqlCommand("INSERT INTO`passengersregistration` ( `fullname`,`username`, `phonenumber`, `email`, `password`) VALUES( @fn, @un, @pn, @em, @pa)", db.getConnection());



            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = TextBoxFullname.Texts;
            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = TextBoxUsername.Texts;
            command.Parameters.Add("@pn", MySqlDbType.VarChar).Value = TextBoxPhoneNumber.Texts;
            command.Parameters.Add("@em", MySqlDbType.VarChar).Value = TextBoxEmail.Texts;
            command.Parameters.Add("@pa", MySqlDbType.VarChar).Value = hc.PassHash(TextBoxPassword.Texts);

            // open the connection so i can connect to my database
            db.openConnection();


            if (TextBoxFullname.Texts == "" || TextBoxUsername.Texts == "" || TextBoxPhoneNumber.Texts == "" || TextBoxEmail.Texts == "" || TextBoxPassword.Texts == "" || TextBoxConfirmPassword.Texts == "")
            {
                MessageBox.Show("A field is empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
            else
            {

                if (username())
                {
                    MessageBox.Show("This Username Already Exists, Select A Different One", "Duplicate Names found", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    TextBoxUsername.Texts = "";
                }

                else if (TextBoxPassword.Texts == TextBoxConfirmPassword.Texts)
                {

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Your account has been created Successfully!", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        this.Hide();
                        loginpassenger f8 = new loginpassenger();
                        f8.ShowDialog();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("ERROR");
                    }


                    TextBoxFullname.Texts = "";
                    TextBoxUsername.Texts = "";
                    TextBoxEmail.Texts = "";
                    TextBoxPhoneNumber.Texts = "";
                    TextBoxPassword.Texts = "";
                    TextBoxConfirmPassword.Texts = "";







                }
                else
                {
                    MessageBox.Show("Passwords does not match, Please Re-type your password", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextBoxPassword.Texts = "";
                    TextBoxConfirmPassword.Texts = "";
                    TextBoxPassword.Focus();


                }
                db.closeConnection();
            }
        }
        public Boolean username()
        {
            Db db = new Db();
            String usernamee = TextBoxUsername.Texts;


            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `passengersregistration` WHERE `username` = @un", db.getConnection());

            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = usernamee;


            adapter.SelectCommand = command;

            adapter.Fill(table);

            // To check if the Username already exists in the database 
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;

            }



        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void showpaslabel_Click(object sender, EventArgs e)
        {

        }

        private void registerpassenger_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            PassengersDashboard F5 = new PassengersDashboard();
            F5.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            registerpassenger f1 = new registerpassenger();
            f1.ShowDialog();
            this.Close();
        }
    }
}
