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
                calculator.GetStartTimeFromUser();

                Assert.AreEqual(StartTimePrompt, consoleOutput.GetOuput());
            }

            Console.Clear();

            var EndTimePrompt = "Please enter end time: ";

            using (var consoleOutput = new ConsoleOutput())
            {
                calculator.GetEndTimeFromUser();

                Assert.AreEqual(EndTimePrompt, consoleOutput.GetOuput());
            }
        }

        [TestMethod()]
        public void GetThreadStateMethodReturnsCorrectThreadState()
        {
            PayForTheNightCalculator calculator = new PayForTheNightCalculator();

            Assert.AreEqual(System.Threading.ThreadState.Unstarted, calculator.GetThreadState("Start"));

            calculator.StartTimeThread.Start();

            Assert.AreEqual(System.Threading.ThreadState.Running, calculator.GetThreadState("Start"));

            Assert.AreEqual(System.Threading.ThreadState.Unstarted, calculator.GetThreadState("End"));

            calculator.EndTimeThread.Start();

            Assert.AreEqual(System.Threading.ThreadState.Running, calculator.GetThreadState("End"));

            calculator.StartTimeThread.Abort();

            calculator.EndTimeThread.Abort();
        }

        [TestMethod()]
        public void BabysitterGetsPaidTwelveAnHourFromStartToBedTime()
        {
            PayForTheNightCalculator calculator = new PayForTheNightCalculator();

            Assert.AreEqual(12, calculator.CalculateStartToBedTimePay(1));

            Assert.AreEqual(24, calculator.CalculateStartToBedTimePay(2));

            Assert.AreEqual(0, calculator.CalculateStartToBedTimePay(0));
        }

        [TestMethod()]
        public void BabysitterGetsPaidEightAnHourFromBedTimeToMidnight()
        {
            PayForTheNightCalculator calculator = new PayForTheNightCalculator();

            Assert.AreEqual(8, calculator.CalculateBedTimeToMidnightPay(1));

            Assert.AreEqual(16, calculator.CalculateBedTimeToMidnightPay(2));

            Assert.AreEqual(0, calculator.CalculateBedTimeToMidnightPay(0));
        }
    }
}