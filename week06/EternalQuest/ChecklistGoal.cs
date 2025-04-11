public class ChecklistGoal : Goal
{
    private string _name;
    private string _description;
    private int _points;
    private int _timesToComplete;
    private int _timesCompleted;
    private int _bonusPoints;

    // Constructor matching the data format in the file
    public ChecklistGoal(string name, string description, int points, int timesToComplete, int timesCompleted, int bonusPoints)
    {
        _name = name;
        _description = description;
        _points = points;
        _timesToComplete = timesToComplete;
        _timesCompleted = timesCompleted;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        _timesCompleted++;
        int pointsEarned = _points;

        // Add bonus points when the goal is fully completed
        if (_timesCompleted >= _timesToComplete)
        {
            pointsEarned += _bonusPoints;
        }

        return pointsEarned;
    }

    public override string GetStatus()
    {
        return $"{_name} ({_description}) - Completed: {_timesCompleted}/{_timesToComplete}";
    }

    public override string SaveData()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_timesToComplete}|{_timesCompleted}|{_bonusPoints}";
    }
}
