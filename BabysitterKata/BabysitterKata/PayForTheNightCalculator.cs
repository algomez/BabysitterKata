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
        Int32 StartTime, EndTime;

        String PayForTheNight;

        public Thread StartTimeThread, EndTimeThread;

        public PayForTheNightCalculator()
        {
            StartTimeThread = new Thread(GetStartTimeFromUser);

            EndTimeThread = new Thread(GetEndTimeFromUser);
        }

        public void GetStartTimeFromUser()
        {
            Console.WriteLine("Please enter start time: ");
        
            StartTime = int.Parse(Console.ReadLine());
        }

        public void GetEndTimeFromUser()
        {
            Console.WriteLine("Please enter end time: ");

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

        public int CalculateStartToBedTimePay(int v)
        {
            throw new NotImplementedException();
        }
    }
}
