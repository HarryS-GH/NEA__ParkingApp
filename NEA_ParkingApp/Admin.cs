using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_ParkingApp
{
    public class Admin : Account
    {
        public override double CostMultiplier { get; set; } = 0; // Make bookings free 

        public override AccountType AccountTier { get; set; } = AccountType.Admin;

        public Admin(int userID, string username, string password, string forename, string surname) : base(userID, username, password, forename, surname) { } // Initialise account with user values
        
        public void CreateKey(string key, string accountType) // Create a new tier key for staff/admin accounts
        {


            try
            {
                string checkKeys = "SELECT * FROM ACCOUNT_KEYS WHERE KeyString = @key"; // Ensure all keys are unique (no duplicates)

                using (SqlConnection conn = new SqlConnection(Security.connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(checkKeys, conn))
                    {
                        cmd.Parameters.AddWithValue("@key", key);

                        int existingKeys = (int)cmd.ExecuteScalar();

                        if (existingKeys > 0)
                        {

                            MessageBox.Show(

                                "This key already exists. Please input a different key.",

                                "Error",

                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error

                                );

                            return;
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show(

                "An error occured when creating the key, please try again later.",

                "Error",

                MessageBoxButtons.OK,
                MessageBoxIcon.Error

                );
            }

            try
            {
                string makeKey = "INSERT INTO ACCOUNT_KEYS (KeyString, AccountType)  VALUES (@key, @type)";

                using (SqlConnection conn = new SqlConnection(Security.connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(makeKey, conn))
                    {
                        cmd.Parameters.AddWithValue("@key", key);
                        cmd.Parameters.AddWithValue("@type", accountType);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(

                    "Key created successfully.",
                    "Key Created",

                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information

                    );

            }
            catch
            {
                MessageBox.Show(

                "An error occured when creating the key, please try again later.",

                "Error",

                MessageBoxButtons.OK,
                MessageBoxIcon.Error

                );
            }
        }

        public void RemoveKey(string key, string accountType)
        {
            string removeKey = "DELETE FROM ACCOUNT_KEYS WHERE KeyString = @key";

            try
            {
                using (SqlConnection conn = new SqlConnection(Security.connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(removeKey, conn))
                    {
                        cmd.Parameters.AddWithValue("@key", key);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show(

                                "Key deleted successfully.",
                                "Key Deleted",

                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information

                                );
                        }
                        else
                        {
                            MessageBox.Show(

                                "No matching keys found.",
                                "Error",

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

                "An error occured when deleting the key, please try again later.",

                "Error",

                MessageBoxButtons.OK,
                MessageBoxIcon.Error

                );
            }
        } // Delete a given key from the database
            
    }
}
