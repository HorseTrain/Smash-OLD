using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Physics.Structs
{
    public struct Line2D
    {
        public Vector2 Point0;
        public Vector2 Point1;
        public Vector2 Direction => Point1 - Point0;
        public float Length => Direction.Length;
        public Vector2 Normal
        {
            get
            {
                Vector2 temp = Direction / Direction.Length;

                return new Vector2(-temp.Y,temp.X);
            }
        }
        public float Angle => (float)MathHelper.RadiansToDegrees(Math.Acos(Vector2.Dot(Normal,new Vector2(0,1))));
        public Line2D(Vector2 point0,Vector2 point1)
        {
            Point0 = point0;
            Point1 = point1;
        }

        public float GetT(Vector2 point)
        {
            if (Direction.X != 0)
            {
                return (Point0.X - point.X) / Length;
            }
            else if (Direction.Y != 0)
            {
                return (Point0.Y - point.Y) / Length;
            }

            return (float)double.NaN;
        }

        public Vector3 LineSlope
        {
            get
            {
                Vector2 dir = Direction;

                return new Vector3(dir.Y, -dir.X,-((dir.Y * -Point0.X) + (dir.X * Point0.Y)));
            }
        }

        public override string ToString()
        {
            return Point0 + " " + Point1;
        }

        public bool LineOnPoint(Vector2 point)
        {
            Vector2 pd = (point - Point0);
            pd /= pd.Length;

            if (Vector2.Dot(Direction.Normalized(),pd) <= 0)
            {
                return false;
            }
            else
            {
                return (point - Point0).Length <= Length;
            }
        }

        public void Compare(float x, float y, ref float max, ref float min)
        {
            if (x <= y)
            {
                min = x;
                max = y;
            }
            else
            {
                max = y;
                min = x;
            }
        }

        public static Line2D operator +(Line2D l0, Vector2 offset)
        {
            return new Line2D(l0.Point0 + offset,l0.Point1 + offset);
        }

        public static Line2D operator *(Line2D l0, Matrix4 matrix)
        {
            return new Line2D(Vector3.TransformPosition(new Vector3(l0.Point0), matrix).Xy, Vector3.TransformPosition(new Vector3(l0.Point1), matrix).Xy);
        }
    }
}
