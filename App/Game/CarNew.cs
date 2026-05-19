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
        Random r = new Random ();
        string[] textures =
        {
            "Data/Textures/Car2.png",
            "Data/Textures/Truck.png",
        };
        int textureIndex = r.Next(0, textures.Length);
        Texture tex = new Texture(textures[textureIndex]);
        sp = new AnimatedSprite (tex, 3, 1);	
        sp.Scale = new Vector2f(4.0f, 4.0f);
        speed = r.Next(80, 150);
        Forward = new Vector2f(-1.0f,0.0f);
        newPos();
    }
    public void Update( float dt){
        Position += Forward * speed * dt;
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
    public void newPos()
    {
        Random r = new Random();
        Position = new Vector2f(1920, r.Next (270, 810));
        sp.FrameTime = r.Next (10, 100) / 100.0f; 
    }
}
    
    
