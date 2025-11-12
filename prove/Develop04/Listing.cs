class Listing : Activity
{
    //attributes
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
    };
    private List<string> _responses = new List<string> {}; //blank last that user responses will fill
    private int _numOfItems;

    //constructor
    public Listing()
    :base("Listing Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _numOfItems = 0;
    }
    
    //behaviours
    public void ListingActivity()
    {
        DisplayCommonMessage(); //begins with starting message
        int duration = GetDuration();
        Console.WriteLine("List as many responses as you can to the following prompt"); //prints task 
        Console.Write($"  ——— {RandomGenerator(_prompts)} ———\n"); //pull random question from list
        Timer(5); // allows time to think
        Console.WriteLine();
        DateTime startTime = DateTime.Now; //time logic to loop code until actual time has passed.
        DateTime endTime = startTime.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Display("");
            string userResponse = Console.ReadLine();
            _responses.Add(userResponse); //adds user response to list of responses
            _numOfItems++; //adds 1 to the counter of items in list
        }
        Console.WriteLine($"You wrote {_numOfItems} items!");
        EndMessage();
    }
    
}