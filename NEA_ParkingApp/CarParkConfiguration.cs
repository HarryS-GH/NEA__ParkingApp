using System;
using System.Collections.Generic;
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

    }
}
