    public class Job //creates the Job class
{
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company})\n{_startYear}-{_endYear}");
    }
}