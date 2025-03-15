using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<JournalEntry> entries;
    private List<string> prompts;

    public Journal()
    {
        entries = new List<JournalEntry>();
        prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
    }

    public void AddEntry(string prompt, string response, string date, string emotion)
    {
        JournalEntry newEntry = new JournalEntry(prompt, response, date, emotion);
        entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.");
            return;
        }

        foreach (var entry in entries)
        {
            Console.WriteLine(entry.ToStringEntry());
        }
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }

    public void SaveToFileCsv(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                sw.WriteLine($"\"{entry.Date}\",\"{entry.Prompt}\",\"{entry.Response}\",\"{entry.Emotion}\"");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        entries.Clear();
        using (StreamReader sr = new StreamReader(filename))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var parts = line.Split('|');
                if (parts.Length == 4)
                {
                    string date = parts[0].Trim();
                    string prompt = parts[1].Trim();
                    string response = parts[2].Trim();
                    string emotion = parts[3].Trim();

                    AddEntry(prompt, response, date, emotion);
                }
            }
        }
    }

    public void AddCustomPrompt(string newPrompt)
    {
        prompts.Add(newPrompt);
    }

    public void SearchEntries(string keyword)
    {
        foreach (var entry in entries)
        {
            if (entry.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase) || entry.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(entry.ToStringEntry());
            }
        }
    }
}
