
using System;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;
        int completedActivities = 0;

        while (choice != 4)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Please enter a valid number.");
                Console.WriteLine();
                continue;
            }

            Activity activity = null;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;

                case 2:
                    activity = new ReflectingActivity();
                    break;

                case 3:
                    activity = new ListingActivity();
                    break;

                case 4:
                    Console.WriteLine();
                    Console.WriteLine(
                        $"You completed {completedActivities} activities this session.");
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Please choose a number from 1 to 4.");
                    break;
            }

            if (activity != null)
            {
                activity.Run();
                completedActivities++;
            }

            Console.WriteLine();
        }
    }
}