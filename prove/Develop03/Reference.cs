class Reference
{
    //attributes
    private string _bookName;
    private string _chapter;
    private string _verse;


    //behaviours
    public void Display()
    {
        Console.WriteLine($"{_bookName} {_chapter} {_verse} ");//scripture goes here
    }
    public Reference(string bookName, string chapter, string verse) //constructor
    {
        _bookName = bookName;
        _chapter = chapter;
        _verse = verse;
    }
}