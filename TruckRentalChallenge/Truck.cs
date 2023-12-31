﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckRentalChallenge
{
    public class Truck
    {
        public decimal HourlyRate { get; set; }
        public decimal WeekdayRate { get; set; }
        public decimal WeekendRate { get; set; }
        public decimal FirstTwentyMinutes { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public Truck(decimal hourlyRate, decimal weekdayRate, decimal weekendRate, decimal firstTwentyMinutes)
        {
            this.HourlyRate = hourlyRate;
            this.WeekdayRate = weekdayRate;
            this.WeekendRate = weekendRate;
            this.FirstTwentyMinutes = firstTwentyMinutes;
        }
        public decimal CalculatePrice()
        {
            int totalHours = CalculateHours();

            decimal price = 0;
            if (totalHours < 24 && StartTime.DayOfWeek != DayOfWeek.Saturday && StartTime.DayOfWeek != DayOfWeek.Sunday)
            {
                // If the rental period is less than a day and it's a weekday, calculate the price based on the hourly rate
                if (totalHours == 1)
                {
                    // If the rental period is less than or equal to an hour, apply the discounted price for the first twenty minutes
                    price = FirstTwentyMinutes;
                }
                else
                {
                    // If the rental period is more than an hour, apply the discounted price for the first twenty minutes and the hourly rate for the remaining time
                    price = FirstTwentyMinutes + HourlyRate * (totalHours - 1);
                }
            }
            else
            {
                // If the rental period is a day or more, or it's a weekend, calculate the price based on the daily rate
                int totalDays = CalculateDays();
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
        public int CalculateHours()
        {
            // Calculate total duration of rental in hours
            int totalHours = (int)(EndTime - StartTime).TotalHours;

            // Round up to the next hour if rental period extends pass 20 minutes
            if ((EndTime - StartTime).TotalMinutes % 60 > 20)
            {
                totalHours = totalHours + 1;
            }
            return totalHours;
        }
    }
}