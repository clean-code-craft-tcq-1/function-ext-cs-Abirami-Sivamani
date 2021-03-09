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
            if (MessageLanguage == "English")
                Console.WriteLine(Measure + " has exceeded its Maximum Limit of " + MaximumLimit);
            if (MessageLanguage == "German")
                Console.WriteLine("Die " + Measure + " hat seine Höchstgrenze von " + MaximumLimit + " überschritten");
        }

        public static void PrintMinimumLimitMessage(string Measure, float MinimumLimit, string MessageLanguage)
        {
            if (MessageLanguage == "English")
                Console.WriteLine(Measure + " has fall behind its Minimum Limit of " + MinimumLimit);
            if (MessageLanguage == "German")
                Console.WriteLine("Die " + Measure + " ist unter seine Mindestgrenze von " + MinimumLimit + " gefallen");
        }

        public static void DisplayOutOfRangeMessage(string Measure)
        {
            Console.WriteLine(Measure + " is out of range!");
        }
  }
}
