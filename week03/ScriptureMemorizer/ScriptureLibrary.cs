using System;
using System.Collections.Generic;
using System.IO;

class ScriptureLibrary
{
    private List<Scripture> _scriptures = new List<Scripture>();
    private Random _random = new Random();

    public void LoadFromFile(string filename)
    {
        // Check if file exists
        if (!File.Exists(filename))
        {
            Console.WriteLine("Error: Scripture file not found.");
            return;
        }

        // Read each line, split it, and add scriptures
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 2)
            {
                _scriptures.Add(new Scripture(parts[0], parts[1]));
            }
        }
    }

    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}
