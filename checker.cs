using System;
using System.Diagnostics;

namespace BatteryManagement
{
    class Checker
    {

        static bool IsBatteryOkay(BatteryMeasure measures, string Language)
        {
            bool isTemperatureOkay = CheckTemperature(measures.Temperature, Language);
            bool isStateOfChargeOkay = CheckStateOfCharge(measures.StateOfCharge, Language);
            bool isChargeRateOkay = CheckChargeRate(measures.ChargeRate, Language);
            if(Language == "English")
                BatteryLimitMessage.CreateConsolidatedReportEN();
            else
                BatteryLimitMessage.CreateConsolidatedReportDE();
            return (isTemperatureOkay && isStateOfChargeOkay && isChargeRateOkay);
        }

       static bool CheckTemperature(float temperature, string Language)
        {
            BatteryMeasureFactors measures = new BatteryMeasureFactors("Temperature", temperature, 45, 0, Language);
            return TestBatteryMeasureState(measures);
        }

        static bool CheckStateOfCharge(float soc, string Language)
        {
            BatteryMeasureFactors measures = new BatteryMeasureFactors("State of Charge", soc, 80, 20, Language);
            return TestBatteryMeasureState(measures);
        }

        static bool CheckChargeRate(float chargeRate, string Language)
        {
            BatteryMeasureFactors measures = new BatteryMeasureFactors("Charge Rate", chargeRate, 0.8f, 0.0f, Language);
            return TestBatteryMeasureState(measures);
        }

        static bool TestBatteryMeasureState(BatteryMeasureFactors measures)
        {
            BatteryMeasure.ReachingHigh(measures);
            BatteryMeasure.ReachingLow(measures);       
            return BatteryMeasure.CrossedMaximum(measures) && BatteryMeasure.CrossedMinimum(measures);
        }
        
        static void PassedBatteryMeasure(bool IsBatteryOk)
        {
            if (!IsBatteryOk)
            {
                Console.WriteLine("Expected true, but got false");
                Environment.Exit(1);
            }
        }
        
        static void FailedBatteryMeasure(bool IsBatteryOk)
        {
            if (IsBatteryOk)
            {
                Console.WriteLine("Expected false, but got true");
                Environment.Exit(1);
            }
        }

        static int Main()
        {
            PassedBatteryMeasure(IsBatteryOkay(new BatteryMeasure(25, 70, 0.7f), "English"));
            FailedBatteryMeasure(IsBatteryOkay(new BatteryMeasure(60, 65, 0.6f), "English"));
            FailedBatteryMeasure(IsBatteryOkay(new BatteryMeasure(-50, 85, 0.0f), "English"));
            FailedBatteryMeasure(IsBatteryOkay(new BatteryMeasure(43, 10, 0.9f), "English"));
            PassedBatteryMeasure(IsBatteryOkay(new BatteryMeasure(43, 78, 0.7f), "English"));
            
            PassedBatteryMeasure(IsBatteryOkay(new BatteryMeasure(25, 70, 0.7f), "German"));
            FailedBatteryMeasure(IsBatteryOkay(new BatteryMeasure(60, 65, 0.6f), "German"));
            FailedBatteryMeasure(IsBatteryOkay(new BatteryMeasure(-50, 85, 0.0f), "German"));
            FailedBatteryMeasure(IsBatteryOkay(new BatteryMeasure(43, 10, 0.9f), "German"));
            PassedBatteryMeasure(IsBatteryOkay(new BatteryMeasure(43, 78, 0.7f), "German"));
            return 0;
        }
    }
}

