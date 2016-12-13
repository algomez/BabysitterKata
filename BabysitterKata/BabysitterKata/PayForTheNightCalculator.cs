using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BabysitterKata
{
    public class PayForTheNightCalculator
    {
        Int32 StartTime;

        public PayForTheNightCalculator()
        {

        }

        public void GetStartTime()
        {
            Console.WriteLine("Please enter start time: ");
        
            StartTime = int.Parse(Console.ReadLine());
        }

        public ThreadState GetThreadState()
        {
            throw new NotImplementedException();
        }

        public ThreadWaitReason GetWaitReason()
        {
            throw new NotImplementedException();
        }
    }
}
