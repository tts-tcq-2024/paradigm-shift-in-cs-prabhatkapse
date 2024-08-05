using System;
using System.Diagnostics;
namespace paradigm_shift_csharp
{
    class Program
    {
        static void Main()
        {
            //Battery Temperature
            float minTemp = 0;
            float maxTemp = 45;
            //Battery SOC
            float minSoc = 20;
            float maxSoc = 80;
            //Battery Charge Rate
            float maxChargeRate = 0.8f;

            BatterySystem battery;

            Console.WriteLine("TP1: Battery Condition is good");

            float temp = 25;
            float soc = 70;
            float chargeRate = 0.7f;

            battery = new BatterySystem(minTemp, maxTemp, temp, minSoc, maxSoc, soc, maxChargeRate, chargeRate);
            Debug.Assert(battery.IsOk() == true);
            Debug.Assert(battery.GetStateStatus() == "Battery status: NORMAL_TEMPERATURE_STATE, NORMAL_SOC_STATE, NORMAL_CHARGE_RATE_STATE");

            temp = 2;
            soc = 77;
            chargeRate = 0.9f;

            battery = new BatterySystem(minTemp, maxTemp, temp, minSoc, maxSoc, soc, maxChargeRate, chargeRate);
            Debug.Assert(battery.IsOk() == false);
            Debug.Assert(battery.GetStateStatus() == "Battery status: LOW_TEMPERATURE_WARNING, HIGH_SOC_WARNING, HIGH_CHARGE_RATE_BREACH");

            battery.ConfigureWarning(true, false, true);
            Debug.Assert(battery.GetStateStatus() == "Battery status: LOW_TEMPERATURE_WARNING, INVALID, HIGH_CHARGE_RATE_BREACH");
        }

    }
}
