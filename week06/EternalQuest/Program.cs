using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool keepRunning = true;
        string filename = "goals.txt";

        while (keepRunning)
        {
            Console.WriteLine();
            Console.WriteLine("=== Eternal Quest ===");
            Console.WriteLine($"Current score: {manager.Score}");

            // Creativity: the player gains a new level for every 1,000 points.
            // This adds a simple game-like reward to encourage continued progress.
            int level = (manager.Score / 1000) + 1;
            Console.WriteLine($"Quest level: {level}");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record goal event");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    ListGoals(manager);
                    break;
                case "3":
                    RecordGoal(manager);
                    break;
                case "4":
                    try
                    {
                        manager.Save(filename);
                        Console.WriteLine($"Goals saved to {filename}.");
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Could not save the file: {ex.Message}");
                    }
                    break;
                case "5":
                    try
                    {
                        manager.Load(filename);
                        Console.WriteLine($"Goals loaded from {filename}.");
                    }
                    catch (Exception ex) when (ex is IOException || ex is FormatException || ex is IndexOutOfRangeException)
                    {
                        Console.WriteLine($"Could not load the file: {ex.Message}");
                    }
                    break;
                case "6":
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Please choose a number from 1 to 6.");
                    break;
            }
        }

        Console.WriteLine("Good luck with your Eternal Quest!");
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine();
        Console.WriteLine("Choose a goal type:");
        Console.WriteLine("1. Simple goal");
        Console.WriteLine("2. Eternal goal");
        Console.WriteLine("3. Checklist goal");
        Console.Write("Type: ");
        string type = Console.ReadLine() ?? "";

        if (type != "1" && type != "2" && type != "3")
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("Goal name: ");
        string name = Console.ReadLine() ?? "Unnamed goal";
        Console.Write("Description: ");
        string description = Console.ReadLine() ?? "No description";
        int points = ReadNumber("Points awarded for each completion: ", 0);

        Goal goal;
        if (type == "1")
        {
            goal = new SimpleGoal(name, description, points);
        }
        else if (type == "2")
        {
            goal = new EternalGoal(name, description, points);
        }
        else
        {
            int target = ReadNumber("How many times must it be completed? ", 1);
            int bonus = ReadNumber("Bonus points for finishing: ", 0);
            goal = new ChecklistGoal(name, description, points, target, bonus);
        }

        manager.AddGoal(goal);
        Console.WriteLine("Goal created successfully.");
    }

    static void ListGoals(GoalManager manager)
    {
        Console.WriteLine();
        Console.WriteLine("Your goals:");
        if (manager.Goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create one first.");
            return;
        }

        for (int i = 0; i < manager.Goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {manager.Goals[i].GetDetailsString()}");
        }
    }

    static void RecordGoal(GoalManager manager)
    {
        if (manager.Goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record yet.");
            return;
        }

        ListGoals(manager);
        int number = ReadNumber("Which goal did you accomplish? Enter its number: ", 1);
        if (number > manager.Goals.Count)
        {
            Console.WriteLine("That goal number does not exist.");
            return;
        }

        int earned = manager.RecordEvent(number - 1);
        Console.WriteLine($"You earned {earned} points.");
        Console.WriteLine($"Your total score is now {manager.Score}.");
    }

    static int ReadNumber(string prompt, int minimum)
    {
        while (true)
        {
            Console.Write(prompt);
            string answer = Console.ReadLine() ?? "";
            if (int.TryParse(answer, out int number) && number >= minimum)
            {
                return number;
            }

            Console.WriteLine($"Please enter a whole number of at least {minimum}.");
        }
    }
}
