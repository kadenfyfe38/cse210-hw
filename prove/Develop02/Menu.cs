class Menu
{
    //attributes (vars)
    public int _userchoice;

    //behaviours (functions)
    public void mainMenu(Journal myJournal)//takes myJournal as parameter so we can use it 
    {
        Console.WriteLine("[1] Write\n[2] Display\n[3] Load\n[4] Save\n[5] Quit\n");
        Console.WriteLine("What do you want to do? ");
        int _userchoice = int.Parse(Console.ReadLine());

        switch (_userchoice)
        {
            case 1: // allows user to write new entry
                Entry newEntry = myJournal.UserWrite();
                myJournal.AppendEntry(newEntry);
                break;
            case 2: //allows user to Display Journal
                myJournal.Display();
                break;
            case 3: // allwos user to load a specific Journal file
                myJournal.ReadFromFile();
                break;
            case 4: //allows user to save current journal to a file
                myJournal.WriteToFile();
                break;
            case 5: //allows user to quit the program
                Console.WriteLine("Goodbye.");
                return;
            default:
                Console.WriteLine("Not valid, please try again.");
                break;

        }
        mainMenu(myJournal); //loops the main menu until 5 is picked
    }

    public void UserWrite()
    {
        UserWrite();
    }
}