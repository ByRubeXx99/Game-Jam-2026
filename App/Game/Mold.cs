using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Mold
{
	public class Mold : Actor
	{
		public Mold ( float _x, float _y)
		{
			Texture = new Texture ("Data/Textures/Mold1.png");
			Center ();
			Scale = Scale / 4;
			Position = new Vector2f (_x, _y);
		}

		public override void Update(float dt){
			base.Update (dt);
			Vector2f mousePos = new Vector2f (Mouse.GetPosition(MoldGame.rw).X, Mouse.GetPosition(MoldGame.rw).Y);

			Vector2f dist = mousePos-Position;

			Forward = dist.Normal ();
			Speed = dist.Size () / 2.0f;
			Rotation = (float) Math.Atan2(Forward.Y, Forward.X) * MathUtil.RAD2DEG + 90;
		}

		public void Upgrade()
		{
			Texture = new Texture ("Data/Textures/Mold2.png");
			Center ();
		}

	}
}

