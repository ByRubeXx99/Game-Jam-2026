using System;
using SFML.Window;
using SFML.Graphics;
using System.Collections.Generic;
using SFML.System;

namespace Mold
{
	public class MoldGame : Game
	{
		public static RenderWindow rw;

		private Mold mo;
		private Food f;
		private HUD h;
		private CarNew _car;

		private StartMenu menu;

		public List<Food> Foods = new List<Food>();
		public List<CarNew> Cars = new List<CarNew>();

		private float timer = 0;

		private enum GameState
		{
			StartMenu,
			Playing
		}

		private GameState currentState;

		public void Init()
		{
			VideoMode videoMode = new VideoMode(640, 480);
			rw = new RenderWindow(videoMode, "snakeGame");

			currentState = GameState.StartMenu;

			menu = new StartMenu();

			h = new HUD();

			_car = new CarNew();

			f = new Food();
			f.newPos();

			mo = new Mold(rw.Size.X / 2.0f, rw.Size.Y / 2.0f);
		}

		public void DeInit()
		{
			rw.Dispose();
		}

		public void Update(float dt)
		{
			rw.DispatchEvents();

			if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
			{
				rw.Close();
			}

			if (currentState == GameState.StartMenu)
			{
				if (Keyboard.IsKeyPressed(Keyboard.Key.Enter))
				{
					currentState = GameState.Playing;
				}

				return;
			}

			mo.Update(dt);

			h.Update(dt);

			timer += dt;

			if (timer > 2)
			{
				_car = new CarNew();
				Cars.Add(_car);

				timer = 0;
			}

			foreach (CarNew car in Cars)
			{
				car.Update(dt);
			}

			if (mo.GetGlobalBounds().Intersects(f.GetGlobalBounds()))
			{
				h.ScoreAdd();
				f.newPos();
			}

			if (h.puntos > 15)
			{
				mo.Upgrade();
			}
		}

		public void Draw()
		{
			rw.Clear();

			if (currentState == GameState.StartMenu)
			{
				rw.Draw(menu);
			}
			else
			{
				foreach (CarNew car in Cars)
				{
					rw.Draw(car);
				}

				rw.Draw(h);
				rw.Draw(mo);
				rw.Draw(f);
			}

			rw.Display();
		}

		public bool IsAlive()
		{
			return rw.IsOpen;
		}
	}
}

