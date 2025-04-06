class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "List as many positive things as you can in a specific area.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        int duration = Duration;

        Random random = new Random();
        Console.WriteLine(_prompts[random.Next(_prompts.Count)]);
        ShowCountDown(3);

        _count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        Console.WriteLine("Start listing items:");

        while (DateTime.Now < endTime)
        {
            Console.Write("Item: ");
            Console.ReadLine();
            _count++;
        }

        Console.WriteLine($"You listed {_count} items.");
        DisplayEndingMessage();
    }
}