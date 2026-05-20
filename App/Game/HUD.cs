using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Mold
{
    public class HUD : Transformable, Drawable
    {
        private int points;
        private int health;
        private int level;

        Font f;
        Text t;
        Text tH;
        Text l;

        private Mold player;
        private bool hasChangedPhase;
        
        private int[] phaseThresholds = { 5, 10, 15, 20 };
        private int currentPhaseIndex = 1;
        public HUD(Mold playerInstance)
        {
            player = playerInstance;
            points = 0;
            health = 100;

            f = new Font("Data/arial.ttf");

            t = new Text("Puntos: ", f);
            tH = new Text("Health: ", f);
            l = new Text("Level: ", f);

            hasChangedPhase = false;
        }

        public void Update(float dt)
        {
            t.DisplayedString = String.Format("Food: {0}", points);
            t.Position = new Vector2f(20f, 20f);

            tH.DisplayedString = String.Format("Health: {0}", health);
            tH.Position = new Vector2f(150f, 20f);
            
            l.DisplayedString = String.Format("Level: {0}", level);
            l.Position = new Vector2f(330f, 20f);

            if (currentPhaseIndex < phaseThresholds.Length)
            {
                if (points >= phaseThresholds[currentPhaseIndex])
                {
                    player.ChangePhase(currentPhaseIndex);
                    LevelUp();
                    currentPhaseIndex++; 
                }
            }
        }

        public void Draw(RenderTarget rt, RenderStates st)
        {
            rt.Draw(t);
            rt.Draw(tH);
            rt.Draw(l);
        }

        public void ScoreAdd()
        {
            points++;
        }

        public void RestHealth()
        {
            health -= 10;
        }
        public int GetPoints()
        {
            return points;
        }
        public int GetHealth()
        {
            return health;
        }

        public void LevelUp()
        {
            level++;
        }
    }
}