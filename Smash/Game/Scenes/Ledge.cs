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

        }

        public override void Update()
        {

        }

        public void Release()
        {

        }
    }
}
