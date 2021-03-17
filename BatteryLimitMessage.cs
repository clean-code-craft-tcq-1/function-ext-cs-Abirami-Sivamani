using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryManagement
{
  class BatteryLimitMessage 
  {
        public static List<String> MeasureCrossedMaximum = new List<String>();
        public static List<String> MeasureCrossedMinimum = new List<String>();
        public static List<String> MeasureReachingLow = new List<String>();
        public static List<String> MeasureReachingHigh = new List<String>();
    
      public static void PrintConsolidatedReport()
      {
        for(int MaxCount = 0 ; MaxCount < MeasureCrossedMaximum.Count; MaxCount++)
        {
          Console.WriteLine((MaxCount == 0) ? "Below are the Battery Measures that exceeds Maximum Limit" : "");      
          Console.WriteLine((MaxCount+1) + ". " + MeasureCrossedMaximum[MaxCount]);
        }
    }
  }
}
