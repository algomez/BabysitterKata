using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabysitterKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using ConsoleLogger.Tests;
using System.Text.RegularExpressions;

namespace BabysitterKata.Tests
{
    [TestClass()]
    public class PayForTheNightCalculatorTests
    {
        [TestMethod()]
        public void PayForTheNightCalculatorConstructorReturnsNonNull()
        {
            TestingCalculator calculator = new TestingCalculator();

            Assert.IsNotNull(calculator);
        }

        [TestMethod()]
        public void CalculatorAsksForInput()
        {
            TestingCalculator calculator = new TestingCalculator();

            var StartTimePrompt = "Please enter start time (24-hour HH:mm): ";

            var currentConsoleOut = Console.Out;

            using (var consoleOutput = new ConsoleOutput())
            {
                calculator.GetStartTimeFromUser();

                Assert.AreEqual(StartTimePrompt, consoleOutput.GetOuput());
            }

            Console.Clear();

            var EndTimePrompt = "Please enter end time (24-hour HH:mm): ";

            using (var consoleOutput = new ConsoleOutput())
            {
                calculator.GetEndTimeFromUser();

                Assert.AreEqual(EndTimePrompt, consoleOutput.GetOuput());
            }
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

        [TestMethod()]
        public void BabysitterGetsPaidSixteenAnHourFromMidnightToEnd()
        {
            PayForTheNightCalculator calculator = new PayForTheNightCalculator();

            Assert.AreEqual(16, calculator.CalculateMidnightToEndPay(1));

            Assert.AreEqual(32, calculator.CalculateMidnightToEndPay(2));

            Assert.AreEqual(0, calculator.CalculateMidnightToEndPay(0));
        }

        [TestMethod()]
        public void StartTimesOutsideRangeAreRejected()
        {
            TestingCalculator calculator = new TestingCalculator();

            Assert.IsTrue(calculator.GetStartTimeFromUser("17:00"));

            Assert.IsFalse(calculator.GetStartTimeFromUser("16:59"));

            Assert.IsTrue(calculator.GetStartTimeFromUser("17:01"));

            Assert.IsFalse(calculator.GetStartTimeFromUser("00:00"));

            Assert.IsTrue(calculator.GetStartTimeFromUser("23:59"));
        }

        [TestMethod()]
        public void EndTimesOutsideRangeAreRejected()
        {
            TestingCalculator calculator = new TestingCalculator();

            Assert.IsTrue(calculator.GetEndTimeFromUser("4:00"));

            Assert.IsFalse(calculator.GetEndTimeFromUser("4:01"));

            Assert.IsTrue(calculator.GetEndTimeFromUser("3:59"));

            Assert.IsFalse(calculator.GetEndTimeFromUser("5:00"));

            Assert.IsTrue(calculator.GetEndTimeFromUser("00:00"));
        }

        [TestMethod()]
        public void PartialHoursAreRoundedUpForPayCalculation()
        {
            PayForTheNightCalculator calculator = new PayForTheNightCalculator();

            calculator.SetStartTime(TimeSpan.Parse("17:59"));

            calculator.SetEndTime(TimeSpan.Parse("0:59"));

            calculator.SetBedTime(TimeSpan.Parse("19:30"));

            Assert.AreEqual(3, calculator.CalculateStartToBedTimeHours());

            Assert.AreEqual(5, calculator.CalculateBedTimeToMidnightHours());

            Assert.AreEqual(1, calculator.CalculateMidnightToEndHours());
        }
    }
}