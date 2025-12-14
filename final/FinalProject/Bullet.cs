using System.Numerics;

public class Bullet : Actor
{
    //attributes

    //constructor
    public Bullet(Vector2 startPosition, Vector2 velocity) : base("bullet", "Bullet", startPosition, 1)
    {
        SetVelocity(velocity);
    }
    //behaviours
    public override void Move()
    {
        // Vector2 direction = Vector2.Zero;

        // float speed = 5.0f;
        // _velocity = direction * speed;
        
        base.Move();
    }
}