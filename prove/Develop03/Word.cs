class Word
{
    //attributes
    private readonly string _word;
    private bool _hiddenBool;


    //behaviours
    public Word(string w) //constructor
    {
        _word = w;
        _hiddenBool = false;
    }


    public void SetHidden(bool hidden) //set the word to be hidden
    {
        _hiddenBool = hidden;
    }
    
    
    public void Display()
    {
        if (_hiddenBool)
        {
            Console.Write(new string('_', _word.Length));
        }
        else
        {
            Console.Write(_word);
        }
    }
}