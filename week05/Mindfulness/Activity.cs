using System;
using System.Threading;

public abstract class Activity
{
    protected string startMessage;
    protected string endMessage;
    protected int duration;

    public Activity(string startMessage, string endMessage)
    {
        this.startMessage = startMessage;
        this.endMessage = endMessage;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine(startMessage);
        Console.WriteLine("Please enter the duration in seconds:");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Pause(3);
    }

    public void Finish()
    {
        Console.WriteLine($"Good job! You completed the activity for {duration} seconds.");
        Pause(2);
    }

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Clear();
            Console.WriteLine($"Pausing... {i} seconds left.");
            Thread.Sleep(1000);
        }
    }
}
