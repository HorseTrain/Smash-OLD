using OpenTK;
using OpenTK.Graphics.OpenGL;
using SimpleGameEngine.Graphics.Assets;
using Smash.GraphicWrangler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Physics.Structs
{
    public class CircleRenderer : IRenderable
    {
        public float R { get; set; } 
        public float LineWidth { get; set; } = 0.1f;
        public Vector4 Color { get; set; } = new Vector4(0,1,0,1);
        public Vector2 Position { get; set; } = new Vector2();
        public CircleRenderer()
        {
            Material.RenderShader = RenderShader.AllShaders["Circle"];
        }

        public override void GLDraw()
        {
            Material.UseMaterial();

            SceneBuffer.BindToMaterial(Material);

            Material.UniformFloat("r",R);
            Material.UniformFloat("LineWidth", LineWidth);
            Material.UniformVector4("color", Color);
            Material.UniformVector2("Position",Position);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha,BlendingFactor.OneMinusSrcAlpha);

            GL.Begin(BeginMode.Quads);

            GL.Vertex3(new Vector3(0,0, 0) - new Vector3(0.5f,0.5f,0));
            GL.Vertex3(new Vector3(1, 0,0) - new Vector3(0.5f, 0.5f,0));
            GL.Vertex3(new Vector3(1, 1,0) - new Vector3(0.5f, 0.5f,0));
            GL.Vertex3(new Vector3(0, 1,0) - new Vector3(0.5f, 0.5f,0));

            GL.End();

            GL.Disable(EnableCap.Blend);
        }
    }

    public class CircleLineIntersection
    {
        public Line2D line { get; set; }
        public Circle circle { get; set; }
        public bool Valid { get; set; }
    }

    public class CircleQuadIntersection
    {
        public Quad quad { get; set; }
        public Circle circle { get; set; }
        public bool Valid { get; set; }
    }

    public class Circle
    {
        public float R { get; set; }
        public Vector2 Position { get; set; }
        public CircleRenderer renderer { get; set; } = new CircleRenderer();
        public Circle(float r)
        {
            R = r;
        }

        public void Draw()
        {
            renderer.Position = Position;
            renderer.R = R;
            renderer.Draw();
        }
    }
}
