public class Circle : Shape
{
    //attributes
    private double _radius;
    //Constructor
    public Circle(string color, double radius) : base (color)
    {
        _radius = radius;
    }

    //Behaviours
    public override double GetArea()
    {
        return Math.PI * _radius*_radius;
    }
    
}