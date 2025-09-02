using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_ParkingApp
{
    public partial class BookingView : Form
    {
        private Account Account;

        private ListViewItem selected = null;

        public BookingView(Account account)
        {
            InitializeComponent();
            this.Account = account;

            RefreshList();
        }

        private List<Booking> GetBookings() // Return a list of bookings owned by the user
        {
            string getBookingString = "SELECT * FROM BookingInfo WHERE UserID = @userID ORDER BY StartTime ASC"; // Grab all the bookings owned by the user, ordered by start time in ascending order

            List<Booking> bookings = new List<Booking>();

            using (SqlConnection conn = new SqlConnection(Security.connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(getBookingString, conn))
                {

                    cmd.Parameters.AddWithValue("@userID", Account.userID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking booking = new Booking(

                                Convert.ToInt32(reader["BookingID"]),
                                Convert.ToString(reader["SpaceID"]),
                                Convert.ToInt32(reader["UserID"]),
                                Convert.ToDateTime(reader["StartTime"]),
                                Convert.ToDateTime(reader["EndTime"])


                                );

                            bookings.Add(booking);
                        }
                    }

                }
            }

            return bookings;

        }


        private void RefreshList() // Refresh the list of bookings - placing the earliest starting time at the top
        {
            this.BookingList.Clear();
            List<Booking> bookings = GetBookings();

            foreach (Booking booking in bookings)
            {
                this.BookingList.Items.Add(new ListViewItem { Text = $"Space {booking.spaceID} -- {booking.startTime.ToString()} - {booking.endTime.ToString()}", Tag = booking }); // Store the booking within the item, whilst having separate display text
            }
        }

        private void Close_Click(object sender, EventArgs e) // Reopen main menu, close view form
        {
            MainMenu form = new MainMenu(Account);
            form.Location = this.Location;
            form.Show();

            this.Close();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (selected == null) { return; }

            if (selected.Tag as Booking != null)
            {

            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (selected == null) { return; } // Return if nothing selected

            if (selected.Tag is Booking booking)
            {
                booking.Cancel(); // Cancel selected booking
            }

            RefreshList(); // Redraw list, without cancelled booking
        }

        private void BookingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BookingList.SelectedItems.Count > 0)
            {
                selected = BookingList.SelectedItems[0]; // Get the first item selected by the user
            }
            else
            {
                selected = null;
            }
        }
    }
}
