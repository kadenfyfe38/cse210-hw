public abstract class Shape
{
    //attributes
    private string _color;

    //Constructor
    public Shape(string color)
    {
        _color = color;
    }

    //behaviours
    public abstract double GetArea();

    public string GetColor()
    {
        return _color;
    }
    public void SetColor(string color)
    {
        _color = color;
    }
}