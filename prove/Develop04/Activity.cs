class Activity
{
    //attributes
    private string _name;
    private string _activityDescription;
    private int _duration;

    //constructor
    public Activity(string name, string activityDescription)
    {
        _name = name;
        _activityDescription = activityDescription;
        _duration = 0;
    }
    //behaviours

    public int DisplayCommonMessage()
    {
        Console.WriteLine($"{_name}:\n\n{_activityDescription}\n");
        Console.WriteLine($"How long (in seconds) would you like to do the {_name} for?\n");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.Write("Get Ready...");
        Spinner(5); //prepares user for activity
        Console.WriteLine();
        return _duration;
    }
    public void EndMessage()
    {
        Console.WriteLine("\nWell Done!\n");
        Spinner(3);
        Console.WriteLine($"You completed a {_name} for {_duration} seconds.\n");
        Spinner(3);
        return;
    }
    public void Spinner(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("/");
            Thread.Sleep(300);
            Console.Write("\b \b");
            Console.Write("—");
            Thread.Sleep(300);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(300);
            Console.Write("\b \b");
        }
    }
    public string RandomGenerator(List<string> prompts)
    {
        Random rand = new Random();
        string randomPrompt = prompts[rand.Next(prompts.Count)];
        return randomPrompt;
    }
    public void Display(string prompt)
    {
        Console.Write($"> {prompt} ");
    }
    public void Timer(int time)
    {
        Console.Write("You may begin in:");
        for (int i = time; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    public string GetName()
    {
        string name = _name;
        return name;
    }
    public string GetActivityDescription()
    {
        return _activityDescription;
    }
    public int GetDuration()
    {
        return _duration;
    }
}