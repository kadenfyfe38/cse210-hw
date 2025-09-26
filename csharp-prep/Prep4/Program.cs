using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int sum = 0; //init sum
        float average = 0; //init avg
        int runningTotal = 0; //init running total for list
        int response = 1; //init response
        int maxNum = 0; //init maximum number

        do
        {
            Console.Write("Please add a number: ");
            string responseStr = Console.ReadLine();
            response = int.Parse(responseStr);
            numbers.Add(response);
            runningTotal ++; //adds 1 to running total


        } while (response != 0);
        runningTotal = runningTotal - 1; //subtracts 1 from running total to account for user entering 0
        foreach (int num in numbers)
        {
            sum = sum += num; //adds sum to total sum
            if (num > maxNum)
            {
                maxNum = num;
            }
        }
        average = (float)sum / (float)runningTotal; //compute average 

        Console.WriteLine($"Sum: {sum}\nAverage: {average}\nLargest Number: {maxNum}"); 
    }
}