public class EternalGoal : Goal
{
    private string _name;
    private string _description;
    private int _points;

    public EternalGoal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public override int RecordEvent()
    {
        return _points; // Eternal goals always give points when recorded
    }

    public override string GetStatus()
    {
        return $"{_name} - {_description} - No completion (Eternal)";
    }

    public override string SaveData()
    {
        return $"EternalGoal|{_name}|{_description}|{_points}";
    }
}
