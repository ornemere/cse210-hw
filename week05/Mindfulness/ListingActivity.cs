using System;
using System.Collections.Generic;
using System.Diagnostics;

class ListingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(string name, string description) : base(name, description) { }

    protected override void PerformActivity()
    {
        string prompt = _prompts[Rng.Next(_prompts.Count)];
        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        Console.WriteLine($"--- {prompt} ---\n");

        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        var sw = Stopwatch.StartNew();
        var items = new List<string>();

        Console.WriteLine("Start listing (press Enter after each item). Time is running...");
        while (sw.Elapsed.TotalSeconds < DurationSeconds)
        {
            // We check time between inputs; if time is up, we stop gracefully
            if (Console.KeyAvailable)
            {
                // If the user pressed Enter quickly, still read the line
                string item = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(item.Trim());
                }
            }
            else
            {
                // small sleep to avoid busy-waiting
                System.Threading.Thread.Sleep(50);
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items. Great job!");
        // (Optional) echo the list:
        // foreach (var s in items) Console.WriteLine($" - {s}");
    }
}
