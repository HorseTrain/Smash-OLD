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
    public class MoveDirPartical : ParticalObject
    {
        public Vector3 StartPosition;
        public Vector3 Direction;

        public float Speed;

        float timer = 150;

        public void Set(Vector3 StartPosition,Vector3 Direction)
        {
            this.StartPosition = StartPosition;
            this.Direction = Direction + new Vector3(Scene.RandomFloat(-1,1)/10f, Scene.RandomFloat(-1, 1) / 10f, Scene.RandomFloat(-1, 1) / 10f);

            Speed = Scene.RandomFloat(5,20);

            Position = StartPosition;


            Scale = Scene.RandomFloat(1,10);
        }

        public override void Update()
        {
            timer -= Window.MainWindow.GlobalDeltaTime;

            Scale -= Window.MainWindow.GlobalDeltaTime * 0.1f;

            if (timer >= 20)
            {
                if (Scale < 0)
                {
                    Position = StartPosition;
                    Scale = Scene.RandomFloat(1, 10);
                }
            }
            else
            {
                if (Scale <= 0)
                    Destroy();
            }

            Position += Direction * Speed * Window.MainWindow.GlobalDeltaTime * 2;
        }
    }
}
