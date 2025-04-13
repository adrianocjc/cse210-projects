using System;

class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetDistance() => (speed * Minutes) / 60;
    public override double GetSpeed() => speed;
    public override double GetPace() => 60 / speed;

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Cycling - Speed: {GetSpeed():0.0} mph, Distance: {GetDistance():0.0} miles, Pace: {GetPace():0.0} min per mile";
    }
}