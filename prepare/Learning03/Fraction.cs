class Fraction
{
    //attributes
    private int _numerator;

    private int _denominator;

    //behaviours

    public Fraction() //initializes fraction to be 1/1
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    //getters and setters
    public int GetNumerator() //method to get numerator from user inpit
    {
        Console.WriteLine("What is the numerator? ");
        _numerator = int.Parse(Console.ReadLine());
        return _numerator;
    }

    public int SetNumerator(int numerator) //method to set numerator to an input 
    {
        return _numerator = numerator;
    }

    public int GetDenominator()// method to get denominator from user
    {
        Console.WriteLine("What is the denominator? ");
        _denominator = int.Parse(Console.ReadLine());
        return _denominator;
    }

    public int SetDenominator(int denominator) //method to set denominator to input
    {
        return _denominator = denominator;
    }

    //methods to return values 
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}"; //returns fraction as a string
    }

    public double GetDecimalValue() //returns fraction as a decimal
    {
        return (double)_numerator / (double)_denominator; //got the (double) form the example. got stuck here for a sec seing zeros in the termina;
        //i did learn that apparently you can just (double) cast the numerator and C# should do the denominaotr automatically. kinda cool
    }
}