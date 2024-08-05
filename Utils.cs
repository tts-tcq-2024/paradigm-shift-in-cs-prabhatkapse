namespace paradigm_shift_csharp
{
    public static class Utils
    {
        public static bool IsInRange(float value, float min, float max)
        {
            return value >= min && value <= max;
        }

        public static void ExpectTrue(bool expression)
        {
            if (!expression)
            {
                Console.WriteLine("Expected true, but got false");
            }
        }
        public static void ExpectFalse(bool expression)
        {
            if (expression)
            {
                Console.WriteLine("Expected false, but got true");
            }
        }

        public static void StatusCompare(string actualString, string expectedString)
        {
            if (String.Equals(actualString, expectedString))
                Console.WriteLine($"Battery Status is as expected");
            else
                Console.WriteLine($"Battery Status is not as expected: {actualString}");
        }
    }


}
