using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals; // List to store all goals
    private int _score; // Track the user's score
    private int _level; // Track the user's level
    private List<string> _eventHistory; // History of recorded events
    private Dictionary<int, string> _achievements; // Dictionary for achievements

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _eventHistory = new List<string>();
        _achievements = new Dictionary<int, string>
        {
            { 1000, "Bronze Achievement" },
            { 5000, "Silver Achievement" },
            { 10000, "Gold Achievement" }
        };
    }

    public void Start()
    {
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Create Goal");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. View Event History");
            Console.WriteLine("6. Save Goals");
            Console.WriteLine("7. Load Goals");
            Console.WriteLine("8. Quit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    DisplayPlayerInfo();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    CreateGoal();
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    ViewEventHistory();
                    break;
                case "6":
                    SaveGoals();
                    break;
                case "7":
                    LoadGoals();
                    break;
                case "8":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nPlayer Info:");
        Console.WriteLine($"Score: {_score}");
        Console.WriteLine($"Level: {_level}");

        Console.WriteLine("Achievements Earned:");
        foreach (var achievement in _achievements)
        {
            if (_score >= achievement.Key)
            {
                Console.WriteLine($"- {achievement.Value}");
            }
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
        }
        else
        {
            foreach (var goal in _goals)
            {
                Console.WriteLine(goal.GetDetailsString());
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\n1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal\n4. Negative Goal");
        Console.Write("Select Goal Type: ");
        string type = Console.ReadLine();

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Description: ");
        string description = Console.ReadLine();
        Console.Write("Enter Points (negative for negative goals): ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter Target Completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter Bonus Points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                break;
            default:
                Console.WriteLine("Invalid Goal Type.");
                break;
        }
    }

    private void RecordEvent()
    {
        Console.WriteLine("\nSelect a Goal to Record:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Choose a Goal: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal selectedGoal = _goals[index];
            selectedGoal.RecordEvent();
            _score += selectedGoal._points;
            _eventHistory.Add($"Recorded '{selectedGoal._shortName}' on {DateTime.Now}");
            MotivationalQuotes.DisplayRandomQuote();
            UpdateLevel();
        }
        else
        {
            Console.WriteLine("Invalid selection. Please choose a valid goal.");
        }
    }

    private void ViewEventHistory()
    {
        Console.WriteLine("\nEvent History:");
        if (_eventHistory.Count == 0)
        {
            Console.WriteLine("No events recorded yet.");
        }
        else
        {
            foreach (var record in _eventHistory)
            {
                Console.WriteLine(record);
            }
        }
    }

    private void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_level);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }

            writer.WriteLine("EventHistory:");
            foreach (var record in _eventHistory)
            {
                writer.WriteLine(record);
            }
        }

        Console.WriteLine("Goals and Event History Saved Successfully.");
    }

    private void LoadGoals()
    {
        _goals.Clear();
        _eventHistory.Clear();

        string[] lines = File.ReadAllLines("goals.txt");
        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);

        int i = 2;
        while (i < lines.Length && lines[i] != "EventHistory:")
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] details = parts[1].Split(",");

            if (type == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(details[0], details[1], int.Parse(details[2])));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[3]), int.Parse(details[4])));
            }
            else if (type == "NegativeGoal")
            {
                _goals.Add(new NegativeGoal(details[0], details[1], int.Parse(details[2])));
            }
            i++;
        }

        for (int j = i + 1; j < lines.Length; j++)
        {
            _eventHistory.Add(lines[j]);
        }

        Console.WriteLine("Goals and Event History Loaded Successfully.");
    }

    private void UpdateLevel()
    {
        _level = (_score / 1000) + 1;
    }
}