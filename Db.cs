using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailwayReservationSystem
{
    class Db
    {
       // MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=railwayreservationsystem");

        MySqlConnection connection = new MySqlConnection("server=db4free.net;port=3306;username=your_username;password=your_password;database=viarail");

        //A function to open the connection
        /*use the Ping class to ping Google's DNS server (which has the IP address of 8.8.8.8). If the ping is successful (i.e. the Status property of the PingReply object is IPStatus.Success), we assume that the user has internet connectivity and proceed to open the database connection. If the ping fails, we show an error message and return without opening the connection. If an exception is thrown while attempting to ping the server, we also show an error message and return without opening the connection.*/
        public void openConnection()
        {

            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send("8.8.8.8"); // Ping Google's DNS server
                if (reply.Status != IPStatus.Success)
                {
                    MessageBox.Show("Please connect to the internet to use this application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking internet connectivity: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();

            }

        }

        // A function to close the connection
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // A function to return the connection
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
