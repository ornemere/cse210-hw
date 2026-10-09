
using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        StartActivity();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountDown(3);

            if (DateTime.Now < endTime)
            {
                Console.Write("Breathe out...");
                ShowCountDown(3);
            }
        }

        EndActivity();
    }
}