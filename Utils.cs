namespace paradigm_shift_csharp
{
    public static class Utils
    {
        public static bool IsInRange(float value, float min, float max)
        {
            return value >= min && value <= max;
        }
    }
}
