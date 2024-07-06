using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace RailwayReservationSystem
{
    public partial class notify : Form
    {
        public notify()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Size = new Size(420, 99);//w,h
            popup.BodyColor = Color.Black;
            popup.Image = Properties.Resources.brd3;
            popup.HeaderColor = Color.Black;
            popup.ImageSize = new Size(82, 38);
            //popup.ImagePadding = new Padding(165, 0, 100, 0);
            popup.TitleFont= new Font("Nirmala", 18, FontStyle.Bold);
            popup.TitleText = "Welcome";
            popup.TitleColor = Color.White;
            popup.ContentFont= new Font("Nirmala", 13, FontStyle.Regular);
            popup.ContentColor = Color.White;
            popup.ContentText = "Hey " + "Alfred" + " your train will arrive at " + " 12:30 " + " 2/2/2022";
            popup.Popup();
        }
    }
}
