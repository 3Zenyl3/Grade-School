public class GradeSchool
{
    public Dictionary<int, List<string>> _Grade = new Dictionary<int, List<string>>();
    public bool Add(string student, int grade)
    {
        if (_Grade.Values.Any(list => list.Contains(student))) 
        {
            return false;
        }
        if (!_Grade.ContainsKey(grade))
        {
            _Grade[grade] = new List<string>();
        }
        _Grade[grade].Add(student);
        _Grade[grade].Sort();
        return true;
    }

    public IEnumerable<string> Roster()
    {
        return _Grade.OrderBy(pair => pair.Key).SelectMany(pair=>pair.Value);
    }

    public IEnumerable<string> Grade(int grade)
    {
        if (_Grade.ContainsKey(grade))
        {
            return _Grade[grade];
        }
        return new List<string>();
    }
}
