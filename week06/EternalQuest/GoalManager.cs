using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int Score => _score;
    public IReadOnlyList<Goal> Goals => _goals.AsReadOnly();

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public int RecordEvent(int index)
    {
        int pointsEarned = _goals[index].RecordEvent();
        _score += pointsEarned;
        return pointsEarned;
    }

    public void Save(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Score|{_score}");
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void Load(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0 || !lines[0].StartsWith("Score|"))
        {
            throw new FormatException("The save file does not have a valid score line.");
        }

        int loadedScore = int.Parse(lines[0].Split('|')[1]);
        List<Goal> loadedGoals = new List<Goal>();

        for (int i = 1; i < lines.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(lines[i]))
            {
                loadedGoals.Add(Goal.CreateFromString(lines[i]));
            }
        }

        _score = loadedScore;
        _goals = loadedGoals;
    }
}
