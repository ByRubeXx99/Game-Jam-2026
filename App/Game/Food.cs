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
				r.Next (16, (int) MoldGame.rw.Size.X-16),
				r.Next (128, (int)MoldGame.rw.Size.Y-16));
			sp = new Sprite (new Texture ("Data/Textures/Food"+ r.Next(1, 4) +".png"));
		}
	}
}

