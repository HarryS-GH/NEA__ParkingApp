using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NEA_ParkingApp
{
    public static class Security
    {

        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hosta\source\repos\NEA_ParkingApp\NEA_ParkingApp\ParkingDatabase.mdf;Integrated Security=True"; // Store connection string centrally so I can change it easily
        

        public static string HashPassword(string password) // Encrypt password using SHA256 hashing
        {
            using (SHA256 Sha_Hash = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = Sha_Hash.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash) // Check that the user's entered password matches the stored one
        {
            string enteredHash = HashPassword(enteredPassword);

            return storedHash == enteredHash; // If passwords match, returns true
        }

        public static void ClearErrors(Form form, List<Label> activeErrors) // Clears all custom error messages from a given form
        {
            foreach (Label label in activeErrors)
            {

                Debug.WriteLine("Removing Error Message: " + label.Text);

                form.Controls.Remove(label);
                label.Dispose();

            }
            activeErrors.Clear();
        }

        public static void CreateErrorMessage(string message, Form form, Point location, List<Label> activeErrors) // Creates a basic custom error message on the specificed form, in the specified location
        {
            Size ERROR_SIZE = new Size(50, 20);

            Label error = new Label();
            error.Size = ERROR_SIZE;
            error.Text = "! - " + message;

            error.AutoSize = true;

            error.ForeColor = Color.Maroon;

            int numErrors = activeErrors.Count;
            int offset = numErrors * ERROR_SIZE.Height;

            activeErrors.Add(error);
            error.Location = new Point(location.X, location.Y + offset);

            form.Controls.Add(error);
        }

    }
}
