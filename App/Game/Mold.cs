using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Mold
{
	public class Mold : Actor
	{
		public int Health = 100;
		public float MovementSpeed = 250f;
		public Mold ( float _x, float _y)
		{
			Texture = new Texture ("Data/Textures/Mold.png");
			Center ();
			Position = new Vector2f (_x, _y);
		}

		public override void Update(float dt){
			Vector2f movement = new Vector2f(0f, 0f);
			if (Keyboard.IsKeyPressed(Keyboard.Key.W))
			{
				movement.Y -= 1f;
			} 
			if (Keyboard.IsKeyPressed(Keyboard.Key.S))
			{
				movement.Y += 1f;
			} 
			if (Keyboard.IsKeyPressed(Keyboard.Key.A))
			{
				movement.X -= 1f;
			} 
			if (Keyboard.IsKeyPressed(Keyboard.Key.D))
			{
				movement.X += 1f;
			}

			if (movement.X != 0 || movement.Y != 0)
			{
				Forward = movement.Normal();
				Speed = MovementSpeed;
			}
			else
			{
				Speed = 0;
			}
			base.Update(dt);
			
			if (Position.Y < 270)
			{
				Position = new Vector2f(Position.X, 270);
			}
			else if (Position.Y > 810)
			{
				Position = new Vector2f(Position.X, 810);
			}
			
			if (Position.X < 0)
			{
				Position = new Vector2f(0, Position.Y);
			}
			else if (Position.X > 1920)
			{
				Position = new Vector2f(1920, Position.Y);
			}
		}
		public void ChangePhase()
		{
			Texture = new Texture("Data/player.png");
			TextureRect = new IntRect(0, 0, (int)Texture.Size.X, (int)Texture.Size.Y);
			Center();
		}

	}
}

