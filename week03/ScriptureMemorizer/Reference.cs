using System;

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; }

    public Reference(string reference)
    {
        // Split the reference into "Book" and "Chapter:Verse"
        string[] parts = reference.Split(' ');

        // First part is always the Book name
        Book = parts[0];

        // Split Chapter and Verse
        string[] chapterVerse = parts[1].Split(':');
        Chapter = int.Parse(chapterVerse[0]); // Chapter number

        // Check if there's a verse range (e.g., "5-6")
        string[] verses = chapterVerse[1].Split('-');
        StartVerse = int.Parse(verses[0]);
        
        if (verses.Length > 1)
        {
            EndVerse = int.Parse(verses[1]); // Handle verse ranges
        }
        else
        {
            EndVerse = null; // Single verse only
        }
    }

    public override string ToString()
    {
        if (EndVerse.HasValue)
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        else
            return $"{Book} {Chapter}:{StartVerse}";
    }
}
