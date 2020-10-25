using OpenTK;
using SimpleGameEngine.Graphics;
using Smash.Game.Fighter;
using Smash.Game.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Scenes
{
    public class Ledge : SceneObject
    {
        public Vector2 Position { get; set; }
        public float Size { get; set; } = 10;
        public int Direction { get; set; }

        public Ledge(Vector2 Position,float size, int direction)
        {
            this.Position = Position;
            this.Size = size;
            this.Direction = direction;
        }

        fighter caughtfighter;

        public void TestLedge(fighter f)
        {
            if (f.skeleton.RootNode.LocalPosition.Y < Position.Y && caughtfighter != f)
            {
                if (f.phy.Velocity.Y < 0 && (Math.Abs(Position.Y - f.skeleton.RootNode.LocalPosition.Y) < 20 && Math.Abs(Position.X - f.skeleton.RootNode.LocalPosition.X) < 10) && (FighterInput.GetDir(f.phy.Velocity.X) == -Direction || Math.Abs(f.phy.Velocity.X) < 0.1f) && f.AirVelocityEverPositive)
                {
                    caughtfighter = f;

                    f.anim.CrossFade("cliffcatch");

                    f.HeldLedge = this;
                }
            }
        }

        public override void Update()
        {
            if (caughtfighter != null)
            {
                caughtfighter.phy.DoGravity = false;

                caughtfighter.phy.Velocity = new Vector2(0);

                caughtfighter.skeleton.RootNode.LocalPosition += (new Vector3(Position.X, Position.Y + caughtfighter.skeleton.GetNode("Trans").WantedPosition.Y, 0) - caughtfighter.skeleton.RootNode.LocalPosition) / (2 / (float)Window.MainWindow.GlobalDeltaTime);

                caughtfighter.Gdir = -Direction;
            }
        }

        public void Release()
        {
            caughtfighter.HeldLedge = null;

            caughtfighter = null;
        }
    }
}
