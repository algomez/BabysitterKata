using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BabysitterKata
{
    class Program
    {
        static void Main(string[] args)
        {
            PayForTheNightCalculator calculator = new PayForTheNightCalculator();

            while(true)
            {
                calculator.GetStartTimeFromUser();

                calculator.GetEndTimeFromUser();

                if(calculator.GetEndTimeFromMemory() <= calculator.GetStartTimeFromMemory() && calculator.GetEndTimeFromMemory().Hours > 4)
                {
                    Console.WriteLine("Start time cannot be after or the same as end time. Please try again.");
                }
                else
                {
                    break;
                }
            }

            calculator.GetBedTimeFromUser();

            calculator.ComputePayForTheNight();

            Console.WriteLine("Your total pay for the night is " + calculator.PayForTheNight);

            Console.WriteLine("Press any key to exit");

            Console.ReadLine();
        }
    }
}
