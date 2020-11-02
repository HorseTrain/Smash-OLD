using OpenTK;
using SimpleGameEngine.Graphics;
using Smash.Game.Scenes;
using Smash.GraphicWrangler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter.Particals
{
    public class CircleTravelPartical : ParticalObject
    {
        public float Speed = 0.02f;

        public CircleTravelPartical()
        {

        }

        public void Set(Vector3 Offset)
        {
            Velocity = new Vector3(Scene.RandomFloat(-10, 10), Scene.RandomFloat(-10, 10), Scene.RandomFloat(-10, 10)).Normalized();

            Position = Offset;

            Scale = Scene.RandomFloat(5,10);
        }

        public override void Update()
        {
            Scale -= Window.MainWindow.GlobalDeltaTime * Speed;

            if (Scale >= 0)
            {
                Position += Velocity * Window.MainWindow.GlobalDeltaTime * 2;
            }
            else
            {
                parent.RemoveObject(this);
            }
        }
    }
}
