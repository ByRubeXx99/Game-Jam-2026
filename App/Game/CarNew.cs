using System;

namespace Mold; 
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System;
public class CarNew:Transformable, Drawable
{
    
    private AnimatedSprite sp; 
    private Vector2f Forward ;
    private float speed;
    public CarNew ()
    {
        sp = new AnimatedSprite (new Texture ("Data/Textures/Car2.png"), 3, 1);	
       // sp.FrameTime = 1.0f; 
        Forward = new Vector2f(-1.0f,0.0f);
        speed = 45; 
        newPos();
    }
    public void Update( float dt){
        //sp.Update (dt); 
        Position+=Forward*speed*dt;
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
		
        Random r = new Random();
        Position = new Vector2f(645, r.Next (120, 360));
        sp.FrameTime = r.Next (10, 100) / 100.0f; 
		
    }
}
    
    
