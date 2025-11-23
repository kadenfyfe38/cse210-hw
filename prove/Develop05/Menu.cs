using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.ComponentModel;

class Menu
{
    //attributes
    private List<Goal>_goals = new List<Goal>(); //automatically create a new list
    // private List<Goal>_completedGoals = new List<Goal>(); //when goals are recorded, add to this list
    int _totalPoints; //add points to this as goals are completed

    //behaviours
    public void Start() //method for main menu 
    {   
        Console.Clear();
        Console.WriteLine("Welcome to the Eternal Quest Goal-Tracking Game!");
        bool isRunning = true;
        while (isRunning)
        {
            
            //CalculateTotalPoints();
            DisplayScore();
            
            Console.WriteLine("\n---Main Menu---\nPlease Select from the following:\n");
            Console.WriteLine("[1] Create New Goal\n[2] List Goals\n[3] Save Goals\n[4] Load Goals\n[5] Record Event\n[6] Quit\n[7] Check Point Status");

            string userResponse = Console.ReadLine();

            switch (userResponse)
            {
                case "1"://create goal
                    //get user input for simple goal
                    Console.WriteLine("Select which type of goal to create. Press [0] to return to menu.");
                    Console.WriteLine("[1] Simple Goal\n[2] Eternal Goal\n[3] Checklist Goal\n");
                    string typeOfGoal = Console.ReadLine();

                    switch(typeOfGoal)
                    {
                        case "1": //Simple Goal
                            MakeSimpleGoal();
                            break;

                        case "2": //eternal goal
                            MakeEternalGoal();
                            break;

                        case "3": //checklist goal
                            MakeChecklistGoal();
                            break;

                        case "0"://back to main menu
                            break;

                        default:
                            Console.WriteLine("Please enter a valid entry");
                            break;
                    }break;//end of inner switch statement

                case "2": //list all goals
                    ListGoals();
                    break;

                case "3": //save goals
                    SaveGoals();
                    break;

                case "4": //load goals
                    LoadGoals();
                    break;

                case "5": //Record goals
                    RecordEvent();
                    break;

                case "6"://end program
                    isRunning = false;
                    Console.WriteLine("Have a nice day!");
                    break;

                case "7":
                    DisplayScore();
                    // Console.WriteLine($"You have {_totalPoints}");
                    Console.WriteLine($"You have obtained {_totalPoints} out of {CalculatePossiblePoints()} possible points if you were to only complete each of your goals once.");
                    Console.WriteLine($"There are still {CalculateTotalUnobtainedPoints(CalculatePossiblePoints())} points which you have never claimed.");
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

        }
    }
    private void DisplayScore() 
    {
        Console.WriteLine($"\n---{_totalPoints} Points---");
        
    }
    private int CalculatePossiblePoints() //these three following methods help calculate how many points are available if you completed each goal once 
    {
        int possiblePoints = 0;
        foreach (Goal goal in _goals)
        {
            int points = goal.GetPoints();

            if (goal is SimpleGoal)
            {
                possiblePoints += points;
            }
            else if (goal is EternalGoal)
            {
                possiblePoints += points;
            }

            else if (goal is ChecklistGoal checklistgoal) //checks if the goal ios a checklist goal
            {
                int targetcount = checklistgoal.GetTargetCount();
                int bonusPoints = checklistgoal.GetBonusPoints();
                int multiplePoints = targetcount * points;
                int maximumPoints = multiplePoints + bonusPoints;

                possiblePoints += maximumPoints;  
            }
        }
        return possiblePoints;
    }
    private int CalculateTotalUnobtainedPoints(int possiblePoints) 
    {
            int unobtainedTotal = possiblePoints-_totalPoints;
            return unobtainedTotal;
    }

    private void ListGoals()
    {
        Console.WriteLine("\nGoals:");
        int i =1;
        foreach (Goal goal in _goals)
        {
            string item = goal.GetDisplayString(); //gets each goal and prints 
            Console.WriteLine($"[{i}] {item}");
            i++;
        }
    }
    private void SaveGoals()
    {
        Console.WriteLine("What should the name of the file be?\n");
        string nameOfFile = Console.ReadLine();
        
        using (StreamWriter outputFile = new StreamWriter(nameOfFile))
        {
            outputFile.WriteLine(_totalPoints);//first line in file
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }
    private void LoadGoals()
    {
        _goals.Clear(); //init list to avoid duplication
        Console.WriteLine("What is the filename?");
        string fileName = Console.ReadLine();

        using (StreamReader sr = new StreamReader(fileName))//reads first line to set total points
        {
            _totalPoints = int.Parse(sr.ReadLine());
        }

        string[] lines = System.IO.File.ReadAllLines(fileName);
        _totalPoints = int.Parse(lines[0]);

        foreach (string line in lines.Skip(1)) //skips first line cause thats where _totalPoints are held
        {
            string[] parts = line.Split("#$%^*&");

            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            bool isComplete = bool.Parse(parts[4]);

            if (type == "Eternal") // add eternal goals
            {
                Goal loadEternalGoal = new EternalGoal(name, description, points);
                _goals.Add(loadEternalGoal);
            }
            else if (type == "Simple") //add simple goals
            {
                Goal loadSimpleGoal = new SimpleGoal(name, description, points, isComplete);
                _goals.Add(loadSimpleGoal);
            }
            else if (type == "Checklist") //add checklist goals
            {
                int currentCount = int.Parse(parts[5]); //parse the checklist goal specific items
                int targetCount = int.Parse(parts[6]);

                ChecklistGoal loadChecklistGoal = new ChecklistGoal(name, description, points, targetCount);
                loadChecklistGoal.SetCurrentCount(currentCount);

                _goals.Add(loadChecklistGoal);
            }
        }
    }
    private void RecordEvent()
    {
        ListGoals();
        Console.WriteLine("\nWhich goal have you accomplished? ");
        int completedGoal = int.Parse(Console.ReadLine());

        Goal goalToAddPointsFor = _goals[completedGoal-1];
        int awardedPoints = goalToAddPointsFor.RecordEvent();
        _totalPoints += awardedPoints;
    }

    //MAKE GOALS:
    private void MakeSimpleGoal()
    {
        //get info for goal:
        Console.WriteLine("What is the name of your goal? ");
        string goalName =Console.ReadLine();
        Console.WriteLine("Short description of this goal? ");
        string goalDescription = Console.ReadLine();
        Console.WriteLine("How many points should this goal be worth? ");
        int goalPoints = int.Parse(Console.ReadLine());

        //make goal
        SimpleGoal simpleGoal = new SimpleGoal(goalName, goalDescription, goalPoints, false);
        _goals.Add(simpleGoal);
    }
    private void MakeEternalGoal()
    {
        //get info for goal:
        Console.WriteLine("What is the name of your goal? ");
        string goalName =Console.ReadLine();
        Console.WriteLine("Short description of this goal? ");
        string goalDescription = Console.ReadLine();
        Console.WriteLine("How many points should this goal be worth? ");
        int goalPoints = int.Parse(Console.ReadLine());

        //make goal
        EternalGoal eternalGoal = new EternalGoal(goalName, goalDescription, goalPoints);
        _goals.Add(eternalGoal);
    }
    private void MakeChecklistGoal()
    {
        //get info for goal:
        Console.WriteLine("What is the name of your goal? ");
        string goalName =Console.ReadLine();
        Console.WriteLine("Short description of this goal? ");
        string goalDescription = Console.ReadLine();
        Console.WriteLine("How many points should this goal be worth? ");
        int goalPoints = int.Parse(Console.ReadLine());
        Console.WriteLine("How many times should you complete this goal for a bonus? ");
        int targetCount = int.Parse(Console.ReadLine());

        //make goal
        ChecklistGoal checklistGoal = new ChecklistGoal(goalName, goalDescription, goalPoints, targetCount);
        _goals.Add(checklistGoal);
    }
}