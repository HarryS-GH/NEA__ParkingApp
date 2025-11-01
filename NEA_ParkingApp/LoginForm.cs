using Microsoft.VisualBasic.ApplicationServices;
using System.Data.SqlClient;
using System.Diagnostics;

namespace NEA_ParkingApp
{
    public partial class LoginForm : Form
    {


        private Point ERROR_START_POS = new Point(271, 488);
        private List<Label> ActiveErrors = new List<Label>();

        public LoginForm()
        {
            InitializeComponent();
        }

        // Toggle the hidden password string so the user can verify their password
        private void TogglePasswordShow(TextBox passBox, LinkLabel triggerButton)
        {

            if (passBox.PasswordChar == '*')
            {
                triggerButton.Text = "Hide";
                passBox.PasswordChar = '\0';
            }
            else
            {
                triggerButton.Text = "Show";
                passBox.PasswordChar = '*';
            }
        }
        private void ShowPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TogglePasswordShow(this.PasswordBox, this.ShowPassword);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Login attempt

            // Validate inputs, display errors if failed
            Security.ClearErrors(this, ActiveErrors);

            if (this.UsernameBox.Text.Length == 0 || this.PasswordBox.Text.Length == 0) // Presence check
            {
                Security.CreateErrorMessage("All fields must be filled in.", this, ERROR_START_POS, ActiveErrors);
                return;
            }

            // Check database after validation passed

            string loginCheck = "Select * From Users Where Username = @username and Password = @password";

            using (SqlConnection conn = new SqlConnection(Security.connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(loginCheck, conn))
                {
                    cmd.Parameters.AddWithValue("@username", this.UsernameBox.Text);
                    cmd.Parameters.AddWithValue("@password", Security.HashPassword(this.PasswordBox.Text));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Login success
                            int accountID = (int)reader["UserID"];
                            string username = reader["Username"].ToString();
                            string password = reader["Password"].ToString();
                            string forename = reader["Forename"].ToString();
                            string surname = reader["Surname"].ToString();
                            string tier = reader["AccountTier"].ToString();

                            Account userAccount = CarParkConfiguration.CreateAccount(accountID,username,password,forename,surname,tier);

                            Debug.WriteLine(userAccount.AccountTier);

                            this.Hide();

                            MainMenu menuForm = new MainMenu(userAccount);
                            menuForm.Location = this.Location;
                            menuForm.Show();
                        }
                        else
                        {
                            // Login failed
                            Security.CreateErrorMessage("Incorrect username or password.", this, ERROR_START_POS, ActiveErrors);
                        }
                    }
                }
            }
        }

        private void SignUpButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            // Open signup form

            SignupForm signupForm = new SignupForm();
            signupForm.Location = this.Location;
            signupForm.Show();
        }
    }
}
