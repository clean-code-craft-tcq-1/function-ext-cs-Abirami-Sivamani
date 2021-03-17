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
    
      public static void CreateConsolidatedReport(string Language)
        {
            PrintHeading(MeasureCrossedMaximum, "crossed Maximum Limit", "Höchstgrenze überschritten", Language);
            PrintMeasureList(MeasureCrossedMaximum);

            PrintHeading(MeasureCrossedMinimum, "crossed Minimum Limit", "Mindestgrenze überschritten", Language);
            PrintMeasureList(MeasureCrossedMinimum);

            PrintHeading(MeasureReachingHigh, "reaching towards Maximum Limit", "Erreichen der Höchstgrenze", Language);
            PrintMeasureList(MeasureReachingHigh);

            PrintHeading(MeasureReachingLow, "reaching towards Minimum Limit", "Erreichen des Mindestlimits", Language);
            PrintMeasureList(MeasureReachingLow);
        }

        static void PrintHeading(List<String> Measures, string LimitTextEN, string LimitTextDE, string Language)
        {
            if(Language == "English")
                Console.WriteLine((Measures.Count > 0) ? "Below are the Battery Measures "+ LimitTextEN : "None of the Battery Measures "+ LimitTextEN);
            else
                Console.WriteLine((Measures.Count > 0) ? "Nachfolgend finden Sie die Batteriemaßnahmen " + LimitTextDE : "Keine der Batterien misst " + LimitTextDE);
        }

        static void PrintMeasureList(List<String> Measures)
        {
            Measures.ToList().ForEach(MeasureName => {
                Console.WriteLine(MeasureName);
            });
        }
  }
}
