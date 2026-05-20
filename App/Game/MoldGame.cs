using System;
using SFML.Window;
using SFML.Graphics;
using System.Collections.Generic;
using SFML.System;
using SFML.Audio;

namespace Mold
{
	public class MoldGame : Game
	{
		public static RenderWindow rw;

		private Mold mo;
		private Food f;
		private HUD h;

		private Texture backGroundTexture;
		private Sprite backGroundSprite;

		public List<CarNew> Cars = new List<CarNew>();

		private Random rnd = new Random();

		private float carTimer = 0;
		private float carSpawnTimer = 2.0f;

		private float foodTimer = 0;
		private float nextFoodSpawn = 0f;

		private bool isFoodActive = true;

		private StartMenu menu;
		private EndingMenu endingMenu;

		private enum GameState
		{
			StartMenu,
			Playing,
			GameOver
		}

		private GameState currentState;

		public void Init()
		{
			VideoMode videoMode = new VideoMode(1920, 1080);
			rw = new RenderWindow(videoMode, "snakeGame");

			backGroundTexture = new Texture("Data/Textures/Background.png");
			backGroundSprite = new Sprite(backGroundTexture);

			mo = new Mold(rw.Size.X / 2.0f, rw.Size.Y / 2.0f);

			h = new HUD(mo);

			f = new Food();
			f.newPos();

			currentState = GameState.StartMenu;

			menu = new StartMenu();

			Music m = new Music("Data/music.wav");
			m.Play();
			m.Loop = true;
		}

		public void DeInit()
		{
			rw.Dispose();
		}

		private void RestartGame()
		{
			Cars.Clear();

			mo = new Mold(rw.Size.X / 2.0f, rw.Size.Y / 2.0f);

			h = new HUD(mo);

			f = new Food();
			f.newPos();

			isFoodActive = true;

			carTimer = 0;
			foodTimer = 0;
		}

		public void Update(float dt)
		{
			if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
			{
				rw.Close();
			}

			rw.DispatchEvents();

			if (currentState == GameState.StartMenu)
			{
				if (Keyboard.IsKeyPressed(Keyboard.Key.Enter))
				{
					currentState = GameState.Playing;
				}

				return;
			}

			if (currentState == GameState.GameOver)
			{
				if (Keyboard.IsKeyPressed(Keyboard.Key.Enter))
				{
					RestartGame();
					currentState = GameState.StartMenu;
				}

				return;
			}

			mo.Update(dt);
			h.Update(dt);

			carTimer += dt;

			if (carTimer >= carSpawnTimer)
			{
				Cars.Add(new CarNew());

				carTimer = 0;

				carSpawnTimer = (float)(rnd.NextDouble() * 3.0 + 1.0);
			}

			for (int i = Cars.Count - 1; i >= 0; i--)
			{
				CarNew car = Cars[i];

				car.Update(dt);

				if (mo.GetGlobalBounds().Intersects(car.GetGlobalBounds()))
				{
					h.RestHealth();

					Cars.RemoveAt(i);

					if (h.GetHealth() <= 0)
					{
						endingMenu = new EndingMenu(h.GetPoints());
						currentState = GameState.GameOver;
					}
				}
			}

			Cars.RemoveAll(c => c.Position.X < -300);

			if (isFoodActive)
			{
				if (mo.GetGlobalBounds().Intersects(f.GetGlobalBounds()))
				{
					h.ScoreAdd();

					isFoodActive = false;

					foodTimer = 0;

					nextFoodSpawn = (float)(rnd.NextDouble() * 3.0 + 1.0);
				}
			}
			else
			{
				foodTimer += dt;

				if (foodTimer >= nextFoodSpawn)
				{
					f.newPos();
					isFoodActive = true;
				}
			}
		}

		public void Draw()
		{
			rw.Clear();

			rw.Draw(backGroundSprite);

			if (currentState == GameState.StartMenu)
			{
				rw.Draw(menu);
			}
			else if (currentState == GameState.GameOver)
			{
				rw.Draw(endingMenu);
			}
			else
			{
				if (isFoodActive)
				{
					rw.Draw(f);
				}
				foreach (CarNew car in Cars)
				{
					rw.Draw(car);
				}

				rw.Draw(mo);
				rw.Draw(h);
			}

			rw.Display();
		}

		public bool IsAlive()
		{
			return rw.IsOpen;
		}
	}
}