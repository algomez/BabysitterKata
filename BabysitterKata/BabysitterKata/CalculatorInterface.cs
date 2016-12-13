using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BabysitterKata
{
    interface CalculatorInterface
    {
        void GetStartTime();

        System.Diagnostics.ThreadState GetThreadState();

        System.Diagnostics.ThreadWaitReason GetWaitReason();
    }
}
