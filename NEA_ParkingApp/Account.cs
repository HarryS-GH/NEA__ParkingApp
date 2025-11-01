using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace NEA_ParkingApp
{
    public class Account
    {

        public virtual double CostMultiplier { get; set; } = 1; // Default price multiplier for bookings (1x)
        public int userID { get; }
        public string username;
        public string forename;
        public string surname;
        private string password;

        public virtual AccountType AccountTier { get; set; } = AccountType.Default;

        public Account(int userID, string username, string password, string forename, string surname) // Initialise account with user values
        {

            this.userID = userID;
            this.username = username;
            this.password = password;
            this.forename = forename;
            this.surname = surname;

        }

        private bool UserIsTaken(string testUsername)
        {
            bool taken = false;

            string getUser = "SELECT Username FROM Users WHERE Username = @user";

            try
            {
                using (SqlConnection conn = new SqlConnection(Security.connectionString))
                {

                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(getUser, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", testUsername);

                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            taken = true;
                        }
                    }
                }
            }
            catch
            {
                taken = true;
            }
           

            return taken;
        }

        public void ChangeUser(string newUsername)
        {
            if (UserIsTaken(newUsername))
            {
                MessageBox.Show(

                    "An account with this username already exists. Please enter a different name and try again.",
                    "Error Updating Username",

                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error

                    );

                return;
            }

            string updateUser = "UPDATE Users SET Username = @user WHERE UserID = @id";

            try
            {

                using (SqlConnection conn = new SqlConnection(Security.connectionString))
                {

                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(updateUser, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", newUsername);
                        cmd.Parameters.AddWithValue("@id", this.userID);

                        int rows = cmd.ExecuteNonQuery(); // Update the user's username in the database

                        if (rows > 0)
                        {

                            MessageBox.Show(

                                "Successfully changed username from " + this.username + " to " + newUsername + ".",
                                "Updated Username",

                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information

                                );

                            this.username = newUsername;
                        }
                        else
                        {
                            MessageBox.Show(

                                "Your username could not be updated. Please try again later.",
                                "Error Updating Username",

                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error

                                );


                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show(

                    "Your username could not be updated. Please try again later.",
                    "Error Updating Username",

                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error

                 );
            }
        } // STILL NEEDS VALIDATION!!! ADD VALIDATION!!! DONT FORGET TO ADD THE VALIDATION!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    }


}
