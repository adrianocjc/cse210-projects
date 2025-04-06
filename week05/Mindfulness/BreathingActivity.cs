class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding you through deep breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        int duration = Duration;

        for (int i = 0; i < duration / 2; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(3);
            Console.WriteLine("Breathe out...");
            ShowCountDown(3);
        }

        DisplayEndingMessage();
    }
}