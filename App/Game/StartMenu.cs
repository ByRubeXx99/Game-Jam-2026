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
        private Text instructions;

        private RectangleShape titleFrame;
        private RectangleShape pressEnterFrame;
        private RectangleShape instructionsFrame;

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

            title.Origin = new Vector2f(
                tBounds.Left + tBounds.Width / 2,
                tBounds.Top + tBounds.Height / 2
            );

            title.Position = new Vector2f(MoldGame.rw.Size.X / 2, 120);

            titleFrame = new RectangleShape(
                new Vector2f(tBounds.Width + 40, tBounds.Height + 30)
            );

            titleFrame.Origin = new Vector2f(
                titleFrame.Size.X / 2,
                titleFrame.Size.Y / 2
            );

            titleFrame.Position = title.Position;
            titleFrame.FillColor = Color.Black;
            titleFrame.OutlineColor = Color.Yellow;
            titleFrame.OutlineThickness = 4f;

            pressEnter = new Text("PRESS ENTER TO START", font);
            pressEnter.CharacterSize = 28;
            pressEnter.FillColor = Color.White;

            FloatRect pBounds = pressEnter.GetLocalBounds();

            pressEnter.Origin = new Vector2f(
                pBounds.Left + pBounds.Width / 2,
                pBounds.Top + pBounds.Height / 2
            );

            pressEnter.Position = new Vector2f(MoldGame.rw.Size.X / 2, 200);

            pressEnterFrame = new RectangleShape(
                new Vector2f(pBounds.Width + 40, pBounds.Height + 30)
            );
            pressEnterFrame.Origin = new Vector2f(
                pressEnterFrame.Size.X / 2,
                pressEnterFrame.Size.Y / 2
            );

            pressEnterFrame.Position = pressEnter.Position;
            pressEnterFrame.FillColor = Color.Black;
            pressEnterFrame.OutlineColor = Color.Yellow;
            pressEnterFrame.OutlineThickness = 4f;

            carTexture = new Texture("Data/Textures/Car2.png");

            car1 = new Sprite(carTexture);
            car1.Position = new Vector2f(1300, 300);

            car2 = new Sprite(carTexture);
            car2.Position = new Vector2f(1000, 600);

            car3 = new Sprite(carTexture);
            car3.Position = new Vector2f(420, 440);

            car4 = new Sprite(carTexture);
            car4.Position = new Vector2f(520, 770);

            instructions = new Text("Eat all the moldy food you can find and dodge traffic to make your monster evolve.", font);
            instructions.CharacterSize = 20;
            instructions.FillColor = Color.White;
            FloatRect iBounds = instructions.GetLocalBounds();
            instructions.Origin = new Vector2f(iBounds.Left + iBounds.Width / 2, iBounds.Top + iBounds.Height / 2);
            instructions.Position = new Vector2f(MoldGame.rw.Size.X / 2, 270);
            
            instructionsFrame = new RectangleShape(new Vector2f(iBounds.Width + 40, iBounds.Height + 30));
            instructionsFrame.Origin = new Vector2f(instructionsFrame.Size.X / 2, instructionsFrame.Size.Y / 2);
            instructionsFrame.Position =  instructions.Position;
            instructionsFrame.FillColor = Color.Black;
            instructionsFrame.OutlineColor = Color.Yellow;
            instructionsFrame.OutlineThickness = 4f;
            
        }

        public void Draw(RenderTarget rt, RenderStates st)
        {
            rt.Draw(car1);
            rt.Draw(car2);
            rt.Draw(car3);
            rt.Draw(car4);

            rt.Draw(titleFrame);
            rt.Draw(pressEnterFrame);
            rt.Draw(instructionsFrame);

            rt.Draw(title);
            rt.Draw(pressEnter);
            
            rt.Draw(instructions);
        }
    }
}