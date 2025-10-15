using System;
using System.Diagnostics;
using System.Threading;

abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;
    private readonly Random _random = new Random();

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected int DurationSeconds => _durationSeconds;
    protected Random Rng => _random;

    public void Run()
    {
        DisplayStartingMessage();
        PerformActivity();        // implemented by derived classes
        DisplayEndingMessage();
    }

    protected void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow many seconds would you like for this session? ");

        int seconds = ReadPositiveInt();
        _durationSeconds = seconds;

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
        Console.Clear();
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done! You have completed the activity.");
        ShowSpinner(2);
        Console.WriteLine($"\nYou have completed the {_name} for {DurationSeconds} seconds.");
        ShowSpinner(3);
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    protected void ShowSpinner(int seconds)
    {
        // simple spinner animation
        char[] frames = { '|', '/', '-', '\\' };
        var sw = Stopwatch.StartNew();
        int i = 0;
        while (sw.Elapsed.TotalSeconds < seconds)
        {
            Console.Write($"\r{frames[i % frames.Length]} ");
            Thread.Sleep(100);
            i++;
        }
        Console.Write("\r   \r");
    }

    protected void ShowCountdown(int seconds, bool withBar = false)
    {
        // optional progress bar (creativity)
        for (int s = seconds; s >= 1; s--)
        {
            if (withBar)
            {
                int width = 20;
                int filled = (int)Math.Round((double)(seconds - s + 1) / seconds * width);
                string bar = new string('█', filled).PadRight(width, '░');
                Console.Write($"\r{bar}  {s} ");
            }
            else
            {
                Console.Write($"\r{s} ");
            }
            Thread.Sleep(1000);
        }
        Console.Write("\r    \r");
    }

    private int ReadPositiveInt()
    {
        while (true)
        {
            string input = (Console.ReadLine() ?? "").Trim();
            if (int.TryParse(input, out int seconds) && seconds > 0)
                return seconds;

            Console.Write("Please enter a valid positive number: ");
        }
    }

    // Each derived activity implements its own behavior here
    protected abstract void PerformActivity();
}
