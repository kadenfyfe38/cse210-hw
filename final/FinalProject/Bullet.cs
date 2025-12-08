using System.Numerics;

public class Bullet : Actor
{
    //attributes

    //constructor
    public Bullet(string name, string type, Vector2 startPosition, int health) : base(name, "Bullet", startPosition, 1)
    {}
    //behaviours
    public override void Move()
    {
        Vector2 direction = Vector2.Zero;

        float speed = 5.0f;
        _velocity = direction * speed;
        
        base.Move();
    }
}