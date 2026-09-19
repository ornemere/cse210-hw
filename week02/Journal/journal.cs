using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }
    public void DisplayAll()
    {
        Console.WriteLine($"Entries saved: {_entries.Count}");

        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"Date: {entry._date} - {entry._prompt}");
            Console.WriteLine($"Response: {entry._response}");
            Console.WriteLine();
        }
        Console.WriteLine($"You have {_entries.Count} journal entries.");
        
        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {   
                outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }
    }
    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            _entries.Clear();

            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split("|");

                Entry entry = new Entry();

                entry._date = parts[0];
                entry._prompt = parts[1];
                entry._response = parts[2];

                _entries.Add(entry);
            }

            Console.WriteLine("Journal loaded!");
        }
        else
        {
            Console.WriteLine("No journal file found.");
        }
    }
}