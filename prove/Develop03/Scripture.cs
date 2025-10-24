using System.Data;

class Scripture
{
    //attributes
    private readonly Reference _reference; 
    private readonly List <Word> _ListOfWords;
    private readonly List<int> _visibleWords; //list to keep track of which words have been erased.
    private readonly Random _random = new Random();
    //behaviours
    private int RandomGenerator()
{
    return _random.Next(0, _visibleWords.Count);
}

    public void Display()
    {
        _reference.Display();//display reference ahead of scripture

        foreach (Word w in _ListOfWords)
        {
            //dont write on separate lines, call word methods to hide a word if they are set to hidden.
            //then checks to see if words are hidden or not
            w.Display();
            Console.Write(" ");
        }
        Console.WriteLine(); //for the aesthetic
    }

    public void Menu(Scripture s) //makes a menu for the program and is main way user interacts
    {
        string input;
        Console.WriteLine("Press enter to continue or type \"quit\" to finish: ");
        input = Console.ReadLine();

        if (input == "")
        {
            Hide(); //adds number to the list to ensure the same word isn't snapped twice

            //i need liogic here to actuslly hide the words. use the hide method below in this class...maybe...

            //Console.WriteLine($"{s}"); //write the scripture again var newScripture
        }

        else if (input == "quit")
        {
            Environment.Exit(0); //quit the program
        }
        else
        {
            Console.WriteLine("Invalid input");
        }

    }

    public Scripture(Reference reference, string text) //constructor
    {
        _reference = reference;
        _ListOfWords = new List<Word>(); //make new list
        
        string[] words = text.Split(' '); //dissect list

        foreach (string w in words)
        {
            _ListOfWords.Add(new Word(w)); //add words to list as a Word
        }
        _visibleWords = Enumerable.Range(0, _ListOfWords.Count).ToList(); //list class instead of enumerable class
    }
    
    private void Hide()
    {
        if (_visibleWords.Count==0) //if visible words is empty, end program
        {
            Environment.Exit(0);
        }
        int wordToBeThanosSnappedOutOfThisReality = RandomGenerator(); //randomly generatees an int
        int indexOfWordToHide = _visibleWords[wordToBeThanosSnappedOutOfThisReality];  //finds the word to hide at index of random int in list of visible words
        _ListOfWords[indexOfWordToHide].SetHidden(true); //classifies the Word as hidden in the List of Words 
        _visibleWords.RemoveAt(wordToBeThanosSnappedOutOfThisReality); //removes word at random index from list to ensure it wont be hidden again
    }
}   