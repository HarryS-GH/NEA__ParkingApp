using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_ParkingApp
{
    internal class Booking
    {

        public int bookingID { get; }
        public string spaceID { get; set; }

        public int userID { get; }

        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public Booking(int bookingID, string spaceID, int userID, DateTime startTime, DateTime endTime)
        {
            this.bookingID = bookingID;
            this.spaceID = spaceID;
            this.userID = userID;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public void Cancel() // Removes this booking from the database
        {
            string cancelString = "DELETE FROM BookingInfo WHERE BookingID = @bookingID";

            try
            {
                using(SqlConnection conn = new SqlConnection(Security.connectionString))
                {
                    conn.Open();

                    using(SqlCommand cmd = new SqlCommand(cancelString, conn))
                    {
                        cmd.Parameters.AddWithValue("@bookingID", this.bookingID);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show(
                                "Booking successfully cancelled!",
                                "Cancel Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                                ); // Inform the user if their booking is cancelled successfully
                        }
                        else
                        {
                            MessageBox.Show(
                               "Your booking could not be found or no longer exists.",
                               "Cancel Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error
                               ); // Inform the user if their booking isn't found
                        }
                    }
                }
            }
            catch ( Exception ex)
            {
                MessageBox.Show(
                    "Something went wrong while cancelling your booking. Please try again later.",
                    "Cancel Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                ); // Inform the user if their booking couldn't be cancelled
            }
        }

        public void Edit(string spaceid, DateTime start, DateTime end) // Updates this booking's data 
        {
            this.spaceID = spaceid;
            this.startTime = start;
            this.endTime = end;

            string editString = "UPDATE BookingInfo SET SpaceID = @spaceid, StartTime = @start, EndTime = @end WHERE BookingID = @bookingID";

            try
            {
                using (SqlConnection conn = new SqlConnection(Security.connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(editString, conn))
                    {
                        cmd.Parameters.AddWithValue("@spaceid", this.spaceID);
                        cmd.Parameters.AddWithValue("@start", this.startTime);
                        cmd.Parameters.AddWithValue("@end", this.endTime);
                        cmd.Parameters.AddWithValue("@bookingID", this.bookingID);

                        int affectedRows = cmd.ExecuteNonQuery(); // Replaces the relevant fields with the new inputted data

                        if (affectedRows > 0)
                        {
                            MessageBox.Show(
                                "Booking updated successfully!",
                                "Edit Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                                ); // Inform the user that the database was updated with their new values
                        }
                        else
                        {
                            MessageBox.Show(
                                "Your booking could not be found, or no longer exists.",
                                "Edit Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                ); // If no rows were affected, inform the user that their update failed
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Something went wrong while updating your booking. Please try again later.",
                    "Edit Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    ); // Inform the user if the update failed, requesting them to try again 
            }

        }


    }
}
