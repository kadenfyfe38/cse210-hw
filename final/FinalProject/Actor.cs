using System.Dynamic;
using System.Numerics;

public abstract class Actor
{
    //attributes
    protected string _name;
    protected int _health;
    private string _typeOfActor;
    protected Vector2 _position;
    protected Vector2 _velocity;

    //constructor
    protected Actor(string name, string type, Vector2 position, int health)
    {
        _name = name;
        _typeOfActor = type;
        _position = position;
        _health = health;
        _velocity = Vector2.Zero; //sets it's movement to zero or standstill
    }
    //behabiours
    public virtual void Move() //virtual and not abstract because there is a default way to move
    {
        _position += _velocity;
    }
    public void SetVelocity(Vector2 newVelocity) 
    {
        _velocity = newVelocity;
    }
    public string GetTypeOfActor()
    {
        return _typeOfActor;
    }
}