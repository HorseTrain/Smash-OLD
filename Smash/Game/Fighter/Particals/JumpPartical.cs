using OpenTK;
using Smash.GraphicWrangler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter.Particals
{
    public class JumpPartical : ParticalObject
    {
        fighter fref;

        public void Set(Vector3 Position,fighter fref)
        {
            this.fref = fref;
            this.Position = Position;

            Velocity = (Position - fref.RootNode.LocalPosition).Normalized();

            Scale = Scene.RandomFloat(1,5);
        }

        public override void Update()
        {
            Position += Velocity *fref.FinalSpeed ;

            Scale -= fref.FinalSpeed * 0.2f;

            if (Scale < 0)
            {
                Destroy();
            }
        }
    }
}
