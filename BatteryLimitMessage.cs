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
           string Message = (MessageLanguage == "German") ? "Die "+ Measure +" läuft in Richtung ihrer unteren Bruchgrenze" : Measure + " running towards low breach limit";
           PrintMessage(Message);
        }
        public static void PrintHighBreachMessage(string Measure, string MessageLanguage)
        {
            string Message = (MessageLanguage == "German") ? "Die " + Measure + " läuft in Richtung ihrer oberen Bruchgrenze" : Measure + " running towards high breach limit";
            PrintMessage(Message);
        }

        public static void PrintMaximumLimitMessage(string Measure, float MaximumLimit, string MessageLanguage)
        {
            string Message = (MessageLanguage == "German") ? "Die " + Measure + " hat seine Höchstgrenze von " + MaximumLimit + " überschritten" : Measure + " has exceeded its Maximum Limit of " + MaximumLimit;
            PrintMessage(Message);
        }

        public static void PrintMinimumLimitMessage(string Measure, float MinimumLimit, string MessageLanguage)
        {
            string Message = (MessageLanguage == "German") ? "Die " + Measure + " ist unter seine Mindestgrenze von " + MinimumLimit + " gefallen" : Measure + " has fall behind its Minimum Limit of " + MinimumLimit;
            PrintMessage(Message);
        }
    
        public static void PrintMessage(string Message)
        {
          Console.WriteLine(Message);
        }
  }
}
