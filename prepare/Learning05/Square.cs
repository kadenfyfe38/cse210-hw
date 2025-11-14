public class Square : Shape
{
    //attributes
    private double _side;

    //behaviours
    public Square(string color, double side) : base (color)
    {
        _side = side;
    }
    public override double GetArea()
    {
        return _side * _side;
    }
    
}