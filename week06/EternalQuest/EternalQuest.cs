using System;
using System.Collections.Generic;
using System.IO;

public class EternalQuest
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void RecordEvent(int index)
    {
        int points = _goals[index].RecordEvent();
        _score += points;
        Console.WriteLine($"You earned {points} points!");
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    public void DisplayScore() => Console.WriteLine($"Total Score: {_score}");

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.SaveData());
            }
        }
    }
   public void LoadFromFile(string filename)
{
    if (!File.Exists(filename))
    {
        Console.WriteLine("Save file not found.");
        return;
    }

    _goals.Clear();
    string[] lines = File.ReadAllLines(filename);
    
    // Validate that there is at least one line for the score
    if (lines.Length < 1)
    {
        Console.WriteLine("Invalid file format. No score data found.");
        return;
    }

    // Try to parse the score, handle potential errors
    try
    {
        _score = int.Parse(lines[0]);
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid score format in file.");
        return;
    }

    // Start reading the goals from the second line onward
    for (int i = 1; i < lines.Length; i++)
    {
        string line = lines[i];
        string[] parts = line.Split('|');

        // Ensure that the data has at least the minimum required fields
        if (parts.Length < 4)
        {
            Console.WriteLine($"Invalid data format at line {i + 1}. Skipping.");
            continue;
        }

        string type = parts[0];

        if (type == "SimpleGoal")
        {
            // Ensure enough data for SimpleGoal
            if (parts.Length != 5)
            {
                Console.WriteLine($"Invalid data format for SimpleGoal at line {i + 1}. Skipping.");
                continue;
            }
            _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
        }
        else if (type == "EternalGoal")
        {
            // Ensure enough data for EternalGoal
            if (parts.Length != 4)
            {
                Console.WriteLine($"Invalid data format for EternalGoal at line {i + 1}. Skipping.");
                continue;
            }
            _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
        }
        else if (type == "ChecklistGoal")
        {
            // Ensure enough data for ChecklistGoal
            if (parts.Length != 7)
            {
                Console.WriteLine($"Invalid data format for ChecklistGoal at line {i + 1}. Skipping.");
                continue;
            }
            _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
        }
        else
        {
            Console.WriteLine($"Unknown goal type at line {i + 1}. Skipping.");
        }
    }
}

}
