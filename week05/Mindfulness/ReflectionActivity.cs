using System;
using System.Collections.Generic;
using System.Diagnostics;

class ReflectionActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(string name, string description) : base(name, description) { }

    protected override void PerformActivity()
    {
        // pick one random prompt
        string prompt = _prompts[Rng.Next(_prompts.Count)];
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($"--- {prompt} ---\n");
        Console.WriteLine("When you have something in mind, press Enter to continue...");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        // Ask random questions without repeating in this session (creativity)
        var sw = Stopwatch.StartNew();
        var shuffled = new List<string>(_questions);
        Shuffle(shuffled);

        int index = 0;
        while (sw.Elapsed.TotalSeconds < DurationSeconds)
        {
            if (index >= shuffled.Count)
            {
                // reshuffle if we run out (allowed by simplifications, but we avoid repeats first)
                Shuffle(shuffled);
                index = 0;
            }

            Console.Write($"> {shuffled[index]}  ");
            ShowSpinner(6); // pause several seconds showing spinner
            Console.WriteLine(); // next line for readability
            index++;
        }
    }

    private void Shuffle(List<string> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Rng.Next(i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }
}
