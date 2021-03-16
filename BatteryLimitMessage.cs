using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryManagement
{
  class BatteryLimitMessage 
  {
        List<String> MeasureCrossedMaximum, MeasureCrossedMinimum, MeasureReachingLow, MeasureReachingHigh;
        public static void FormatLowBreachMessage(string Measure, string MessageLanguage)
        {
           string Message = (MessageLanguage == "German") ? "Die "+ Measure +" läuft in Richtung ihrer unteren Bruchgrenze" : Measure + " running towards low breach limit";
           MeasureReachingLow.Add(Measure); 
          PrintMessage(Message);
        }
        public static void FormatHighBreachMessage(string Measure, string MessageLanguage)
        {
            string Message = (MessageLanguage == "German") ? "Die " + Measure + " läuft in Richtung ihrer oberen Bruchgrenze" : Measure + " running towards high breach limit";
            MeasureReachingHigh.Add(Measure);  
          PrintMessage(Message);
        }

        public static void FormatMaximumLimitMessage(string Measure, float MaximumLimit, string MessageLanguage)
        {
            string Message = (MessageLanguage == "German") ? "Die " + Measure + " hat seine Höchstgrenze von " + MaximumLimit + " überschritten" : Measure + " has exceeded its Maximum Limit of " + MaximumLimit;
          MeasureCrossedMaximum.Add(Measure);  
          PrintMessage(Message);
        }

        public static void FormatMinimumLimitMessage(string Measure, float MinimumLimit, string MessageLanguage)
        {
            string Message = (MessageLanguage == "German") ? "Die " + Measure + " ist unter seine Mindestgrenze von " + MinimumLimit + " gefallen" : Measure + " has fall behind its Minimum Limit of " + MinimumLimit;
           MeasureCrossedMinimum.Add(Measure);  
          PrintMessage(Message);
        }
    
        public static void PrintMessage(string Message)
        {
          Console.WriteLine(Message);
        }
    
    public static void PrintConsolidatedReport(){
      for(int MaxCount = 1 ; MaxCount <= MeasureCrossedMaximum.Count; MaxCount++)
      {
        if(MaxCount == 1)
          Console.WriteLine("Below are the Battery Measures that exceeds Maximum Limit");
        
        Console.WriteLine(MaxCount + ". " + MeasureCrossedMaximum[MaxCount]);
      }
    }
  }
}
