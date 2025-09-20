using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string ValueFromUser = Console.ReadLine();

        int NumGrade = int.Parse(ValueFromUser);
        string letter = "";


        if (NumGrade >= 90)
        {
            letter = "A";
        }

        else if (NumGrade >= 80)
        {
            letter = "B";
        }

        else if (NumGrade >= 70)
        {
            letter = "C";
        }

        else if (NumGrade >= 60)
        {
            letter = "D";
        }

        else //(NumGrade < 60)
        {
            letter = "F";
        }

        if (NumGrade >= 70)
        {
            Console.WriteLine($"Congrats! You passed with a grade of {NumGrade}!");
        }

        else
        {
            Console.WriteLine("You'll get 'em next time.");
        }

        Console.WriteLine($"Your grade is: {letter}");
    }
}