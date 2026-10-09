
using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private Random _random;

    public ReflectingActivity()
        : base(
            "Reflecting Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience?",
            "What did you learn about yourself?",
            "How can you remember this experience in the future?"
        };
    }

    public override void Run()
    {
        StartActivity();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        int promptIndex = _random.Next(_prompts.Count);
        Console.WriteLine($"--- {_prompts[promptIndex]} ---");

        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter.");
        Console.ReadLine();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            int questionIndex = _random.Next(_questions.Count);

            Console.WriteLine();
            Console.WriteLine(_questions[questionIndex]);
            ShowSpinner(5);
        }

        EndActivity();
    }
}