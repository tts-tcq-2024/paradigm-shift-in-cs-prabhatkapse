
namespace paradigm_shift_csharp
{

    public class ParameterMonitoring
    {
        private string name;
        private float value;
        private float? min; // Changed to nullable float
        private float max;
        private float tolerance;
        private bool warning = true;

        private readonly Dictionary<(float, float), string> stateList;

        public ParameterMonitoring(string name, float value, float? min, float max, float tolerance)
        {
            this.name = name;
            this.value = value;
            this.min = min;
            this.max = max;
            this.tolerance = tolerance;

            stateList = new Dictionary<(float, float), string>();

            if (min.HasValue)
            {
                stateList.Add((-100, min.Value), $"LOW_{name}_BREACH");
                stateList.Add((min.Value + 0.01f, min.Value + tolerance), $"LOW_{name}_WARNING");
            }

            stateList.Add((min.HasValue ? min.Value + tolerance + 0.01f : -100, max - tolerance), $"NORMAL_{name}_STATE");
            stateList.Add((max - tolerance + 0.01f, max), $"HIGH_{name}_WARNING");
            stateList.Add((max + 0.01f, 100), $"HIGH_{name}_BREACH");
        }

        public bool IsOk()
        {
            return Utils.IsInRange(value, min.HasValue ? min.Value + tolerance + 0.01f : -100, max - tolerance);
        }

        public string GetStateStatus()
        {
            foreach (var temp in stateList)
            {
                if (Utils.IsInRange(value, temp.Key.Item1, temp.Key.Item2))
                {
                    if (!warning && (temp.Value.Contains("WARNING")))
                    {
                        continue;
                    }
                }
                return temp.Value;
            }
            return "INVALID";
        }

        public void ConfigureWarning(bool input)
        {
            warning = input;
        }  
        
        public bool GetWarning()
        {
            return warning;
        }

    }
}
