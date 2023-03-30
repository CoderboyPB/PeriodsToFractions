namespace Euklidian;

using PeriodsToFractions;

internal class Program
{
    static void Main(string[] args)
    {
        double number;
        int periodLength;
        bool again = true;

        while (again)
        {
            Console.WriteLine("Periodische Dezimalzahl:");
            Double.TryParse(Console.ReadLine(), out number);
            Console.WriteLine("Periodenlänge:");
            Int32.TryParse(Console.ReadLine(), out periodLength);

            Console.WriteLine(number.ToFraction(periodLength));

            Console.WriteLine();
            Console.WriteLine("Noch einmal? (j/n)");
            again = Console.ReadLine().Equals("j") ? true : false;

            Console.WriteLine();
        }
    }
}
