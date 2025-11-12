using System;

class Program
{
    static void Main(string[] args)
    {
        Menu();
    }
    static void Menu() // this does work so far but is this the best place for a menu? Where else could it logically be put?
    {
        Console.Clear();
            while (true)
            {   
                Console.Clear();
                Console.WriteLine("Welcome to the Menu\nChoose from the following:\n");
                Console.WriteLine("[1] Breathing Activity\n[2] Listing Activity\n[3] Reflection Activity\n[0] Exit Program");
                string userChoice = Console.ReadLine();
                int userChoiceInt = int.Parse(userChoice);
                switch (userChoiceInt)
                {
                case 0:
                    return;
                case 1:
                    //breathe activity
                    Breathe breathe = new Breathe(4, 4, 4); //444box breathing, change duration of each by adjusting here
                    breathe.BreatheActivity();
                    break;
                case 2:
                    //List activity()
                    Listing listing = new Listing();
                    listing.ListingActivity();
                    break;
                case 3:
                    //reflection activity()
                    Reflection reflection = new Reflection();
                    reflection.ReflectionActivity();
                    break;
                default: //if user does anything else
                    break;
            }
        }
    }
}
