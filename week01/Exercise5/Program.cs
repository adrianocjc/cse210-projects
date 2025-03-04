using System;

class MyApp
{
    static void Main(string[] args)
    {
        ShowWelcomeMessage();

        string personName = GetUserName();
        int favoriteNumber = GetUserNumber();

        int squaredValue = CalculateSquare(favoriteNumber);

        ShowResult(personName, squaredValue);
    }

    static void ShowWelcomeMessage()
    {
        Console.WriteLine("Hello! Welcome to the program!");
    }

    static string GetUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();

        return userName;
    }

    static int GetUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int chosenNumber = int.Parse(Console.ReadLine());

        return chosenNumber;
    }

    static int CalculateSquare(int numberToSquare)
    {
        int result = numberToSquare * numberToSquare;
        
        return result;
    }

    static void ShowResult(string personName, int squaredNumber)
    {
        Console.WriteLine($"{personName}, the square of your favorite number is {squaredNumber}!");
    }
}
