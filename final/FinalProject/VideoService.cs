using System.Numerics;
using Raylib_cs;

class VideoService
{
    //attributes
    private int _width = 800;
    private int _height = 600;
    private string _caption = "Space Invaders Clone";
    private int _frameRate = 60;

    //behaviours
    
    public void OpenWindow() //initializes a window 
    {
        Raylib.InitWindow(_width, _height, _caption);
        Raylib.SetTargetFPS(_frameRate);
    }

    public void CloseWindow()
    {
        Raylib.CloseWindow();
    }

    public void ClearBuffer()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
    }

    public void DrawActor(Actor actor)
    {
        string type = actor.GetTypeOfActor();
        Vector2 position = actor.GetPosition();

        Color color = Color.White;
        int size = 20;

        switch(type)
        {
            case "Player":
                color = Color.Green;
                size = 30; //player should be bigger so we can see him
                break;
            
            case "Enemy":
                color = Color.Red;
                size = 25;
                break;
            
            case "Bullet":
                color = Color.Yellow;
                size = 10; //bullets are smaller
                break;

            case "Debris":
                color = Color.Gray;
                break;

            case "Score":
                // Draw the score as text at actor position
                Raylib.DrawText($"Score: {actor.GetHealth()}", (int)position.X, (int)position.Y, 20, Color.White);
                return;

            default:
                break;

        }
        Raylib.DrawRectangle((int) position.X, (int)position.Y, size, size, color);
    }

    public void DrawActors(List<Actor> actors)
    {
        foreach(Actor actor in actors)
        {
            DrawActor(actor);
        }
    }

    public void FlushBuffer()
    {
        Raylib.EndDrawing();
    }

    public bool IsWindowOpen()
    {
        return !Raylib.WindowShouldClose();
    }

    public int GetWidth()
    {
        return _width;
    }
    public int GetHeight()
    {
        return _height;
    }   

    //draws a single text string onto the current frame
    public void DrawText(string text, int x, int y, int fontSize)
    {
        Raylib.DrawText(text, x, y, fontSize, Color.White);
    }

    //     public void DisplayEndGameMessage()
    // {
    //     ClearBuffer();
    //     Raylib.DrawText("Game Over!", _width / 2 - 100, _height / 2 - 20, 40, Color.White);
    //     FlushBuffer();
    //     Raylib.WaitTime(3.0f); //display for 3 seconds
    // }
}