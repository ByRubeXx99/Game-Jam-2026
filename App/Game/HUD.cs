using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Mold
{
	public class HUD: Transformable, Drawable
	{
		private int points;
		Font f;
		Text t;

		private Mold player;
		private bool hasChangedPhase;
		public HUD (Mold playerInstance)
		{
			player =  playerInstance;
			points = 0;
			f = new Font ("Data/arial.ttf");
			t = new Text ("Puntos: ", f);
			hasChangedPhase = false;
		}

		public void Update(float dt){
			t.DisplayedString=String.Format("Puntos: {0}",points);
			if (points >= 15 && !hasChangedPhase)
			{
				player.ChangePhase();
				hasChangedPhase = true;
			}
		}

		public void Draw(RenderTarget rt, RenderStates st){
			rt.Draw (t);
		}
		public void ScoreAdd(){
			points++;
		}
	}
}

