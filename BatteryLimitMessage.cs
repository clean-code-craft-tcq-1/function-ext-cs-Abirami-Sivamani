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
    
      public static void CreateConsolidatedReportEN()
        {
            PrintHeadingEN(MeasureCrossedMaximum, "Höchstgrenze überschritten");
            PrintMeasureList(MeasureCrossedMaximum);

            PrintHeadingEN(MeasureCrossedMinimum, "Mindestgrenze überschritten");
            PrintMeasureList(MeasureCrossedMinimum);

            PrintHeadingEN(MeasureReachingHigh, "Erreichen der Höchstgrenze");
            PrintMeasureList(MeasureReachingHigh);

            PrintHeadingEN(MeasureReachingLow, "Erreichen des Mindestlimits");
            PrintMeasureList(MeasureReachingLow);
        }

        public static void CreateConsolidatedReportDE()
        {
            PrintHeadingDE(MeasureCrossedMaximum, "crossed Maximum Limit");
            PrintMeasureList(MeasureCrossedMaximum);

            PrintHeadingDE(MeasureCrossedMinimum, "crossed Minimum Limit");
            PrintMeasureList(MeasureCrossedMinimum);

            PrintHeadingDE(MeasureReachingHigh, "reaching towards Maximum Limit");
            PrintMeasureList(MeasureReachingHigh);

            PrintHeadingDE(MeasureReachingLow, "reaching towards Minimum Limit");
            PrintMeasureList(MeasureReachingLow);
        }

        static void PrintHeadingEN(List<String> Measures, string LimitText)
        {
            Console.WriteLine((Measures.Count > 0) ? "Below are the Battery Measures " + LimitText : "None of the Battery Measures " + LimitText);
        }

        static void PrintHeadingDE(List<String> Measures, string LimitText)
        {     
            Console.WriteLine((Measures.Count > 0) ? "Nachfolgend finden Sie die Batteriemaßnahmen " + LimitText : "Keine der Batterien misst " + LimitText);
        }

        static void PrintMeasureList(List<String> Measures)
        {
            Measures.ToList().ForEach(MeasureName => {
                Console.WriteLine(MeasureName);
            });
        }
  }
}
