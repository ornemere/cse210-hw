using System;
using System.Collections.Generic;
using System.Globalization;

/// <summary>
/// W05 - Mindfulness Program
/// Principles: Inheritance (base Activity + 3 derived), Encapsulation (private fields + public/protected methods), Abstraction.
/// Menu-driven console app with shared start/end messages and animated pauses.
/// 
/// Exceeding requirements (creativity):
/// 1) ReflectionActivity: avoids repeating questions in a session.
/// 2) BreathingActivity: shows a simple progress bar during countdown.
/// 3) ListingActivity: displays total items entered at the end.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1) Breathing Activity");
            Console.WriteLine("2) Reflection Activity");
            Console.WriteLine("3) Listing Activity");
            Console.WriteLine("4) Quit");
            Console.Write("\nChoose an option: ");
            string choice = (Console.ReadLine() ?? "").Trim();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity(
                        "Breathing Activity",
                        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
                    );
                    break;
                case "2":
                    activity = new ReflectionActivity(
                        "Reflection Activity",
                        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
                    );
                    break;
                case "3":
                    activity = new ListingActivity(
                        "Listing Activity",
                        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
                    );
                    break;
                case "4":
                    Console.WriteLine("\nGoodbye! Keep practicing mindfulness. 🌿");
                    return;
                default:
                    Console.WriteLine("\nInvalid option. Press Enter to continue...");
                    Console.ReadLine();
                    continue;
            }

            Console.Clear();
            activity.Run(); // common flow: start message -> activity body -> end message
        }
    }
}
