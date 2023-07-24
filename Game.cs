using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Game
{
    public static RenderWindow window = new RenderWindow(new VideoMode(600,600), "");
    public static Vector2f catcherSize = new Vector2f(150,20);
    public static Vector2f itemSize = new Vector2f(20,20);
    private static Catcher catcher;
    public static float deltaTime;
    public static void Run()
    {
        window.SetFramerateLimit(60);
        float interval = 0.1875f;
        float accumulator = 0f;
        Clock deltaTimeClock = new Clock();

        catcher = new Catcher(0xffffffff, catcherSize);
        List<Items> itemList = new List<Items>();

        while (window.IsOpen)
        {
            window.DispatchEvents();

            float deltaTime = deltaTimeClock.Restart().AsSeconds();
            accumulator += deltaTime;
            Game.deltaTime = deltaTime;

            window.Closed += (sender, e) => window.Close();
            window.Clear(Color.Black);

            itemList.RemoveAll(item => !item.active);

            if (accumulator >= interval)
            {
                Items newItem = new Items(itemSize, 0x666666ff);
                itemList.Add(newItem);
                accumulator -= interval;
            }

            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].Movement();
                window.Draw(itemList[i].rect);
            }

            catcher.Movement();
            window.Draw(Catcher.rect);
            Score.Update();

            window.Display();
        } 
    }
}