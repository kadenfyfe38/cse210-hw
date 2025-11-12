class Reflection : Activity
{
    //attributes
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    //constructor
    public Reflection()
    :base("Reflection Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") {}
    //behaviours

    
    public void ReflectionActivity() //main method for activity
    {
        DisplayCommonMessage(); //standard starting message & prompt for duration
        int duration = GetDuration();
        Console.WriteLine("Consider the following prompt:\n");
        Console.Write($"  ——— {RandomGenerator(_prompts)} ———\n"); //after starting message select random prompt to show user
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine(); //wait for user to type enter

        Console.WriteLine("Ponder the following questions");
        Timer(5);
        Console.Clear();

        DateTime startTime = DateTime.Now; //time logic to loop code until actual time has passed.
        DateTime endTime = startTime.AddSeconds(duration);
        
        while (DateTime.Now < endTime)
        {
            Display(RandomGenerator(_questions)); //pull questions from list
            Spinner(7); //program pause for several seconds and displays spinner
            Console.WriteLine();
        }
        EndMessage(); //conlcudes with standard finishing message for all activities
    }
}