using System;
Journal journal = new Journal();

string choice = "";
// Creative feature: the journal displays the total number of entries.
while (choice != "5")
{
    Console.WriteLine();
    Console.WriteLine("Please select one of the following choices:");
    Console.WriteLine("1. Write");
    Console.WriteLine("2. Display");
    Console.WriteLine("3. Load");
    Console.WriteLine("4. Save");
    Console.WriteLine("5. Quit");

    Console.Write("What would you like to do? ");
    choice = Console.ReadLine();

    if (choice == "1")
    {
        Entry entry = new Entry();

        entry._date = DateTime.Now.ToShortDateString();

        PromptGenerator promptGenerator = new PromptGenerator();
        entry._prompt = promptGenerator.GetRandomPrompt();

        Console.WriteLine(entry._prompt);

        Console.Write("Write your response: ");
        entry._response = Console.ReadLine();

        journal.AddEntry(entry);

        Console.WriteLine("Entry saved!");
    }

    if (choice == "2")
    {
        Console.WriteLine("Entering Display...");
        journal.DisplayAll();
        Console.WriteLine("Finished Display.");
    }

    if (choice == "3")
    {
        journal.LoadFromFile("journal.txt");
        Console.WriteLine("Journal loaded!");
    }

    if (choice == "4")
    {
        journal.SaveToFile("journal.txt");
        Console.WriteLine("Journal saved!");
    }
}
