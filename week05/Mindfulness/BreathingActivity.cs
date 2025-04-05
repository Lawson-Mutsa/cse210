using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "This activity will help you relax by walking you through breathing in and out slowly.\n Clear your mind and focus on your breathing.",
        "Good job! You completed the breathing activity."
    ) {}

    public void PerformBreathing()
    {
        Start();

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Clear();
            Console.WriteLine("Breathe in...");
            Pause(4);

            Console.Clear();
            Console.WriteLine("Breathe out...");
            Pause(4);
        }

        Finish();
    }
}
