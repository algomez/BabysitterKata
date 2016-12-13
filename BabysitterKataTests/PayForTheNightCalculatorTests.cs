using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabysitterKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using ConsoleLogger.Tests;

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

            var StartTimePrompt = "Please enter start time: ";

            var currentConsoleOut = Console.Out;

            using (var consoleOutput = new ConsoleOutput())
            {
                calculator.GetStartTime();

                Assert.AreEqual(StartTimePrompt, consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);

            //Assert.IsTrue(calculator.GetThreadState() == System.Diagnostics.ThreadState.Wait && calculator.GetWaitReason() == ThreadWaitReason.UserRequest);
        }
    }
}