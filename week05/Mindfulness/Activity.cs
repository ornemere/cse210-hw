
using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    protected int Duration
    {
        get { return _duration; }
    }

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    protected void StartActivity()
    {
        Console.WriteLine();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();

        while (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a positive number: ");
            input = Console.ReadLine();
        }

        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    protected void EndActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Good job!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        char[] symbols = { '|', '/', '-', '\\' };

        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(symbols[i % symbols.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }

        Console.WriteLine();
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

        Console.WriteLine();
    }

    public abstract void Run();
}