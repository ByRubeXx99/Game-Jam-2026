using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Mold
{
	public class Food: Transformable, Drawable
	{
		private AnimatedSprite sp;
		public Food ()
		{
			sp = new AnimatedSprite (new Texture ("Data/food2.png"), 4, 1);	
			sp.FrameTime = 1.0f;
			newPos();
		}
		public void Update( float dt){
			sp.Update (dt);
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
			sp.FrameTime = r.Next (10, 100) / 100.0f;
		}
	}
}

