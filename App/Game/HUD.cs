using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Snake
{
	public class HUD: Transformable, Drawable
	{
		private int puntos;
		Font f;
		Text t;

		public HUD ()
		{
			puntos = 0;
			f = new Font ("Data/arial.ttf");
			t = new Text ("Puntos: ", f);
		}

		public void Update(float dt){
			t.DisplayedString=String.Format("Puntos: {0}",puntos);
		}

		public void Draw(RenderTarget rt, RenderStates st){
			rt.Draw (t);
		}
		public void ScoreAdd(){
			puntos++;
		}
	}
}

