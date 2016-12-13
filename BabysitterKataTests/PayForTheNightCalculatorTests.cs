using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabysitterKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace BabysitterKata.Tests
{
    [TestClass()]
    public class PayForTheNightCalculatorTests
    {
        [TestMethod()]
        public void PayForTheNightCalculatorConstructorTest()
        {
            PayForTheNightCalculator calculator = new PayForTheNightCalculator();

            Assert.IsNotNull(calculator);
        }

        [TestMethod()]
        public void CalculatorAsksForInput()
        {
            PayForTheNightCalculator calculator = new PayForTheNightCalculator();

            calculator.GetStartTime();

            Assert.IsTrue(calculator.GetThreadState() == ThreadState.Wait && calculator.GetWaitReason() == ThreadWaitReason.UserRequest);
        }
    }
}