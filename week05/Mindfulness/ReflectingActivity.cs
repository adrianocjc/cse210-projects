class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "How did you get started?",
        "What made this time different than other times?",
        "What did you learn about yourself through this experience?"
    };

    public ReflectingActivity() : base("Reflection", "Reflect on times in your life when you showed strength and resilience.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        int duration = Duration;

        Random random = new Random();
        int timeElapsed = 0;

        while (timeElapsed < duration)
        {
            Console.WriteLine(_prompts[random.Next(_prompts.Count)]);
            ShowSpinner(2);

            foreach (var question in _questions)
            {
                Console.WriteLine(question);
                ShowSpinner(2);
                timeElapsed += 2;
                if (timeElapsed >= duration) break;
            }
        }

        DisplayEndingMessage();
    }
}