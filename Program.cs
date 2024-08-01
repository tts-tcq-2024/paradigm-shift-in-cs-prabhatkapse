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
            Utils.ExpectTrue(battery.IsOk());
            if (String.Equals(battery.GetStateStatus(), "Battery status: NORMAL_TEMPERATURE_STATE, NORMAL_SOC_STATE, NORMAL_CHARGE_RATE_STATE"))
                Console.WriteLine($"TP1: Passed, {battery.GetStateStatus()}");
            else
                Console.WriteLine($"TP1: Fails, {battery.GetStateStatus()}");


            Console.WriteLine("TP2: Battery Condition is not good");

            temp = 2;
            soc = 77;
            chargeRate = 0.9f;

            battery = new BatterySystem(minTemp, maxTemp, temp, minSoc, maxSoc, soc, maxChargeRate, chargeRate);
            Utils.ExpectFalse(battery.IsOk());
            battery.ConfigureWarning(true, true, false);
            if (String.Equals(battery.GetStateStatus(), "Battery status: LOW_TEMPERATURE_WARNING, HIGH_SOC_WARNING, HIGH_CHARGE_RATE_BREACH"))
                Console.WriteLine($"TP2: Passed, {battery.GetStateStatus()}");
            else
                Console.WriteLine($"TP1: Fails, {battery.GetStateStatus()}");
        }

    }
}
