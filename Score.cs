using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Score
{
    public static int count;
    private readonly static uint size = 150;
    private readonly static uint fillColor = 0x888888ff;
    private readonly static Font font = new Font("./poppins.ttf");
    public static void Update()
    {
        Text displayText = new Text(count.ToString(), font, size);
        displayText.Origin = new Vector2f(displayText.GetGlobalBounds().Width / 2, displayText.GetGlobalBounds().Height /2);
        displayText.Position = new Vector2f(Game.window.Size.X / 2, Game.window.Size.Y / 2);
        if (count >= 0) displayText.FillColor = new Color(fillColor);
        else if (count < 0) displayText.FillColor = new Color(0xff0000ff);
        Game.window.Draw(displayText);
    }
}