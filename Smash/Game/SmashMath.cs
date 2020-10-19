using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game
{
    public class SmashMath
    {
        public static float Pow(float a)
        {
            return a * a;
        }
        public static float TrajectoryParabola(float x,float d, float h)
        {
            h = (float)Math.Sqrt(h);

            return -Pow(((x / (d / (2 * h))) - h)) + Pow(h);
        }

        public static float InfinateAproach(float x,float o,float r)
        {
            return (r/ (-x + o));
        }
    }
}
