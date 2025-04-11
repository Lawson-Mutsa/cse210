public class SimpleGoal : Goal
{
    private string _name;
    private string _description;
    private int _points;
    private bool _isCompleted;

    public SimpleGoal(string name, string description, int points, bool isCompleted)
    {
        _name = name;
        _description = description;
        _points = points;
        _isCompleted = isCompleted;
    }

    public override int RecordEvent()
    {
        if (!_isCompleted)
        {
            _isCompleted = true;
            return _points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return $"{_name} - {_description} - Completed: {_isCompleted}";
    }

    public override string SaveData()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_isCompleted}";
    }
}
