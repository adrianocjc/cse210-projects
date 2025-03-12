using System;
using System.Collections.Generic;

public class Resume
{
    public string _name { get; set; }
    public List<Job> _jobs { get; set; } = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (var job in _jobs)
        {
            job.Display();
        }
    }
}
