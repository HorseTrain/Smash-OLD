using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Physics.Structs
{
    public class LineIntersection2D
    {
        public Line2D Line0 { get; set; }
        public Line2D Line1 { get; set; }
        public Vector2 IntersectionPoint { get; set; }
        public bool Valid { get; set; }
        public float DistanceToPoint(Vector2 point)
        {
            return (point - IntersectionPoint).Length;
        }
    }
}
