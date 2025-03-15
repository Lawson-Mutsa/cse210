using System;

public class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string Emotion { get; set; }

    public JournalEntry(string prompt, string response, string date, string emotion = "Neutral")
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        Emotion = emotion;
    }

    public string ToStringEntry()
    {
        return $"{Date} | {Prompt} | {Response} | Emotion: {Emotion}";
    }
}
