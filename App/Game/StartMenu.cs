using System;
using SFML.Graphics;
using SFML.System;

namespace Mold
{
    public class StartMenu : Drawable
    {
        private Font font;
        private Text title;
        private Text pressEnter;

        private Sprite car1;
        private Sprite car2;
        private Sprite car3;
        private Sprite car4;

        private Texture carTexture;

        public StartMenu()
        {
            font = new Font("Data/arial.ttf");

            title = new Text("MOLD GAME", font);
            title.CharacterSize = 42;
            title.FillColor = Color.White;

            FloatRect tBounds = title.GetLocalBounds();

            title.Origin = new Vector2f(tBounds.Width / 2, tBounds.Height / 2);
            title.Position = new Vector2f(MoldGame.rw.Size.X / 2, 120);

            pressEnter = new Text("PRESS ENTER TO START", font);
            pressEnter.CharacterSize = 28;
            pressEnter.FillColor = Color.White;

            FloatRect pBounds = pressEnter.GetLocalBounds();

            pressEnter.Origin = new Vector2f(pBounds.Width / 2, pBounds.Height / 2);
            pressEnter.Position = new Vector2f(MoldGame.rw.Size.X / 2, 320);

            carTexture = new Texture("Data/Textures/Car2.png");

            car1 = new Sprite(carTexture);
            car1.Position = new Vector2f(80, 200);

            car2 = new Sprite(carTexture);
            car2.Position = new Vector2f(200, 260);

            car3 = new Sprite(carTexture);
            car3.Position = new Vector2f(420, 180);

            car4 = new Sprite(carTexture);
            car4.Position = new Vector2f(520, 320);
        }

        public void Draw(RenderTarget rt, RenderStates st)
        {
            rt.Draw(car1);
            rt.Draw(car2);
            rt.Draw(car3);
            rt.Draw(car4);

            rt.Draw(title);
            rt.Draw(pressEnter);
        }
    }
}