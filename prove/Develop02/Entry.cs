using System.ComponentModel.DataAnnotations;
using System.Data;

class Entry
{
    //attributes
    public string _givenPrompt; //public so anywhere can use
    public string _entryDateTime;
    public string _entryText;

    //behavior

    public Entry()
    {
        _entryDateTime = "";
        _entryText = "";
        _givenPrompt = "";
    }

    public Entry(string entryDateTime, string entryText, string givenPrompt)
    {
        _entryDateTime = entryDateTime;
        _entryText = entryText;
        _givenPrompt = givenPrompt;
    }
    public void Display() //Basically a function
    {
        Console.Write($"{_entryDateTime} -- ");
        Console.WriteLine($"{_givenPrompt}");
        Console.WriteLine($"{_entryText}");
        Console.WriteLine("-----------");
    }

    public override string ToString()
    {
        return $"{_entryDateTime}|||{_givenPrompt}|||{_entryText}";
    }

}