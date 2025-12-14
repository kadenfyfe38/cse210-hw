using System.Numerics;
using System.Runtime.CompilerServices;

public class Player : Actor
{
    //attributes
    private int _cooldown = 0;
    private int _cooldownFrames = 20;

    //constructor
    public Player(string name, string type, Vector2 startPosition, int health) 
    :base(name, "Player", startPosition, 100)
    {}

    //behaviours
    public override void Move()
    {
        base.Move();

        if(_cooldown > 0)
        {
            _cooldown--;
        }
    }

    public Bullet Shoot()
    {
        //see if weapon is ready, create new bullet actor.
        if(_cooldown > 0)
        {
            return null;
        }

        _cooldown = _cooldownFrames; //reset timer for gun

        Vector2 spawnPosition = new Vector2(_position.X, _position.Y -20);
        Vector2 velocity = new Vector2(0,-8);

        return new Bullet(spawnPosition, velocity); 
    }
}