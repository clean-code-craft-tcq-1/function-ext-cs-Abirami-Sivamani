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
            if(Language == "English")
                BatteryLimitMessage.CreateConsolidatedReportEN();
            else
                BatteryLimitMessage.CreateConsolidatedReportDE();
        }

       static void CheckTemperature(float temperature, string Language)
        {
            BatteryMeasureFactors measures = new BatteryMeasureFactors("Temperature", temperature, 45, 0, Language);
            TestBatteryMeasureState(measures);
        }

        static void CheckStateOfCharge(float soc, string Language)
        {
            BatteryMeasureFactors measures = new BatteryMeasureFactors("State of Charge", soc, 80, 20, Language);
            TestBatteryMeasureState(measures);
        }

        static void CheckChargeRate(float chargeRate, string Language)
        {
            BatteryMeasureFactors measures = new BatteryMeasureFactors("Charge Rate", chargeRate, 0.8f, 0.0f, Language);
            TestBatteryMeasureState(measures);

        }

        static void TestBatteryMeasureState(BatteryMeasureFactors measures)
        {
            BatteryMeasure.ReachingHigh(measures);
            BatteryMeasure.ReachingLow(measures);
            BatteryMeasure.CrossedMaximum(measures);
            BatteryMeasure.CrossedMinimum(measures);
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
            IsBatteryOkay(new BatteryMeasure(25, 70, 0.7f), "English");
            IsBatteryOkay(new BatteryMeasure(60, 65, 0.6f), "English");
            IsBatteryOkay(new BatteryMeasure(-50, 85, 0.0f), "English");
            IsBatteryOkay(new BatteryMeasure(43, 10, 0.9f), "English");
            IsBatteryOkay(new BatteryMeasure(43, 78, 0.7f), "English");
            
            IsBatteryOkay(new BatteryMeasure(25, 70, 0.7f), "German");
            IsBatteryOkay(new BatteryMeasure(60, 65, 0.6f), "German");
            IsBatteryOkay(new BatteryMeasure(-50, 85, 0.0f), "German");
            IsBatteryOkay(new BatteryMeasure(43, 10, 0.9f), "German");
            IsBatteryOkay(new BatteryMeasure(43, 78, 0.7f), "German");
            return 0;
        }
    }
}

