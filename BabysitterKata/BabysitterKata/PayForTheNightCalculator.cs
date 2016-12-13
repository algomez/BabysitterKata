using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace BabysitterKata
{
    public class PayForTheNightCalculator : CalculatorInterface
    {
        Regex TimeFormat = new Regex(@"^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$");

        TimeSpan StartTime, EndTime, BedTime;

        TimeSpan EarliestStart = new TimeSpan(17, 0, 0);

        TimeSpan LatestEnd = new TimeSpan(4, 0, 0);

        Int32 StartToBedTimeWage = 12, BedTimeToMidNightWage = 8, MidnightToEndWage = 16;

        public String PayForTheNight;

        public void ComputePayForTheNight()
        {
            PayForTheNight = (CalculateBedTimeToMidnightPay(CalculateBedTimeToMidnightHours()) + CalculateMidnightToEndPay(CalculateMidnightToEndHours()) + CalculateStartToBedTimePay(CalculateStartToBedTimeHours())).ToString("C");
        }

        public void SetStartTime(TimeSpan Time)
        {
            StartTime = Time;
        }

        public void SetEndTime(TimeSpan Time)
        {
            EndTime = Time;
        }

        public void SetBedTime(TimeSpan Time)
        {
            BedTime = Time;
        }

        public void GetStartTimeFromUser()
        {
            String InputText;

            Console.WriteLine("Please enter start time (24-hour HH:mm): ");

            while (true)
            {
                InputText = Console.ReadLine();

                if(!TimeFormat.IsMatch(InputText))
                {
                    Console.WriteLine("Incorrect format. Please try again");

                    continue;
                }

                StartTime = TimeSpan.Parse(InputText);

                if(StartTime < EarliestStart)
                {
                    Console.WriteLine("Start time cannot be earlier than 5:00PM. Please try again.");
                }
                else
                {
                    return;
                }
            }
        }

        public void GetEndTimeFromUser()
        {
            String InputText;

            Console.WriteLine("Please enter end time (24-hour HH:mm): ");

            while (true)
            {               
                InputText = Console.ReadLine();

                if (!TimeFormat.IsMatch(InputText))
                {
                    Console.WriteLine("Incorrect format. Please try again");

                    continue;
                }

                EndTime = TimeSpan.Parse(InputText);

                if(EndTime > LatestEnd)
                {
                    Console.WriteLine("End time cannot be later than 4:00AM. Please try again.");
                }
                else
                {
                    return;
                }
            }
        }

        public void GetBedTimeFromUser()
        {
            String InputText;

            Console.WriteLine("Please enter bed time (24-hour HH:mm): ");

            while (true)
            {
                InputText = Console.ReadLine();

                if (!TimeFormat.IsMatch(InputText))
                {
                    Console.WriteLine("Incorrect format. Please try again");

                    continue;
                }

                BedTime = TimeSpan.Parse(InputText);

                return;
            }
        }

        public TimeSpan GetStartTimeFromMemory()
        {
            return StartTime;
        }

        public TimeSpan GetEndTimeFromMemory()
        {
            return EndTime;
        }

        public Int32 CalculateStartToBedTimeHours()
        {
            Int32 Minutes = BedTime.Minutes + StartTime.Minutes;

            TimeSpan StartToBed = BedTime.Subtract(StartTime);

            return (Int32)Math.Ceiling(((StartToBed.TotalMinutes + Minutes) / 60));
        }

        public Int32 CalculateStartToBedTimePay(Int32 Hours)
        {
            TimeSpan StartToBed = BedTime.Subtract(StartTime);

            return Hours * StartToBedTimeWage;
        }

        public Int32 CalculateBedTimeToMidnightHours()
        {
            return Math.Abs((Int32)Math.Ceiling((1440 - BedTime.TotalMinutes) / 60));
        }

        public Int32 CalculateBedTimeToMidnightPay(Int32 Hours)
        {
            return Hours * BedTimeToMidNightWage;
        }

        public Int32 CalculateMidnightToEndHours()
        {
            return Math.Abs((Int32)Math.Ceiling(EndTime.TotalMinutes / 60));
        }

        public Int32 CalculateMidnightToEndPay(Int32 Hours)
        {
            return Hours * MidnightToEndWage;
        }
    }
}
