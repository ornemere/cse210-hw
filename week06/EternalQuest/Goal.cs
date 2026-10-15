using System;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    protected Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public string ShortName => _shortName;
    public string Description => _description;
    public int Points => _points;

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description})";
    }

    public static Goal CreateFromString(string line)
    {
        string[] parts = line.Split('|');

        switch (parts[0])
        {
            case "SimpleGoal":
                return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
            case "EternalGoal":
                return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
            case "ChecklistGoal":
                return new ChecklistGoal(
                    parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]),
                    int.Parse(parts[5]), int.Parse(parts[6]));
            default:
                throw new FormatException($"Unknown goal type: {parts[0]}");
        }
    }
}
