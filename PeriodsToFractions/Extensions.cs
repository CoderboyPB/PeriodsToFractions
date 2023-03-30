namespace PeriodsToFractions;
public static class Extensions
{
    public static string ToFraction(this double number, int periodLength)
    {
        int numberOfDecimalPlaces = number.ToString().Split(",")[1].Length;
        int factorA = (int)Math.Pow(10, Convert.ToDouble(numberOfDecimalPlaces));
        int factorB = (int)Math.Pow(10, Convert.ToDouble(numberOfDecimalPlaces - periodLength));

        int numerator = (int)(number * Math.Pow(10, numberOfDecimalPlaces) - cutDecimals(number, numberOfDecimalPlaces - periodLength) * Math.Pow(10, numberOfDecimalPlaces - periodLength));
        int denumerator = factorA - factorB;

        int ggt = ggT(numerator, denumerator);

        numerator /= ggt;
        denumerator /= ggt;

        return $"{numerator}/{denumerator}";
    }

    private static int ggT(int a, int b) => (b == 0) ? a : ggT(b, a % b);

    private static double cutDecimals(double number, int v)
    {
        (string, string) parts = (Math.Truncate(number).ToString(), number.ToString().Split(",")[1].Substring(0, v));
        string strDecimal = $"{parts.Item1},{parts.Item2}";
        return Double.Parse(strDecimal);
    }
}
