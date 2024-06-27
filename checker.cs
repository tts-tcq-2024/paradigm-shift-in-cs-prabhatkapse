using System;
using System.Diagnostics;
namespace paradigm_shift_csharp
{
class Checker
{
    #region helper function
    static bool valueRangeCheck(object minValue, object maxValue, object value)
    {
        if (value < minValue || value > maxValue)
        {
            return false; // Value is not in the given range
        }

        return true; // Value is in the given range
    }
    #end_region
    
    static bool batteryIsOk(batteryIsOk(float minTemp, float maxTemp, float temp, float minSoc, float maxSoc, float soc, float maxChargeRate, float chargeRate))
    {
        return batteryTempIsOk(minTemp, maxTemp, temp) && batterySocIsOk(minSoc, maxSoc, soc) && batteryChargeRateIsOk(maxChargeRate, chargeRate);
    }
       
    static bool batteryTempIsOk(float minTemp, float maxTemp, float temp) 
    {
        if !(valueRangeCheck(minTemp, maxTemp, temp))
        {
            Console.WriteLine("Temperature is out of range!");
            return false;
        }
            
        return true;
    }

    static bool batterySocIsOk(float minSoc, float maxSoc, float soc) 
    {

        if !(valueRangeCheck(minSoc, maxSoc, soc))
        {
            Console.WriteLine("State of Charge is out of range!");
            return false;
        }

        return true;
    }

    static bool batteryChargeRateIsOk(float maxChargeRate, float chargeRate) 
    {

        if (chargeRate > maxChargeRate) 
        {
            Console.WriteLine("Charge Rate is out of range!");
            return false;
        }
        
        return true;
    }


    static void ExpectTrue(bool expression) {
        if(!expression) {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    static void ExpectFalse(bool expression) {
        if(expression) {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }

         
    static int Main() {
        //Battery Temperature
        float minTemp = 0;
        float maxTemp = 45;
        float temp = 25;
        //Battery SOC
        float minSoc = 20;
        float maxSoc = 80;
        float soc = 70;
        //Battery Charge Rate
        float maxChargeRate = 0.8;
        float chargeRate = 0.7f;
            
        ExpectTrue(batteryIsOk(minTemp, maxTemp, temp, minSoc, maxSoc, soc, maxChargeRate, chargeRate));

        temp = 50;
        soc = 85;
        chargeRate = 0.0f;
        
        ExpectFalse(batteryIsOk(minTemp, maxTemp, temp, minSoc, maxSoc, soc, maxChargeRate, chargeRate));
        
        Console.WriteLine("All ok");
        return 0;
    }
    
}
}
