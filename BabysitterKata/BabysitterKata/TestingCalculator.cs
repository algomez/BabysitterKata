using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace BabysitterKata
{
    public class TestingCalculator : CalculatorInterface
    {
        Int32 StartTime;

        public Thread CurrentWork;

        public List<String> LinesToRead = new List<String>();

        public int EarliestStart = 1700;

        public TestingCalculator()
        {
            //CurrentWork = new Thread(GetStartTimeFromUser);
        }

        public void GetStartTimeFromUser()
        {
            Console.Write("Please enter start time (24-hour format): ");
        }

        public bool GetStartTimeFromUser(String Time)
        {
            String InputText = Time;

            while (true)
            {
                if (!Int32.TryParse(InputText, out StartTime))
                {
                    return false;
                }

                if (StartTime >= 2400 || StartTime < 0)
                {
                    return false;
                }

                if (StartTime < EarliestStart)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void GetEndTimeFromUser()
        {
            Console.Write("Please enter end time (24-hour format): ");
        }

        public void GetEndTimeFromUser(Int32 Time)
        {
            Console.Write("Please enter end time: ");
        }

        public System.Threading.ThreadState GetThreadState()
        {
            throw new NotImplementedException();
        }

        public ThreadWaitReason GetThreadWaitReason()
        {
            throw new NotImplementedException();
        }
    }
}
