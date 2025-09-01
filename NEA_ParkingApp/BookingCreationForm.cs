using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_ParkingApp
{
    public partial class BookingCreationForm : Form

    {

        private Point ERROR_START_POS = new Point(602, 278);
        private List<Label> ActiveErrors = new List<Label>();

        Account account;

        DateTimePicker BookingDate_Picker;
        DateTimePicker StartTime_Picker;
        DateTimePicker EndTime_Picker;

        DateTime Date;
        DateTime Start;
        DateTime End;

        Space UserSelectedSpace;

        List<Space> Spaces = new List<Space>(); // List of available spaces

        public BookingCreationForm(Account Useraccount)
        {
            InitializeComponent();

            account = Useraccount;

            // Initialise the time pickers with values relevent to the user

            BookingDate_Picker = this.DatePicker;
            StartTime_Picker = this.StartTimePicker;
            EndTime_Picker = this.EndTimePicker;

            BookingDate_Picker.Value = DateTime.Today; // Set start date to the current day
            StartTime_Picker.Value = DateTime.Now.AddMinutes(30); // Set start time to the current time, plus 30 minutes (still has seconds data, but custom format will ignore it - will be trimmed before storing)
            EndTime_Picker.Value = DateTime.Now.AddMinutes(60); // Set end time to the current time, plus an hour (seconds data same as above ^ )

        }

        private DateTime RemoveSeconds(DateTime time) // Method to truncate the seconds off of inputted DateTime values, as seconds will be discarded when stored
        {
            return new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, 0);
        }

        private bool ValidateBooking()
        {
            List<Space> spaceList = new List<Space>();
            spaceList = GetSpaces();

            if (spaceList == null) { Security.CreateErrorMessage("Invalid times picked", this, ERROR_START_POS, ActiveErrors); ; return false; } // Don't create booking if times are invalid

            if (UserSelectedSpace == null) { Security.CreateErrorMessage("No space selected", this, ERROR_START_POS, ActiveErrors); return false; } // Require a space to be selected

            bool spaceAvailable = false;

            foreach (Space item in spaceList)
            {
                if (item.SpaceID == UserSelectedSpace.SpaceID)
                {
                    spaceAvailable = true;
                }
            }

            if (!spaceAvailable) { Security.CreateErrorMessage("This space is no longer available", this, ERROR_START_POS, ActiveErrors); return false; }

            return true;

        }


        private void AvailableSpaces_SelectedIndexChanged(object sender, EventArgs e) // Fires when an item in the available spaces list is clicked
        {
            if (this.AvailableSpaces.SelectedItem == null || this.AvailableSpaces.SelectedIndex == -1) { return; }

            this.SelectedSpace.Text = "Selected Space: " + this.AvailableSpaces.SelectedItem.ToString();
            string spaceString = this.AvailableSpaces.SelectedItem.ToString();

            Debug.WriteLine("Changed to " + spaceString);

            using (SqlConnection conn = new SqlConnection(Security.connectionString)) // Create a space object using the spaceID taken from the list
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Spaces WHERE SpaceID = @spaceid", conn))
                {

                    cmd.Parameters.AddWithValue("@spaceid", spaceString);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserSelectedSpace = new Space();

                            UserSelectedSpace.SpaceID = reader["SpaceID"].ToString();
                            UserSelectedSpace.Width = (int)reader["Width"];
                            UserSelectedSpace.Height = (int)reader["Height"];
                            UserSelectedSpace.IsVertical = (bool)reader["IsVertical"];
                            UserSelectedSpace.X = (int)reader["X"];
                            UserSelectedSpace.Y = (int)reader["Y"];
                            UserSelectedSpace.NodeID = (int)reader["NodeID"];
                        }
                        else
                        {
                            UserSelectedSpace = null;
                            this.SelectedSpace.Text = "Selected Space: None";
                        }
                    }
                }
            }

            if (UserSelectedSpace != null)
            {
                this.ViewSpaceButton.Visible = true;
            }
            else
            {
                this.ViewSpaceButton.Visible = false;
            }
        }

        private List<Space> GetSpaces()
        {
            Security.ClearErrors(this, ActiveErrors);

            DateTime SelectedDay = BookingDate_Picker.Value.Date; // Get the user's selected stay date
            DateTime ArrivalTime = RemoveSeconds(SelectedDay + StartTimePicker.Value.TimeOfDay); // Get the user's selected arrival time
            DateTime LeavingTime = RemoveSeconds(SelectedDay + EndTimePicker.Value.TimeOfDay); // Get the user's selected departure time

            DateTime OpeningTime = SelectedDay.AddHours(CarParkConfiguration.OPENING_HOUR); // Fetch opening hour
            DateTime ClosingTime = SelectedDay.AddHours(CarParkConfiguration.CLOSING_HOUR); // Fetch closing hour

            // Validate user inputs

            if (ArrivalTime < DateTime.Now.AddMinutes(CarParkConfiguration.MINIMUM_ADVANCE_NOTICE)) // Ensure the user's booking is made with the correct advance notice        
            {
                Security.CreateErrorMessage("This arrival time has already passed, or ample advance notice was not given", this, ERROR_START_POS, ActiveErrors);
                return null;
            }

            if (LeavingTime <= ArrivalTime) // Ensure arrival/departure times were entered in the correct order
            {

                Security.CreateErrorMessage("Departure time must be after arrival time", this, ERROR_START_POS, ActiveErrors);
                return null;
            }

            TimeSpan miniumumStayDuration = TimeSpan.FromMinutes(CarParkConfiguration.MINIMUM_STAY_DURATION); // Convert minimum stay duration to timespan so it can be compared

            if (LeavingTime - ArrivalTime < miniumumStayDuration)
            {
                Security.CreateErrorMessage("This stay duration is too short.", this, ERROR_START_POS, ActiveErrors);
                return null;
            }

            if (ArrivalTime < OpeningTime || LeavingTime > ClosingTime) // Ensure the user's stay is within opening hours
            {
                Security.CreateErrorMessage("Selected times are outside of opening hours", this, ERROR_START_POS, ActiveErrors);
                return null;
            }

            // Passed initial validation

            // Get Available Spaces

            List<Space> tempSpaces = new List<Space>();

            tempSpaces = MapFunctions.GetAvailableSpaces(ArrivalTime, LeavingTime);

            return tempSpaces;
        }

        private void FindSpaces_Click(object sender, EventArgs e) // Find available spaces within the given timeframe and display them to the user
        {

            Debug.WriteLine("Validating inputs and finding spaces...");
            this.AvailableSpaces.Items.Clear(); // Clear any current items from the list
            UserSelectedSpace = null;
            this.SelectedSpace.Text = "Selected Space: None";
            this.ViewSpaceButton.Visible = false;

            // Get spaces
            Spaces = GetSpaces();
            if (Spaces == null) { return; } // If error then exit out

            // Add available spaces to the listbox for the user to select

            foreach (Space space in Spaces)
            {
                this.AvailableSpaces.Items.Add(space.SpaceID);
            }

        }

        private void ViewSpaceButton_Click(object sender, EventArgs e) // Load the virtual map to display the selected space, and any other available spaces
        {
            if (UserSelectedSpace == null) { return; } // Map only opens if there's a valid selected space

            VirtualMap Map = new VirtualMap(UserSelectedSpace, Spaces);
            Map.Location = this.Location;
            Map.Show();
        }

        private void CreateBooking_Click(object sender, EventArgs e) // When the user confirms their booking
        {
            if (!ValidateBooking()) { return; } // Exit if booking is not valid

            DateTime SelectedDay = BookingDate_Picker.Value.Date; // Get the user's selected stay date
            DateTime ArrivalTime = RemoveSeconds(SelectedDay + StartTimePicker.Value.TimeOfDay); // Get the user's selected arrival time to store in database
            DateTime LeavingTime = RemoveSeconds(SelectedDay + EndTimePicker.Value.TimeOfDay); // Get the user's selected departure time to store in database

            string addBookingSQL = "INSERT INTO BookingInfo (SpaceID, StartTime, EndTime, UserID) VALUES (@spaceid, @starttime, @endtime, @userid)";

            try
            {
                using (SqlConnection conn = new SqlConnection(Security.connectionString))
                {

                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(addBookingSQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@spaceid", UserSelectedSpace.SpaceID);
                        cmd.Parameters.AddWithValue("@starttime", ArrivalTime);
                        cmd.Parameters.AddWithValue("@endtime", LeavingTime);
                        cmd.Parameters.AddWithValue("@userid", account.userID);

                        cmd.ExecuteNonQuery(); // Add the user's booking to database

                    }
                }

                Debug.WriteLine("Booking created successfully.");

                MessageBox.Show(

                    "Booking created successfully.",
                    "Booking Confirmation",

                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information

                    );
            }
            catch
            {
                Security.CreateErrorMessage("An error was encountered whilst creating the booking. Please try again later.", this, ERROR_START_POS, ActiveErrors);
            }

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            MainMenu form = new MainMenu(account);
            form.Location = this.Location;
            form.Show();

            this.Close();
        }
    }
}
