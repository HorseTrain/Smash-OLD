using OpenTK;
using SimpleGameEngine.Graphics;
using Smash.GraphicWrangler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter.Particals
{
    public class DamageFlyPartical : ParticalObject
    {
        public fighter fref;

        public void SetUp(Vector3 Position, fighter fref)
        {
            this.fref = fref;

            this.Position = Position + new Vector3(Scene.RandomFloat(-5, 5), Scene.RandomFloat(-5, 5), 0);

            Scale = Scene.RandomFloat(2, 5);
        }

        public override void Update()
        {
            if (!fref.InDamageFly)
            {
                Scale -= fref.FinalSpeed * 0.1f;

                if (Scale < 0)
                    Destroy();
            }
        }
    }
}
