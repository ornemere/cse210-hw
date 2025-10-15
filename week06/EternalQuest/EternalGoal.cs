class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent() { /* adds points, never completes */ }
    public override bool IsComplete() => false;
}
