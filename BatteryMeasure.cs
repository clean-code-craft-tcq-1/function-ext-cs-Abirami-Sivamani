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
        public BatteryMeasure(float temperature, float soc, float chargeRate)
        {
            this.Temperature = temperature;
            this.StateOfCharge = soc;
            this.ChargeRate = chargeRate;
        }

        public static void EvaluateBatteryMeasure(BatteryMeasureFactors battery)
        {
            if(battery.MeasureValue > battery.MaximumLimit)
                PrintMaximumLimitMessage(battery.MeasureName, battery.MaximumLimit, battery.MessageLanguage);
            if (battery.MeasureValue < battery.MinimumLimit)
                PrintMinimumLimitMessage(battery.MeasureName, battery.MinimumLimit, battery.MessageLanguage);

            DisplayOutOfRangeMessage(battery.MeasureName);
        }
        
        public static void CheckBreaches(BatteryMeasureFactors battery)
        {
            if ((battery.MeasureValue > (battery.MinimumLimit + battery.LowBreach)) && (battery.MeasureValue<(battery.MinimumLimit + battery.HighBreach)))
                PrintLowBreachMessage(battery.MeasureName, battery.MessageLanguage);
            if (((battery.MeasureValue > battery.MaximumLimit - battery.HighBreach)) && (battery.MeasureValue<battery.MaximumLimit))
                PrintHighBreachMessage(battery.MeasureName, battery.MessageLanguage);
        }

        static void PrintMaximumLimitMessage(string Measure, float MaximumLimit, string MessageLanguage)
        {
                Console.WriteLine(Measure + " has exceeded its Maximum Limit of " + MaximumLimit);
        }

        static void PrintMinimumLimitMessage(string Measure, float MinimumLimit, string MessageLanguage)
        {
                Console.WriteLine(Measure + " has fall behind its Minimum Limit of " + MinimumLimit);
        }

        static void DisplayOutOfRangeMessage(string Measure)
        {
            Console.WriteLine(Measure + " is out of range!");
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

