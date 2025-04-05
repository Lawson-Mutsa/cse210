using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness App!");
        
        while (true)
        {
            Console.WriteLine("\nSelect an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.PerformBreathing();
            }
            else if (choice == "2")
            {
                ReflectionActivity reflection = new ReflectionActivity();
                reflection.AskReflectionQuestions();
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.PromptListing();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid selection, please try again.");
            }
        }
    }
}
