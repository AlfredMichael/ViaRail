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
    public partial class ticket2 : Form
    {
        public ticket2()
        {
            InitializeComponent();
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

        private void ticket2_Load(object sender, EventArgs e)
        {
            textBoxFullname.Text = MyTrips.SetValueForText1;
            textBoxUsername.Text = MyTrips.SetValueForText2;
            textBoxSource.Text = MyTrips.SetValueForText3;
            textBoxDestination.Text = MyTrips.SetValueForText4;
            textBoxPhonenumber.Text = MyTrips.SetValueForText5;
            textBoxBookingCode.Text = MyTrips.SetValueForText6;
            textBoxTripCode.Text = MyTrips.SetValueForText7;
            textBoxSeatNo.Text = MyTrips.SetValueForText8;
            textBoxTicketFare.Text = MyTrips.SetValueForText9;

            textBoxTrainName.Text = MyTrips.SetValueForText10;
            textBoxStation.Text = MyTrips.SetValueForText11;
            textBoxDate.Text = MyTrips.setValueForText12;
            textBoxArrivalTime.Text = MyTrips.setValueForText13;
            textBoxDepartureTime.Text = MyTrips.setValueForText14;
            textBoxDistance.Text = MyTrips.setValueForText15;
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

        private void textBoxUsername_Click(object sender, EventArgs e)
        {

        }
    }
}
