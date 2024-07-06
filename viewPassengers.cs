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
    public partial class viewPassengers : Form
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
        public viewPassengers()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panelNav.Height = RegisteredPassengersButton.Height;
            panelNav.Top = RegisteredPassengersButton.Top;
            panelNav.Left = RegisteredPassengersButton.Left;
            RegisteredPassengersButton.BackColor = Color.WhiteSmoke;
        }

        private void viewPassengers_Load(object sender, EventArgs e)
        {
            labelUsername.Text = loginAdministrator.recall;
            labelUsername.Text = labelUsername.Text.ToUpper();


            Db db = new Db();
            //MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=railway");
            db.openConnection();
            MySqlCommand cmdDataBase = new MySqlCommand("SELECT `id` as 'ID', `fullname` as 'Full Name', `username` as 'Username', `phonenumber` as 'Phone Number', `email` as 'Email' FROM `passengersregistration`", db.getConnection());

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                sda.Update(dbdataset);
                db.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
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
                TripsButton.BackColor = Color.Black;
                RegisteredPassengersButton.BackColor = Color.Black;
                MessagesButton.BackColor = Color.Black;
                StationsButton.BackColor = Color.Black;
                AdministratorSettingsButton.BackColor = Color.Black;
                LogOutButton.BackColor = Color.Black;

                Cancel.ForeColor = Color.White;
                label4.BackColor = Color.White;

                dataGridView1.BackgroundColor = Color.Black;
                
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Black;
                dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.White;

                dataGridView1.DefaultCellStyle.BackColor = Color.Black;
                dataGridView1.DefaultCellStyle.ForeColor = Color.White;

                dataGridView1.RowsDefaultCellStyle.BackColor = Color.Black;
                dataGridView1.RowsDefaultCellStyle.ForeColor = Color.White;

                this.BackColor = Color.Black;

                panelNav.Height = RegisteredPassengersButton.Height;
                panelNav.Top = RegisteredPassengersButton.Top;
                panelNav.Left = RegisteredPassengersButton.Left;
                RegisteredPassengersButton.BackColor = Color.Black;
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


                dataGridView1.BackgroundColor = Color.WhiteSmoke;
                
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

                dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.Black;

                dataGridView1.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;

                dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dataGridView1.RowsDefaultCellStyle.ForeColor = Color.Black;


                this.BackColor = Color.WhiteSmoke;

                panelNav.Height = RegisteredPassengersButton.Height;
                panelNav.Top = RegisteredPassengersButton.Top;
                panelNav.Left = RegisteredPassengersButton.Left;
                RegisteredPassengersButton.BackColor = Color.WhiteSmoke;

            }
        }

        private void MessagesButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMessages f4 = new AdminMessages();
            f4.ShowDialog();
            this.Close();
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
            Db db = new Db();
            //MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=railway");
            MySqlDataAdapter da;
            DataTable dt;
            db.openConnection();

            da = new MySqlDataAdapter("SELECT `id` , `fullname` , `username` , `phonenumber` , `email` FROM `passengersregistration`  WHERE   username LIKE'" + alfredTextBox1.Texts + "%'", db.getConnection());
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            db.closeConnection();
        }

        private void alfredButton1_Click(object sender, EventArgs e)
        {
            Db db = new Db();
            //MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=railway");
            MySqlDataAdapter da;
            DataTable dt;
            db.openConnection();

            da = new MySqlDataAdapter("SELECT `id` , `fullname` , `username` , `phonenumber` , `email` FROM `passengersregistration`  WHERE   username LIKE'" + alfredTextBox1.Texts + "%'", db.getConnection());
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            db.closeConnection();

        }
    }
}
