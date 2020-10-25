using Smash.Game.Physics.Structs;
using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using SimpleGameEngine.Graphics.Assets;
using SimpleGameEngine.IO.Collada.Scene;

namespace Smash.Game.Physics.Shapes
{
    public class Rectangle : Shape
    {
        List<Line2D> Lines { get; set; } = new List<Line2D>();

        public Rectangle(float width, float height, float ox = 0, float oy = 0)
        {
            Lines = SimplePhysics.LinesFromPoints(new Vector2[] { new Vector2(0,0) - new Vector2(ox,oy), new Vector2(width, 0) - new Vector2(ox, oy), new Vector2(width, height) - new Vector2(ox, oy), new Vector2(0, height) - new Vector2(ox, oy) },true);

            Material.RenderShader = RenderShader.AllShaders["2DGeomatryRenderer"];
        }

        public List<Line2D> TransformedPoints
        {
            get
            {
                List<Line2D> Out = new List<Line2D>();

                Matrix4 t = Transform;

                foreach (Line2D line in Lines)
                    Out.Add(line * t);

                return Out;
            }
        }

        public override void GLDraw()
        {
            SceneBuffer.BindToMaterial(Material);

            GL.Begin(BeginMode.Lines);

            List<Line2D> tlines = TransformedPoints;

            foreach (Line2D line in tlines)
            {
                GL.Vertex3(line.Point0.X,line.Point0.Y,0);
                GL.Vertex3(line.Point1.X, line.Point1.Y,0);
            }

            GL.End();
        }

        public bool TestCollision(Rectangle rectangle)
        {
            List<Line2D> t0 = TransformedPoints;
            List<Line2D> t1 = rectangle.TransformedPoints;

            foreach (Line2D line in t0)
            {
                foreach (Line2D line1 in t1)
                {
                    if (SimplePhysics.TestIntersection(line, line1).Valid)
                        return true;
                }
            }

            return false;
        }

        public bool TestCollision(Circle2D circle)
        {
            return circle.TestCollision(this);
        }

        public bool TestCollision(Capsule2D capsule)
        {
            if (capsule.TransformedC0.TestCollision(this) || capsule.TransformedC1.TestCollision(this) || capsule.TransformedRectangle.TestCollision(this))
                return true;

            return false;
        }
    }
}
