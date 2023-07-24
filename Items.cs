using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Items
{
    private static Random random = new Random();
    public RectangleShape rect { get; set; }
    public bool active { get; private set; } = true;
    private static readonly float fallRate = 750f;
    public Items(Vector2f size, uint fillColor)
    {
        rect = new RectangleShape
        {
            Size = size,
            FillColor = new Color(fillColor),
            Position = new Vector2f(random.Next(0, (int)Game.window.Size.X - (int)size.X), 0),
        };
    }
    public void Movement()
    {
        if (!Collision(rect))
        {
            Vector2f newPosition = rect.Position;
            newPosition.Y += fallRate * Game.deltaTime;
            rect.Position = newPosition;
        } 
        else if (Collision(rect)) 
        {
            active = false;
        }
    }
    public static bool Collision(RectangleShape rect)
    {
        if (rect.GetGlobalBounds().Intersects(Catcher.rect.GetGlobalBounds()))
        {
            Score.count += 1;
            return true;
        }
        else if (rect.Position.Y > Game.window.Size.Y) {
            Score.count -= 1;
            return true;
        }
        return false;
    }
}