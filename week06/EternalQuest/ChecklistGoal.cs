class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _completedCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _completedCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent() { /* increase count, add bonus if done */ }
    public override bool IsComplete() => _completedCount >= _targetCount;

    public override string GetDetailsString()
        => $"{_name} ({_description}) -- Progress: {_completedCount}/{_targetCount}";
}
