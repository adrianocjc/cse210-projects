using System;

class Program
{
    static void Main(string[] args)
    {
        // Testing constructors
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(6);
        Fraction fraction3 = new Fraction(3, 4);

        // Display outputs
        Console.WriteLine(fraction1.GetFractionString()); // Output: "1/1"
        Console.WriteLine(fraction1.GetDecimalValue());  // Output: 1.0

        Console.WriteLine(fraction2.GetFractionString()); // Output: "6/1"
        Console.WriteLine(fraction2.GetDecimalValue());  // Output: 6.0

        Console.WriteLine(fraction3.GetFractionString()); // Output: "3/4"
        Console.WriteLine(fraction3.GetDecimalValue());  // Output: 0.75

        // Using setters and getters
        fraction3.SetNumerator(1);
        fraction3.SetDenominator(3);
        Console.WriteLine(fraction3.GetFractionString()); // Output: "1/3"
        Console.WriteLine(fraction3.GetDecimalValue());  // Output: 0.3333333333333333
    }
}
