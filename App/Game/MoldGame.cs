using System;
using SFML.Window;
using SFML.Graphics;
using System.Collections.Generic;
using SFML.System;

namespace Mold
{
	public class MoldGame: Game
	{
		public static RenderWindow rw;
		private Mold mo;
		private Food f;
		private HUD h; 
		private CarNew _car;
		public List<Food> Foods = new List<Food>();
		private float timer=0;  
		public List<CarNew> Cars = new List<CarNew>();
		public void Init(){
			VideoMode videoMode = new VideoMode(640, 480);
			rw = new RenderWindow(videoMode, "snakeGame");
			h = new HUD ();
			
            _car = new CarNew();
			Food p0 = new Food();
			Food p1 = new Food();

			Foods.Add (p0);
			Foods.Add (p1);

			foreach (Food a in Foods) {
				a.Dispose ();
			}

			System.Threading.Thread.Sleep (5000);

			f = new Food ();
			f.newPos ();
			mo = new Mold(rw.Size.X/2.0f, rw.Size.Y/2.0f);
		}
		public void DeInit(){
			rw.Dispose ();
		}
		public void Update( float dt){
			if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
			{
				rw.Close();
			}
			rw.DispatchEvents();
			
			//_car.Update(dt);
			mo.Update (dt);
			h.Update (dt);
			timer += dt;  
			if (timer>2)
			{
				
				_car = new CarNew(); 
				Cars.Add(_car);
				timer = 0;
			} 
			foreach (CarNew car in Cars)
			{
				car.Update(dt);
			}
			if (mo.GetGlobalBounds ().Intersects (f.GetGlobalBounds())) {
				h.ScoreAdd ();
				f.newPos ();
			}

			if (h.puntos > 15)
			{
				mo.Upgrade();
			}
		}
		public void Draw(){
			rw.Clear (); 
			foreach (CarNew car in Cars)
			{
				rw.Draw(car);
				
			}
			rw.Draw (h);
			rw.Draw(mo);
			rw.Draw (f);
			rw.Display (); 
			rw.Draw (_car); 
			
		}
		public bool IsAlive()
		{
			return rw.IsOpen;
		}
	}
}

