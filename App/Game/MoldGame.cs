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
    public List<Food> Foods = new List<Food>();

    public void Init(){
			VideoMode videoMode = new VideoMode(640, 480);
			rw = new RenderWindow(videoMode, "snakeGame");
			h = new HUD ();

			Food p0 = new Food();
			Food p1 = new Food();

			Foods.Add (p0);
			Foods.Add (p1);

			foreach (Food a in Foods) {
				a.Dispose ();
			}

			System.Threading.Thread.Sleep (5000);
			//=========================== AQUI !!!!! =============================

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

			f.Update(dt);
			mo.Update (dt);
			h.Update (dt);

			if (mo.GetGlobalBounds ().Intersects (f.GetGlobalBounds())) {
				h.ScoreAdd ();
				f.newPos ();
			}
		}
		public void Draw(){
			rw.Clear ();
			rw.Draw (h);
			rw.Draw(mo);
			rw.Draw (f);
			rw.Display ();
		}
		public bool IsAlive()
		{
			return rw.IsOpen;
		}
	}
}

