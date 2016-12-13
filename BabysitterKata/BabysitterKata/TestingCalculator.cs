using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace BabysitterKata
{
    public class TestingCalculator : CalculatorInterface
    {
        Regex TimeFormat = new Regex(@"^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$");

        TimeSpan StartTime, EndTime, BedTime;

        TimeSpan EarliestStart = new TimeSpan(17, 0, 0);

        TimeSpan LatestEnd = new TimeSpan(4, 0, 0);

        Int32 StartToBedTimeWage = 12, BedTimeToMidNightWage = 8, MidnightToEndWage = 16;

        public String PayForTheNight;


        public TestingCalculator()
        {
            //CurrentWork = new Thread(GetStartTimeFromUser);
        }

        public bool GetStartTimeFromUser(String InputText)
        {
            Console.WriteLine("Please enter start time (24-hour HH:mm): ");

            while (true)
            {
                if (!TimeFormat.IsMatch(InputText))
                {
                    Console.WriteLine("Incorrect format. Please try again");

                    return false;
                }

                StartTime = TimeSpan.Parse(InputText);

                if (StartTime < EarliestStart)
                {
                    Console.WriteLine("Start time cannot be earlier than 5:00PM. Please try again.");

                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void GetStartTimeFromUser()
        {
            Console.Write("Please enter start time (24-hour HH:mm): ");
        }

        public void GetEndTimeFromUser()
        {
            Console.Write("Please enter end time (24-hour HH:mm): ");
        }

        public bool GetEndTimeFromUser(String InputText)
        {
            while (true)
            {
                if (!TimeFormat.IsMatch(InputText))
                {
                    Console.WriteLine("Incorrect format. Please try again");

                    return false;
                }

                EndTime = TimeSpan.Parse(InputText);

                if (EndTime > LatestEnd)
                {
                    Console.WriteLine("End time cannot be later than 4:00AM. Please try again.");

                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool GetBedTimeFromUser(String InputText)
        {
            while (true)
            {
                InputText = Console.ReadLine();

                if (!TimeFormat.IsMatch(InputText))
                {
                    Console.WriteLine("Incorrect format. Please try again");

                    return false;
                }

                BedTime = TimeSpan.Parse(InputText);

                return true;
            }
        }
    }
}
