using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckRentalChallenge
{
    public class Truck
    {
        public double WeekdayRate { get; set; }
        public double WeekendRate { get; set; }
        public double FirstTwentyMinutes { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public Truck(double weekdayRate, double weekendRate, double firstTwentyMinutes)
        {
            this.WeekdayRate = weekdayRate;
            this.WeekendRate = weekendRate;
            this.FirstTwentyMinutes = firstTwentyMinutes;
        }
        public double CalculatePrice()
        {
            return 15; 
        }
    }
}
