using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What is your favorite thing about this experience?",
        "What did you learn about yourself through this experience?"
    };

    public ReflectionActivity() : base(
        "This activity will help you reflect on times in your life when you have shown strength and resilience\n.This will help you recognize the power you have and how you can use it in other aspects of your life.",
        "Good job! You completed the reflection activity."
    ) {}

    public void AskReflectionQuestions()
    {
        Start();

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        Random rand = new Random();
        string selectedPrompt = prompts[rand.Next(prompts.Count)];
        Console.Clear();
        Console.WriteLine(selectedPrompt);

        Pause(3);

        while (DateTime.Now < endTime)
        {
            string selectedQuestion = questions[rand.Next(questions.Count)];
            Console.Clear();
            Console.WriteLine(selectedQuestion);
            Pause(5);
        }

        Finish();
    }
}
