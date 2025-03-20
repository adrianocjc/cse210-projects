using System;

public class Fraction
{
    // Private attributes for the numerator (top) and denominator (bottom)
    private int numerator;
    private int denominator;

    // Constructors
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    public Fraction(int top)
    {
        numerator = top;
        denominator = 1;
    }

    public Fraction(int top, int bottom)
    {
        numerator = top;
        denominator = bottom;
    }

    // Getters and Setters
    public int GetNumerator()
    {
        return numerator;
    }

    public void SetNumerator(int value)
    {
        numerator = value;
    }

    public int GetDenominator()
    {
        return denominator;
    }

    public void SetDenominator(int value)
    {
        denominator = value;
    }

    // Method to return the fractional string representation (e.g., "3/4")
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    // Method to return the decimal value (e.g., 0.75)
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}
