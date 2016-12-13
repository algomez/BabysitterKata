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

        public TestingCalculator()
        {
            CurrentWork = new Thread(GetStartTime);
        }

        public void GetStartTime()
        {
            Console.Write("Please enter start time: ");
        }

        public System.Threading.ThreadState GetThreadState()
        {
            throw new NotImplementedException();
        }

        public ThreadWaitReason GetWaitReason()
        {
            throw new NotImplementedException();
        }
    }
}
