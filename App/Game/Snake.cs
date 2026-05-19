using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Snake
{
	public class Snake : Actor
	{
		public Snake ( float _x, float _y)
		{
			Texture = new Texture ("Data/player.png");
			base.Center ();
			Position = new Vector2f (_x, _y);
		}

		public override void Update(float dt){
			base.Update (dt);
			Vector2f mousePos = new Vector2f (Mouse.GetPosition(SnakeGame.rw).X, Mouse.GetPosition(SnakeGame.rw).Y);

			Vector2f dist = mousePos-Position;

			Forward = dist.Normal ();
			Speed = dist.Size () / 2.0f;
			Rotation = (float) Math.Atan2(Forward.Y, Forward.X) * MathUtil.RAD2DEG;
		}

	}
}

