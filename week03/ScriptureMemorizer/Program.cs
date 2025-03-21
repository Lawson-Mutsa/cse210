using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        ScriptureLibrary scriptureLibrary = new ScriptureLibrary();
        scriptureLibrary.LoadFromFile("scriptures.txt"); // Load scriptures from file

        Scripture scripture = scriptureLibrary.GetRandomScripture(); // Get a random scripture
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorization Program!");
        Console.Write("Choose difficulty (1 - Easy, 2 - Medium, 3 - Hard): ");
        int difficulty = int.TryParse(Console.ReadLine(), out int level) ? level : 2;

        while (!scripture.IsFullyHidden())
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nPress ENTER to hide words, type 'hint' for help, or 'quit' to exit.");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "quit") break;
            if (input == "hint") scripture.RevealWord();
            else scripture.HideWords(difficulty);
        }

        Console.Clear();
        scripture.Display(); // Final fully hidden scripture
        Console.WriteLine("\nWell done! You memorized the scripture.");
    }
}
