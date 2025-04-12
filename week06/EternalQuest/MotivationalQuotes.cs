using System;
using System.Collections.Generic;

public static class MotivationalQuotes
{
    private static readonly List<string> _quotes = new List<string>
    {
        "Keep going! You're doing great.",
        "Every step forward is progress!",
        "Consistency is key to success.",
        "Small steps lead to big victories.",
        "Believe in yourself—you've got this!"
    };

    public static void DisplayRandomQuote()
    {
        Random rand = new Random();
        int index = rand.Next(_quotes.Count);
        Console.WriteLine($"\nMotivational Quote: {_quotes[index]}");
    }
}