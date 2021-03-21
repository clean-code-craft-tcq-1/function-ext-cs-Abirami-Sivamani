using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryManagement
{
    class BatteryMeasure
    {
        public float Temperature, StateOfCharge, ChargeRate;
        public static List<String> MeasureCrossedMaximum, MeasureCrossedMinimum, MeasureReachingLow, MeasureReachingHigh;
        public BatteryMeasure(float temperature, float soc, float chargeRate)
        {
            this.Temperature = temperature;
            this.StateOfCharge = soc;
            this.ChargeRate = chargeRate;
            MeasureCrossedMaximum = new List<String>();
            MeasureCrossedMinimum = new List<String>();
            MeasureReachingHigh = new List<String>();
            MeasureReachingLow = new List<String>();
        }

        public static bool CrossedMaximum(BatteryMeasureFactors battery)
        {
            if (battery.MeasureValue > battery.MaximumLimit)
            {
                MeasureCrossedMaximum.Add(battery.MeasureName);
                return false;
            }
            return true;
        }

        public static bool CrossedMinimum(BatteryMeasureFactors battery)
        {
            if (battery.MeasureValue < battery.MinimumLimit)
            {
                MeasureCrossedMinimum.Add(battery.MeasureName);
                return false;
            }
            return true;
        }

        public static void ReachingLow(BatteryMeasureFactors battery)
        {
            if ((battery.MeasureValue > (battery.MinimumLimit + battery.LowBreach)) && (battery.MeasureValue < (battery.MinimumLimit + battery.HighBreach)))
                MeasureReachingLow.Add(battery.MeasureName);
        }

        public static void ReachingHigh(BatteryMeasureFactors battery)
        {
            if (((battery.MeasureValue > battery.MaximumLimit - battery.HighBreach)) && (battery.MeasureValue < battery.MaximumLimit))
                MeasureReachingHigh.Add(battery.MeasureName); ;
        }
    }

    class BatteryMeasureFactors
    {
        public float MeasureValue, MaximumLimit, MinimumLimit, LowBreach, HighBreach;
        public string MeasureName, MessageLanguage;
        public BatteryMeasureFactors(string Name, float Value, float MaximumValue, float MinimumValue, string Language)
        {
            this.MeasureName = Name;
            this.MeasureValue = Value;
            this.MaximumLimit = MaximumValue;
            this.MinimumLimit = MinimumValue;
            this.MessageLanguage = Language;
            this.LowBreach = (MinimumValue * 0.05f);
            this.HighBreach = (MaximumValue * 0.05f);
        }
    }
}

