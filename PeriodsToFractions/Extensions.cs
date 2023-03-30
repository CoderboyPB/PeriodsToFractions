namespace PeriodsToFractions;
public static class Extensions
{
    public static string ToFraction(this double number, int periodLength = 0)
    {
        if(number >= 1)
        {
            throw new ArgumentException("Decimal number has to be smaller than 1!");
        }

        int zaehler;
        int nenner;

        int numberOfDecimalPlaces = number.ToString().Split(",")[1].Length;

        if (periodLength > 0)
        {
            numberOfDecimalPlaces = number.ToString().Split(",")[1].Length;
            int factorA = (int)Math.Pow(10, Convert.ToDouble(numberOfDecimalPlaces));
            int factorB = (int)Math.Pow(10, Convert.ToDouble(numberOfDecimalPlaces - periodLength));

            zaehler = (int)(number * Math.Pow(10, numberOfDecimalPlaces) - cutDecimals(number, numberOfDecimalPlaces - periodLength) * Math.Pow(10, numberOfDecimalPlaces - periodLength));
            nenner = factorA - factorB;
        }
        else
        {
            zaehler = (int)(number * Math.Pow(10, numberOfDecimalPlaces));
            nenner = (int)Math.Pow(10, numberOfDecimalPlaces);
        }

        int ggt = ggT(zaehler, nenner);

        // shorten fracture
        zaehler /= ggt;
        nenner /= ggt;

        return $"{zaehler}/{nenner}";
    }

    private static int ggT(int a, int b) => (b == 0) ? a : ggT(b, a % b);

    // Helper function to cut of decimals WITHOUT rounding
    private static double cutDecimals(double number, int v)
    {
        (string, string) parts = (Math.Truncate(number).ToString(), number.ToString().Split(",")[1].Substring(0, v));
        string strDecimal = $"{parts.Item1},{parts.Item2}";
        return Double.Parse(strDecimal);
    }
}
