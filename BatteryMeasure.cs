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
                BatteryLimitMessage.FormatMaximumLimitMessage(battery.MeasureName, battery.MaximumLimit, battery.MessageLanguage);
            if (battery.MeasureValue < battery.MinimumLimit)
                BatteryLimitMessage.FormatMinimumLimitMessage(battery.MeasureName, battery.MinimumLimit, battery.MessageLanguage);
        }
        
        public static void CheckLowBreach(BatteryMeasureFactors battery)
        {
            if ((battery.MeasureValue > (battery.MinimumLimit + battery.LowBreach)) && (battery.MeasureValue<(battery.MinimumLimit + battery.HighBreach)))
                BatteryLimitMessage.FormatLowBreachMessage(battery.MeasureName, battery.MessageLanguage);
        }    
        
        public static void CheckHighBreach(BatteryMeasureFactors battery)
        {
             if (((battery.MeasureValue > battery.MaximumLimit - battery.HighBreach)) && (battery.MeasureValue<battery.MaximumLimit))
                BatteryLimitMessage.FormatHighBreachMessage(battery.MeasureName, battery.MessageLanguage);
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

