using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string UserName = PromptUserName();
        int UserNum = PromptUserNumber();
        int birthyear;
        PromptUserBirthYear(out birthyear);
        int SquareNum = SquareNumber(UserNum);
        DisplayResult(UserName, SquareNum, birthyear);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        string PromptUserName = Console.ReadLine();
        return PromptUserName;
    }

    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number? ");
        int UserNum = int.Parse(Console.ReadLine());
        //int UserNum = int.Parse(UserNum);
        return UserNum;
    }

    static void PromptUserBirthYear(out int birthyear)
    {
        Console.Write("What year were you born? ");
        birthyear = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int x)
    {
        int intSquared = x * x;
        return intSquared;
    }

    static void DisplayResult(string userName, int squaredNumber, int userBirthyear)
    {
        Console.Write($"{userName}, the square of your number is {squaredNumber}\n");
        int birthdayAge = 2026 - userBirthyear;
        Console.WriteLine($"{userName}, you will turn {birthdayAge} next year.");
    }
}   