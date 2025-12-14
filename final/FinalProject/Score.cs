using System.Numerics;

public class Score : Actor
{
    //attributes
    
    //constructor
    public Score(string name, string type, Vector2 x, int health): base("score", "Score", x,0)
    {}
    //behaviours

    //add points to the score
    public void AddPoints(int points) //using actor health to store score points
    {
        _health += points;
    }

    public int GetScore() //return total points
    {
        return _health;
    }
}