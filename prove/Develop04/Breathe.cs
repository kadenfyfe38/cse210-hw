class Breathe : Activity
{
    //attributes
    private int _durationIn;
    private int _durationHeld;
    private int _durationOut;

    //constructor
    public Breathe(int durationIn, int durationHeld, int durationOut)
    : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        _durationIn = durationIn;
        _durationHeld = durationHeld;
        _durationOut = durationOut;
    }
    //behaviours
    private void BreatheIn(int durationIn) //these respective breathe methods allow for individual changes to each aspect with regard to length of that part of the activity.
    {
        Console.Write("Breathe in...");
        for (int i = durationIn; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); 
        }
    }
    private void Hold(int durationHeld)
    {
        Console.Write($"Hold...");
        for (int i = durationHeld; i > 0;i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    private void BreatheOut(int durationOut)
    {
        Console.Write("Breathe out...");
        for (int i = durationOut; i > 0;i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    private void Countdown(int duration)
    {
        int remaining = duration;
        //logic for a countdown for the acitivty, (Box breathing ie 4in, 4hold, 4out, 4hold) 
        while(remaining >0) //I could have used DateTime here but didnt think about it at first, this was annoying to figure out haha
        {
            BreatheIn(_durationIn);
            remaining -= _durationIn;
            Console.WriteLine();
            if (remaining<= 0)
            {
                break;
            }
            Hold(_durationHeld);
            remaining -= _durationHeld;
            Console.WriteLine();
            if (remaining<= 0)
            {
                break;
            }
            BreatheOut(_durationOut);
            remaining -= _durationOut;
            Console.WriteLine();
            if (remaining<= 0)
            {
                break;
            }
            Hold(_durationHeld);
            remaining -= _durationHeld;
            Console.WriteLine();
        }
    }
    
    public void BreatheActivity() //main method to complete the activity
    {
        DisplayCommonMessage(); //begins with standard starting message and prompt for all activities
        int duration = GetDuration();
        Console.WriteLine();
        Countdown(duration); //Shows series of messages alternating between breathe in, hold and breathe out. 
        //pauses and shows a countdown as well
        Console.WriteLine(""); 
        EndMessage(); //concludes with standard finishing message for all activities
    }

}