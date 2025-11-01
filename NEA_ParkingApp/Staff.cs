using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_ParkingApp
{
    public class Staff : Account
    {
        public override double CostMultiplier { get; set; } = 0; // Free bookings for staff

        public override AccountType AccountTier { get; set; } = AccountType.Staff;

        public Staff(int userID, string username, string password, string forename, string surname) : base(userID, username, password, forename, surname) { } // Initialise account with user values

    }
}
