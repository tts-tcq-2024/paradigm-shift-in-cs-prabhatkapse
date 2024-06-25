using System;
using System.Diagnostics;
namespace paradigm_shift_csharp
{
class Checker
{
    static bool batteryTempIsOk(float temperature) 
    {
        if (temperature < 0 || temperature > 45) 
        {
            Console.WriteLine("Temperature is out of range!");
            return false;
        }
        
        return true;
    }

    static bool batterySocIsOk(float soc) 
    {

        if (soc < 20 || soc > 80) 
        {
            Console.WriteLine("State of Charge is out of range!");
            return false;
        }

        return true;
    }

    static bool batteryChargeRateIsOk(float chargeRate) 
    {

        if (chargeRate > 0.8) 
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

    static bool batteryCondition(float temp, float soc, float chargeRate){
        return (batteryTempIsOk(temp) && batterySocIsOk(soc) && batteryChargeRateIsOk(chargeRate);
    }
                
    static int Main() {
        ExpectTrue(batteryCondition(temp = 25, soc= 70, chargeRate= 0.7f));
        ExpectTrue(batteryCondition(temp = 50, soc= 85, chargeRate= 0.0f));
        Console.WriteLine("All ok");
        return 0;
    }
    
}
}
