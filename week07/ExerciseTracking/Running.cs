using System;

class Running : Activity
{
    private double distance;

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;
    public override double GetSpeed() => (distance / Minutes) * 60;
    public override double GetPace() => Minutes / distance;

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Running - Distance: {GetDistance()} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}