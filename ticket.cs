using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailwayReservationSystem
{
    public partial class ticket : Form
    {
        public ticket()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void ticket_Load(object sender, EventArgs e)
        {
            textBoxFullname.Text = Booking.SetValueForText1;
            textBoxUsername.Text = Booking.SetValueForText2;
            textBoxSource.Text = Booking.SetValueForText3;
            textBoxDestination.Text = Booking.SetValueForText4;
            textBoxPhonenumber.Text = Booking.SetValueForText5;
            textBoxBookingCode.Text = Booking.SetValueForText6;
            textBoxTripCode.Text = Booking.SetValueForText7;
            textBoxSeatNo.Text = Booking.SetValueForText8;
            textBoxTicketFare.Text = Booking.SetValueForText9;

            textBoxTrainName.Text = Booking.SetValueForText10;
            textBoxStation.Text = Booking.SetValueForText11;
            textBoxDate.Text = Booking.setValueForText12;
            textBoxArrivalTime.Text = Booking.setValueForText13;
            textBoxDepartureTime.Text = Booking.setValueForText14;
            textBoxDistance.Text = Booking.setValueForText15;




        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            this.Controls.Add(panel);

            Graphics graphics = panel.CreateGraphics();
            Size size = this.ClientSize;
            bitmap = new Bitmap(size.Width, size.Height, graphics);
            graphics = Graphics.FromImage(bitmap);

            Point point = PointToScreen(panel.Location);
            graphics.CopyFromScreen(point.X, point.Y, 0, 0, size);

            printPreviewDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("custom", 1050, 479);
            printPreviewDialog1.ShowDialog();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
        Bitmap bitmap;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PassengersDashboard f8 = new PassengersDashboard();
            f8.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
