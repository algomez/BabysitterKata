using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BabysitterKata
{
    interface CalculatorInterface
    {
        void GetStartTime();

        System.Threading.ThreadState GetThreadState();

        System.Diagnostics.ThreadWaitReason GetWaitReason();
    }
}
