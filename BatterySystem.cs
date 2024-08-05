
namespace paradigm_shift_csharp
{
    public class BatterySystem
    {
        private ParameterMonitoring monitorTemperature;
        private ParameterMonitoring monitorSoC;
        private ParameterMonitoring monitorChargeRate;

        
        public BatterySystem(float minTemp, float maxTemp, float temperature, float minSoc, float maxSoc, float soc, float maxChargeRate, float chargeRate)
        {
            monitorTemperature = new ParameterMonitoring("TEMPERATURE", value: temperature, min: minTemp, max: maxTemp, tolerance: maxTemp * 0.05f);
            monitorSoC = new ParameterMonitoring("SOC", value: soc, min: minSoc, max: maxSoc, tolerance: maxSoc * 0.05f);
            monitorChargeRate = new ParameterMonitoring("CHARGE_RATE", value: chargeRate, min: null ,max: maxChargeRate, tolerance: maxChargeRate * 0.05f);
        }

        public bool IsOk()
        {
            return monitorTemperature.IsOk() && monitorSoC.IsOk() && monitorChargeRate.IsOk();
        }

        public string GetStateStatus()
        {
            string status = "Battery status: ";
            status += monitorTemperature.GetStateStatus();
            status += ", ";
            status += monitorSoC.GetStateStatus();
            status += ", ";
            status += monitorChargeRate.GetStateStatus();

            return status;
        }

        public void ConfigureWarning(bool tempratureWarning, bool socWarning, bool chargeRateWarning)
        {
            monitorTemperature.ConfigureWarning(tempratureWarning);
            monitorSoC.ConfigureWarning(socWarning);
            monitorChargeRate.ConfigureWarning(chargeRateWarning);
        }
    }
}
