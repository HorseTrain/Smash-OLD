using OpenTK;
using Smash.GraphicWrangler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter.Particals
{
    public class RunPartical : ParticalObject
    {
        public RunPartical()
        {

        }

        fighter fref;

        public void Set(fighter fref)
        {
            this.Position = fref.RootNode.LocalPosition;
            this.Scale = Scene.RandomFloat(0,3);

            float speed = 0.3f;

            int dir = 1;

            if (fref.anim.CurrentAnimationName.Contains("turn"))
                dir *= -1;
   
            Velocity = new Vector3(Scene.RandomFloat(0,10)*speed * -fref.Gdir * dir, Scene.RandomFloat(0, 20)/20,0);

            if (fref.anim.CurrentAnimationName == "turnrun" || fref.anim.CurrentAnimationName.Contains("runbrake"))
                Velocity = new Vector3(Scene.RandomFloat(-1, 10) * 0.1f * -fref.Gdir * dir, Scene.RandomFloat(0, 20) / 20, 0);

            this.fref = fref;
        }

        public override void Update()
        {
            base.Update();

            Position += Velocity* fref.FinalSpeed; 

            Scale -= fref.FinalSpeed * 0.1f;

            if (Scale < 0)
            {
                Destroy();
            }
        }
    }
}
