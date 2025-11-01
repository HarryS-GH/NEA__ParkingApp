using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace NEA_ParkingApp
{
    public partial class MainMenu : Form
    {

        Account account;


        public MainMenu(Account UserAccount) // receive account details from signup/login form
        {
            InitializeComponent();
            account = UserAccount;

            this.WelcomeLabel.Text = "Welcome, " + account.forename.Trim() + "!"; // Display welcome message

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void BookingCreate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // Opens the booking creation form
        {
            // Open Booking form

            BookingCreationForm bookingForm = new BookingCreationForm(account);
            bookingForm.Location = this.Location;
            bookingForm.Show();

            this.Close();
        }

        private void MapButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // Opens the virtual map form
        {
            // Open Virtual Map

            VirtualMap map = new VirtualMap();
            map.Location = this.Location;
            map.Show();


        }

        private void ViewBookings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // Opens the booking viewing form
        {
            BookingView view = new BookingView(account);
            view.Location = this.Location;
            view.Show();

            this.Close();
        }

        private void LogoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // Closes the whole application when the user logs out
        {
            Application.Exit();
        }
    }
}
