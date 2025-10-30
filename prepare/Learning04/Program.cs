using System;


class Program
{
   static void Main(string[] args)
   {
       Console.Clear();


       Assignment test = new Assignment("Kaden", "Math");
       string summary = test.GetSummary();
       Console.WriteLine(summary);


       MathAssignment mathTest = new MathAssignment("kaden", "science", "section 8", "1-6");
       Console.WriteLine(mathTest.GetSummary());
       Console.WriteLine(mathTest.GetHomeworkList());


       WritingAssignment writeTest = new WritingAssignment("Bob", "physics", "How a Pendulum Swings");
       Console.WriteLine(writeTest.GetSummary());
       Console.WriteLine(writeTest.GetWritingInformation());
   }
}
