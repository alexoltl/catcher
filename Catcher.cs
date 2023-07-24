using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Catcher
{
    public static RectangleShape rect { get; set; }
    private readonly float speed = 10f;
    private readonly float hyper = 40f;
    private static float movementSpeed;
    
    public Catcher(uint fillColor, Vector2f size)
    {
        rect = new RectangleShape
        {
            Size = size,
            FillColor = new Color(fillColor)
        };
        rect.Position = new Vector2f(0, Game.window.Size.Y - rect.Size.Y);
    }

    public void Movement()
    {
        Vector2f newPosition = rect.Position;

        if (Keyboard.IsKeyPressed(Keyboard.Key.LShift)) movementSpeed = hyper;
        else movementSpeed = speed;

        if (Keyboard.IsKeyPressed(Keyboard.Key.Left)) 
        {
            if (!Collision(rect)) 
            {
                newPosition.X -= movementSpeed;
                rect.Position = newPosition;
            }
            if (Collision(rect)) 
            {
                newPosition.X = 2;
                rect.Position = newPosition;
            }
        }
        if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
        {
            if (!Collision(rect)) 
            {
                newPosition.X += movementSpeed;
                rect.Position = newPosition;
            }
            if (Collision(rect)) 
            {
                newPosition.X = Game.window.Size.X - rect.Size.X - 2;
                rect.Position = newPosition;
            }
        }
    }
    private static bool Collision(RectangleShape rect)
    {
        if (rect.Position.X < 0 || rect.Position.X > Game.window.Size.X - rect.Size.X) return true;
        else return false;
    }
}