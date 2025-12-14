using System.Numerics;


public class Director
{
    //attributes
    private List<Actor> _listOfActors = new List<Actor>();
    private bool _isPlaying = true;
    private Input _inputService = new Input();
    private VideoService _videoService = new VideoService();
    private Score _score;
    private Player _player; //a private reference to playrer so we dont't treat them liek all otehr actors in list
    private int _enemySize = 25;
        private float _enemySpeed = 1.5f;//speed at which enemies move toward the player
    private float _enemyDirection = 1f;//1 or -1 for alternating left/right
    private int _bulletSize = 10;



    //Constructor

    //behaviours
    public void StartGame()
    {
        _videoService.OpenWindow();
    
        _player = new Player("Player1", "Player", new Vector2(400, 500), 100);
        _listOfActors.Add(_player);

        // Create score actor in top-left
        _score = new Score("Score", "Score", new Vector2(10, 10), 0);
        _listOfActors.Add(_score);

        SpawnEnemies();

        while (_videoService.IsWindowOpen() && _isPlaying)
        {
            GetInputs();
            DoUpdates();
            DoOutputs();
        }

        //After game loop ends, show final screen with score until window is closed
        ShowGameOver();

        // if (_isPlaying == false)
        // {
        //     _videoService.DisplayEndGameMessage();
        //     //game ends
        // }
    }

    private void SpawnEnemies()
    {
        //Create a 5x3 grid of enemies
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                int x = 100 + (col * 100); //spacing X
                int y = 50 + (row * 60);   //spacing Y
                
                Enemy alien = new Enemy("Alien", "Enemy", new Vector2(x, y), 1);
                _listOfActors.Add(alien);
            }
        }
    }

    private void GetInputs()
    {
        Vector2 direction = _inputService.IsKeyDown();
        
        _player.SetVelocity(direction *5.0f); //mkae it actually move in the direction

        if (_inputService.IsAttackPressed())
        {
            Bullet bullet = _player.Shoot();

            if (bullet !=null)
            {
                _listOfActors.Add(bullet);
            }
        }

        if (_inputService.ShouldCloseWindow()) //if the window should close, stop playing
        {
            _isPlaying = false;
        }
    }
    
    private void DoUpdates() //infinite loop to update all actors
    {
        //update positions
        foreach (Actor actor in _listOfActors)
        {
            actor.Move();
        }

        //get the screen width and height
        int width = _videoService.GetWidth();
        int height = _videoService.GetHeight();

        //get player size and make it so their model cannot leave screen
        const int playerSize = 30;
        Vector2 playerPos = _player.GetPosition();
        float playerLockXAxis = Math.Max(0f, Math.Min(playerPos.X, width - playerSize));
        float playerLockYAxis = Math.Max(0f, Math.Min(playerPos.Y, height - playerSize));
        _player.SetPosition(new Vector2(playerLockXAxis, playerLockYAxis)); //keep the player inside the window so they cannot leave the screen

        //enemies move horizontally and drop when any hits edge of screen
        List<Actor> enemiesForMovement = _listOfActors.Where(a => a.GetTypeOfActor() == "Enemy").ToList();
        foreach (Actor enemyForMovement in enemiesForMovement)
        {
            //move side to side
            Vector2 lateral = new Vector2(_enemyDirection * _enemySpeed, 0f);
            enemyForMovement.SetVelocity(lateral);

            //keep enemies inside the window bounds
            Vector2 enemyPos = enemyForMovement.GetPosition();
            float enemyLockXAxis = Math.Max(0f, Math.Min(enemyPos.X, width - _enemySize));
            float enemyLockYAxis = Math.Max(0f, Math.Min(enemyPos.Y, height - _enemySize));
            enemyForMovement.SetPosition(new Vector2(enemyLockXAxis, enemyLockYAxis));
        }

        //if any enemy touches the left or right edge, flip direction and move lower
        bool shouldFlipDueToEdge = false;
        foreach (Actor enemyCheck in enemiesForMovement)
        {
            Vector2 pos = enemyCheck.GetPosition();
            if (pos.X <= 0f || pos.X >= width - _enemySize)
            {
                shouldFlipDueToEdge = true;
                break;
            }
        }

        if (shouldFlipDueToEdge)
        {
            //flip xaxis direction for all enemies and move them down
            _enemyDirection *= -1f;
            foreach (Actor enemyForMovement in enemiesForMovement)
            {
                Vector2 pos = enemyForMovement.GetPosition();
                enemyForMovement.SetPosition(new Vector2(pos.X, pos.Y + 20f));

                //update x velocity so they react immediately
                Vector2 lateral = new Vector2(_enemyDirection * _enemySpeed, 0f);
                enemyForMovement.SetVelocity(lateral);
            }
        }

        
        foreach (Actor enemyCheck in enemiesForMovement)//if any enemy reaches the player's vertical position, player dies
        {
            Vector2 pos = enemyCheck.GetPosition();
            if (pos.Y + _enemySize >= playerPos.Y)
            {
                _isPlaying = false; //player died
                break;
            }
        }
        
        
        //remove bullet and enemy if they touch
        List<Actor> bullets = _listOfActors.Where(a => a.GetTypeOfActor() == "Bullet").ToList();
        List<Actor> enemies = _listOfActors.Where(a => a.GetTypeOfActor() == "Enemy").ToList();

        List<Actor> toRemove = new List<Actor>();

        foreach (Actor bullet in bullets) //find circle for bullet
        {
            Vector2 bulletPosition = bullet.GetPosition();
            Vector2 bulletCenter = new Vector2(bulletPosition.X + _bulletSize / 2f, bulletPosition.Y + _bulletSize / 2f);

            foreach (Actor enemy in enemies) //find circle for enemy
            {
                Vector2 enemyPosition = enemy.GetPosition();
                Vector2 enemyCenter = new Vector2(enemyPosition.X + _enemySize / 2f, enemyPosition.Y + _enemySize / 2f); //

                float distance = Vector2.Distance(bulletCenter, enemyCenter);
                float collisionDistance = (_bulletSize + _enemySize) / 2f;

                if (distance <= collisionDistance) //if the two circles are touching, both bullet and enemy get removed.
                {
                    toRemove.Add(bullet);
                    // Only add the enemy once and give the player points when it's first discovered as removed
                    if (!toRemove.Contains(enemy))
                    {
                        toRemove.Add(enemy);
                        _score.AddPoints(100);
                    }
                }
            }
        }

        //remove bullets that go off screen
        foreach (Actor actor in _listOfActors.ToList())
        {
            if (actor.GetTypeOfActor() == "Bullet")
            {
                Vector2 pos = actor.GetPosition();
                if (pos.X < -50 || pos.X > 850 || pos.Y < -50 || pos.Y > 650)
                {
                    toRemove.Add(actor);
                }
            }
        }

        // Remove collided/out of bounds actors
        foreach (Actor actor in toRemove) //.Distinct() to avoid double removal
        {
            _listOfActors.Remove(actor);
        }
    }
    private void DoOutputs()
    {
        _videoService.ClearBuffer();

        _videoService.DrawActors(_listOfActors);
        
        _videoService.FlushBuffer();
    }

    // Display a final game over screen with the score until the window is closed by user.
    private void ShowGameOver()
    {
        while (_videoService.IsWindowOpen())
        {
            _videoService.ClearBuffer();
            _videoService.DrawActors(_listOfActors);
            _videoService.DrawText($"Game Over - Final Score: {_score.GetScore()}", 200, 250, 30);
            _videoService.FlushBuffer();

            if (_inputService.ShouldCloseWindow())
            {
                break;
            }
        }
    }

}