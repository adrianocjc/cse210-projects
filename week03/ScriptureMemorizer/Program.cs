using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        Random random = new Random();

        while (true)
        {
            Console.Clear();
            scripture.Display();
            
            if (scripture.AreAllWordsHidden())
            {
                Console.WriteLine("All words are hidden. Great job!");
                break;
            }

            Console.WriteLine("Press Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(random);
        }
    }
}
