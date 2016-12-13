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
        Int32 StartTime;

        public Thread CurrentWork;

        public PayForTheNightCalculator()
        {
            CurrentWork = new Thread(GetStartTime);
        }

        public void GetStartTime()
        {
            Console.WriteLine("Please enter start time: ");
        
            StartTime = int.Parse(Console.ReadLine());
        }

        public System.Threading.ThreadState GetThreadState()
        {
            return CurrentWork.ThreadState;
        }

        public ThreadWaitReason GetWaitReason()
        {
            throw new NotImplementedException();
        }
    }
}
