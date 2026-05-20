using System;
using SFML.Graphics;
using SFML.System;

namespace Mold
{
	public class EndingMenu : Drawable
	{
		private Font font;

		private Text gameOverText;
		private Text scoreText;
		private Text restartText;

		private RectangleShape gameOverFrame;
		private RectangleShape scoreFrame;
		private RectangleShape restartFrame;

		public EndingMenu(int score)
		{
			font = new Font("Data/arial.ttf");

			gameOverText = new Text("GAME OVER", font);
			gameOverText.CharacterSize = 52;
			gameOverText.FillColor = Color.Red;

			FloatRect gBounds = gameOverText.GetLocalBounds();

			gameOverText.Origin = new Vector2f(
				gBounds.Left + gBounds.Width / 2,
				gBounds.Top + gBounds.Height / 2
			);

			gameOverText.Position = new Vector2f(
				MoldGame.rw.Size.X / 2,
				250
			);

			gameOverFrame = new RectangleShape(
				new Vector2f(gBounds.Width + 50, gBounds.Height + 40)
			);

			gameOverFrame.Origin = new Vector2f(
				gameOverFrame.Size.X / 2,
				gameOverFrame.Size.Y / 2
			);

			gameOverFrame.Position = gameOverText.Position;
			gameOverFrame.FillColor = Color.Black;
			gameOverFrame.OutlineColor = Color.Red;
			gameOverFrame.OutlineThickness = 4;

			scoreText = new Text("FOOD EATED: " + score, font);
			scoreText.CharacterSize = 36;
			scoreText.FillColor = Color.White;

			FloatRect sBounds = scoreText.GetLocalBounds();

			scoreText.Origin = new Vector2f(
				sBounds.Left + sBounds.Width / 2,
				sBounds.Top + sBounds.Height / 2
			);

			scoreText.Position = new Vector2f(
				MoldGame.rw.Size.X / 2,
				450
			);

			scoreFrame = new RectangleShape(
				new Vector2f(sBounds.Width + 50, sBounds.Height + 40)
			);

			scoreFrame.Origin = new Vector2f(
				scoreFrame.Size.X / 2,
				scoreFrame.Size.Y / 2
			);

			scoreFrame.Position = scoreText.Position;
			scoreFrame.FillColor = Color.Black;
			scoreFrame.OutlineColor = Color.White;
			scoreFrame.OutlineThickness = 4;

			restartText = new Text("PRESS ENTER TO RETURN", font);
			restartText.CharacterSize = 28;
			restartText.FillColor = Color.Yellow;

			FloatRect rBounds = restartText.GetLocalBounds();

			restartText.Origin = new Vector2f(
				rBounds.Left + rBounds.Width / 2,
				rBounds.Top + rBounds.Height / 2
			);

			restartText.Position = new Vector2f(
				MoldGame.rw.Size.X / 2,
				650
			);

			restartFrame = new RectangleShape(
				new Vector2f(rBounds.Width + 50, rBounds.Height + 40)
			);

			restartFrame.Origin = new Vector2f(
				restartFrame.Size.X / 2,
				restartFrame.Size.Y / 2
			);

			restartFrame.Position = restartText.Position;
			restartFrame.FillColor = Color.Black;
			restartFrame.OutlineColor = Color.Yellow;
			restartFrame.OutlineThickness = 4;
		}

		public void Draw(RenderTarget rt, RenderStates st)
		{
			rt.Draw(gameOverFrame);
			rt.Draw(scoreFrame);
			rt.Draw(restartFrame);

			rt.Draw(gameOverText);
			rt.Draw(scoreText);
			rt.Draw(restartText);
		}
	}
}