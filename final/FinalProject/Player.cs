using System.Numerics;
using System.Runtime.CompilerServices;

public class Player : Actor
{
    //attributes

    //constructor
    public Player(string name, string type, Vector2 startPosition, int health) : base(name, "Player", startPosition, 100)
    {}

    //behaviours
    public override void Move()
    {
        Vector2 direction = Vector2.Zero;

        float speed = 5.0f;
        _velocity = direction * speed;

        base.Move();
    }

    public void Shoot()
    {
        //see if weapon is ready, create new bullet actor.
    }
}