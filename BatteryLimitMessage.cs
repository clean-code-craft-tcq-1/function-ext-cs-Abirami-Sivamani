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
       		Console.WriteLine((MeasureCrossedMaximum.Count > 1)? "Below are the Battery Measures exceeds Maximum Limit"  : "");
          MeasureCrossedMaximum.ToList().ForEach( MeasureName => {
            Console.WriteLine(MeasureName);
          });
        
          Console.WriteLine((MeasureCrossedMinimum.Count > 1)? "Below are the Battery Measures fall behind Minimum Limit"  : "");
          MeasureCrossedMinimum.ToList().ForEach( MeasureName => {
            Console.WriteLine(MeasureName);
          });
        
          Console.WriteLine((MeasureReachingHigh.Count > 1)? "Below are the Battery Measures reaching towards behind Maximum Limit"  : "");
          MeasureReachingHigh.ToList().ForEach( MeasureName => {
            Console.WriteLine(MeasureName);
          });
        
         Console.WriteLine((MeasureReachingLow.Count > 1)? "Below are the Battery Measures reaching towards behind Minimum Limit"  : "");
          MeasureReachingLow.ToList().ForEach( MeasureName => {
            Console.WriteLine(MeasureName);
          });
    }
  }
}
