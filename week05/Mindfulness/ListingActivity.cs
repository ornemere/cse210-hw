
using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _random;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public override void Run()
    {
        StartActivity();

        int promptIndex = _random.Next(_prompts.Count);

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {_prompts[promptIndex]} ---");

        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.WriteLine("Start listing items. Press Enter after each one.");

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();

            if (item == null)
            {
                break;
            }

            if (DateTime.Now <= endTime && !string.IsNullOrWhiteSpace(item))
            {
                count++;
            }
        }

        Console.WriteLine($"You listed {count} items.");
        EndActivity();
    }
}