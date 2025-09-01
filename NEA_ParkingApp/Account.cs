using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace NEA_ParkingApp
{
    public class Account
    {

        public int userID { get; }
        public string username;
        public string forename;
        public string surname;
        private string password;
        public string accountTier { get; init; }

        public Account(int userID, string username, string password, string accountTier, string forename, string surname) // Initialise account with user values
        {

            this.userID = userID;
            this.username = username;
            this.password = password;
            this.accountTier = accountTier;
            this.forename = forename;
            this.surname = surname;

        }

    }
}
