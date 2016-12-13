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
            TestingCalculator calculator = new TestingCalculator();

            Assert.IsNotNull(calculator);
        }

        [TestMethod()]
        public void CalculatorAsksForInput()
        {
            TestingCalculator calculator = new TestingCalculator();

            var StartTimePrompt = "Please enter start time: ";

            var currentConsoleOut = Console.Out;

            using (var consoleOutput = new ConsoleOutput())
            {
                calculator.GetStartTime();

                Assert.AreEqual(StartTimePrompt, consoleOutput.GetOuput());
            }

            //Assert.IsTrue(calculator.GetThreadState() == System.Diagnostics.ThreadState.Wait && calculator.GetWaitReason() == ThreadWaitReason.UserRequest);
        }

        [TestMethod()]
        public void GetThreadStateMethodReturnsCorrectThreadState()
        {
            PayForTheNightCalculator calculator = new PayForTheNightCalculator();

            Assert.AreEqual(System.Threading.ThreadState.Unstarted, calculator.GetThreadState());

            calculator.CurrentWork.Start();

            Assert.AreEqual(System.Threading.ThreadState.Running, calculator.GetThreadState());
        }
    }
}