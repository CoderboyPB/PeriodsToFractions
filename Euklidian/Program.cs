namespace Euklidian;

internal class Program
{
    static void Main(string[] args)
    {
        double number;
        int periodLength;
        bool again = true;

        while (again)
        {
            Console.WriteLine("Gebe periodische Dezimalzahl, beginnend mit 0 ein");
            Console.WriteLine("Beispiel: 0, Komma Periode 3: 0,3");
            Double.TryParse(Console.ReadLine(), out number);
            Console.WriteLine("Periodenlänge:");
            Console.WriteLine("Beispiel: 0,Komma 2 Periode 7 1 = 2");
            Int32.TryParse(Console.ReadLine(), out periodLength);

            calculateFraction(number, periodLength, out int numerator, out int denumerator);

            Console.WriteLine($"{numerator}/{denumerator}");

            Console.WriteLine("Again (y/n)");
            again = Console.ReadLine().Equals("y") ? true : false;
        }
    }

    private static void calculateFraction(double number, int periodLength, out int numerator, out int denumerator)
    {
        int numberOfDecimalPlaces = number.ToString().Split(",")[1].Length;
        int factorA = (int)Math.Pow(10, Convert.ToDouble(numberOfDecimalPlaces));
        int factorB = (int)Math.Pow(10, Convert.ToDouble(numberOfDecimalPlaces - periodLength));

        numerator = (int)(number * Math.Pow(10, numberOfDecimalPlaces) - cutDecimals(number, numberOfDecimalPlaces - periodLength) * Math.Pow(10,numberOfDecimalPlaces - periodLength));
        denumerator = factorA - factorB;

        int ggt = ggT(numerator, denumerator);

        numerator /= ggt;
        denumerator /= ggt;
    }

    private static double cutDecimals(double number, int v)
    {
        (string, string) parts = (Math.Truncate(number).ToString(), number.ToString().Split(",")[1].Substring(0, v));
        string strDecimal = $"{parts.Item1},{parts.Item2}";
        return Double.Parse(strDecimal);
    }

    static int ggT(int a, int b) => (b == 0) ? a : ggT(b, a % b);
}
