using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace BabysitterKata
{
    public class PayForTheNightCalculator : CalculatorInterface
    {
        Int32 StartTime, EndTime, BedTime, EarliestStart = 1700, LatestEnd = 400;

        Int32 StartToBedTimePay = 12, BedTimeToMidNightPay = 8, MidnightToEndPay = 16;

        String PayForTheNight;

        public Thread StartTimeThread, EndTimeThread;

        public PayForTheNightCalculator()
        {
            StartTimeThread = new Thread(GetStartTimeFromUser);

            EndTimeThread = new Thread(GetEndTimeFromUser);
        }

        public void GetStartTimeFromUser()
        {
            String InputText;

            while (true)
            {
                Console.WriteLine("Please enter start time (24-hour format): ");

                InputText = Console.ReadLine();

                if(!Int32.TryParse(InputText, out StartTime))
                {
                    StartTime = 0;

                    break;
                }

                if(StartTime >= 2400 || StartTime < 0)
                {
                    Console.WriteLine("Invalid format for time. Try again.");

                    StartTime = 0;

                    break;
                }

                if (StartTime < EarliestStart)
                {
                    Console.WriteLine("Start time cannot be earlier than 5:00PM.");

                    StartTime = 0;
                }
                else
                {
                    return;
                }
            }
        }

        public void GetEndTimeFromUser()
        {
            Console.WriteLine("Please enter end time (24-hour format): ");

            EndTime = int.Parse(Console.ReadLine());
        }

        public System.Threading.ThreadState GetThreadState(String WhichThread)
        {
            if (WhichThread.Equals("Start", StringComparison.CurrentCultureIgnoreCase))
            {
                return StartTimeThread.ThreadState;
            }
            else if (WhichThread.Equals("End", StringComparison.CurrentCultureIgnoreCase))
            {
                return EndTimeThread.ThreadState;
            }
            else
            {
                Console.WriteLine("Thread type not recognized for GetThreadState(). Returning 'Stopped' by default.");

                return System.Threading.ThreadState.Stopped;
            }
        }

        public Int32 GetStartTimeFromMemory()
        {
            return StartTime;
        }

        public Int32 GetEndTimeFromMemory()
        {
            return EndTime;
        }

        public Int32 CalculateStartToBedTimePay(Int32 Hours)
        {
            return Hours * StartToBedTimePay;
        }

        public Int32 CalculateBedTimeToMidnightPay(Int32 Hours)
        {
            return Hours * BedTimeToMidNightPay;
        }

        public Int32 CalculateMidnightToEndPay(Int32 Hours)
        {
            return Hours * MidnightToEndPay;
        }
    }
}
