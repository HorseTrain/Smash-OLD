using OpenTK;
using OpenTK.Graphics.OpenGL;
using SimpleGameEngine.Graphics.Assets;
using Smash.Game.Physics.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Physics.Shapes
{
    public class Circle2D : Shape
    {
        public float R = 5;
        public float LineWidth = 0.1f;
        public Vector4 Color = new Vector4(1,0,0,0);

        public Circle2D()
        {
            Material.RenderShader = RenderShader.AllShaders["Circle"];
        }

        public Circle2D(float r)
        {
            R = r;

            Material.RenderShader = RenderShader.AllShaders["Circle"];        
        }

        public override void GLDraw()
        {
            SceneBuffer.BindToMaterial(Material);

            Material.UniformFloat("r", R * 2);
            Material.UniformVector2("Position",Position);
            Material.UniformFloat("LineWidth", LineWidth);
            Material.UniformVector4("color", Color);

            GL.CullFace(CullFaceMode.Back);

            GL.Begin(BeginMode.Quads);

            GL.Vertex3(0.5f,0.5f,0.5);
            GL.Vertex3(-0.5f, 0.5f, 0.5);
            GL.Vertex3(-0.5f, -0.5f, 0.5);
            GL.Vertex3(0.5f, -0.5f, 0.5);

            GL.End();
        }

        public bool TestCollision(Circle2D other)
        {
            return (Position - other.Position).Length < R + other.R;
        }

        public bool TestCollision(Vector2 point)
        {
            return Vector2.Distance(Position, point) < R;
        }

        public bool TestCollision(Line2D line)
        {
            if (TestCollision(line.Point0) || TestCollision(line.Point1))
                return true;

            Line2D linetest = new Line2D(Position - (line.Normal * R),Position + (line.Normal * R));

            return SimplePhysics.TestIntersection(line,linetest).Valid;
        }

        public bool TestCollision(Rectangle rectangle)
        {
            List<Line2D> Lines = rectangle.TransformedPoints;

            foreach (Line2D line in Lines)
            {
                if (TestCollision(line))
                    return true;
            }

            return false;
        }

        public bool TestCollision(Capsule2D capsule)
        {
            if (TestCollision(capsule.TransformedC0) || TestCollision(capsule.TransformedC1) || TestCollision(capsule.TransformedRectangle))
                return true;

            return false;
        }
    }
}
