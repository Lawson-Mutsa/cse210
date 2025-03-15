using System;

class Program
{
    static void ShowMenu()
    {
        Console.WriteLine("Journal App");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display journal");
        Console.WriteLine("3. Save journal to file");
        Console.WriteLine("4. Load journal from file");
        Console.WriteLine("5. Add a custom prompt");
        Console.WriteLine("6. Search journal entries");
        Console.WriteLine("7. Exit");
        Console.Write("Choose an option: ");
    }

    static int GetUserChoice()
    {
        string input = Console.ReadLine();
        return int.TryParse(input, out int choice) ? choice : 0;
    }

    static void Main()
    {
        Journal journal = new Journal();
        bool running = true;
        
        while (running)
        {
            ShowMenu();
            int choice = GetUserChoice();
            
            switch (choice)
            {
                case 1:
                    CreateEntry(journal);
                    break;
                case 2:
                    journal.DisplayEntries();
                    break;
                case 3:
                    SaveJournal(journal);
                    break;
                case 4:
                    LoadJournal(journal);
                    break;
                case 5:
                    AddCustomPrompt(journal);
                    break;
                case 6:
                    SearchJournal(journal);
                    break;
                case 7:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void CreateEntry(Journal journal)
    {
        string prompt = journal.GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        Console.Write("What emotion best describes your day? ");
        string emotion = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        journal.AddEntry(prompt, response, date, emotion); 
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save journal (use .csv extension): ");
        string filename = Console.ReadLine();
        journal.SaveToFileCsv(filename);
        Console.WriteLine("Journal saved as CSV.");
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load journal: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
    }

    static void AddCustomPrompt(Journal journal)
    {
        Console.Write("Enter a new journal prompt: ");
        string newPrompt = Console.ReadLine();
        journal.AddCustomPrompt(newPrompt);
        Console.WriteLine("Custom prompt added successfully.");
    }

    static void SearchJournal(Journal journal)
    {
        Console.Write("Enter a keyword or emotion to search: ");
        string keyword = Console.ReadLine();
        journal.SearchEntries(keyword);
    }
}
