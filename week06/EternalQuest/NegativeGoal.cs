public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) : base(name, description, points)
    {
        if (points > 0)
        {
            _points = -points; // Ensure points are negative
        }
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Negative goal '{_shortName}' recorded! You lost {-_points} points.");
    }

    public override bool IsComplete()
    {
        return false; // Negative goals don't "complete"
    }

    public override string GetDetailsString()
    {
        return $"[!] {_shortName} - {_description} (Lose {-_points} points)";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName},{_description},{_points}";
    }
}