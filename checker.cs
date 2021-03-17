using System;
using System.Diagnostics;

namespace BatteryManagement
{
    class Checker
    {

        static void IsBatteryOkay(BatteryMeasure measures, string Language)
        {
            CheckTemperature(measures.Temperature, Language);
            CheckStateOfCharge(measures.StateOfCharge, Language);
            CheckChargeRate(measures.ChargeRate, Language);
            BatteryLimitMessage.PrintConsolidatedReport();
        }

        static void CheckTemperature(float temperature, string Language)
        {
            BatteryMeasureFactors measures = new BatteryMeasureFactors("Temperature", temperature, 45, 0, Language);
            CheckReachingBreaches(measures);
            IsBatteryMeasurenOkay(measures);
        }

        static void CheckStateOfCharge(float soc, string Language)
        {
            BatteryMeasureFactors measures = new BatteryMeasureFactors("State of Charge", soc, 20, 80, Language);
            CheckReachingBreaches(measures);
            IsBatteryMeasurenOkay(measures);
        }

        static void CheckChargeRate(float chargeRate, string Language)
        {
            BatteryMeasureFactors measures = new BatteryMeasureFactors("Charge Rate",chargeRate, 0.8f, 0.0f, Language);
            CheckReachingBreaches(measures);
            IsBatteryMeasurenOkay(measures);

        }

        static void CheckReachingBreaches(BatteryMeasureFactors measures)
        {
            BatteryMeasure.CheckLowBreach(measures);
            BatteryMeasure.CheckHighBreach(measures);
        }

        static bool IsBatteryMeasurenOkay(BatteryMeasureFactors measures)
        {
            if (measures.MeasureValue < measures.MinimumLimit || measures.MeasureValue > measures.MaximumLimit)
                BatteryMeasure.EvaluateBatteryMeasure(measures);
        }

        static int Main()
        {
            IsBatteryOkay(new BatteryMeasure(25, 70, 0.7f), "English");
            IsBatteryOkay(new BatteryMeasure(60, 65, 0.6f), "English");
            IsBatteryOkay(new BatteryMeasure(-50, 85, 0.0f), "English");
            IsBatteryOkay(new BatteryMeasure(43, 10, 0.9f), "English");
            IsBatteryOkay(new BatteryMeasure(43, 78, 0.7f), "English");
            return 0;
        }
    }
}

