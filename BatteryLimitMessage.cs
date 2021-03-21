using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryManagement
{
    class BatteryLimitMessage
    {
        public static void CallPrintMethodsForDE()
        {
            PrintHeadingDE(BatteryMeasure.MeasureCrossedMaximum, "Höchstgrenze überschritten");
            PrintMeasureList(BatteryMeasure.MeasureCrossedMaximum);

            PrintHeadingDE(BatteryMeasure.MeasureCrossedMinimum, "Mindestgrenze überschritten");
            PrintMeasureList(BatteryMeasure.MeasureCrossedMinimum);

            PrintHeadingDE(BatteryMeasure.MeasureReachingHigh, "Erreichen der Höchstgrenze");
            PrintMeasureList(BatteryMeasure.MeasureReachingHigh);

            PrintHeadingDE(BatteryMeasure.MeasureReachingLow, "Erreichen des Mindestlimits");
            PrintMeasureList(BatteryMeasure.MeasureReachingLow);
        }

        public static void CallPrintMethodsForEN()
        {
            PrintHeadingEN(BatteryMeasure.MeasureCrossedMaximum, "crossed Maximum Limit");
            PrintMeasureList(BatteryMeasure.MeasureCrossedMaximum);

            PrintHeadingEN(BatteryMeasure.MeasureCrossedMinimum, "crossed Minimum Limit");
            PrintMeasureList(BatteryMeasure.MeasureCrossedMinimum);

            PrintHeadingEN(BatteryMeasure.MeasureReachingHigh, "reaching towards Maximum Limit");
            PrintMeasureList(BatteryMeasure.MeasureReachingHigh);

            PrintHeadingEN(BatteryMeasure.MeasureReachingLow, "reaching towards Minimum Limit");
            PrintMeasureList(BatteryMeasure.MeasureReachingLow);
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
