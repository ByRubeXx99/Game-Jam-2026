using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Mold
{
	public class Food: Transformable, Drawable
	{
		private Sprite sp;
		public Food ()
		{
			Random r = new Random();
			sp = new Sprite (new Texture ("Data/Textures/Food"+ r.Next(1, 3) +".png"));
			Scale = Scale / 6;
			newPos();
		}
		public void Draw(RenderTarget rt, RenderStates st){
			st.Transform *= Transform;
			rt.Draw (sp,st);
		}
		public virtual FloatRect GetLocalBounds()
		{
			return sp.GetLocalBounds ();
		}
		public FloatRect GetGlobalBounds()
		{
			return Transform.TransformRect(GetLocalBounds());
		}
		public void newPos(){
			Random r = new Random ();
			Position = new Vector2f(
				r.Next (0, 1919),
				r.Next (270, 810));
			sp.FrameTime = r.Next (10, 100) / 100.0f;
			sp = new Sprite (new Texture ("Data/Textures/Food"+ r.Next(1, 4) +".png"));
		}
	}
}

