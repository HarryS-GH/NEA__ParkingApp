using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------- //

// Signup requirements:

// No fields can be empty.

// Username - Between 5 and 50 characters inclusive. Cannot contain spaces. Cannot contain special characters.
// Password - Between 10 and 50 characters inclusive. Cannot contain spaces. Must include at least 1 number, with a mix of uppercase and lowercase. 
// Confirm password - Must match the password entered above. Cannot be shown, so the user must be able to reproduce their own password.

// Forename - 25 characters max.
// Surname - 25 characters max.

// Account Tier - Must be selected from the drop-down box. 
// Tier Passkey - Certain tiers will require a passkey stored in a database. Passkeys can be created/removed by admin tier accounts and must be shared externally.

// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------- //

namespace NEA_ParkingApp
{
    public partial class SignupForm : Form
    {


        private Point ERROR_START_POS = new Point(23, 769);
        private List<Label> ActiveErrors = new List<Label>();



        public SignupForm()
        {
            InitializeComponent();
            UpdatePasskeyFuncs();

        }

        // Validates user's inputs according to the signup specifications starting at Line 13
        private bool ValidateInputs()
        {
            bool validInputs = true;

            // Validate Username -------------------------------------------------------------------------------- //

            string username = this.UsernameBox.Text;

            string usernameCheck = "SELECT UserID FROM Users WHERE Username = @username"; // Ensure the username is not already taken

            using (SqlConnection conn = new SqlConnection(Security.connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(usernameCheck, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    if (cmd.ExecuteScalar() != null)
                    {
                        validInputs = false;
                        Security.CreateErrorMessage("Usernames must be unique.", this, ERROR_START_POS, ActiveErrors);
                    }
                }
            }

            if (username.Length < 5 || username.Length > 50) // Validate username Length
            {
                validInputs = false;
                Security.CreateErrorMessage("Username must be between 5 and 50 characters in length.", this, ERROR_START_POS, ActiveErrors);
            }

            foreach (char c in username) // Reject special characters and spaces
            {
                if (!char.IsLetterOrDigit(c))
                {
                    validInputs = false;
                    Security.CreateErrorMessage("Username cannot contain special characters or spaces.", this, ERROR_START_POS, ActiveErrors);
                    break;

                }
            }

            // Validate Password ------------------------------------------------------------------------------------- //

            string password = this.PasswordBox.Text;

            if (password.Length < 10 || password.Length > 50) // Validate password Length
            {
                validInputs = false;
                Security.CreateErrorMessage("Password must be between 10 and 50 characters in length.", this, ERROR_START_POS, ActiveErrors);
            }



            bool passwordHasNumbers = false;
            bool passwordHasLower = false;
            bool passwordHasUpper = false;
            bool passwordHasSpaces = false;

            foreach (char c in password) // Gather password information
            {
                if (char.IsUpper(c))
                {
                    passwordHasUpper = true;
                }

                if (char.IsLower(c))
                {
                    passwordHasLower = true;
                }

                if (char.IsNumber(c))
                {
                    passwordHasNumbers = true;

                }

                if (char.IsWhiteSpace(c))
                {
                    passwordHasSpaces = true;
                }
            }

            if (!passwordHasNumbers) // Require numbers
            {
                validInputs = false;
                Security.CreateErrorMessage("Password must contain at least 1 numerical character.", this, ERROR_START_POS, ActiveErrors);
            }

            if (!(passwordHasLower && passwordHasUpper)) // Require a mix of lowercase and uppercase letters
            {
                validInputs = false;
                Security.CreateErrorMessage("Password must contain a mix of lowercase and uppercase letters.", this, ERROR_START_POS, ActiveErrors);
            }

            if (passwordHasSpaces) // Reject spaces
            {
                validInputs = false;
                Security.CreateErrorMessage("Password cannot contain spaces.", this, ERROR_START_POS, ActiveErrors);
            }

            if (password != this.ConfirmPasswordBox.Text) // Ensure the confirm password box matches the inputted password
            {
                validInputs = false;
                Security.CreateErrorMessage("Passwords must match.", this, ERROR_START_POS, ActiveErrors);
            }

            // Validate Forename and Surname   ------------------------------------------------------------------------------------------- //

            string forename = this.ForenameBox.Text;
            string surname = this.SurnameBox.Text;

            if (forename.Length == 0 || surname.Length == 0)
            {
                validInputs = false;
                Security.CreateErrorMessage("Name fields cannot be empty.", this, ERROR_START_POS, ActiveErrors);
            }

            if (forename.Length > 25 || surname.Length > 25)
            {
                validInputs = false;
                Security.CreateErrorMessage("Name fields cannot exceed 25 characters.", this, ERROR_START_POS, ActiveErrors);
            }

            // Validate Tier Passkey ----------------------------------------------------------------------------------------------- //

            Debug.WriteLine(TierKeyBox.Text);
            Debug.WriteLine(AccountTier.Text);
            if (AccountTier.Text == "Staff" || AccountTier.Text == "Admin")
            {
                string getKeys = "SELECT KeyID FROM ACCOUNT_KEYS WHERE KeyString = @key AND AccountType = @tier";

                try
                {               

                    using (SqlConnection conn = new SqlConnection(Security.connectionString))
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(getKeys, conn))
                        {
                            cmd.Parameters.AddWithValue("@key", TierKeyBox.Text);
                            cmd.Parameters.AddWithValue("@tier", AccountTier.Text.ToUpper());

                            var validKeys = cmd.ExecuteScalar();

                            if (validKeys == null)
                            {
                                validInputs = false;
                                Security.CreateErrorMessage("Invalid tier passkey was entered.", this, ERROR_START_POS, ActiveErrors);

                            }

                        }
                    }
                }
                catch
                {
                    Security.CreateErrorMessage("An error occured whilst verifying your account tier passkey. Please try again.", this, ERROR_START_POS, ActiveErrors);
                }
            }

            return validInputs;
        }

        private void UpdatePasskeyFuncs()
        {
            // Update passkey box status when account tier is changed

            string selectedTier = this.AccountTier.Text;

            if (selectedTier == "Admin" || selectedTier == "Staff")
            {
                this.TierKeyBox.Clear();

                this.PasskeyShow.Text = "Show";
                this.TierKeyBox.PasswordChar = '*';

                this.TierKeyBox.Visible = true;
                this.TierKeyLabel.Visible = true;
                this.PasskeyShow.Visible = true;
            }
            else
            {
                this.TierKeyBox.Visible = false;
                this.TierKeyLabel.Visible = false;
                this.PasskeyShow.Visible = false;
            }
        }

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


        private void AccountTier_SelectedIndexChanged(object sender, EventArgs e)
        {

            UpdatePasskeyFuncs();
        }

        private void ShowPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TogglePasswordShow(this.PasswordBox, this.ShowPassword);
        }

        private void PasskeyShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TogglePasswordShow(this.TierKeyBox, this.PasskeyShow);
        }

        private void SignupButton_Click(object sender, EventArgs e)
        {
            Security.ClearErrors(this, ActiveErrors);
            if (ValidateInputs())
            {
                // Once validation is passed, add new user to database

                string createAccount = "INSERT INTO Users (Username, Password, Forename, Surname, AccountTier) OUTPUT INSERTED.* VALUES (@Username, @Password, @Forename, @Surname, @AccountTier)";

                try
                {
                    using (SqlConnection conn = new SqlConnection(Security.connectionString))
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(createAccount, conn))
                        {

                            string hashedPass = Security.HashPassword(this.PasswordBox.Text);

                            // Add inputted signup information
                            cmd.Parameters.AddWithValue("@Username", this.UsernameBox.Text);
                            cmd.Parameters.AddWithValue("@Password", hashedPass);
                            cmd.Parameters.AddWithValue("@Forename", this.ForenameBox.Text);
                            cmd.Parameters.AddWithValue("@Surname", this.SurnameBox.Text);
                            cmd.Parameters.AddWithValue("@AccountTier", this.AccountTier.Text);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int accountID = (int)reader["UserID"];
                                    string username = reader["Username"].ToString();
                                    string password = reader["Password"].ToString();
                                    string forename = reader["Forename"].ToString();
                                    string surname = reader["Surname"].ToString();
                                    string tier = reader["AccountTier"].ToString();

                                    Account userAccount = CarParkConfiguration.CreateAccount(accountID, username, password, forename, surname, tier);

                                    MainMenu menuForm = new MainMenu(userAccount);
                                    menuForm.Location = this.Location;
                                    menuForm.Show();

                                    this.Close();
                                }
                            }
                        }
                    }
                }
                catch
                {
                    Security.ClearErrors(this, ActiveErrors);
                    Security.CreateErrorMessage("An error occured whilst making your account. Please try again later.", this, ERROR_START_POS, ActiveErrors);
                }
            }

        }

        
    }
}
