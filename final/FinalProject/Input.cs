using System.Numerics;
using Raylib_cs;
class Input
{
    //attributes

    //behaviours
    public Vector2 IsKeyDown()
    {
        int x = 0;

        //move left
        if (Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A))
        {
            x = -1;
        }
        
        //move right
        if (Raylib.IsKeyDown(KeyboardKey.Right) || Raylib.IsKeyDown(KeyboardKey.D))
        {
            x = 1;
        }

        return new Vector2(x,0);
    }

    public bool IsAttackPressed() //checks if user wants to attact
    {
        return Raylib.IsKeyPressed(KeyboardKey.Space);
    }
    public bool ShouldCloseWindow() //checks to see if user wants to close window by pressing escape
    {
        return Raylib.WindowShouldClose();
    }
}