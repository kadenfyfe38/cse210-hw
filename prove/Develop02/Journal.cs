using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

class Journal
{
    //attributes
    public List<Entry> _entryList; //its a list of entries (in other file class entry.cs) called _entryList. We could initialize in main or do it here

    public readonly List<string> bankOfPrompts = new List<string>
   {
    "What was the best part of your day?", "Who is someone memorable you spoke with today",
    "What made you get out of bed this morning?", "Name three memorable events from today",
    "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?",
    "If I had one thing I could do over today, what would it be?"
    };

    //behaviours
    public void Initialize()
    {
        _entryList = new List<Entry>(); //initializes the _entryList to create new object
    }
    public void AppendEntry(Entry e)
    {
        _entryList.Add(e);
    }
    public void Display()
    {
        //Console.WriteLine("-----------");
        foreach (Entry i in _entryList)
        {
            i.Display();
        }
    }

    public Entry UserWrite()
    {
        Random random = new Random();
        int RandomIndex = random.Next(0, 6);
        string RandomPrompt = bankOfPrompts[RandomIndex];
        Console.WriteLine($"{RandomPrompt} "); //test to see if working
        string userResponse = Console.ReadLine();
        string i = DateTime.Now.ToShortDateString();
        Entry UserEntry = new Entry(i, userResponse, RandomPrompt); // make new entry to store user response
        return UserEntry;
    }
    public void WriteToFile()
    {
        //for loop to write 
        //for each loop --> entry.tostring
        Console.WriteLine("What is the filename? ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename, append: false)) //uses StreamWriteer & set append to true so it doesn't overwrite
        {
            foreach (Entry entry in _entryList)
            {
                outputFile.WriteLine($"{entry}");
            }
        }
    }

    public void ReadFromFile()
    {
        //if #, break it into pieces and display
        //add each entry to entry list
        Console.WriteLine($"What is the filename? ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);

        _entryList.Clear(); //clears entry list so you don't duplicate stuff

        foreach (string line in lines)
        {
            string[] entry = line.Split("#");
            string _entryDateTime = entry[0];
            string _givenPrompt = entry[1];
            string _entryText = entry[2];
            Entry e = new Entry(_entryDateTime, _entryText, _givenPrompt); //turns previously stored lines into new entries to be displayed again
            _entryList.Add(e);
            //Display();
        }
        Display();
    }
    
}