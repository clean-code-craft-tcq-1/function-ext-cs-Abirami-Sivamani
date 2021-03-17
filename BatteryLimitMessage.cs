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
            PrintHeading(MeasureCrossedMaximum, "exceeds Maximum Limit");
            MeasureCrossedMaximum.ToList().ForEach(MeasureName => {
                Console.WriteLine(MeasureName);
            });

            PrintHeading(MeasureCrossedMinimum, "fall behind Minimum Limit");
            MeasureCrossedMinimum.ToList().ForEach(MeasureName => {
                Console.WriteLine(MeasureName);
            });

            PrintHeading(MeasureReachingHigh, "reaching towards Maximum Limit");
            MeasureReachingHigh.ToList().ForEach(MeasureName => {
                Console.WriteLine(MeasureName);
            });

            PrintHeading(MeasureReachingLow, "reaching towards Minimum Limit");
            MeasureReachingLow.ToList().ForEach(MeasureName => {
                Console.WriteLine(MeasureName);
            });
    }
    
        static void PrintHeading(List<String> Measures, string LimitText)
        {
            Console.WriteLine((Measures.Count > 0) ? "Below are the Battery Measures "+ LimitText : "None of the Battery Measures "+ LimitText);
        }
  }
}
