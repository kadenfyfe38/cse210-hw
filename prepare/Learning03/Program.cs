using System;

class Program
{
    static void Main(string[] args)
    {
        // int n = 6;//init vars for fracs //i was using these in the functions but just decided to go with the examples on canvas in the assignment instead
        // int d = 7;


        Fraction fraction1 = new Fraction(); //creates fraction 1/1
        Console.WriteLine(fraction1.GetFractionString()); //PRINTS FRACTIONS 
        Console.WriteLine(fraction1.GetDecimalValue()); //prints decimal values 1/1
        Fraction fraction2 = new Fraction(5); //creates fraction 5/1
        Console.WriteLine(fraction2.GetFractionString()); //5/1
        Console.WriteLine(fraction2.GetDecimalValue()); //5
        Fraction fraction3 = new Fraction(3, 4); //creates fraction 3/4
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue()); //0.75


        Fraction fraction4 = new Fraction(1,3); // makes a fourth fraction
        Console.WriteLine(fraction4.GetFractionString()); //does it again with new numbers
        Console.WriteLine(fraction4.GetDecimalValue());
    }
}