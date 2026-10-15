public class ChecklistGoal : Goal
{
    private int _target;
    private int _bonus;
    private int _amountCompleted;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
        : base(shortName, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus, int amountCompleted)
        : base(shortName, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _amountCompleted++;
        if (IsComplete())
        {
            return Points + _bonus;
        }

        return Points;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} — Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{ShortName}|{Description}|{Points}|{_target}|{_bonus}|{_amountCompleted}";
    }
}
