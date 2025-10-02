using System;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2004;
        job1._endYear = 2025;

        //job1.Display();

        Job job2 = new Job();
        job2._jobTitle = "Grenadier";
        job2._company = "U.S. Army";
        job2._startYear = 2001;
        job2._endYear = 2005;

        //job2.Display();

        Resume resume1 = new Resume();
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        resume1._name = "Cool Guy";


        //Console.WriteLine($"{resume1._jobs[]._jobTitle}");

        resume1.Display(); //displays the content of the resume and the name
    }
}