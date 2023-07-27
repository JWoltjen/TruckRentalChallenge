using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckRentalChallenge
{
    public class Truck
    {
        public decimal WeekdayRate { get; set; }
        public decimal WeekendRate { get; set; }
        public decimal FirstTwentyMinutes { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public Truck(decimal weekdayRate, decimal weekendRate, decimal firstTwentyMinutes)
        {
            this.WeekdayRate = weekdayRate;
            this.WeekendRate = weekendRate;
            this.FirstTwentyMinutes = firstTwentyMinutes;
        }
        public decimal CalculatePrice()
        {
            int totalDays = CalculateDays();

            decimal price = 0;
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

            // Round up to the next day if rental period extends pass the end of working hours
            if(EndTime.TimeOfDay > new TimeSpan(17, 0, 0)) // 5 PM
            {
                totalDays = totalDays + 1;
            }
            return totalDays;
        }
    }
}