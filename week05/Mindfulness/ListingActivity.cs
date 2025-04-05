using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?"
    };

    public ListingActivity() : base(
        "This activity will help you reflect on the good things in your life by having\n you list as many things as you can in a certain area.",
        "Good job! You completed the listing activity."
    ) {}

    public void PromptListing()
    {
        Start();

        Random rand = new Random();
        string selectedPrompt = prompts[rand.Next(prompts.Count)];
        Console.Clear();
        Console.WriteLine(selectedPrompt);

        Pause(3);

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Clear();
            Console.WriteLine("Please enter an item (or type 'done' to finish):");
            string item = Console.ReadLine();
            if (item.ToLower() == "done")
            {
                break;
            }
            items.Add(item);
        }

        Console.Clear();
        Console.WriteLine($"You listed {items.Count} items.");
        Finish();
    }
}
