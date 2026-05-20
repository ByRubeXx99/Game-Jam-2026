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
		private Texture backGroundTexture;
		private Sprite backGroundSprite;
		
		public List<Food> Foods = new List<Food>();
		public List<CarNew> Cars = new List<CarNew>();
		
		private Random rnd = new Random();
		private float carTimer = 0;
		private float carSpawnTimer = 2.0f;
		
		private float foodTimer = 0;
		private float nextFoodSpawn = 0f;
		private bool isFoodActive = true;
		
		private StartMenu menu;
		private enum GameState
		{
			StartMenu,
			Playing
		}

		private GameState currentState;

		public void Init(){
			VideoMode videoMode = new VideoMode(1920, 1080);
			rw = new RenderWindow(videoMode, "snakeGame");
			
			backGroundTexture = new Texture("Data/Textures/Background.png");
			backGroundSprite = new Sprite(backGroundTexture);
			
			mo = new Mold(rw.Size.X/2.0f, rw.Size.Y/2.0f);
			h = new HUD (mo);

			f = new Food();
			f.newPos();

			currentState = GameState.StartMenu;
			menu = new StartMenu();
		}

		public void DeInit()
		{
			rw.Dispose();
		}

		public void Update(float dt)
		{
			if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
			{
				rw.Close();
			}
			rw.DispatchEvents();
			mo.Update (dt);
			h.Update (dt);
			
			carTimer += dt;  
			if (carTimer >= carSpawnTimer)
			{
				Cars.Add(new CarNew());
				carTimer = 0;
				carSpawnTimer = (float)(rnd.NextDouble() * 3.0 + 5.0);
			} 

			if (currentState == GameState.StartMenu)
			{
				if (Keyboard.IsKeyPressed(Keyboard.Key.Enter))
				{
					currentState = GameState.Playing;
				}

				return;
			}

			foreach (CarNew car in Cars)
			{
				car.Update(dt);
			}

			Cars.RemoveAll(c => c.Position.X < -300);
			if (isFoodActive)
			{
				if (mo.GetGlobalBounds().Intersects(f.GetGlobalBounds())) {
					h.ScoreAdd ();
					isFoodActive = false;
					foodTimer = 0;
					nextFoodSpawn = (float)(rnd.NextDouble() * 5.0 + 3.0);
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
		public void Draw(){
			rw.Clear (); 
			rw.Draw (backGroundSprite);
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
				if (isFoodActive)
				{
					rw.Draw(f);
				}
				rw.Draw(mo);
				rw.Draw(h);
			}
			rw.Display (); 
			
		}

		public bool IsAlive()
		{
			return rw.IsOpen;
		}
	}
}

