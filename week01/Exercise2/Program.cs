using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int percent = int.Parse(grade);

        string letter = "";
        string sign = "";

        // Determine the grade letter
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign if grade is not F
        if (letter != "F")
        {
            int lastDigit = percent % 10; // Get the last digit of the percentage
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Handle special cases for A and F grades
        if (letter == "A" && sign == "+")
        {
            sign = ""; // No A+ exists
        }
        else if (letter == "F")
        {
            sign = ""; // No F+ or F- exists
        }

        // Display the final grade with sign
        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (percent >= 70)
        {
            Console.WriteLine("You've passed!");
        }
        else
        {
            Console.WriteLine("Sorry, you haven't passed!");
        }
    }
}
