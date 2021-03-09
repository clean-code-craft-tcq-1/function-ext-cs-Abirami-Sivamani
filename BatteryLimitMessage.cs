using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryManagement
{
  class BatteryLimitMessage 
  {
        static void PrintLowBreachMessage(string Measure, string MessageLanguage)
        {
            Console.WriteLine(Measure + " running towards low breach limit");
        }
        static void PrintHighBreachMessage(string Measure, string MessageLanguage)
        {
            Console.WriteLine(Measure + " running towards high breach limit");
        }

        static void PrintMaximumLimitMessage(string Measure, float MaximumLimit, string MessageLanguage)
        {
                Console.WriteLine(Measure + " has exceeded its Maximum Limit of " + MaximumLimit);
        }

        static void PrintMinimumLimitMessage(string Measure, float MinimumLimit, string MessageLanguage)
        {
                Console.WriteLine(Measure + " has fall behind its Minimum Limit of " + MinimumLimit);
        }

        static void DisplayOutOfRangeMessage(string Measure)
        {
            Console.WriteLine(Measure + " is out of range!");
        }
  }
}
