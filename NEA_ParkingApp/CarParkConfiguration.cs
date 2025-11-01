using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Class to store constant values regarding the car park

namespace NEA_ParkingApp
{
    static class CarParkConfiguration
    {

        public static int OPENING_HOUR = 6; // 24 hour clock
        public static int CLOSING_HOUR = 21; // 24 hour clock

        public static int MINIMUM_ADVANCE_NOTICE = 30; // Minimum advance notice required to create a booking, in minutes
        public static int MINIMUM_STAY_DURATION = 30; // Minimum required length of a stay to create a booking, in minutes

        public static float COST_PER_HOUR = 2; // Per-hour cost of a stay in GBP (£)

        public static Account CreateAccount(int accountID, string username, string password, string forename, string surname, string accountTier) // Creates and returns an account object using the corresponding account type
        {
            Account userAccount;

            Debug.WriteLine(accountTier.ToLower());

            switch (accountTier.Trim().ToLower())
            {
                case "guest":
                    userAccount = new Guest(accountID, username, password, forename, surname);
                    break;
                case "student":
                    userAccount = new Student(accountID, username, password, forename, surname);
                    break;
                case "staff":
                    userAccount = new Staff(accountID, username, password, forename, surname);
                    break;
                case "admin":
                    userAccount = new Admin(accountID, username, password, forename, surname);
                    break;
                default:
                    Debug.WriteLine("No account tier recognised - using default.");
                    userAccount = new Account(accountID, username, password, forename, surname); // Fallback
                    break;
            }


            return userAccount;
        }
    }

    public enum AccountType 
    {
        Default, // Fallback (hopefully will never be used)
        Guest,
        Student,
        Staff,
        Admin
    }
}
