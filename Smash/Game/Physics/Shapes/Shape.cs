using OpenTK;
using Smash.GraphicWrangler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Physics.Shapes
{
    public class Shape : IRenderable
    {
        public Vector2 Position { get; set; }
        public float Angle { get; set; }
        public Matrix4 Transform => Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Angle)) * Matrix4.CreateTranslation(new Vector3(Position.X,Position.Y,0));
    }
}
