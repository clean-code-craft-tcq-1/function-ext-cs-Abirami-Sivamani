using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryManagement
{
  class BatteryLimitMessage 
  {
        public static void PrintLowBreachMessage(string Measure, string MessageLanguage)
        {
            Console.WriteLine(Measure + " running towards low breach limit");
        }
        public static void PrintHighBreachMessage(string Measure, string MessageLanguage)
        {
            Console.WriteLine(Measure + " running towards high breach limit");
        }

        public static void PrintMaximumLimitMessage(string Measure, float MaximumLimit, string MessageLanguage)
        {
                Console.WriteLine(Measure + " has exceeded its Maximum Limit of " + MaximumLimit);
        }

        public static void PrintMinimumLimitMessage(string Measure, float MinimumLimit, string MessageLanguage)
        {
                Console.WriteLine(Measure + " has fall behind its Minimum Limit of " + MinimumLimit);
        }

        public static void DisplayOutOfRangeMessage(string Measure)
        {
            Console.WriteLine(Measure + " is out of range!");
        }
  }
}
