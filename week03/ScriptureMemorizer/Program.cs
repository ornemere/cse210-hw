using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        // Create a sample scripture
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";
        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
            {
                Console.WriteLine("Program ended by user.");
                break;
            }

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden! Great job memorizing!");
                break;
            }
        }
    }
}