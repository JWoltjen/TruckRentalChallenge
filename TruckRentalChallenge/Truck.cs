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
            int totalDays = CalculateDays();

            double price = 0;
            for (int i = 0; i < totalDays; i++)
            {
                DateTime day = StartTime.AddDays(i);
                if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                {
                    price += WeekendRate;
                }
                else
                {
                    price += WeekdayRate;
                }
            }

            return price;
        }

        public int CalculateDays()
        {
            // Calculate total duration of rental days
            int totalDays = (EndTime - StartTime).Days;

            // Round up to the next day if more than 20 minutes
            if((EndTime - StartTime).TotalMinutes > 20)
            {
                totalDays = totalDays + 1;
            }
            return totalDays;
        }
    }
}
