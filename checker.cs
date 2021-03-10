using System;
using System.Diagnostics;

namespace BatteryManagement
{
    class Checker
    {
        /// <summary>
        /// Batteries the is ok.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <param name="soc">The soc.</param>
        /// <param name="chargeRate">The charge rate.</param>
        /// <returns></returns>
        static bool batteryIsOk(BatteryMeasure measures, string Language)
        {
            bool TemperatureMeasureCheck = CheckTemperature(measures.Temperature, Language);
            bool ChargeStateMeasureCheck = CheckStateOfCharge(measures.StateOfCharge, Language);
            bool ChargeRateMeasureCheck = CheckChargeRate(measures.ChargeRate, Language);
            return (TemperatureMeasureCheck && ChargeStateMeasureCheck && ChargeRateMeasureCheck);
        }

        /// <summary>
        /// Checks the temperature.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <returns></returns>
        static bool CheckTemperature(float temperature, string Language)
        {
            BatteryMeasureFactors measures = new BatteryMeasureFactors("Temperature", temperature, 45, 0, Language);
            BatteryMeasure.CheckLowBreach(measures);
            BatteryMeasure.CheckHighBreach(measures);
            if (temperature < 0 || temperature > 45)
            {
                BatteryMeasure.EvaluateBatteryMeasure(measures);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks the state of charge.
        /// </summary>
        /// <param name="soc">The soc.</param>
        /// <returns></returns>
        static bool CheckStateOfCharge(float soc, string Language)
        {
            BatteryMeasureFactors measures = new BatteryMeasureFactors("State of Charge", soc, 20, 80, Language);
            BatteryMeasure.CheckLowBreach(measures);
            BatteryMeasure.CheckHighBreach(measures);
            if (soc < 20 || soc > 80)
            {
                BatteryMeasure.EvaluateBatteryMeasure(measures);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks the charge rate.
        /// </summary>
        /// <param name="chargeRate">The charge rate.</param>
        /// <returns></returns>
        static bool CheckChargeRate(float chargeRate, string Language)
        {
            BatteryMeasureFactors measures = new BatteryMeasureFactors("Charge Rate",chargeRate, 0.8f, 0.0f, Language);
            BatteryMeasure.CheckLowBreach(measures);
            BatteryMeasure.CheckHighBreach(measures);
            if (chargeRate > 0.8)
            {
                BatteryMeasure.EvaluateBatteryMeasure(measures);
                return false;
            }
            return true;
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
            PassedBatteryMeasure(batteryIsOk(new BatteryMeasure(25, 70, 0.7f), "English"));
            FailedBatteryMeasure(batteryIsOk(new BatteryMeasure(60, 65, 0.6f), "English"));
            FailedBatteryMeasure(batteryIsOk(new BatteryMeasure(-50, 85, 0.0f), "English"));
            FailedBatteryMeasure(batteryIsOk(new BatteryMeasure(43, 10, 0.9f), "English"));
            PassedBatteryMeasure(batteryIsOk(new BatteryMeasure(43, 78, 0.7f), "English"));
            
            PassedBatteryMeasure(batteryIsOk(new BatteryMeasure(25, 70, 0.7f), "German"));
            FailedBatteryMeasure(batteryIsOk(new BatteryMeasure(60, 65, 0.6f), "German"));
            FailedBatteryMeasure(batteryIsOk(new BatteryMeasure(-50, 85, 0.0f), "German"));
            FailedBatteryMeasure(batteryIsOk(new BatteryMeasure(43, 10, 0.9f), "German"));
            return 0;
        }
    }
}

