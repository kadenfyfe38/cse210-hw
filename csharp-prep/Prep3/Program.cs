using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        //Console.Write("What is the magic num ");
        //string magicNum = Console.ReadLine();
        //int magicNumInt = int.Parse(magicNum);

        Random randomGenerator = new Random();
        int magicNumInt = randomGenerator.Next(1, 101);

        string response;

        
        do //loop to check if response == magic num or not
        {
            Console.Write("What is your guess? ");
            response = Console.ReadLine();
            int responseInt = int.Parse(response);

            if (responseInt < magicNumInt) //checks if response is less than num
            {
                Console.WriteLine("Higher");
            }
            else if (responseInt > magicNumInt) //checks if response is greater than num
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!"); //prints message if they got it right
            }

        } while (int.Parse(response) != magicNumInt); //ends loop if they guessed it


    }
}