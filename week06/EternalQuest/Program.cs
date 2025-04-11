using System;

class Program
{
    static void Main(string[] args)
    {
        EternalQuest quest = new EternalQuest();
        string filename = "goal.txt";

        // Load existing data
        quest.LoadFromFile(filename);

        bool running = true;
        while (running)
        {
            Console.WriteLine("");
            Console.WriteLine("1. Add Simple Goal");
            Console.WriteLine("2. Add Eternal Goal");
            Console.WriteLine("3. Add Checklist Goal");
            Console.WriteLine("4. Display Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Display Score");
            Console.WriteLine("7. Save and Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("");
                    Console.Write("Enter goal name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter description: ");
                    string description = Console.ReadLine();
                    Console.Write("Enter points: ");
                    int points = int.Parse(Console.ReadLine());
                    Console.Write("Is the goal completed (true/false): ");
                    bool isCompleted = bool.Parse(Console.ReadLine());
                    quest.AddGoal(new SimpleGoal(name, description, points, isCompleted));
                    break;
                case "2":
                    Console.WriteLine("");
                    Console.Write("Enter goal name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter description: ");
                    description = Console.ReadLine();
                    Console.Write("Enter points: ");
                    points = int.Parse(Console.ReadLine());
                    quest.AddGoal(new EternalGoal(name, description, points));
                    break;
                case "3":
                     Console.WriteLine("");
                    Console.Write("Enter goal name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter description: ");
                    description = Console.ReadLine();
                    Console.Write("Enter points: ");
                    points = int.Parse(Console.ReadLine());
                    Console.Write("Enter number of times to complete: ");
                    int timesToComplete = int.Parse(Console.ReadLine());
                    Console.Write("Enter times already completed: ");
                    int timesCompleted = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus points: ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    quest.AddGoal(new ChecklistGoal(name, description, points, timesToComplete, timesCompleted, bonusPoints));
                    break;
                case "4":
                     Console.WriteLine("");
                    quest.DisplayGoals();
                    break;
                case "5":
                     Console.WriteLine("");
                    Console.Write("Enter goal index to record event: ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    quest.RecordEvent(index);
                    break;
                case "6":
                    Console.WriteLine("");
                    quest.DisplayScore();
                    break;
                case "7":
                    Console.WriteLine("");
                    quest.SaveToFile(filename);
                    running = false;
                    break;
                default:
                     Console.WriteLine("");
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
